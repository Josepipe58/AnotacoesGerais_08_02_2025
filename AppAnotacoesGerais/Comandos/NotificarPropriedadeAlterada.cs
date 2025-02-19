using System.ComponentModel;

namespace AppAnotacoesGerais.Comandos
{
    public class NotificarPropriedadeAlterada : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void Dispose() { }
    }
}