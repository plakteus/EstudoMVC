﻿using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;
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
        public ViewResult ListaProdutos(string categoria, int pagina = 1)
        {
            var listaProduto = _repositorioDeProduto.Produtos
                     .Where(p => categoria == null || p.Categoria == categoria)
                     .OrderBy(p => p.Descricao)
                     .Skip((pagina - 1) * ProdutosPorPagina)
                     .Take(ProdutosPorPagina);

            ProdutosViewModel model = new ProdutosViewModel
                {
                    Produtos = listaProduto,

                    Paginacao = new Paginacao
                    {
                        PaginaAtual = pagina,
                        ItensPorPagina = ProdutosPorPagina,
                        ItensTotal = _repositorioDeProduto.Produtos.Count()

                    },

                    CategoriaAtual = categoria
                };

            return View(model);
        }
    }
}