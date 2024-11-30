using Microsoft.AspNetCore.Mvc;
using Projeto_Interdisciplinar.DAO;
using Projeto_Interdisciplinar.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

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

            if (model.IDCliente == 0)
                ModelState.AddModelError("IDCliente", "Escolha um cliente.");

            if (model.Perfil == "0")
                ModelState.AddModelError("Perfil", "Escolha um perfil.");

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
                    UsuarioViewModel user = DAO.Consulta(model.Id);
                    model.ImagemEmByte = user.ImagemEmByte;
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
    }
}