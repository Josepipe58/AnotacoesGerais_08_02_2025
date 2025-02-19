using AcessarDadosDoBanco.Entities;
using NavigationMVVM.Services;
using NavigationMVVM.Stores;
using NavigationMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavigationMVVM.Commands
{
    public class AddCategoriaCommand : CommandBase
    {
        private readonly AddCategoriaViewModel _addCategoriaViewModel;
        private readonly PeopleStore _peopleStore;
        private readonly INavigationService _navigationService;

        public AddCategoriaCommand(AddCategoriaViewModel addCategoriaViewModel, PeopleStore peopleStore, INavigationService navigationService)
        {
            _addCategoriaViewModel = addCategoriaViewModel;
            _peopleStore = peopleStore;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            string nomeDacategoria = _addCategoriaViewModel.Name;
            _peopleStore.CategoriaAdicionar(nomeDacategoria);

            _navigationService.Navigate();
        }
    }
}
