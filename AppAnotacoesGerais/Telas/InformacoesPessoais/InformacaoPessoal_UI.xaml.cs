using AcessarDadosDoBanco.Entities;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppAnotacoesGerais.Telas.InformacoesPessoais
{
    public partial class InformacaoPessoal_UI : UserControl
    {
        public string _nomeDoMetodo = string.Empty;

        public InformacaoPessoal_UI()
        {
            InitializeComponent();
            CarregarDataGrid();
        }

        public void CarregarDataGrid()
        {
            DtgDados.ItemsSource = InformacaoPessoal_AD.ObterInformacaoPessoal();
            TxtTitulo.Focus();
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtId.Text == "" && TxtTitulo.Text != "" && TxtDescricao.Text != "")
            {
                try
                {
                    InformacaoPessoal_AD informacaoPessoal_AD = new();
                    InformacaoPessoal informacaoPessoal = new()
                    {
                        Titulo = TxtTitulo.Text,
                        Descricao = TxtDescricao.Text
                    };
                    informacaoPessoal_AD.Cadastrar(informacaoPessoal);

                    GerenciarMensagens.SucessoAoCadastrar(informacaoPessoal.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception ex)
                {
                    _nomeDoMetodo = "BtnCadastrar_Click";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    return;
                }
                LimparEAtualizarDados();
            }
            else if (TxtId.Text != "" && TxtTitulo.Text != "" && TxtDescricao.Text != "")
            {
                GerenciarMensagens.ErroAoCadastrar();
                TxtDescricao.Focus();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                TxtDescricao.Focus();
                return;
            }
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtId.Text != "" && TxtTitulo.Text != "" && TxtDescricao.Text != "")
            {
                try
                {
                    InformacaoPessoal_AD informacaoPessoal_AD = new();
                    InformacaoPessoal informacaoPessoal = new()
                    {
                        Id = Convert.ToInt32(TxtId.Text),
                        Titulo = TxtTitulo.Text,
                        Descricao = TxtDescricao.Text
                    };
                    informacaoPessoal_AD.Alterar(informacaoPessoal);

                    GerenciarMensagens.SucessoAoCadastrar(informacaoPessoal.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception ex)
                {
                    _nomeDoMetodo = "BtnCadastrar_Click";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    return;
                }
                LimparEAtualizarDados();
            }
            else if (TxtId.Text == "" && TxtTitulo.Text != "" && TxtDescricao.Text != "")
            {
                GerenciarMensagens.ErroAoAlterarOuExcluir();
                TxtDescricao.Focus();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                TxtDescricao.Focus();
                return;
            }
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (TxtId.Text != "" && TxtTitulo.Text != "" && TxtDescricao.Text != "")
            {
                MessageBoxResult resultado = GerenciarMensagens.ConfirmarExcluir(Convert.ToInt32(TxtId.Text));
                if (resultado == MessageBoxResult.Yes)
                {
                    try
                    {
                        InformacaoPessoal_AD informacaoPessoal_AD = new();
                        InformacaoPessoal informacaoPessoal = new()
                        {
                            Id = Convert.ToInt32(TxtId.Text)
                        };
                        informacaoPessoal_AD.Excluir(informacaoPessoal.Id);

                        GerenciarMensagens.SucessoAoExcluir(informacaoPessoal.Id);
                        LimparEAtualizarDados();
                    }
                    catch (Exception ex)
                    {
                        _nomeDoMetodo = "BtnExcluir_Click";
                        GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    }
                }
                else
                {
                    LimparEAtualizarDados();
                    return;
                }
            }
            else if (TxtId.Text == "" && TxtTitulo.Text != "" && TxtDescricao.Text != "")
            {
                GerenciarMensagens.ErroAoAlterarOuExcluir();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                return;
            }
        }

        private void DtgDados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DtgDados.SelectedIndex >= 0)
            {
                if (DtgDados.SelectedItems.Count >= 0)
                {
                    if (DtgDados.SelectedItems[0].GetType() == typeof(InformacaoPessoal))
                    {
                        InformacaoPessoal informacaoPessoal = (InformacaoPessoal)DtgDados.SelectedItems[0];

                        TxtId.Text = informacaoPessoal.Id.ToString();
                        TxtTitulo.Text = informacaoPessoal.Titulo.ToString();
                        TxtDescricao.Text = informacaoPessoal.Descricao.ToString();
                        TxtTitulo.Focus();
                    }
                }
            }
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtConsultar.Text != "")
            {
                /*
                try
                {
                    bool retorno = rn_InformacoesPessoais.VerificarRegistros(TxtConsultar.Text);//Retorna true ou false
                    if (retorno)
                    {
                        ot_InformacoesPessoaisColecao = rn_InformacoesPessoais.ConsultarPorTitulo(TxtConsultar.Text);
                        DtgDados.ItemsSource = null;
                        DtgDados.ItemsSource = ot_InformacoesPessoaisColecao;
                        TxtConsultar.Text = "";
                        _ = TxtConsultar.Focus();
                    }
                    else
                    {
                        string resultado = TxtConsultar.Text;
                        _ = MessageBox.Show($"Nenhum resultado foi encontrado com a palavra \"{resultado}\", que você digitou.",
                            "Mensagem da Consulta!", MessageBoxButton.OK, MessageBoxImage.Information);
                        TxtConsultar.Text = "";
                        _ = TxtConsultar.Focus();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show($"Erro ao Consultar por Título. Detalhes: {ex.Message}", "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                */
            }
            else
            {
                _ = MessageBox.Show("O campo de consulta está vazio, preencha-o para continuar.", "Mensagem de Alerta!", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
        }

        private void TxtConsultar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BtnConsultar_Click(sender, e);
            }
        }

        public void LimparEAtualizarDados()
        {
            TxtId.Text = "";
            TxtTitulo.Text = "";
            TxtDescricao.Text = "";
            CarregarDataGrid();
        }
        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CarregarDataGrid();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimparEAtualizarDados();
        }

        private void BtnConsultarInfoPes_Click(object sender, RoutedEventArgs e)
        {
            /*
            FrmInformacoesPessoais_Consultar frm = new FrmInformacoesPessoais_Consultar();
            frm.Show();
            Close();
            */
        }
    }
}
