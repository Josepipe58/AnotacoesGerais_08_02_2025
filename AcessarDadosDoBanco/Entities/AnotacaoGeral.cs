using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcessarDadosDoBanco.Entities
{
    public class AnotacaoGeral
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string NomeDaCategoria { get; set; }

        [Required, StringLength(100)]
        public string NomeDaSubCategoria { get; set; }

        [Required, StringLength(100)]
        public string NomeDaDescricao { get; set; }

        [Required, StringLength(maximumLength: 100000)]
        public string Descricao { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data { get; set; }

        public AnotacaoGeral() { }

        public AnotacaoGeral(AnotacaoGeral anotacaoGeral)
        {
            Id = anotacaoGeral.Id;
            NomeDaCategoria = anotacaoGeral.NomeDaCategoria;
            NomeDaSubCategoria = anotacaoGeral.NomeDaSubCategoria;
            NomeDaDescricao = anotacaoGeral.NomeDaDescricao;
            Descricao = anotacaoGeral.Descricao;
            Data = anotacaoGeral.Data;
        }
    }
    public class ListaDeAnotacoesGerais : ObservableCollection<AnotacaoGeral> { }
}
