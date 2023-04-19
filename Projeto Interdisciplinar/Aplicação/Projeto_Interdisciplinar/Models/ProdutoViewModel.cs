using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.Models
{
    public class ProdutoViewModel : PadraoViewModel
    {
        public string NomeProduto { get; set; }

        public string FotoProduto { get; set; }

        public string DescricaoProduto { get; set; }

        public decimal PrecoProduto { get; set; }

        public int EstoqueProduto { get; set; }
    }
}