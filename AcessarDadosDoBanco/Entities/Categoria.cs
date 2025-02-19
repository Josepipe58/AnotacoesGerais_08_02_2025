using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AcessarDadosDoBanco.Entities
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string NomeDaCategoria { get; set; }

        public Categoria() { }
        public Categoria(Categoria categoria)
        {
            Id = categoria.Id;
            NomeDaCategoria = categoria.NomeDaCategoria;
        }
    }
    public class ListaDeCategorias : ObservableCollection<Categoria> { }
}
