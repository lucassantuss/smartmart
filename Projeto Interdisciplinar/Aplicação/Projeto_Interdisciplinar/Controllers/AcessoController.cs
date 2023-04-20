using Microsoft.AspNetCore.Mvc;
using Projeto_Interdisciplinar.DAO;
using Projeto_Interdisciplinar.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Projeto_Interdisciplinar.Controllers
{
    public class AcessoController : PadraoController<UsuarioViewModel>
    {
        public AcessoController()
        {
            DAO = new UsuarioDAO();
            GeraProximoId = true;
        }

        protected override void ValidaDados(UsuarioViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);

            if (string.IsNullOrEmpty(model.LoginUsuario))
                ModelState.AddModelError("LoginUsuario", "Preencha o usuário.");

            if (string.IsNullOrEmpty(model.SenhaUsuario))
                ModelState.AddModelError("SenhaUsuario", "Preencha a senha.");

            if (model.IDCliente <= 0)
                ModelState.AddModelError("IDCliente", "Digite um Id do Cliente válido.");

            // Imagem será obrigatório apenas na inclusão.
            // Na alteração iremos considerar a que já estava salva.
            if (model.Foto.Imagem == null && operacao == "I")
                ModelState.AddModelError("Imagem", "Escolha uma imagem.");

            if (model.Foto.Imagem != null && model.Foto.Imagem.Length / 1024 / 1024 >= 2)
                ModelState.AddModelError("Imagem", "Imagem limitada a 2 mb.");

            if (ModelState.IsValid)
            {
                // Na alteração, se não foi informada a imagem, iremos manter a que já estava salva.
                if (operacao == "A" && model.Foto.Imagem == null)
                {
                    UsuarioViewModel user = DAO.Consulta(model.Id);
                    model.Foto.ImagemEmByte = user.Foto.ImagemEmByte;
                }
                else
                {
                    model.Foto.ImagemEmByte = ConvertImageToByte(model.Foto.Imagem);
                }
            }
        }

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
    }
}