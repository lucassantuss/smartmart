﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.Models
{
    public class PedidoViewModel : PadraoViewModel
    {
        public int? IDCliente { get; set; }

        public int? IDCarrinho { get; set; }

        public DateTime DataPedido { get; set; }

        public decimal? ValorTotal { get; set; }
    }
}