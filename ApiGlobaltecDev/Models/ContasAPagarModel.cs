using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace ApiGlobaltecDev.Models
{
    public class ContasAPagarModel
    {
        [Key]
        public int Numero { get; set; }

        public long CodigoFornecedor { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataProrrogacao { get; set;}
        public decimal Valor { get; set; }
        public decimal Acressimo { get; set; }
        public decimal Desconto { get; set; }

    }
}
