using AcessarDadosDoBanco.Modelos;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppAnotacoesGerais.Telas.InformacoesPessoais
{
    public partial class InformacaoPessoal_UI : UserControl
    {
        public InformacaoPessoal InformacaoPessoal { get; set; }
        public string _nomeDoMetodo = string.Empty;

        public InformacaoPessoal_UI()
        {
            InitializeComponent();            
            InformacaoPessoal = new InformacaoPessoal();           
            CarregarDataGrid();
        }

        public void CarregarDataGrid()
        {
            DtgDados.ItemsSource = InformacaoPessoal_AD.ObterInformacaoPessoal();
            TxtId.Focus();
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtId.Text != "")
            {
                try
                {
                    AlterarInformacaoPessoal_UI alterarIP = new(InformacaoPessoal);

                    InformacaoPessoal.Id = Convert.ToInt32(TxtId.Text);

                    InformacaoPessoal_AD informacaoPessoal_AD = new();
                    InformacaoPessoal informacaoPessoal = new();
                    bool retorno = informacaoPessoal_AD.VerificarRegistros(InformacaoPessoal.Id);
                    if (retorno)
                    {
                        informacaoPessoal.Id = InformacaoPessoal.Id;
                        var linha = InformacaoPessoal_AD.ObterInformacaoPessoalPorId(informacaoPessoal.Id);
                        if (InformacaoPessoal.Id >= 0)
                        {
                            if (linha.Count >= 0)
                            {
                                if (linha[0].GetType() == typeof(InformacaoPessoal))
                                {
                                    informacaoPessoal = linha[0];
                                    alterarIP.TxtId.Text = Convert.ToString(informacaoPessoal.Id);
                                    alterarIP.TxtTitulo.Text = informacaoPessoal.Titulo.ToString();
                                    alterarIP.TxtDescricao.Text = informacaoPessoal.Descricao.ToString();
                                }
                            }
                        }
                        alterarIP.Show();
                    }
                    else
                    {
                        _nomeDoMetodo = "BtnAlterar_Click";
                        GerenciarMensagens.MensagemDeErroDeObterId(InformacaoPessoal.Id, _nomeDoMetodo);
                    }
                }
                catch (Exception ex)
                {
                    _nomeDoMetodo = "BtnAlterar_Click";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    return;
                }
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                return;
            }
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (TxtId.Text != "")
            {
                MessageBoxResult resultado = GerenciarMensagens.ConfirmarExcluir(Convert.ToInt32(TxtId.Text));
                if (resultado == MessageBoxResult.No)
                {
                    TxtId.Text = "";
                    LimparEAtualizarDados();
                    return;
                }
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
                    return;
                }
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
                        TxtId.Focus();
                    }
                }
            }
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            LimparEAtualizarDados();
        }

        public void LimparEAtualizarDados()
        {
            TxtId.Text = "";          
            CarregarDataGrid();
        }
    }
}
