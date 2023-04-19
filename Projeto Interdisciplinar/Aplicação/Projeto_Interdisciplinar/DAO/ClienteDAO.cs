using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Projeto_Interdisciplinar.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.DAO
{
    public class ClienteDAO
    {
        private SqlParameter[] CriaParametros(ClienteViewModel cliente)
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("IDCliente", cliente.IDCliente);
            p[1] = new SqlParameter("NomeCliente", cliente.NomeCliente);
            p[2] = new SqlParameter("EnderecoCliente", cliente.EnderecoCliente);
            p[3] = new SqlParameter("EmailCliente", cliente.EmailCliente);
            p[4] = new SqlParameter("TelefoneCliente", cliente.TelefoneCliente);

            return p;
        }

        public void Inserir(ClienteViewModel cliente)
        {
            HelperDAO.ExecutaProc("spIncluiCliente", CriaParametros(cliente));
        }

        public void Alterar(ClienteViewModel cliente)
        {
            HelperDAO.ExecutaProc("spAlteraCliente", CriaParametros(cliente));
        }

        public void Excluir(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("IDCliente", id)
            };

            HelperDAO.ExecutaProc("spExcluiCliente", p);
        }

        public ClienteViewModel Consulta(int id)
        {
            var p = new SqlParameter[]
            {
                 new SqlParameter("IDCliente", id)
            };

            DataTable tabela = HelperDAO.ExecutaProcSelect("spConsultaCliente", p);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaCliente(tabela.Rows[0]);
        }

        private ClienteViewModel MontaCliente(DataRow registro)
        {
            ClienteViewModel c = new ClienteViewModel();
            c.IDCliente = Convert.ToInt32(registro["IDCliente"]);
            c.NomeCliente = registro["NomeCliente"].ToString();
            c.EnderecoCliente = registro["EnderecoCliente"].ToString();
            c.EmailCliente = registro["EmailCliente"].ToString();
            c.TelefoneCliente = registro["TelefoneCliente"].ToString();

            return c;
        }

        public List<ClienteViewModel> Listagem()
        {
            List<ClienteViewModel> lista = new List<ClienteViewModel>();

            DataTable tabela = HelperDAO.ExecutaProcSelect("spListagemClientes", null);

            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaCliente(registro));

            return lista;
        }

        public int ProximoId()
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("tabela", "Clientes")
            };

            DataTable tabela = HelperDAO.ExecutaProcSelect("spProximoId", p);

            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }
    }
}