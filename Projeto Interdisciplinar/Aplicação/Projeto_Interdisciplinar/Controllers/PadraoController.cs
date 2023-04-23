using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Interdisciplinar.DAO;
using Projeto_Interdisciplinar.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Projeto_Interdisciplinar.Controllers
{
    public class PadraoController<T> : Controller where T : PadraoViewModel
    {
        protected PadraoDAO<T> DAO { get; set; }

        protected bool GeraProximoId { get; set; }

        protected string NomeViewIndex { get; set; } = "Index";

        protected string NomeViewForm { get; set; } = "Form";

        protected bool ExigeAutenticacao { get; set; } = true;

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
                T model = Activator.CreateInstance(typeof(T)) as T;
                PreencheDadosParaView("I", model);

                PreparaCombos();

                return View(NomeViewForm, model);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        protected virtual void PreencheDadosParaView(string Operacao, T model)
        {
            if (GeraProximoId && Operacao == "I")
                model.Id = DAO.ProximoId();
        }

        public virtual IActionResult Save(T model, string Operacao)
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

        protected virtual void ValidaDados(T model, string operacao)
        {
            ModelState.Clear();

            if (operacao == "I" && DAO.Consulta(model.Id) != null)
                ModelState.AddModelError("Id", "Código já está em uso!");

            if (operacao == "A" && DAO.Consulta(model.Id) == null)
                ModelState.AddModelError("Id", "Este registro não existe!");

            if (model.Id <= 0)
                ModelState.AddModelError("Id", "Id inválido!");
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

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (ExigeAutenticacao && !HelperController.VerificaUserLogado(HttpContext.Session))
                context.Result = RedirectToAction("Index", "Home");
            else
            {
                ViewBag.Logado = true;
                base.OnActionExecuting(context);
            }

            ViewBag.Perfil = HelperController.VerificaPerfil(HttpContext.Session);
        }

        #region Combo Box
        private void PreparaCombos()
        {
            ClienteDAO daoCliente = new ClienteDAO();
            FornecedorDAO daoFornecedor = new FornecedorDAO();

            var clientes = daoCliente.Listagem();
            var fornecedores = daoFornecedor.Listagem();

            List<SelectListItem> listaClientes = new List<SelectListItem>();
            List<SelectListItem> listaFornecedores = new List<SelectListItem>();
            List<SelectListItem> listaPerfis = new List<SelectListItem>();

            listaClientes.Add(new SelectListItem("Selecione um cliente...", "0"));
            listaFornecedores.Add(new SelectListItem("Selecione um fornecedor...", "0"));
            listaPerfis.Add(new SelectListItem("Selecione um perfil...", "0"));

            foreach (var cliente in clientes)
            {
                SelectListItem item = new SelectListItem(cliente.NomeCliente, cliente.Id.ToString());
                listaClientes.Add(item);
            }

            foreach (var fornecedor in fornecedores)
            {
                SelectListItem item = new SelectListItem(fornecedor.NomeFornecedor, fornecedor.Id.ToString());
                listaFornecedores.Add(item);
            }

            listaPerfis.Add(new SelectListItem("Administrador", "Administrador"));
            listaPerfis.Add(new SelectListItem("Cliente", "Cliente"));
            listaPerfis.Add(new SelectListItem("Funcionario", "Funcionario"));

            ViewBag.Clientes = listaClientes;
            ViewBag.Fornecedores = listaFornecedores;
            ViewBag.Perfis = listaPerfis;
        }
        #endregion
    }
}