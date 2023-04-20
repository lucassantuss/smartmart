using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Interdisciplinar.Models;

namespace Projeto_Interdisciplinar.Controllers
{
    public class AutenticacaoController : Controller
    {
        // Ação para exibir a página de login
        public ActionResult _Login()
        {
            return PartialView();
        }

        public IActionResult FazLogin(string usuario, string senha)
        {
            //Este é apenas um exemplo, aqui você deve consultar na sua tabela de usuários
            //se existe esse usuário e senha
            if (usuario == "admin" && senha == "1234")
            {
                HttpContext.Session.SetString("Logado", "true");
                return RedirectToAction("index", "Home");
            }
            else
            {
                ViewBag.Erro = "Usuário ou senha inválidos!";
                return View("Index");
            }
        }

        // Ação para realizar o logoff
        public IActionResult LogOff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }








        // Ação para processar o formulário de login
        [HttpPost]
        public ActionResult _Login(string login, string senha)
        {
            // Lógica para validar o login e senha do usuário
            // Pode envolver consulta ao banco de dados, validação de credenciais, etc.

            // Se as credenciais forem válidas, redirecionar para a página principal
            if (ValidarCredenciais(login, senha))
            {
                HttpContext.Session.SetString("Logado", "true");
                string logado = HttpContext.Session.GetString("Logado");

                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Caso contrário, exibir mensagem de erro
                ViewBag.MensagemErro = "Credenciais inválidas. Por favor, tente novamente.";
                return PartialView();
            }
        }

        // Método para validar as credenciais do usuário
        private bool ValidarCredenciais(string login, string senha)
        {
            // Lógica para validar as credenciais do usuário
            // Pode envolver consulta ao banco de dados, validação de credenciais, etc.

            // Exemplo básico: validar se o login e senha correspondem a um usuário válido
            var usuario = ObterUsuarioPorLogin(login);
            if (usuario != null && usuario.SenhaUsuario == senha)
            {
                // Armazenar informações de autenticação, como ID do usuário, na sessão, cookie, etc.
                // ou usar um mecanismo de autenticação mais avançado, como o ASP.NET Identity
                return true;
            }
            else
            {
                return false;
            }
        }

        // Método para obter um usuário por login (exemplo básico)
        private UsuarioViewModel ObterUsuarioPorLogin(string login)
        {
            // Lógica para obter um usuário do banco de dados por login
            // Pode envolver consulta ao banco de dados, busca em uma lista, etc.

            // Exemplo básico: busca em uma lista fixa de usuários em memória
            var usuarios = new List<UsuarioViewModel>
                {
                    new UsuarioViewModel { Id = 1, LoginUsuario = "usuario", SenhaUsuario = "senha" }
                };

            return usuarios.FirstOrDefault(u => u.LoginUsuario == login);
        }
    }
}