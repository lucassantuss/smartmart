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
            object endereco = fornecedor.EnderecoFornecedor;
            object email = fornecedor.EmailFornecedor;
            object telefone = fornecedor.TelefoneFornecedor;

            if (endereco == null)
                endereco = DBNull.Value;
            if (email == null)
                email = DBNull.Value;
            if (telefone == null)
                telefone = DBNull.Value;

            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("Id", fornecedor.Id);
            p[1] = new SqlParameter("NomeFornecedor", fornecedor.NomeFornecedor);
            p[2] = new SqlParameter("EnderecoFornecedor", endereco);
            p[3] = new SqlParameter("EmailFornecedor", email);
            p[4] = new SqlParameter("TelefoneFornecedor", telefone);

            return p;
        }

        protected override FornecedorViewModel MontaModel(DataRow registro)
        {
            FornecedorViewModel f = new FornecedorViewModel();
            f.Id = Convert.ToInt32(registro["Id"]);
            f.NomeFornecedor = registro["NomeFornecedor"].ToString();

            if (registro["EnderecoFornecedor"] != DBNull.Value)
                f.EnderecoFornecedor = registro["EnderecoFornecedor"].ToString();

            if (registro["EmailFornecedor"] != DBNull.Value)
                f.EmailFornecedor = registro["EmailFornecedor"].ToString();

            if (registro["TelefoneFornecedor"] != DBNull.Value)
                f.TelefoneFornecedor = registro["TelefoneFornecedor"].ToString();

            return f;
        }

        protected override void SetTabela()
        {
            Tabela = "Fornecedores";
        }
    }
}