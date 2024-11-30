using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Projeto_Interdisciplinar.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.DAO
{
    public class ClienteDAO : PadraoDAO<ClienteViewModel>
    {
        protected override SqlParameter[] CriaParametros(ClienteViewModel cliente)
        {
            object endereco = cliente.EnderecoCliente;
            object email = cliente.EmailCliente;
            object telefone = cliente.TelefoneCliente;

            if (endereco == null)
                endereco = DBNull.Value;
            if (email == null)
                email = DBNull.Value;
            if (telefone == null)
                telefone = DBNull.Value;

            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("Id", cliente.Id);
            p[1] = new SqlParameter("NomeCliente", cliente.NomeCliente);
            p[2] = new SqlParameter("EnderecoCliente", endereco);
            p[3] = new SqlParameter("EmailCliente", email);
            p[4] = new SqlParameter("TelefoneCliente", telefone);

            return p;
        }

        protected override ClienteViewModel MontaModel(DataRow registro)
        {
            ClienteViewModel c = new ClienteViewModel();
            c.Id = Convert.ToInt32(registro["Id"]);
            c.NomeCliente = registro["NomeCliente"].ToString();
            
            if (registro["EnderecoCliente"] != DBNull.Value)
                c.EnderecoCliente = registro["EnderecoCliente"].ToString();

            if (registro["EmailCliente"] != DBNull.Value)
                c.EmailCliente = registro["EmailCliente"].ToString();

            if (registro["TelefoneCliente"] != DBNull.Value)
                c.TelefoneCliente = registro["TelefoneCliente"].ToString();

            return c;
        }

        protected override void SetTabela()
        {
            Tabela = "Clientes";
        }
    }
}