using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Carrinho
    {
        private readonly List<ItemCarrinho> _ItemCarrinho = new List<ItemCarrinho>();

        // Adicionar
        public void AdicionarItem(Produto produto, int quantidade)
        {
            ItemCarrinho item = _ItemCarrinho.FirstOrDefault(p => p.Produto.IdProduto == produto.IdProduto);

            if (item == null)
            {
                _ItemCarrinho.Add(new ItemCarrinho
                {
                    Produto = produto,
                    Quantidade = quantidade
                });
            }
            else
                item.Quantidade += quantidade;

        }

        // Remover item
        public void RemoverItem(Produto produto)
        {
            _ItemCarrinho.RemoveAll(l => l.Produto.IdProduto == produto.IdProduto);
        }

        // Obter Valor Total
        public decimal ObterValorTotal()
        {
            return _ItemCarrinho.Sum(s => s.Produto.Preco * s.Quantidade);
        }

        // Limpar lista de compras (carrinho)
        public void LimparCarrinho()
        {
            _ItemCarrinho.Clear();
        }

        // Itens do Carrinho
        public IEnumerable<ItemCarrinho> ItensCarrinho
        {
            get { return _ItemCarrinho; }
        }
    }

    public class ItemCarrinho
    {
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
    }
}
