using Microsoft.AspNetCore.Mvc;
using Projeto_Interdisciplinar.DAO;
using Projeto_Interdisciplinar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.Controllers
{
    public class AcessoController : Controller
    {
        #region Listagem - Usuários existentes
        public IActionResult Index()
        {
            try
            {
                UsuarioDAO dao = new UsuarioDAO();
                var lista = dao.Listagem();

                return View(lista);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
        #endregion
    }
}
