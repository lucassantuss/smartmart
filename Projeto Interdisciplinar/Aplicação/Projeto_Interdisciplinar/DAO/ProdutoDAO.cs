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
            object imgByte = produto.ImagemEmByte;

            if (imgByte == null)
                imgByte = DBNull.Value;

            SqlParameter[] p = new SqlParameter[7];
            p[0] = new SqlParameter("Id", produto.Id);
            p[1] = new SqlParameter("NomeProduto", produto.NomeProduto);
            p[2] = new SqlParameter("FotoProduto", imgByte);
            p[3] = new SqlParameter("DescricaoProduto", produto.DescricaoProduto);
            p[4] = new SqlParameter("PrecoProduto", produto.PrecoProduto);
            p[5] = new SqlParameter("EstoqueProduto", produto.EstoqueProduto);
            p[6] = new SqlParameter("IDFornecedor", produto.IDFornecedor);

            return p;
        }

        protected override ProdutoViewModel MontaModel(DataRow registro)
        {
            ProdutoViewModel p = new ProdutoViewModel();
            p.Id = Convert.ToInt32(registro["Id"]);
            p.NomeProduto = registro["NomeProduto"].ToString();
            p.DescricaoProduto = registro["DescricaoProduto"].ToString();
            p.PrecoProduto = Convert.ToDecimal(registro["PrecoProduto"]);
            p.EstoqueProduto = Convert.ToInt32(registro["EstoqueProduto"]);
            p.IDFornecedor = Convert.ToInt32(registro["IDFornecedor"]);

            if (registro["FotoProduto"] != DBNull.Value)
                p.ImagemEmByte = registro["FotoProduto"] as byte[];

            return p;
        }

        protected override void SetTabela()
        {
            Tabela = "Produtos";
        }
    }
}