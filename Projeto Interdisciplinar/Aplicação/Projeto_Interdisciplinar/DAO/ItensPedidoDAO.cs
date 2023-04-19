using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Projeto_Interdisciplinar.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.DAO
{
    public class ItensPedidoDAO : PadraoDAO<ItensPedidoViewModel>
    {
        protected override SqlParameter[] CriaParametros(ItensPedidoViewModel itensPedido)
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("Id", itensPedido.Id);
            p[1] = new SqlParameter("IDPedido", itensPedido.IDPedido);
            p[2] = new SqlParameter("IDProduto", itensPedido.IDProduto);
            p[3] = new SqlParameter("Quantidade", itensPedido.Quantidade);
            p[4] = new SqlParameter("ValorUnitario", itensPedido.ValorUnitario);

            return p;
        }

        protected override ItensPedidoViewModel MontaModel(DataRow registro)
        {
            ItensPedidoViewModel ip = new ItensPedidoViewModel();
            ip.Id = Convert.ToInt32(registro["Id"]);
            ip.IDPedido = Convert.ToInt32(registro["IDPedido"]);
            ip.IDProduto = Convert.ToInt32(registro["IDProduto"]);
            ip.Quantidade = Convert.ToInt32(registro["Quantidade"]);
            ip.ValorUnitario = Convert.ToDecimal(registro["ValorUnitario"]);

            return ip;
        }

        protected override void SetTabela()
        {
            Tabela = "ItensPedido";
        }
    }
}