using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Projeto_Interdisciplinar.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.DAO
{
    public class UsuarioDAO : PadraoDAO<UsuarioViewModel>
    {
        protected override SqlParameter[] CriaParametros(UsuarioViewModel usuario)
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("Id", usuario.Id);
            p[1] = new SqlParameter("FotoUsuario", usuario.FotoUsuario);
            p[2] = new SqlParameter("LoginUsuario", usuario.LoginUsuario);
            p[3] = new SqlParameter("SenhaUsuario", usuario.SenhaUsuario);
            p[4] = new SqlParameter("IDCliente", usuario.IDCliente);

            return p;
        }

        protected override UsuarioViewModel MontaModel(DataRow registro)
        {
            UsuarioViewModel u = new UsuarioViewModel();
            u.Id = Convert.ToInt32(registro["Id"]);
            u.FotoUsuario = registro["FotoUsuario"].ToString();
            u.LoginUsuario = registro["LoginUsuario"].ToString();
            u.SenhaUsuario = registro["SenhaUsuario"].ToString();
            u.IDCliente = Convert.ToInt32(registro["IDCliente"]);

            return u;
        }

        protected override void SetTabela()
        {
            Tabela = "Usuarios";
        }
    }
}