using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

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
        public ConsumoDeGas() { }
        public ConsumoDeGas(ConsumoDeGas consumoDeGas)
        {
            Id = consumoDeGas.Id;
            DataDaTroca = consumoDeGas.DataDaTroca;
            DiasDeConsumo = consumoDeGas.DiasDeConsumo;
            DataDaCompra = consumoDeGas.DataDaCompra;
            Preco = consumoDeGas.Preco;
            Fornecedor = consumoDeGas.Fornecedor;
        }
    }
    public class ListaDeConsumoDeGas : ObservableCollection<ConsumoDeGas> { }
}
