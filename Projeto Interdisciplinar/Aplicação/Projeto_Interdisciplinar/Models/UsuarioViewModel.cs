using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.Models
{
    public class UsuarioViewModel : PadraoViewModel
    {
        public string FotoUsuario { get; set; }

        public string LoginUsuario { get; set; }

        public string SenhaUsuario { get; set; }

        public int IDCliente { get; set; }

        // TODO chamar a view model de cliente

        public ImagemViewModel Foto { get; set; }
    }
}