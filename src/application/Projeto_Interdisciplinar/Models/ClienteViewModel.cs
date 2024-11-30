using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.Models
{
    public class ClienteViewModel : PadraoViewModel
    {
        public string NomeCliente { get; set; }

        public string EnderecoCliente { get; set; }

        public string EmailCliente { get; set; }

        public string TelefoneCliente { get; set; }
    }
}