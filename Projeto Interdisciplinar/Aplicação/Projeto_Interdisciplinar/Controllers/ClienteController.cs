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
    public class ClienteController : PadraoController<ClienteViewModel>
    {
        public ClienteController()
        {
            DAO = new ClienteDAO();
            GeraProximoId = true;
        }

        protected override void ValidaDados(ClienteViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);

            if (string.IsNullOrEmpty(model.NomeCliente))
                ModelState.AddModelError("NomeCliente", "Preencha o nome.");
        }
    }
}