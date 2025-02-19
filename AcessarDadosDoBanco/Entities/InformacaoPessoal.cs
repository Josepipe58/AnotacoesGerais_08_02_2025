using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AcessarDadosDoBanco.Entities
{
    public class InformacaoPessoal
    {

        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Titulo { get; set; }

        [Required, StringLength(maximumLength: 100000)]
        public string Descricao { get; set; }

        public InformacaoPessoal() { }

        public InformacaoPessoal(InformacaoPessoal informacaoPessoal)
        {
            Id = informacaoPessoal.Id;
            Titulo = informacaoPessoal.Titulo;
            Descricao = informacaoPessoal.Descricao;
        }
    }
    public class ListaDeInformacaoPessoal : ObservableCollection<InformacaoPessoal> { }
}
