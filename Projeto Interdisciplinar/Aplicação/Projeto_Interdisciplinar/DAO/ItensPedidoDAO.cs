using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Projeto_Interdisciplinar.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.DAO
{
    public class ItensPedidoDAO
    {
        private SqlParameter[] CriaParametros(ItensPedidoViewModel itensPedido)
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("IDItemPedido", itensPedido.IDItemPedido);
            p[1] = new SqlParameter("IDPedido", itensPedido.IDPedido);
            p[2] = new SqlParameter("IDProduto", itensPedido.IDProduto);
            p[3] = new SqlParameter("Quantidade", itensPedido.Quantidade);
            p[4] = new SqlParameter("ValorUnitario", itensPedido.ValorUnitario);

            return p;
        }

        public void Inserir(ItensPedidoViewModel itensPedido)
        {
            HelperDAO.ExecutaProc("spIncluiItensPedido", CriaParametros(itensPedido));
        }

        public void Alterar(ItensPedidoViewModel itensPedido)
        {
            HelperDAO.ExecutaProc("spAlteraItensPedido", CriaParametros(itensPedido));
        }

        public void Excluir(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("IDItemPedido", id)
            };

            HelperDAO.ExecutaProc("spExcluiItensPedido", p);
        }

        public ItensPedidoViewModel Consulta(int id)
        {
            var p = new SqlParameter[]
            {
                 new SqlParameter("IDItemPedido", id)
            };

            DataTable tabela = HelperDAO.ExecutaProcSelect("spConsultaItensPedido", p);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaItensPedido(tabela.Rows[0]);
        }

        private ItensPedidoViewModel MontaItensPedido(DataRow registro)
        {
            ItensPedidoViewModel ip = new ItensPedidoViewModel();
            ip.IDItemPedido = Convert.ToInt32(registro["IDItemPedido"]);
            ip.IDPedido = Convert.ToInt32(registro["IDPedido"]);
            ip.IDProduto = Convert.ToInt32(registro["IDProduto"]);
            ip.Quantidade = Convert.ToInt32(registro["Quantidade"]);
            ip.ValorUnitario = Convert.ToDecimal(registro["ValorUnitario"]);

            return ip;
        }

        public List<ItensPedidoViewModel> Listagem()
        {
            List<ItensPedidoViewModel> lista = new List<ItensPedidoViewModel>();

            DataTable tabela = HelperDAO.ExecutaProcSelect("spListagemItensPedidos", null);

            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaItensPedido(registro));

            return lista;
        }

        public int ProximoId()
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("tabela", "ItensPedido")
            };

            DataTable tabela = HelperDAO.ExecutaProcSelect("spProximoId", p);

            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }
    }
}