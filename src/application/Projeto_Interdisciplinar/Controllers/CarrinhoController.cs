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
        public IActionResult Index(int idCarrinho)
        {
            try
            {
                ProdutoDAO produtoDAO = new ProdutoDAO();
                ItensPedidoDAO itensDAO = new ItensPedidoDAO();
                List<ItensPedidoViewModel> listaDeItensPedido = new List<ItensPedidoViewModel>();

                if (idCarrinho > 0)
                {
                    int totalCarrinho = itensDAO.ConsultaQuantidadeProdutosNoPedido(idCarrinho);

                    listaDeItensPedido = itensDAO.Listagem();

                    foreach (var item in listaDeItensPedido)
                        item.Produto = produtoDAO.Consulta(item.IDProduto);

                    @ViewBag.TotalCarrinho = totalCarrinho;
                    @ViewBag.IdCarrinho = idCarrinho;
                    @ViewBag.Visualizacao = true;
                }
                else
                {
                    @ViewBag.TotalCarrinho = 0;
                    @ViewBag.Visualizacao = false;
                }

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
                PedidoDAO pedidoDAO = new PedidoDAO();
                ProdutoDAO produtoDAO = new ProdutoDAO();
                ItensPedidoDAO itensDAO = new ItensPedidoDAO();
                ProdutoViewModel produtoExibido = new ProdutoViewModel();

                ItensPedidoViewModel itemExibido = itensDAO.Consulta(idItensPedido);

                if (itemExibido == null)
                {
                    itemExibido = new ItensPedidoViewModel();
                    itemExibido.Id = idItensPedido;
                    itemExibido.IDPedido = 0;
                    itemExibido.IDProduto = 0;
                    itemExibido.Quantidade = 0;
                }
                else
                    itemExibido.Produto = produtoDAO.Consulta(itemExibido.IDProduto);

                return View(itemExibido);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult AdicionarCarrinho(int idCarrinho, int idProduto)
        {
            try
            {
                int qtd = 1;
                bool existe = false;

                PedidoDAO pedidoDAO = new PedidoDAO();
                ProdutoDAO produtoDAO = new ProdutoDAO();
                ItensPedidoDAO itensDAO = new ItensPedidoDAO();

                var carrinho = pedidoDAO.ConsultaPedido(idCarrinho);

                if (carrinho == null)
                {
                    PedidoViewModel pedidoNovo = new PedidoViewModel();
                    pedidoNovo.IDCliente = null;
                    pedidoNovo.IDCarrinho = idCarrinho;
                    pedidoNovo.DataPedido = DateTime.Now;
                    pedidoNovo.ValorTotal = null;

                    pedidoDAO.Insert(pedidoNovo);
                }

                var itensPedido = itensDAO.Listagem();

                foreach (var item in itensPedido)
                {
                    var pedidoAUX = pedidoDAO.Consulta(item.IDPedido);

                    if (pedidoAUX != null)
                    {
                        if (pedidoAUX.IDCarrinho == idCarrinho &&
                            item.IDProduto == idProduto)
                        {
                            existe = true;
                        }
                    }
                }

                if (existe != true)
                {
                    ItensPedidoViewModel itemNovo = new ItensPedidoViewModel();
                    ProdutoViewModel produtoAdicionado = produtoDAO.Consulta(idProduto);
                    PedidoViewModel pedidoAtualizado = pedidoDAO.ConsultaPedido(idCarrinho);

                    // Insere novo produto ao pedido correspondente
                    itemNovo.IDPedido = pedidoAtualizado.Id;
                    itemNovo.IDProduto = idProduto;
                    itemNovo.Quantidade = qtd;

                    itensDAO.Insert(itemNovo);

                    // Altera dados do Pedido
                    pedidoAtualizado.DataPedido = DateTime.Now;
                    pedidoAtualizado.ValorTotal = itemNovo.Quantidade * produtoAdicionado.PrecoProduto;

                    if (HelperController.VerificaUserLogado(HttpContext.Session))
                        pedidoAtualizado.IDCliente = 1;
                    else
                        pedidoAtualizado.IDCliente = null;

                    pedidoDAO.Update(pedidoAtualizado);
                }
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }

            return Json(null);
        }

        public IActionResult AlterarQuantidade(int Id, int Quantidade)
        {
            try
            {
                PedidoDAO pedidoDAO = new PedidoDAO();
                ProdutoDAO produtoDAO = new ProdutoDAO();
                ItensPedidoDAO itensDAO = new ItensPedidoDAO();
                PedidoViewModel pedidoAtualizado = new PedidoViewModel();
                ProdutoViewModel produtoAux = new ProdutoViewModel();

                var itemAtualizado = itensDAO.Consulta(Id);

                if (itemAtualizado != null)
                {
                    pedidoAtualizado = pedidoDAO.Consulta(itemAtualizado.IDPedido);
                    produtoAux = produtoDAO.Consulta(itemAtualizado.IDProduto);

                    itemAtualizado.Quantidade = Quantidade;

                    itensDAO.Update(itemAtualizado);

                    if (pedidoAtualizado != null && produtoAux != null)
                    {
                        // Altera dados do Pedido
                        pedidoAtualizado.DataPedido = DateTime.Now;
                        pedidoAtualizado.ValorTotal = itemAtualizado.Quantidade * produtoAux.PrecoProduto;

                        if (HelperController.VerificaUserLogado(HttpContext.Session))
                            pedidoAtualizado.IDCliente = 1;
                        else
                            pedidoAtualizado.IDCliente = null;

                        pedidoDAO.Update(pedidoAtualizado);
                    }
                }

                return Redirect("/Carrinho/?IdCarrinho=" + pedidoAtualizado.IDCarrinho);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Visualizar(int idCarrinho)
        {
            try
            {
                ItensPedidoDAO itensDAO = new ItensPedidoDAO();
                PedidoDAO pedidoDAO = new PedidoDAO();
                ProdutoDAO produtoDAO = new ProdutoDAO();
                List<ItensPedidoViewModel> listaDeItens = new List<ItensPedidoViewModel>();

                PedidoViewModel carrinho = pedidoDAO.ConsultaPedido(idCarrinho);

                if (carrinho != null)
                {
                    listaDeItens = itensDAO.ConsultaProdutosNoPedido(idCarrinho);

                    foreach (var item in listaDeItens)
                        item.Produto = produtoDAO.Consulta(item.IDProduto);
                }

                @ViewBag.IdCarrinho = idCarrinho;

                return View(listaDeItens);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult EfetuarPedido(int idCarrinho)
        {
            try
            {
                ItensPedidoDAO itensDAO = new ItensPedidoDAO();
                PedidoDAO pedidoDAO = new PedidoDAO();
                ProdutoDAO produtoDAO = new ProdutoDAO();

                PedidoViewModel pedidoAtualizado = pedidoDAO.ConsultaPedido(idCarrinho);

                pedidoAtualizado.IDCliente = null;
                pedidoAtualizado.DataPedido = DateTime.Now;
                pedidoAtualizado.ValorTotal = null;

                pedidoDAO.Update(pedidoAtualizado);

                var ListaDeItens = itensDAO.ConsultaProdutosNoPedido(idCarrinho);

                foreach(var item in ListaDeItens)
                {
                    itensDAO.Delete(item.Id);
                }

                return Json(null);
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