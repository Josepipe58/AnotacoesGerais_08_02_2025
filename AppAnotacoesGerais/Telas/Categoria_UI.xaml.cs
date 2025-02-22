using AcessarDadosDoBanco.Entities;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppAnotacoesGerais.Telas
{
    public partial class Categoria_UI : UserControl
    {
        public string _nomeDoMetodo = string.Empty;
        public Categoria_UI()
        {
            InitializeComponent();
            CarregarDataGrid();
        }

        private void CarregarDataGrid()
        {
            try
            {
                Categoria_AD categoria_AD = new();
                DtgDados.ItemsSource = categoria_AD.SelecionarTodos();                
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "CarregarDataGrid";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }
            TxtCategoria.Focus();
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtId.Text == "" && TxtCategoria.Text != "")
            {
                try
                {
                    Categoria_AD categoria_AD = new();
                    Categoria categoria = new()
                    {
                        NomeDaCategoria = TxtCategoria.Text
                    };
                    categoria_AD.Cadastrar(categoria);

                    GerenciarMensagens.SucessoAoCadastrar(categoria.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception ex)
                {
                    _nomeDoMetodo = "BtnCadastrar_Click";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    return;
                }
            }
            else if (TxtId.Text != "" && TxtCategoria.Text != "")
            {
                GerenciarMensagens.ErroAoCadastrar();
                TxtCategoria.Focus();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                TxtCategoria.Focus();
                return;
            }
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtId.Text != "" && TxtCategoria.Text != "")
            {
                try
                {
                    Categoria_AD categoria_AD = new();
                    Categoria categoria = new()
                    {
                        Id = Convert.ToInt32(TxtId.Text),
                        NomeDaCategoria = TxtCategoria.Text
                    };
                    categoria_AD.Alterar(categoria);

                    GerenciarMensagens.SucessoAoAlterar(categoria.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception ex)
                {
                    _nomeDoMetodo = "BtnAlterar_Click";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    return;
                }
            }
            else if (TxtId.Text == "" && TxtCategoria.Text != "")
            {
                GerenciarMensagens.ErroAoAlterarOuExcluir();
                TxtCategoria.Focus();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                TxtCategoria.Focus();
                return;
            }
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (TxtId.Text != "" && TxtCategoria.Text != "")
            {
                MessageBoxResult resultado = GerenciarMensagens.ConfirmarExcluir(Convert.ToInt32(TxtId.Text));
                if (resultado == MessageBoxResult.Yes)
                {
                    try
                    {
                        Categoria_AD categoria_AD = new();
                        Categoria categoria = new()
                        {
                            Id = Convert.ToInt32(TxtId.Text)
                        };
                        categoria_AD.Excluir(categoria.Id);

                        GerenciarMensagens.SucessoAoExcluir(categoria.Id);
                        LimparEAtualizarDados();
                    }
                    catch (Exception ex)
                    {
                        _nomeDoMetodo = "BtnExcluir_Click";
                        GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                        return;
                    }
                }
                else
                {
                    LimparEAtualizarDados();
                    return;
                }
            }
            else if (TxtId.Text == "" && TxtCategoria.Text != "")
            {
                GerenciarMensagens.ErroAoAlterarOuExcluir();
                TxtCategoria.Focus();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                TxtCategoria.Focus();
                return;
            }
        }

        private void DtgDados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DtgDados.SelectedIndex >= 0)
            {
                if (DtgDados.SelectedItems.Count >= 0)
                {
                    if (DtgDados.SelectedItems[0].GetType() == typeof(Categoria))
                    {
                        Categoria categoria = (Categoria)DtgDados.SelectedItems[0];

                        TxtId.Text = categoria.Id.ToString();
                        TxtCategoria.Text = categoria.NomeDaCategoria;
                        TxtCategoria.Focus();
                    }
                }
            }
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            LimparEAtualizarDados();
        }

        private void LimparEAtualizarDados()
        {
            TxtId.Text = "";
            TxtCategoria.Text = "";
            CarregarDataGrid();
        }
    }
}
