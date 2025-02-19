using AppAnotacoesGerais.Views.Menus;
using System.Windows;

namespace AppAnotacoesGerais
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MenuIniciar();
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
