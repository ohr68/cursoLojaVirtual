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
    }
}
