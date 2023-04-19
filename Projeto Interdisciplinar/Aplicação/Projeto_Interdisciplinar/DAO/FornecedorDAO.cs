using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Projeto_Interdisciplinar.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.DAO
{
    public class FornecedorDAO
    {
        private SqlParameter[] CriaParametros(FornecedorViewModel fornecedor)
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("IDFornecedor", fornecedor.IDFornecedor);
            p[1] = new SqlParameter("NomeFornecedor", fornecedor.NomeFornecedor);
            p[2] = new SqlParameter("EnderecoFornecedor", fornecedor.EnderecoFornecedor);
            p[3] = new SqlParameter("EmailFornecedor", fornecedor.EmailFornecedor);
            p[4] = new SqlParameter("TelefoneFornecedor", fornecedor.TelefoneFornecedor);

            return p;
        }

        public void Inserir(FornecedorViewModel fornecedor)
        {
            HelperDAO.ExecutaProc("spIncluiFornecedor", CriaParametros(fornecedor));
        }

        public void Alterar(FornecedorViewModel fornecedor)
        {
            HelperDAO.ExecutaProc("spAlteraFornecedor", CriaParametros(fornecedor));
        }

        public void Excluir(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("IDFornecedor", id)
            };

            HelperDAO.ExecutaProc("spExcluiFornecedor", p);
        }

        public FornecedorViewModel Consulta(int id)
        {
            var p = new SqlParameter[]
            {
                 new SqlParameter("IDFornecedor", id)
            };

            DataTable tabela = HelperDAO.ExecutaProcSelect("spConsultaFornecedor", p);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaFornecedor(tabela.Rows[0]);
        }

        private FornecedorViewModel MontaFornecedor(DataRow registro)
        {
            FornecedorViewModel f = new FornecedorViewModel();
            f.IDFornecedor = Convert.ToInt32(registro["IDFornecedor"]);
            f.NomeFornecedor = registro["NomeFornecedor"].ToString();
            f.EnderecoFornecedor = registro["EnderecoFornecedor"].ToString();
            f.EmailFornecedor = registro["EmailFornecedor"].ToString();
            f.TelefoneFornecedor = registro["TelefoneFornecedor"].ToString();

            return f;
        }

        public List<FornecedorViewModel> Listagem()
        {
            List<FornecedorViewModel> lista = new List<FornecedorViewModel>();

            DataTable tabela = HelperDAO.ExecutaProcSelect("spListagemFornecedores", null);

            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaFornecedor(registro));

            return lista;
        }

        public int ProximoId()
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("tabela", "Fornecedores")
            };

            DataTable tabela = HelperDAO.ExecutaProcSelect("spProximoId", p);

            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }
    }
}