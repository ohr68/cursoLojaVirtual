using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Dominio.Entidade
{
    public class Produto
    {
        //Ao renderizar o Id ele não será mostrado
        [HiddenInput(DisplayValue = false)]
        public int ProdutoId{ get; set; }
        public string Nome { get; set; }          
        [DataType(DataType.MultilineText)]
        public string Descricao  { get; set; }
        public Decimal Preco  { get; set; }
        public string  Categoria { get; set; }
    }
}
