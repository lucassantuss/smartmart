using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Projeto_Interdisciplinar.Models;
using Projeto_Interdisciplinar.DAO;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.Controllers
{
    public class FornecedorController : PadraoController<FornecedorViewModel>
    {
        public FornecedorController()
        {
            DAO = new FornecedorDAO();
            GeraProximoId = true;
        }

        protected override void ValidaDados(FornecedorViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);

            if (string.IsNullOrEmpty(model.NomeFornecedor))
                ModelState.AddModelError("NomeFornecedor", "Preencha o nome.");
        }
    }
}