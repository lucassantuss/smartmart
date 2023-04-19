using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Projeto_Interdisciplinar.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.DAO
{
    public class ProdutoDAO : PadraoDAO<ProdutoViewModel>
    {
        protected override SqlParameter[] CriaParametros(ProdutoViewModel produto)
        {
            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("Id", produto.Id);
            p[1] = new SqlParameter("NomeProduto", produto.NomeProduto);
            p[2] = new SqlParameter("FotoProduto", produto.FotoProduto);
            p[3] = new SqlParameter("DescricaoProduto", produto.DescricaoProduto);
            p[4] = new SqlParameter("PrecoProduto", produto.PrecoProduto);
            p[5] = new SqlParameter("EstoqueProduto", produto.EstoqueProduto);

            return p;
        }

        protected override ProdutoViewModel MontaModel(DataRow registro)
        {
            ProdutoViewModel p = new ProdutoViewModel();
            p.Id = Convert.ToInt32(registro["Id"]);
            p.NomeProduto = registro["NomeProduto"].ToString();
            p.FotoProduto = registro["FotoProduto"].ToString();
            p.DescricaoProduto = registro["DescricaoProduto"].ToString();
            p.PrecoProduto = Convert.ToDecimal(registro["PrecoProduto"]);
            p.EstoqueProduto = Convert.ToInt32(registro["EstoqueProduto"]);

            return p;
        }

        protected override void SetTabela()
        {
            Tabela = "Produtos";
        }
    }
}