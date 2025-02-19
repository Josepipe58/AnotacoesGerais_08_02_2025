using AcessarDadosDoBanco.Entities;
using NavigationMVVM.Commands;
using NavigationMVVM.Services;
using NavigationMVVM.Stores;
using AcessarDadosDoBanco;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using System;
using AcessarDadosDoBanco.Context;
using System.Linq;

namespace NavigationMVVM.ViewModels
{
    public class ListaDeCategoriasViewModel : ViewModelBase
    {
        public AppDbContexto _context { get; set; }
        private readonly PeopleStore _peopleStore;

        public ObservableCollection<Categoria> _listaDeCategorias;

        public IEnumerable<Categoria> ListaDeCategorias => _listaDeCategorias;

        public ICommand AddPersonCommand { get; }

        public ListaDeCategoriasViewModel(PeopleStore peopleStore, INavigationService addPersonNavigationService)
        {
            _peopleStore = peopleStore;

            AddPersonCommand = new NavigateCommand(addPersonNavigationService);
            _listaDeCategorias = new ObservableCollection<Categoria>();
            _listaDeCategorias = new ObservableCollection<Categoria>(_context.TCategoria.ToList());
            //_listaDeCategorias.Add(new CategoriasViewModel(2, "Maria Clara"));
            //_listaDeCategorias.Add(new CategoriasViewModel(3, "Joaquim dos Santos"));

            //_peopleStore.AdicionarCategoria += OnPersonAdded;
        }

        //private void OnPersonAdded(string categoria)
        //{
        //    _listaDeCategorias.Add(new Categoria(categoria));
        //}
    }
}
