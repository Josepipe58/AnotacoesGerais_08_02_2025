using AppAnotacoesGerais.Telas.AnotacoesGerais;
using AppAnotacoesGerais.Telas.GerenciarCategorias;
using AppAnotacoesGerais.Telas.GerenciarConsumoDeGas;
using AppAnotacoesGerais.Telas.GerenciarNomeDaDescricao;
using AppAnotacoesGerais.Telas.GerenciarSubCategorias;
using AppAnotacoesGerais.Views.Menus;
using System.Windows.Input;

namespace AppAnotacoesGerais.Comandos
{
    public partial class ComandosDaTelaPrincipal//Comandos Gerais
    {
        private object _selecionarControleDeUsuario;
        public object SelecionarControleDeUsuario
        {
            get => _selecionarControleDeUsuario;
            set
            {
                _selecionarControleDeUsuario = value;
                OnPropertyChanged(nameof(SelecionarControleDeUsuario));
            }
        }

        #region | Comandos de Voltar Para o Submenu de Anotacoes Gerais |

        private void VoltarParaSubmenuDeAnotacoesGerais()
        {
            SelecionarControleDeUsuario = new SubmenuDeAnotacoesGerais();
        }

        private ICommand _comandoVoltarParaSubmenuDeAnotacoesGerais;
        public ICommand ComandoVoltarParaSubmenuDeAnotacoesGerais
        {
            get
            {
                if (_comandoVoltarParaSubmenuDeAnotacoesGerais == null)
                {
                    _comandoVoltarParaSubmenuDeAnotacoesGerais =
                        new RelayCommand(param => VoltarParaSubmenuDeAnotacoesGerais());
                }
                return _comandoVoltarParaSubmenuDeAnotacoesGerais;
            }
        }

        #endregion

        #region | Comandos de Categorias, SubCategorias e Nome da Descrição |

        public void CategoriaComando()
        {
            SelecionarControleDeUsuario = new Categoria_UI();
        }

        private ICommand _comandoDaCategoria;
        public ICommand ComandoDaCategoria
        {
            get
            {
                if (_comandoDaCategoria == null)
                {
                    _comandoDaCategoria = new RelayCommand(param => CategoriaComando());
                }
                return _comandoDaCategoria;
            }
        }

        public void SubCategoriaComando()
        {
            SelecionarControleDeUsuario = new SubCategoria_UI();
        }

        private ICommand _comandoDaSubCategoria;
        public ICommand ComandoDaSubCategoria
        {
            get
            {
                if (_comandoDaSubCategoria == null)
                {
                    _comandoDaSubCategoria = new RelayCommand(param => SubCategoriaComando());
                }
                return _comandoDaSubCategoria;
            }
        }

        public void NomeDaDescricaoComando()
        {
            SelecionarControleDeUsuario = new NomeDaDescricao_UI();
        }

        private ICommand _comandoNomeDaDescricao;
        public ICommand ComandoNomeDaDescricao
        {
            get
            {
                if (_comandoNomeDaDescricao == null)
                {
                    _comandoNomeDaDescricao = new RelayCommand(param => NomeDaDescricaoComando());
                }
                return _comandoNomeDaDescricao;
            }
        }

        #endregion

        #region | Comandos de Anotaçoes Gerais|

        public void AbrirJanelaDeCadastrar()
        {
            SelecionarControleDeUsuario = new CadastrarAnotacaoGeral_UI();
        }

        private ICommand _comandoAbrirJanelaDeCadastrar;
        public ICommand ComandoAbrirJanelaDeCadastrar
        {
            get
            {
                if (_comandoAbrirJanelaDeCadastrar == null)
                {
                    _comandoAbrirJanelaDeCadastrar = new RelayCommand(param => AbrirJanelaDeCadastrar());
                }
                return _comandoAbrirJanelaDeCadastrar;
            }
        }

        #endregion

        #region | Comandos de Consuumo de Gás |

        public void ConsumoDeGasComando()
        {
            SelecionarControleDeUsuario = new ConsumoDeGas_UI();
        }

        private ICommand _comandoDeConsumoDeGas;
        public ICommand ComandoDeConsumoDeGas
        {
            get
            {
                if (_comandoDeConsumoDeGas == null)
                {
                    _comandoDeConsumoDeGas = new RelayCommand(param => ConsumoDeGasComando());
                }
                return _comandoDeConsumoDeGas;
            }
        }

        #endregion
    }
}
