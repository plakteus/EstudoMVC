using Quiron.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutoRepositorio _repositorioDeProduto = new ProdutoRepositorio();
        public int ProdutosPorPagina = 3;

        // GET: Vitrine
        public ActionResult ListaProdutos(int pagina = 1)
        {
            var listaProduto = _repositorioDeProduto.Produtos
                                 .OrderBy(p => p.Descricao)
                                 .Skip((pagina - 1) * ProdutosPorPagina)
                                 .Take(ProdutosPorPagina);

            return View(listaProduto);
        }
    }
}