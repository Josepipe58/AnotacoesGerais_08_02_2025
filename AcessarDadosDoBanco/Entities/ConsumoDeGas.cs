using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcessarDadosDoBanco.Entities
{
    public class ConsumoDeGas
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataDaTroca { get; set; }

        public int DiasDeConsumo { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataDaCompra { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Preco { get; set; }

        [Required, StringLength(30)]
        public string Fornecedor { get; set; }
    }
}
