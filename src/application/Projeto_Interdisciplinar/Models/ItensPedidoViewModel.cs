﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.Models
{
    public class ItensPedidoViewModel : PadraoViewModel
    {
        public int IDPedido { get; set; }

        public int IDProduto { get; set; }

        public int Quantidade { get; set; }

        public string ImagemEmBase64 { get; set; }

        public ProdutoViewModel Produto { get; set; }
    }
}