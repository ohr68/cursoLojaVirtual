using System;
using System.ComponentModel.DataAnnotations;

namespace Quiron.LojaVirtual.Dominio.Entidade
{
    public class Administrador
    {
        [Key]
        public int AdminId { get; set; }
        [Required(ErrorMessage = "Digite o Login")]
        [Display(Name = "Login:")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite a senha")]
        [Display(Name = "Senha:")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public DateTime UltimoAcesso { get; set; }
    }
}
