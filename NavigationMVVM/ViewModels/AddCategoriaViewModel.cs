using NavigationMVVM.Commands;
using NavigationMVVM.Services;
using NavigationMVVM.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
    public class AddCategoriaViewModel : ViewModelBase
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public AddCategoriaViewModel(PeopleStore peopleStore, INavigationService closeNavigationService)
        {
            SubmitCommand = new AddCategoriaCommand(this, peopleStore, closeNavigationService);
            CancelCommand = new NavigateCommand(closeNavigationService);
        }
    }
}
