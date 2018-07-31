using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Dominio.Entidade
{
    public class Produto
    {
        //Ao renderizar o Produto, o Id não será mostrado
        [HiddenInput(DisplayValue = false)]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Digite o Nome do produto")]
        public string Nome { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Digite a Descrição do Produto")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Digite o valor")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Valor inválido")]
        public Decimal Preco { get; set; }

        [Required(ErrorMessage = "Digite a categoria")]
        public string Categoria { get; set; }
    }
}
