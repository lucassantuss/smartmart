using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Projeto_Interdisciplinar.Models;
using Projeto_Interdisciplinar.DAO;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.Controllers
{
    public class ProdutoController : PadraoController<ProdutoViewModel>
    {
        public ProdutoController()
        {
            DAO = new ProdutoDAO();
            GeraProximoId = true;
        }

        protected override void ValidaDados(ProdutoViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);

            if (string.IsNullOrEmpty(model.NomeProduto))
                ModelState.AddModelError("NomeFornecedor", "Preencha o nome.");

            if (model.PrecoProduto <= 0)
                ModelState.AddModelError("PrecoProduto", "Digite um valor válido.");
        }
    }
}