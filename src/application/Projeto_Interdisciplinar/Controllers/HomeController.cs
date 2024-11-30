﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projeto_Interdisciplinar.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Interdisciplinar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Logado = HelperController.VerificaUserLogado(HttpContext.Session);
            ViewBag.Perfil = HelperController.VerificaPerfil(HttpContext.Session);
            return View();
        }

        public IActionResult Sobre()
        {
            ViewBag.Logado = HelperController.VerificaUserLogado(HttpContext.Session);
            ViewBag.Perfil = HelperController.VerificaPerfil(HttpContext.Session);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
