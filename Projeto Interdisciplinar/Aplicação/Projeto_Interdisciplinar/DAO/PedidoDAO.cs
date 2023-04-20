using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Projeto_Interdisciplinar.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.DAO
{
    public class PedidoDAO : PadraoDAO<PedidoViewModel>
    {
        protected override SqlParameter[] CriaParametros(PedidoViewModel pedido)
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("Id", pedido.Id);
            p[1] = new SqlParameter("IDCliente", pedido.IDCliente);
            p[2] = new SqlParameter("DataPedido", pedido.DataPedido);
            p[3] = new SqlParameter("ValorTotal", pedido.ValorTotal);

            return p;
        }

        protected override PedidoViewModel MontaModel(DataRow registro)
        {
            PedidoViewModel p = new PedidoViewModel();
            p.Id = Convert.ToInt32(registro["Id"]);
            p.IDCliente = Convert.ToInt32(registro["IDCliente"]);
            p.DataPedido = Convert.ToDateTime(registro["DataPedido"]);
            p.ValorTotal = Convert.ToDecimal(registro["ValorTotal"]);

            return p;
        }

        protected override void SetTabela()
        {
            Tabela = "Pedidos";
            ChaveIdentity = true;
        }
    }
}