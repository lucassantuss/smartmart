using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.DAO
{
    public class ConexaoDAO
    {
        /// <summary>
        /// Método Estático que retorna um conexao aberta com o BD
        /// </summary>
        /// <returns>Conexão aberta</returns>
        public static SqlConnection GetConexao()
        {
            //string strCon = "Data Source=LOCALHOST\\SQLEXPRESS; Database=Projeto_Interdisciplinar; user id=sa; password=123456";
            string strCon = "Data Source=LOCALHOST; Database=Projeto_Interdisciplinar; user id=sa; password=123456";
            SqlConnection conexao = new SqlConnection(strCon);
            conexao.Open();
            return conexao;
        }
    }
}