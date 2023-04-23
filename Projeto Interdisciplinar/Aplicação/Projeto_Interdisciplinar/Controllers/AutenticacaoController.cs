using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Interdisciplinar.Models;
using Projeto_Interdisciplinar.DAO;

namespace Projeto_Interdisciplinar.Controllers
{
    public class AutenticacaoController : Controller
    {
        public ActionResult _Login()
        {
            return PartialView();
        }

        public IActionResult FazLogin(string LoginUsuario, string SenhaUsuario)
        {
            UsuarioDAO dao = new UsuarioDAO();

            var lista = dao.Listagem();

            foreach (var item in lista)
            {
                if (item.LoginUsuario == LoginUsuario && item.SenhaUsuario == SenhaUsuario)
                {
                    HttpContext.Session.SetString("Logado", "true");
                    HttpContext.Session.SetString("Perfil", item.Perfil);
                    return RedirectToAction("Index", "Home");
                }
            }

            ViewBag.Erro = "Usuário ou senha inválidos!";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult LogOff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}