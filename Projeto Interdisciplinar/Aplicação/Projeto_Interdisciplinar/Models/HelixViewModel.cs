using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.Models
{
    public class HelixViewModel
    {
        public string id { get; set; }

        public List<ProdutoViewModel> Produtos { get; set; }
    }
}