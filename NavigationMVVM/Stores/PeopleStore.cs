using AcessarDadosDoBanco.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavigationMVVM.Stores
{
    public class PeopleStore
    {
        public event Action<string> AdicionarCategoria;

        public void CategoriaAdicionar(string nomeDaCategoria)
        {
            AdicionarCategoria?.Invoke(nomeDaCategoria);
        }
    }
}
