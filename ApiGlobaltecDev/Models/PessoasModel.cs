using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace ApiGlobaltecDev.Models
{
    public class PessoasModel
    {

        [Key]
        public int Codigo { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string Nome { get; set; } = "";
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Usuario { get; set; } = "";
        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string Senha { get; set; } = "";
        [Required]
        [Column(TypeName = "nvarchar(14)")]
        public string? cpfCnpj { get; set; }
        public string? uf { get; set; }
        public DateTime DataNascimento { get; set; }

    }
}
