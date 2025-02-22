﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcessarDadosDoBanco.Entities
{
    public class SubCategoria
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string NomeDaSubCategoria { get; set; }

        [ForeignKey(nameof(CategoriaId))]
        public int CategoriaId { get; set; }

        //Essas propriedades são usadas como objeto de transferência ou variáveis.  
        [NotMapped]
        public string NomeDaCategoria { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
