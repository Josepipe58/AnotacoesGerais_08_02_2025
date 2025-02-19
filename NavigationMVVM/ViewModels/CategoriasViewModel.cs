using AcessarDadosDoBanco.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavigationMVVM.ViewModels
{
    public class CategoriasViewModel : ViewModelBase
    {
        public int Codigo {  get; }
        public string Name { get; }

        public CategoriasViewModel(Categoria categoria)
        {
            Codigo = categoria.Id;
            Name = categoria.NomeDaCategoria;
        }
    }
}
