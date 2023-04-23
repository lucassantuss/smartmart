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
            object imgByte = usuario.ImagemEmByte;

            if (imgByte == null)
                imgByte = DBNull.Value;

            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("Id", usuario.Id);
            p[1] = new SqlParameter("FotoUsuario", imgByte);
            p[2] = new SqlParameter("LoginUsuario", usuario.LoginUsuario);
            p[3] = new SqlParameter("SenhaUsuario", usuario.SenhaUsuario);
            p[4] = new SqlParameter("Perfil", usuario.Perfil);
            p[5] = new SqlParameter("IDCliente", usuario.IDCliente);

            return p;
        }

        protected override UsuarioViewModel MontaModel(DataRow registro)
        {
            UsuarioViewModel u = new UsuarioViewModel();
            u.Id = Convert.ToInt32(registro["Id"]);
            u.LoginUsuario = registro["LoginUsuario"].ToString();
            u.SenhaUsuario = registro["SenhaUsuario"].ToString();
            u.Perfil = registro["Perfil"].ToString();
            u.IDCliente = Convert.ToInt32(registro["IDCliente"]);

            if (registro["FotoUsuario"] != DBNull.Value)
                u.ImagemEmByte = registro["FotoUsuario"] as byte[];

            return u;
        }

        protected override void SetTabela()
        {
            Tabela = "Usuarios";
        }
    }
}