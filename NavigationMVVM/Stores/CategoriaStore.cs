using AcessarDadosDoBanco.Entities;
using NavigationMVVM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavigationMVVM.Stores
{
    public class CategoriaStore
    {
        private Categoria _categoriaAtual;
        public Categoria CategoriaAtual
        {
            get => _categoriaAtual;
            set
            {
                _categoriaAtual = value;
                CategoriaAtualTrocada?.Invoke();
            }
        }

        public bool IsLoggedIn => CategoriaAtual != null;

        public event Action CategoriaAtualTrocada;

        public void Logout()
        {
            CategoriaAtual = null;
        }
    }
}
