using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Projeto_Interdisciplinar.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.DAO
{
    public class ProdutoDAO
    {
        private SqlParameter[] CriaParametros(ProdutoViewModel produto)
        {
            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("IDProduto", produto.IDProduto);
            p[1] = new SqlParameter("NomeProduto", produto.NomeProduto);
            p[2] = new SqlParameter("FotoProduto", produto.FotoProduto);
            p[3] = new SqlParameter("DescricaoProduto", produto.DescricaoProduto);
            p[4] = new SqlParameter("PrecoProduto", produto.PrecoProduto);
            p[5] = new SqlParameter("EstoqueProduto", produto.EstoqueProduto);

            return p;
        }

        public void Inserir(ProdutoViewModel produto)
        {
            HelperDAO.ExecutaProc("spIncluiProduto", CriaParametros(produto));
        }

        public void Alterar(ProdutoViewModel produto)
        {
            HelperDAO.ExecutaProc("spAlteraProduto", CriaParametros(produto));
        }

        public void Excluir(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("IDProduto", id)
            };

            HelperDAO.ExecutaProc("spExcluiProduto", p);
        }

        public ProdutoViewModel Consulta(int id)
        {
            var p = new SqlParameter[]
            {
                 new SqlParameter("IDProduto", id)
            };

            DataTable tabela = HelperDAO.ExecutaProcSelect("spConsultaProduto", p);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaProduto(tabela.Rows[0]);
        }

        private ProdutoViewModel MontaProduto(DataRow registro)
        {
            ProdutoViewModel p = new ProdutoViewModel();
            p.IDProduto = Convert.ToInt32(registro["IDProduto"]);
            p.NomeProduto = registro["NomeProduto"].ToString();
            p.FotoProduto = registro["FotoProduto"].ToString();
            p.DescricaoProduto = registro["DescricaoProduto"].ToString();
            p.PrecoProduto = Convert.ToDecimal(registro["PrecoProduto"]);
            p.EstoqueProduto = Convert.ToInt32(registro["EstoqueProduto"]);

            return p;
        }

        public List<ProdutoViewModel> Listagem()
        {
            List<ProdutoViewModel> lista = new List<ProdutoViewModel>();

            DataTable tabela = HelperDAO.ExecutaProcSelect("spListagemProdutos", null);

            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaProduto(registro));

            return lista;
        }

        public int ProximoId()
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("tabela", "Produtos")
            };

            DataTable tabela = HelperDAO.ExecutaProcSelect("spProximoId", p);

            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }
    }
}