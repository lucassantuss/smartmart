using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Interdisciplinar.DAO;
using Projeto_Interdisciplinar.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Projeto_Interdisciplinar.Controllers
{
    public class CarrinhoController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                ItensPedidoDAO dao = new ItensPedidoDAO();
                var listaDeItensPedido = dao.Listagem();
                var carrinho = ObtemCarrinhoNaSession();
                //@ViewBag.TotalCarrinho = carrinho.Sum(c => c.Quantidade);
                @ViewBag.TotalCarrinho = 0;

                foreach (var c in carrinho)
                    @ViewBag.TotalCarrinho += c.Quantidade;

                return View(listaDeItensPedido);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Detalhes(int idItensPedido)
        {
            try
            {
                List<ItensPedidoViewModel> carrinho = ObtemCarrinhoNaSession();
                ItensPedidoDAO dao = new ItensPedidoDAO();
                var modelItensPedido = dao.Consulta(idItensPedido);
                ItensPedidoViewModel carrinhoModel = carrinho.Find(c => c.Id == idItensPedido);

                if (carrinhoModel == null)
                {
                    carrinhoModel = new ItensPedidoViewModel();
                    carrinhoModel.Id = idItensPedido;
                    carrinhoModel.IDPedido = 0;
                    carrinhoModel.IDProduto = 0;
                    carrinhoModel.Quantidade = 0;
                    carrinhoModel.ValorUnitario = 0;
                }
                // preenche a imagem
                carrinhoModel.ImagemEmBase64 = modelItensPedido.ImagemEmBase64;

                return View(carrinhoModel);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        private List<ItensPedidoViewModel> ObtemCarrinhoNaSession()
        {
            List<ItensPedidoViewModel> carrinho = new List<ItensPedidoViewModel>();
            string carrinhoJson = HttpContext.Session.GetString("carrinho");

            if (carrinhoJson != null)
                carrinho = JsonConvert.DeserializeObject<List<ItensPedidoViewModel>>(carrinhoJson);
            
            return carrinho;
        }

        public IActionResult AdicionarCarrinho(int idProduto, int Quantidade)
        {
            try
            {
                List<ItensPedidoViewModel> carrinho = ObtemCarrinhoNaSession();
                ItensPedidoViewModel carrinhoModel = carrinho.Find(c => c.IDProduto == idProduto);
                
                if (carrinhoModel != null && Quantidade == 0)
                {
                    //tira do carrinho
                    carrinho.Remove(carrinhoModel);
                }
                else if (carrinhoModel == null && Quantidade > 0)
                {
                    //não havia no carrinho, vamos adicionar
                    ProdutoDAO dao = new ProdutoDAO();
                    var modelProduto = dao.Consulta(idProduto);
                    carrinhoModel = new ItensPedidoViewModel();
                    carrinhoModel.IDProduto = idProduto;
                    carrinhoModel.Quantidade = modelProduto.EstoqueProduto;
                    carrinhoModel.ValorUnitario = modelProduto.PrecoProduto;
                    carrinhoModel.Produto = modelProduto;
                    carrinho.Add(carrinhoModel);
                }

                if (carrinhoModel != null)
                    carrinhoModel.Quantidade = Quantidade;

                string carrinhoJson = JsonConvert.SerializeObject(carrinho);
                HttpContext.Session.SetString("carrinho", carrinhoJson);

                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Visualizar()
        {
            try
            {
                ItensPedidoDAO dao = new ItensPedidoDAO();
                var carrinho = ObtemCarrinhoNaSession();

                return View(carrinho);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult EfetuarPedido()
        {
            try
            {
                using (var transacao = new System.Transactions.TransactionScope())
                {
                    PedidoViewModel pedido = new PedidoViewModel();
                    pedido.DataPedido = DateTime.Now;

                    PedidoDAO pedidoDAO = new PedidoDAO();
                    int idPedido = pedidoDAO.Insert(pedido);

                    ItensPedidoDAO itemDAO = new ItensPedidoDAO();
                    var carrinho = ObtemCarrinhoNaSession();

                    foreach (var elemento in carrinho)
                    {
                        ItensPedidoViewModel item = new ItensPedidoViewModel();
                        item.IDPedido = idPedido;
                        item.IDProduto = elemento.IDProduto;
                        item.Quantidade = elemento.Quantidade;
                        item.ValorUnitario = elemento.ValorUnitario;

                        itemDAO.Insert(item);
                    }

                    transacao.Complete();
                }

                HelperController.LimparCarrinho(HttpContext.Session);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (HelperController.VerificaUserLogado(HttpContext.Session))
            {
                ViewBag.Logado = true;
                base.OnActionExecuting(context);
            }

            ViewBag.Perfil = HelperController.VerificaPerfil(HttpContext.Session);
        }
    }
}