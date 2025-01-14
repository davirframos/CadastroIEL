using System.ComponentModel.DataAnnotations;

namespace CadastroIEL.Infrastructure.Models
{
    public class Cadastro
    {
        [MaxLength(100, ErrorMessage = "Nome Deve Conter Ate 100 Caracteres")]
        [Required(ErrorMessage = "Digite Seu Nome")]
        public string Nome { get; set; } = string.Empty;

        [Key]
        [Required(ErrorMessage = "Digite Seu CPF")]
        public string CPF { get; set; }

        [MaxLength(200, ErrorMessage = "Endereco Deve Conter Ate 200 Caracteres")]
        [Required(ErrorMessage = "Digite Seu Endereco")]
        public string Endereco { get; set; } = string.Empty;

        [Required]
        public int   DataConclusao { get; set; }
    }
}
