using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Projeto_Interdisciplinar.Models;
using Projeto_Interdisciplinar.DAO;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Projeto_Interdisciplinar.Controllers
{
    public class ProdutoController : Controller
    {
        protected PadraoDAO<ProdutoViewModel> DAO { get; set; }

        protected bool GeraProximoId { get; set; } = true;

        protected string NomeViewIndex { get; set; } = "Index";

        protected string NomeViewForm { get; set; } = "Form";

        protected bool ExigeAutenticacao { get; set; } = false;

        public ProdutoController()
        {
            DAO = new ProdutoDAO();
        }

        protected void ValidaDados(ProdutoViewModel model, string operacao)
        {
            ModelState.Clear();

            if (operacao == "I" && DAO.Consulta(model.Id) != null)
                ModelState.AddModelError("Id", "Código já está em uso!");

            if (operacao == "A" && DAO.Consulta(model.Id) == null)
                ModelState.AddModelError("Id", "Este registro não existe!");

            if (model.Id <= 0)
                ModelState.AddModelError("Id", "Id inválido!");

            if (string.IsNullOrEmpty(model.NomeProduto))
                ModelState.AddModelError("NomeFornecedor", "Preencha o nome.");

            if (model.PrecoProduto <= 0)
                ModelState.AddModelError("PrecoProduto", "Digite um valor válido.");

            // Imagem será obrigatório apenas na inclusão.
            // Na alteração iremos considerar a que já estava salva.

            if (model.Imagem == null && operacao == "I")
                ModelState.AddModelError("Imagem", "Escolha uma imagem.");

            if (model.Imagem != null && model.Imagem.Length / 1024 / 1024 >= 2)
                ModelState.AddModelError("Imagem", "Imagem limitada a 2 mb.");

            if (ModelState.IsValid)
            {
                //na alteração, se não foi informada a imagem, iremos manter a que já estava salva.
                if (operacao == "A" && model.Imagem == null)
                {
                    ProdutoViewModel produto = DAO.Consulta(model.Id);
                    model.ImagemEmByte = produto.ImagemEmByte;
                }
                else
                {
                    model.ImagemEmByte = ConvertImageToByte(model.Imagem);
                }
            }
        }

        /// <summary>
        /// Converte a imagem recebida no form em um vetor de bytes
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public byte[] ConvertImageToByte(IFormFile file)
        {
            if (file != null)
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    return ms.ToArray();
                }
            else
                return null;
        }

        public IActionResult Detalhes()
        {
            ExigeAutenticacao = false;

            ProdutoDAO dao = new ProdutoDAO();

            var lista = dao.Listagem();

            if (lista.Count == 0)
                return View("Index", "Home");
            else
                return View(lista);
        }

        public virtual IActionResult Index()
        {
            try
            {
                var lista = DAO.Listagem();

                return View(NomeViewIndex, lista);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public virtual IActionResult Create()
        {
            try
            {
                ViewBag.Operacao = "I";
                ProdutoViewModel model = Activator.CreateInstance(typeof(ProdutoViewModel)) as ProdutoViewModel;
                PreencheDadosParaView("I", model);

                PreparaCombos();

                return View(NomeViewForm, model);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        protected virtual void PreencheDadosParaView(string Operacao, ProdutoViewModel model)
        {
            if (GeraProximoId && Operacao == "I")
                model.Id = DAO.ProximoId();
        }

        public virtual IActionResult Save(ProdutoViewModel model, string Operacao)
        {
            try
            {
                ValidaDados(model, Operacao);

                if (ModelState.IsValid == false)
                {
                    ViewBag.Operacao = Operacao;
                    PreencheDadosParaView(Operacao, model);
                    PreparaCombos();

                    return View(NomeViewForm, model);
                }
                else
                {
                    if (Operacao == "I")
                        DAO.Insert(model);
                    else
                        DAO.Update(model);

                    return RedirectToAction(NomeViewIndex);
                }
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Edit(int id)
        {
            try
            {
                ViewBag.Operacao = "A";
                var model = DAO.Consulta(id);
                PreparaCombos();

                if (model == null)
                    return RedirectToAction(NomeViewIndex);
                else
                {
                    PreencheDadosParaView("A", model);

                    return View(NomeViewForm, model);
                }
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                DAO.Delete(id);

                return RedirectToAction(NomeViewIndex);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Visualizar(int id)
        {
            try
            {
                ViewBag.Operacao = "V";
                var model = DAO.Consulta(id);
                PreparaCombos();

                if (model == null)
                    return RedirectToAction(NomeViewIndex);
                else
                {
                    PreencheDadosParaView("A", model);

                    return View(NomeViewForm, model);
                }
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.Logado = HelperController.VerificaUserLogado(HttpContext.Session);
            ViewBag.Perfil = HelperController.VerificaPerfil(HttpContext.Session);
        }

        #region Combo Box
        private void PreparaCombos()
        {
            ClienteDAO daoCliente = new ClienteDAO();
            FornecedorDAO daoFornecedor = new FornecedorDAO();

            var clientes = daoCliente.Listagem();
            var fornecedores = daoFornecedor.Listagem();

            List<SelectListItem> listaFornecedores = new List<SelectListItem>();

            listaFornecedores.Add(new SelectListItem("Selecione um fornecedor...", "0"));

            foreach (var fornecedor in fornecedores)
            {
                SelectListItem item = new SelectListItem(fornecedor.NomeFornecedor, fornecedor.Id.ToString());
                listaFornecedores.Add(item);
            }

            ViewBag.Fornecedores = listaFornecedores;
        }
        #endregion
    }
}