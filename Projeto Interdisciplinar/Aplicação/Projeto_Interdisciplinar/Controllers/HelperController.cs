using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Projeto_Interdisciplinar.Controllers
{
    public class HelperController : Controller
    {
        public static Boolean VerificaUserLogado(ISession session)
        {
            string logado = session.GetString("Logado");

            if (logado == null)
                return false;
            else
                return true;
        }

        public static void LimparCarrinho(ISession session)
        {
            session.Clear();
        }
    }
}