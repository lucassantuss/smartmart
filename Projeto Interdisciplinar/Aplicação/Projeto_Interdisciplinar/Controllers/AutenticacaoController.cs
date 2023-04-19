using Microsoft.AspNetCore.Mvc;
using Projeto_Interdisciplinar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.Controllers
{
    public class AutenticacaoController : Controller
    {
        // Ação para exibir a página de login
        public ActionResult _Login()
        {
            return PartialView();
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
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Caso contrário, exibir mensagem de erro
                ViewBag.MensagemErro = "Credenciais inválidas. Por favor, tente novamente.";
                return PartialView();
            }
        }

        // Ação para realizar o logout
        public ActionResult Logout()
        {
            // Lógica para realizar o logout do usuário
            // Pode envolver limpar sessão, cookie, etc.

            return RedirectToAction("Index", "Home");
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