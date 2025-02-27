using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppTestes
{
    public class ViewModel : RelayCommand, INotifyPropertyChanged
    {
        //Implementacao do INotifyPropertyChanged 
        public event PropertyChangedEventHandler PropertyChanged;

        private UserControl controle;
        public UserControl Controle
        {
            get { return controle; }
            set
            {
                controle = value;
                OnPropertyChanged("Controle");
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<UserControl> ListaControles { get; set; } //Lista dos UserControls

        //public RelayCommand<string> MudarControle { get; set; }

        public ViewModel()
        {
            //Controles = new List<UserControlModel>();
            //Preencher lista aqui;
            //MudarControle = new Command<string>(Alterar);
        }

        protected void Alterar(string UserControl)
        {
            //Simplifiquei, mas aqui vai uns testes para saber se o controle existe mesmo na lista
            //Controle = Controles.FirstOrDefault(c => c.Nome == UserControl);
        }
    }

    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
