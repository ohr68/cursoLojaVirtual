using Quiron.LojaVirtual.Dominio.Entidade;
using System.Collections.Generic;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class ProdutosRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Produto> Produtos
        {
            get
            {
                return _context.Produtos;
            }
        }

        //Salvar Produto - Alterar Produto
        public void Salvar(Produto produto)
        {
            //Se o Produto não tem Id, deverá ser salvo
            //Caso contrário, será alterado
            if (produto.ProdutoId == 0)
            {
                //Salvar
                _context.Produtos.Add(produto);
            }
            else
            {
                //Alterar
                Produto prod = _context.Produtos.Find(produto.ProdutoId);

                if (prod != null)
                {
                    prod.Nome = produto.Nome;
                    prod.Descricao = produto.Descricao;
                    prod.Preco = produto.Preco;
                    prod.Categoria = produto.Categoria;
                    prod.Imagem = produto.Imagem;
                    prod.ImagemMimeType = produto.ImagemMimeType;
                }
            }

            _context.SaveChanges();
        }

        public Produto Excluir(int produtoId)
        {
            Produto prod = _context.Produtos.Find(produtoId);

            if (prod != null)
            {
                _context.Produtos.Remove(prod);
                _context.SaveChanges();
            }

            return prod;
        }
    }
}
