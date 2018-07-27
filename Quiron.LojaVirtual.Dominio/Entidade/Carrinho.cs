using System.Collections.Generic;
using System.Linq;

namespace Quiron.LojaVirtual.Dominio.Entidade
{
    public class Carrinho
    {

        private readonly List<ItemCarrinho> _itemCarrinho = new List<ItemCarrinho>();
        //Adicionar
        public void AdicionarItem(Produto produto, int quantidade)
        {
            //Verifica se o produto ainda não está no carrinho
            ItemCarrinho item = _itemCarrinho.FirstOrDefault(p => p.Produto.ProdutoId == produto.ProdutoId);

            if (item == null)
            {
                _itemCarrinho.Add(
                    new ItemCarrinho
                    {
                        Produto = produto,
                        Quantidade = quantidade
                    });
            }
            else
            {
                item.Quantidade += quantidade;
            }
        }

        //Remover 
        public void RemoverItem(Produto produto)
        {
            //Remove a quantidade total de determinado item
            _itemCarrinho.RemoveAll(l => l.Produto.ProdutoId == produto.ProdutoId);
        }

        //Obter Valor Total
        public decimal ObterValorTotal()
        {
            return _itemCarrinho.Sum(e => e.Produto.Preco * e.Quantidade);
        }

        //Limpar Carrinho
        public void LimparCarrinho()
        {
            _itemCarrinho.Clear();
        }

        //Itens Carrinho
        public IEnumerable<ItemCarrinho> ItensCarrinho
        {
            get {
                return _itemCarrinho;
            }
        }
    }

    public class ItemCarrinho
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
