using NavigationMVVM.Commands;
using NavigationMVVM.Models;
using NavigationMVVM.Services;
using NavigationMVVM.Stores;
using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        public string NomeDaCategoria
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(NomeDaCategoria));
            }
        }

        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel(CategoriaStore accountStore, INavigationService loginNavigationService)
        {
            LoginCommand = new LoginCommand(this, accountStore, loginNavigationService);
        }
    }
}
