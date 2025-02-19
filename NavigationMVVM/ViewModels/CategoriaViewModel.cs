using NavigationMVVM.Commands;
using NavigationMVVM.Models;
using NavigationMVVM.Services;
using NavigationMVVM.Stores;
using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
    public class CategoriaViewModel : ViewModelBase
    {
        private readonly CategoriaStore _categoriaStore;

        public string NomeDaCategoria => _categoriaStore.CategoriaAtual?.NomeDaCategoria;
        //public int Id => _categoriaStore.CategoriaAtual?.Id;

        public ICommand NavigateHomeCommand { get; }

        public CategoriaViewModel(CategoriaStore accountStore, INavigationService homeNavigationService)
        {
            _categoriaStore = accountStore;

            NavigateHomeCommand = new NavigateCommand(homeNavigationService);

            _categoriaStore.CategoriaAtualTrocada += OnCurrentAccountChanged;
        }

        private void OnCurrentAccountChanged()
        {
            //OnPropertyChanged(nameof(Id));
            OnPropertyChanged(nameof(NomeDaCategoria));
        }

        public override void Dispose()
        {
            _categoriaStore.CategoriaAtualTrocada -= OnCurrentAccountChanged;

            base.Dispose();
        }
    }
}
