using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Projeto_Interdisciplinar.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.DAO
{
    public class UsuarioDAO
    {
        private SqlParameter[] CriaParametros(UsuarioViewModel usuario)
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("IDUsuario", usuario.IDUsuario);
            p[1] = new SqlParameter("FotoUsuario", usuario.FotoUsuario);
            p[2] = new SqlParameter("LoginUsuario", usuario.LoginUsuario);
            p[3] = new SqlParameter("SenhaUsuario", usuario.SenhaUsuario);
            p[4] = new SqlParameter("IDCliente", usuario.IDCliente);

            return p;
        }

        public void Inserir(UsuarioViewModel usuario)
        {
            HelperDAO.ExecutaProc("spIncluiUsuario", CriaParametros(usuario));
        }

        public void Alterar(UsuarioViewModel usuario)
        {
            HelperDAO.ExecutaProc("spAlteraUsuario", CriaParametros(usuario));
        }

        public void Excluir(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("IDUsuario", id)
            };

            HelperDAO.ExecutaProc("spExcluiUsuario", p);
        }

        public UsuarioViewModel Consulta(int id)
        {
            var p = new SqlParameter[]
            {
                 new SqlParameter("IDUsuario", id)
            };

            DataTable tabela = HelperDAO.ExecutaProcSelect("spConsultaUsuario", p);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaUsuario(tabela.Rows[0]);
        }

        private UsuarioViewModel MontaUsuario(DataRow registro)
        {
            UsuarioViewModel u = new UsuarioViewModel();
            u.IDUsuario = Convert.ToInt32(registro["IDUsuario"]);
            u.FotoUsuario = registro["FotoUsuario"].ToString();
            u.LoginUsuario = registro["LoginUsuario"].ToString();
            u.SenhaUsuario = registro["SenhaUsuario"].ToString();
            u.IDCliente = Convert.ToInt32(registro["IDCliente"]);

            return u;
        }

        public List<UsuarioViewModel> Listagem()
        {
            List<UsuarioViewModel> lista = new List<UsuarioViewModel>();

            DataTable tabela = HelperDAO.ExecutaProcSelect("spListagemUsuarios", null);

            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaUsuario(registro));

            return lista;
        }

        public int ProximoId()
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("tabela", "Usuarios")
            };

            DataTable tabela = HelperDAO.ExecutaProcSelect("spProximoId", p);

            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }
    }
}