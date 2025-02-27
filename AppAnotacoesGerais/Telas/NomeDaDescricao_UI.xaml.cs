using AcessarDadosDoBanco.Modelos;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppAnotacoesGerais.Telas
{
    public partial class NomeDaDescricao_UI : UserControl
    {
        public string _nomeDoMetodo = string.Empty;
        public NomeDaDescricao_UI()
        {
            InitializeComponent();
            ComboBoxDeCategorias();
        }

        private void ComboBoxDeCategorias()
        {
            try
            {
                // Combobox Categorias.
                Categoria_AD categoria_AD = new();
                CbxCategoria.ItemsSource = categoria_AD.SelecionarTodos();
                CbxCategoria.DisplayMemberPath = "NomeDaCategoria";
                CbxCategoria.SelectedValuePath = "Id";
                CbxCategoria.SelectedIndex = 0;
                TxtNomeDaDescricao.Focus();
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ComboBoxDeCategorias";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }
            LimparEAtualizarDados();
        }

        private void CbxCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Combobox SubCategorias.
            CbxSubCategoria.ItemsSource = SubCategoria_AD.ObterSubCategoriasPorId(Convert.ToInt32(CbxCategoria.SelectedValue));
            CbxSubCategoria.DisplayMemberPath = "NomeDaSubCategoria";
            CbxSubCategoria.SelectedValuePath = "Id";
            CbxSubCategoria.SelectedIndex = 0;
        }

        private void CarregarDataGrid()
        {
            try
            {
                DtgDados.ItemsSource = NomeDaDescricao_AD.ObterNomeDaDescricao();
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "CarregarDataGrid";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }
            TxtNomeDaDescricao.Focus();
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtIdNomeDaDescricao.Text == "" && TxtNomeDaDescricao.Text != "" && TxtIdCategoria.Text == "" && TxtIdSubCategoria.Text == "")
            {
                try
                {
                    NomeDaDescricao_AD nomeDaDescricao_AD = new();
                    NomeDaDescricao nomeDaDescricao = new()
                    {
                        Nome = TxtNomeDaDescricao.Text,
                        CategoriaId = Convert.ToInt32(CbxCategoria.SelectedValue),
                        SubCategoriaId = Convert.ToInt32(CbxSubCategoria.SelectedValue)
                    };
                    nomeDaDescricao_AD.Cadastrar(nomeDaDescricao);

                    GerenciarMensagens.SucessoAoCadastrar(nomeDaDescricao.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception ex)
                {
                    _nomeDoMetodo = "BtnCadastrar_Click";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    return;
                }
            }
            else if (TxtIdNomeDaDescricao.Text != "" && TxtNomeDaDescricao.Text != "" && TxtIdCategoria.Text != "" && TxtIdSubCategoria.Text != "")
            {
                GerenciarMensagens.ErroAoCadastrar();
                TxtNomeDaDescricao.Focus();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                TxtNomeDaDescricao.Focus();
                return;
            }
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtIdNomeDaDescricao.Text != "" && TxtNomeDaDescricao.Text != "" && TxtIdCategoria.Text != "" && TxtIdSubCategoria.Text != "")
            {
                try
                {
                    NomeDaDescricao_AD nomeDaDescricao_AD = new();
                    NomeDaDescricao nomeDaDescricao = new()
                    {
                        Id = Convert.ToInt32(TxtIdNomeDaDescricao.Text),
                        Nome = TxtNomeDaDescricao.Text,
                        CategoriaId = Convert.ToInt32(CbxCategoria.SelectedValue),
                        SubCategoriaId = Convert.ToInt32(CbxSubCategoria.SelectedValue)

                    };
                    nomeDaDescricao_AD.Alterar(nomeDaDescricao);

                    GerenciarMensagens.SucessoAoAlterar(nomeDaDescricao.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception ex)
                {
                    _nomeDoMetodo = "BtnAlterar_Click";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    return;
                }
            }
            else if (TxtIdNomeDaDescricao.Text == "" && TxtNomeDaDescricao.Text != "" && TxtIdCategoria.Text == "" && TxtIdSubCategoria.Text == "")
            {
                GerenciarMensagens.ErroAoAlterarOuExcluir();
                TxtNomeDaDescricao.Focus();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                TxtNomeDaDescricao.Focus();
                return;
            }
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (TxtIdNomeDaDescricao.Text != "" && TxtNomeDaDescricao.Text != "" && TxtIdCategoria.Text != "" && TxtIdSubCategoria.Text != "")
            {
                MessageBoxResult resultado = GerenciarMensagens.ConfirmarExcluir(Convert.ToInt32(TxtIdNomeDaDescricao.Text));
                if (resultado == MessageBoxResult.Yes)
                {
                    try
                    {
                        NomeDaDescricao_AD nomeDaDescricao_AD = new();
                        NomeDaDescricao nomeDaDescricao = new()
                        {
                            Id = Convert.ToInt32(TxtIdNomeDaDescricao.Text)
                        };
                        nomeDaDescricao_AD.Excluir(nomeDaDescricao.Id);

                        GerenciarMensagens.SucessoAoExcluir(nomeDaDescricao.Id);
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
            else if (TxtIdNomeDaDescricao.Text == "" && TxtNomeDaDescricao.Text != "" && TxtIdCategoria.Text == "" && TxtIdSubCategoria.Text == "")
            {
                GerenciarMensagens.ErroAoAlterarOuExcluir();
                TxtNomeDaDescricao.Focus();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                TxtNomeDaDescricao.Focus();
                return;
            }
        }

        private void TxtPesquisar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text != "")
            {
                var listafiltrada = NomeDaDescricao_AD.ObterNomeDaDescricao()
                    .Where(nd => nd.Nome.ToLower().Contains(textBox.Text.ToLower()));
                DtgDados.ItemsSource = null;
                DtgDados.ItemsSource = listafiltrada;
            }
            else
            {
                DtgDados.ItemsSource = NomeDaDescricao_AD.ObterNomeDaDescricao();
            }
        }

        private void DtgDados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DtgDados.SelectedItems.Count >= 0)
            {
                if (DtgDados.SelectedItems[0].GetType() == typeof(NomeDaDescricao))
                {
                    NomeDaDescricao nomeDaDescricao = (NomeDaDescricao)DtgDados.SelectedItems[0];

                    TxtIdCategoria.Text = nomeDaDescricao.CategoriaId.ToString();
                    CbxCategoria.Text = nomeDaDescricao.NomeDaCategoria;
                    TxtIdSubCategoria.Text = nomeDaDescricao.SubCategoriaId.ToString();
                    CbxSubCategoria.Text = nomeDaDescricao.NomeDaSubCategoria;
                    TxtIdNomeDaDescricao.Text = nomeDaDescricao.Id.ToString();
                    TxtNomeDaDescricao.Text = nomeDaDescricao.Nome;
                    TxtNomeDaDescricao.Focus();
                }
            }
        }

        private void BtnLimpar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            TxtPesquisar.Text = null;
            DtgDados.ItemsSource = NomeDaDescricao_AD.ObterNomeDaDescricao();
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CbxCategoria.SelectedIndex = 0;
            CbxSubCategoria.SelectedIndex = 0;
            LimparEAtualizarDados();
        }

        private void LimparEAtualizarDados()
        {
            TxtIdNomeDaDescricao.Text = "";
            TxtIdCategoria.Text = "";
            TxtIdSubCategoria.Text = "";
            TxtNomeDaDescricao.Text = "";
            TxtPesquisar.Text = "";
            TxtNomeDaDescricao.Focus();
            CarregarDataGrid();
        }
    }
}
