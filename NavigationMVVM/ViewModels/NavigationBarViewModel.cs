using NavigationMVVM.Commands;
using NavigationMVVM.Services;
using NavigationMVVM.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        private readonly CategoriaStore _categoriaStore;

        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateAccountCommand { get; }
        public ICommand NavigateLoginCommand { get; }
        public ICommand NavigatePeopleListingCommand { get; }
        public ICommand LogoutCommand { get; }

        public bool IsLoggedIn => _categoriaStore.IsLoggedIn;

        public NavigationBarViewModel(CategoriaStore accountStore,
            INavigationService homeNavigationService,
            INavigationService accountNavigationService,
            INavigationService loginNavigationService,
            INavigationService peopleListingNavigationService)
        {
            _categoriaStore = accountStore;
            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
            NavigateAccountCommand = new NavigateCommand(accountNavigationService);
            NavigateLoginCommand = new NavigateCommand(loginNavigationService);
            NavigatePeopleListingCommand = new NavigateCommand(peopleListingNavigationService);
            LogoutCommand = new LogoutCommand(_categoriaStore);

            _categoriaStore.CategoriaAtualTrocada += OnCurrentAccountChanged;
        }

        private void OnCurrentAccountChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }

        public override void Dispose()
        {
            _categoriaStore.CategoriaAtualTrocada -= OnCurrentAccountChanged;

            base.Dispose();
        }
    }
}
