using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Projeto_Interdisciplinar.Models;
using Projeto_Interdisciplinar.DAO;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Projeto_Interdisciplinar.Controllers
{
    public class ProdutoController : PadraoController<ProdutoViewModel>
    {
        public ProdutoController()
        {
            DAO = new ProdutoDAO();
            GeraProximoId = true;
            ExigeAutenticacao = false;
        }

        protected override void ValidaDados(ProdutoViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);

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
    }
}