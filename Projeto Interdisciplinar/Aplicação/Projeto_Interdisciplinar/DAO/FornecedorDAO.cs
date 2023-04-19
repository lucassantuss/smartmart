using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Projeto_Interdisciplinar.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.DAO
{
    public class FornecedorDAO : PadraoDAO<FornecedorViewModel>
    {
        protected override SqlParameter[] CriaParametros(FornecedorViewModel fornecedor)
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("Id", fornecedor.Id);
            p[1] = new SqlParameter("NomeFornecedor", fornecedor.NomeFornecedor);
            p[2] = new SqlParameter("EnderecoFornecedor", fornecedor.EnderecoFornecedor);
            p[3] = new SqlParameter("EmailFornecedor", fornecedor.EmailFornecedor);
            p[4] = new SqlParameter("TelefoneFornecedor", fornecedor.TelefoneFornecedor);

            return p;
        }

        protected override FornecedorViewModel MontaModel(DataRow registro)
        {
            FornecedorViewModel f = new FornecedorViewModel();
            f.Id = Convert.ToInt32(registro["Id"]);
            f.NomeFornecedor = registro["NomeFornecedor"].ToString();
            f.EnderecoFornecedor = registro["EnderecoFornecedor"].ToString();
            f.EmailFornecedor = registro["EmailFornecedor"].ToString();
            f.TelefoneFornecedor = registro["TelefoneFornecedor"].ToString();

            return f;
        }

        protected override void SetTabela()
        {
            Tabela = "Fornecedores";
        }
    }
}