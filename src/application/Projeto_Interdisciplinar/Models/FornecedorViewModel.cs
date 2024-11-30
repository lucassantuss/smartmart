using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.Models
{
    public class FornecedorViewModel : PadraoViewModel
    {
        public string NomeFornecedor { get; set; }

        public string EnderecoFornecedor { get; set; }

        public string EmailFornecedor { get; set; }

        public string TelefoneFornecedor { get; set; }
    }
}