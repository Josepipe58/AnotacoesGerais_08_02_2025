using AcessarDadosDoBanco.Entities;
using NavigationMVVM.Models;
using NavigationMVVM.Services;
using NavigationMVVM.Stores;
using NavigationMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace NavigationMVVM.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _viewModel;
        private readonly CategoriaStore _categoriaStore;
        private readonly INavigationService _navigationService;

        public LoginCommand(LoginViewModel viewModel, CategoriaStore categoriaStore, INavigationService navigationService)
        {
            _viewModel = viewModel;
            _categoriaStore = categoriaStore;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            Categoria account = new Categoria()
            {
                Id = _viewModel.Id,
                NomeDaCategoria = _viewModel.NomeDaCategoria
            };

            _categoriaStore.CategoriaAtual = account;

            _navigationService.Navigate();
        }
    }
}
