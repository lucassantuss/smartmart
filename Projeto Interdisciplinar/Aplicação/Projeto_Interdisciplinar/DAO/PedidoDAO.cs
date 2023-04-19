using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Projeto_Interdisciplinar.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.DAO
{
    public class PedidoDAO
    {
        private SqlParameter[] CriaParametros(PedidoViewModel pedido)
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("IDPedido", pedido.IDPedido);
            p[1] = new SqlParameter("IDCliente", pedido.IDCliente);
            p[2] = new SqlParameter("DataPedido", pedido.DataPedido);
            p[3] = new SqlParameter("ValorTotal", pedido.ValorTotal);

            return p;
        }

        public void Inserir(PedidoViewModel pedido)
        {
            HelperDAO.ExecutaProc("spIncluiPedido", CriaParametros(pedido));
        }

        public void Alterar(PedidoViewModel pedido)
        {
            HelperDAO.ExecutaProc("spAlteraPedido", CriaParametros(pedido));
        }

        public void Excluir(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("IDPedido", id)
            };

            HelperDAO.ExecutaProc("spExcluiPedido", p);
        }

        public PedidoViewModel Consulta(int id)
        {
            var p = new SqlParameter[]
            {
                 new SqlParameter("IDPedido", id)
            };

            DataTable tabela = HelperDAO.ExecutaProcSelect("spConsultaPedido", p);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaPedido(tabela.Rows[0]);
        }

        private PedidoViewModel MontaPedido(DataRow registro)
        {
            PedidoViewModel p = new PedidoViewModel();
            p.IDPedido = Convert.ToInt32(registro["IDPedido"]);
            p.IDCliente = Convert.ToInt32(registro["IDCliente"]);
            p.DataPedido = Convert.ToDateTime(registro["DataPedido"]);
            p.ValorTotal = Convert.ToDecimal(registro["ValorTotal"]);

            return p;
        }

        public List<PedidoViewModel> Listagem()
        {
            List<PedidoViewModel> lista = new List<PedidoViewModel>();

            DataTable tabela = HelperDAO.ExecutaProcSelect("spListagemPedidos", null);

            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaPedido(registro));

            return lista;
        }

        public int ProximoId()
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("tabela", "Pedidos")
            };

            DataTable tabela = HelperDAO.ExecutaProcSelect("spProximoId", p);

            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }
    }
}