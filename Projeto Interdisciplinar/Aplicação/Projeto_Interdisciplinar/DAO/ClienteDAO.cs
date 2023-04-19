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
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("Id", cliente.Id);
            p[1] = new SqlParameter("NomeCliente", cliente.NomeCliente);
            p[2] = new SqlParameter("EnderecoCliente", cliente.EnderecoCliente);
            p[3] = new SqlParameter("EmailCliente", cliente.EmailCliente);
            p[4] = new SqlParameter("TelefoneCliente", cliente.TelefoneCliente);

            return p;
        }

        protected override ClienteViewModel MontaModel(DataRow registro)
        {
            ClienteViewModel c = new ClienteViewModel();
            c.Id = Convert.ToInt32(registro["Id"]);
            c.NomeCliente = registro["NomeCliente"].ToString();
            c.EnderecoCliente = registro["EnderecoCliente"].ToString();
            c.EmailCliente = registro["EmailCliente"].ToString();
            c.TelefoneCliente = registro["TelefoneCliente"].ToString();

            return c;
        }

        protected override void SetTabela()
        {
            Tabela = "Clientes";
        }
    }
}