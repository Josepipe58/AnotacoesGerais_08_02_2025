﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcessarDadosDoBanco.Modelos
{
    public class NomeDaDescricao
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nome { get; set; }

        [ForeignKey(nameof(CategoriaId))]
        public int CategoriaId { get; set; }

        [ForeignKey(nameof(SubCategoriaId))]
        public int SubCategoriaId { get; set; }

        [NotMapped]
        public string NomeDaCategoria { get; set; }

        [NotMapped]
        public string NomeDaSubCategoria { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual SubCategoria SubCategoria { get; set; }
    }
}
