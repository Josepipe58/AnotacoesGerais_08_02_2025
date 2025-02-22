using System.ComponentModel.DataAnnotations;

namespace AcessarDadosDoBanco.Entities
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string NomeDaCategoria { get; set; }
    }
}
