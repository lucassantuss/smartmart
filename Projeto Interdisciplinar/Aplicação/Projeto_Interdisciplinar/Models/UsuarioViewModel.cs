using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.Models
{
    public class UsuarioViewModel : PadraoViewModel
    {
        public string LoginUsuario { get; set; }

        public string SenhaUsuario { get; set; }

        public string Perfil { get; set; }

        public int IDCliente { get; set; }

        /// <summary>
        /// Imagem recebida do form pelo controller
        /// </summary>
        public IFormFile Imagem { get; set; }

        /// <summary>
        /// Imagem em bytes pronta para ser salva
        /// </summary>
        public byte[] ImagemEmByte { get; set; }

        /// <summary>
        /// Imagem usada para ser enviada ao form no formato para ser exibida
        /// </summary>
        public string ImagemEmBase64
        {
            get
            {
                if (ImagemEmByte != null)
                    return Convert.ToBase64String(ImagemEmByte);
                else
                    return string.Empty;
            }
        }
    }
}