using AppAnotacoesGerais.Telas;
using AppAnotacoesGerais.Telas.AnotacoesGerais;
using AppAnotacoesGerais.Telas.InformacoesPessoais;
using AppAnotacoesGerais.Views.Menus;
using System.Windows;
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

        #region | Comandos de Informações Pessoais |

        private string _senha = null;
        public string Senha 
        { 
            get => _senha;
            set 
            {
                _senha = value;
                OnPropertyChanged(nameof(Senha));
            } 
        }

        public void FazerLoginInformacaoPessoal()
        {
            if (Senha == "bj250281")
            {
                SelecionarControleDeUsuario = new InformacaoPessoal_UI();
                Senha = null;
            }
            else if (Senha == null)
            {
                MessageBox.Show($"Digite sua senha para logar.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                Senha = null;
            }
            else if (Senha != "bj250281")
            {
                MessageBox.Show($"Senha inválida, tente novamente.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                Senha = null;
            }
        }

        private ICommand _comandoFazerLoginInformacaoPessoal;
        public ICommand ComandoFazerLoginInformacaoPessoal
        {
            get
            {
                if (_comandoFazerLoginInformacaoPessoal == null)
                {
                    _comandoFazerLoginInformacaoPessoal = new RelayCommand(param => FazerLoginInformacaoPessoal());
                }
                return _comandoFazerLoginInformacaoPessoal;
            }
        }

        public void AbrirJanelaDeCadastrarInformacaoPessoal()
        {
            SelecionarControleDeUsuario = new CadastrarInformacaoPessoal_UI();
        }

        private ICommand _comandoAbrirJanelaDeCadastrarInformacaoPessoal;
        public ICommand ComandoAbrirJanelaDeCadastrarInformacaoPessoal
        {
            get
            {
                if (_comandoAbrirJanelaDeCadastrarInformacaoPessoal == null)
                {
                    _comandoAbrirJanelaDeCadastrarInformacaoPessoal = 
                        new RelayCommand(param => AbrirJanelaDeCadastrarInformacaoPessoal());
                }
                return _comandoAbrirJanelaDeCadastrarInformacaoPessoal;
            }
        }

        public void VoltarParaInformacaoPessoal()
        {
            SelecionarControleDeUsuario = new InformacaoPessoal_UI();
        }

        private ICommand _comandoVoltarParaInformacaoPessoal;
        public ICommand ComandoVoltarParaInformacaoPessoal
        {
            get
            {
                if (_comandoVoltarParaInformacaoPessoal == null)
                {
                    _comandoVoltarParaInformacaoPessoal = new RelayCommand(param => VoltarParaInformacaoPessoal());
                }
                return _comandoVoltarParaInformacaoPessoal;
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
