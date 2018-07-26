using System;

namespace Quiron.LojaVirtual.Dominio.Entidade
{
    public class Produto
    {
        public int ProdutoId{ get; set; }
        public string Nome { get; set; }      
        public string Descricao  { get; set; }
        public Decimal Preco  { get; set; }
        public string  Categoria { get; set; }
    }
}
