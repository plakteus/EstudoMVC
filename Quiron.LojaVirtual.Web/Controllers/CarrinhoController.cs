using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private ProdutoRepositorio _repositorio;

        public ViewResult Index(string returnURL)
        {
            return View(new CarrinhoViewModel
            {
                Carrinho = ObterCarrinho(),
                ReturnURL = returnURL
            });
        }


        public RedirectToRouteResult Adicionar(int IdProduto, string returnURL)
        {
            _repositorio = new ProdutoRepositorio();

            Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.IdProduto == IdProduto);

            if (produto != null)
            {
                ObterCarrinho().AdicionarItem(produto, 1);
            }

            return RedirectToAction("Index", new { returnURL });
        }

        public RedirectToRouteResult Remover(int IdProduto, string returnURL)
        {
            _repositorio = new ProdutoRepositorio();

            Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.IdProduto == IdProduto);

            if (produto != null)
            {
                ObterCarrinho().RemoverItem(produto);
            }

            return RedirectToAction("Index", new { returnURL });
        }


        public PartialViewResult Resumo()
        {
            Carrinho carrinho = ObterCarrinho();

            return PartialView(carrinho);
        }

        public ViewResult FecharPedido()
        {
            return View(new Pedido());
        }

        [HttpPost]
        public ViewResult FecharPedido(Pedido pedido)
        {
            Carrinho carrinho = ObterCarrinho();

            EmailConfiguracoes email = new EmailConfiguracoes
            {
                EscreverArquivo = bool.Parse(ConfigurationManager.AppSettings["Email.EscreverArquivo"] ?? "false")
            };

            EmailPedido emailPedido = new EmailPedido(email);

            if (!carrinho.ItensCarrinho.Any())
            {
                ModelState.AddModelError("", "Não foi possível concluir o pedido, seu carrinho está vazio.");
            }

            if (ModelState.IsValid)
            {
                emailPedido.ProcessarPedido(carrinho, pedido);
                carrinho.LimparCarrinho();

                return View("PedidoConcluido");
            }

            else
                return View(pedido);

        }

        public ViewResult PedidoConcluido()
        {
            return View();
        }

        private Carrinho ObterCarrinho()
        {
            Carrinho carrinho = (Carrinho)Session["Carrinho"];

            if (carrinho == null)
            {
                carrinho = new Carrinho();
                Session["Carrinho"] = carrinho;
            }

            return carrinho;
        }

    }
}