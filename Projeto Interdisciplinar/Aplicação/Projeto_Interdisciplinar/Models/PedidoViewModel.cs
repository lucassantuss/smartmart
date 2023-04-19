using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.Models
{
    public class PedidoViewModel
    {
        public int IDPedido { get; set; }

        public int IDCliente { get; set; }

        public DateTime DataPedido { get; set; }

        public decimal ValorTotal { get; set; }
    }
}