using AppAnotacoesGerais.Telas.AnotacoesGerais;
using AppAnotacoesGerais.Telas.InformacoesPessoais;
using AppAnotacoesGerais.Views.Menus;
using GerenciarDados.Mensagens;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace AppAnotacoesGerais.Comandos
{
    public class ListaDeItemsDoMenu
    {
        public string GerenciarDados { get; set; } = string.Empty;
    }
    public partial class ComandosDaTelaPrincipal : RelayCommand
    {
        private static string _nomeDoMetodo = string.Empty;      

        private CollectionViewSource MenuItemsDeConsultarDados { get; set; }

        public ICollectionView SourceConsultarDados => MenuItemsDeConsultarDados.View;

        private CollectionViewSource MenuItemsDeGerenciarDados { get; set; }
        public ICollectionView SourceGerenciarDados => MenuItemsDeGerenciarDados.View;

        public ComandosDaTelaPrincipal()
        {
            ObservableCollection<ListaDeItemsDoMenu> itemsGerenciarDados =
            [
                new ListaDeItemsDoMenu{ GerenciarDados = "Página Inicial" },
                new ListaDeItemsDoMenu{ GerenciarDados = "Anotações Gerais" },
                new ListaDeItemsDoMenu{ GerenciarDados = "Informações Pessoais" },
                new ListaDeItemsDoMenu{ GerenciarDados = "Submenu de Anotações Gerais" },
            ];
            MenuItemsDeGerenciarDados = new CollectionViewSource { Source = itemsGerenciarDados };

            // Configura a página de inicialização.
            SelecionarControleDeUsuario = new PaginaInicial();            
        }

        private void ExibirPaginaInicial()
        {
            SelecionarControleDeUsuario = new PaginaInicial();
        }

        private ICommand _comandoVoltarPaginaInicial;
        public ICommand ComandoVoltarPaginaInicial
        {
            get
            {
                if (_comandoVoltarPaginaInicial == null)
                {
                    _comandoVoltarPaginaInicial ??= new RelayCommand(param => ExibirPaginaInicial());
                }
                return _comandoVoltarPaginaInicial;
            }
        }

        private ICommand _comandoDoMenuGerenciarDados;
        public ICommand ComandoDoMenuGerenciarDados
        {
            get
            {
                _comandoDoMenuGerenciarDados ??= new RelayCommand(param => MenuDoMenuInicialDeGerenciarDados(param));
                return _comandoDoMenuGerenciarDados;
            }
        }

        public void MenuDoMenuInicialDeGerenciarDados(object parameter)
        {
            try
            {
                SelecionarControleDeUsuario = parameter switch
                {
                    "Página Inicial" => new PaginaInicial(),
                    "Anotações Gerais" => new AnotacaoGeral_UI(),
                    "Informações Pessoais" => new Login_UI(),
                    "Submenu de Anotações Gerais" => new SubmenuDeAnotacoesGerais(),
                    _ => new PaginaInicial()
                };
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "MenuDoMenuInicial";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }
        }

        public static void AbrirBancoDeDados()
        {
            Process.Start("C:\\Program Files (x86)\\Microsoft SQL Server Management Studio 19\\Common7\\IDE\\Ssms.exe");
        }

        private ICommand _comandoAbrirBancoDeDados;
        public ICommand ComandoAbrirBancoDeDados
        {
            get
            {
                _comandoAbrirBancoDeDados ??= new RelayCommand(param => AbrirBancoDeDados());
                return _comandoAbrirBancoDeDados;
            }
        }

        public static void SairDoAplicativo()
        {
            Application.Current.Shutdown();
        }

        private ICommand _comandoSairDoAplicativo;
        public ICommand ComandoSairDoAplicativo
        {
            get
            {
                _comandoSairDoAplicativo ??= new RelayCommand(param => SairDoAplicativo());
                return _comandoSairDoAplicativo;
            }
        }
    }
}
