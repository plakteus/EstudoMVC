using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class TesteCarrinhoCompras
    {
        // Teste de adicionar itens ao carrinho
        [TestMethod]
        public void AdionarItensAoCarinho()
        {
            // Arrange - Criação dos Produtos
            Produto _produto1 = new Produto
            {
                Categoria = "Categoria 1",
                Descricao = "Produto 1",
                IdProduto = 1,
                Nome = "Produto Teste 1",
                Preco = 1.0m
            };

            Produto _produto2 = new Produto
            {
                Categoria = "Categoria 1",
                Descricao = "Produto 1",
                IdProduto = 2,
                Nome = "Produto Teste 1",
                Preco = 2.0m
            };

            // Arrange
            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(_produto1, 2);
            carrinho.AdicionarItem(_produto2, 3);

            // Action
            ItemCarrinho[] itens = carrinho.ItensCarrinho.ToArray();

            // Assert

            // Verifica a quatidade de produtos adicionado no carrinho
            Assert.AreEqual(itens.Length, 2);

            Assert.AreEqual(itens[0].Produto, _produto1);
            Assert.AreEqual(itens[1].Produto, _produto2);

        }

        [TestMethod]
        public void AdcionarProdutoExistenteAoCarrinho()
        {
            // Arrange - Criação dos Produtos
            Produto _produto1 = new Produto
            {
                Categoria = "Categoria 1",
                Descricao = "Produto 1",
                IdProduto = 1,
                Nome = "Produto Teste 1",
                Preco = 1.0m
            };

            Produto _produto2 = new Produto
            {
                Categoria = "Categoria 1",
                Descricao = "Produto 1",
                IdProduto = 2,
                Nome = "Produto Teste 1",
                Preco = 2.0m
            };

            Produto _produto3 = new Produto
            {
                Categoria = "Categoria 3",
                Descricao = "Produto 3",
                IdProduto = 3,
                Nome = "Produto Teste 3",
                Preco = 3.0m
            };

            // Arrange
            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(_produto1, 1);

            carrinho.AdicionarItem(_produto2, 1);

            carrinho.AdicionarItem(_produto1, 10);

            // Action
            ItemCarrinho[] itens = carrinho
                                        .ItensCarrinho
                                        .OrderBy(c => c.Produto.IdProduto)
                                        .ToArray();

            //Assert
            Assert.AreEqual(itens.Length, 2);

            Assert.AreEqual(itens[0].Quantidade, 11);


        }

        [TestMethod]
        public void RemoverProdutoDoCarrinho()
        {
            // Arrange - Criação dos Produtos
            Produto _produto1 = new Produto
            {
                Categoria = "Categoria 1",
                Descricao = "Produto 1",
                IdProduto = 1,
                Nome = "Produto Teste 1",
                Preco = 1.0m
            };

            Produto _produto2 = new Produto
            {
                Categoria = "Categoria 1",
                Descricao = "Produto 1",
                IdProduto = 2,
                Nome = "Produto Teste 1",
                Preco = 2.0m
            };

            Produto _produto3 = new Produto
            {
                Categoria = "Categoria 3",
                Descricao = "Produto 3",
                IdProduto = 3,
                Nome = "Produto Teste 3",
                Preco = 3.0m
            };

            // Arrange
            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(_produto1, 1);

            carrinho.AdicionarItem(_produto2, 1);

            carrinho.AdicionarItem(_produto1, 10);

            carrinho.RemoverItem(_produto2);

            Assert.AreEqual(carrinho.ItensCarrinho.Where(p => p.Produto.IdProduto == _produto2.IdProduto).Count(), 0);

            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 1);
        }

        [TestMethod]
        public void CalcularValorTotal()
        {
            // Arrange - Criação dos Produtos
            Produto _produto1 = new Produto
            {
                Categoria = "Categoria 1",
                Descricao = "Produto 1",
                IdProduto = 1,
                Nome = "Produto Teste 1",
                Preco = 1.0m
            };

            Produto _produto2 = new Produto
            {
                Categoria = "Categoria 1",
                Descricao = "Produto 1",
                IdProduto = 2,
                Nome = "Produto Teste 1",
                Preco = 2.0m
            };

            // Arrange
            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(_produto1, 1);

            carrinho.AdicionarItem(_produto2, 1);

            carrinho.AdicionarItem(_produto1, 4);

            // Action
            decimal resultado = carrinho.ObterValorTotal();

            Assert.AreEqual(resultado, 7);

        }

        [TestMethod]
        public void LimparCarrinho()
        {

            // Arrange - Criação dos Produtos
            Produto _produto1 = new Produto
            {
                Categoria = "Categoria 1",
                Descricao = "Produto 1",
                IdProduto = 1,
                Nome = "Produto Teste 1",
                Preco = 1.0m
            };

            Produto _produto2 = new Produto
            {
                Categoria = "Categoria 1",
                Descricao = "Produto 1",
                IdProduto = 2,
                Nome = "Produto Teste 1",
                Preco = 2.0m
            };

            // Arrange
            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(_produto1, 1);

            carrinho.AdicionarItem(_produto2, 1);

            carrinho.AdicionarItem(_produto1, 4);

            carrinho.LimparCarrinho();


            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 0);
        }
    }
}
