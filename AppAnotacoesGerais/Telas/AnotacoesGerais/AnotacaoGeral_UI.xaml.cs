using AcessarDadosDoBanco.Entities;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System.Windows;
using System.Windows.Controls;

namespace AppAnotacoesGerais.Telas.AnotacoesGerais
{
    public partial class AnotacaoGeral_UI : UserControl
    {
        public AnotacaoGeral AnotacaoGeral { get; set; }
        public string _nomeDoMetodo = string.Empty;

        public AnotacaoGeral_UI()
        {
            InitializeComponent();
            AnotacaoGeral = new AnotacaoGeral();
            CarregarDataGrid();
        }

        public void CarregarDataGrid()
        {
            DtgDados.ItemsSource = AnotacaoGeral_AD.ObterAnotacoesGerais();
            ContadorDeRegistros();
        }

        public void ContadorDeRegistros()
        {
            AnotacaoGeral_AD anotacaoGeral_AD = new();
            int contador = anotacaoGeral_AD.ContadorRegistros();
            if (contador <= 0)
            {
                MessageBox.Show($"Atenção! Não existe nenhum registro no Banco de Dados.",
                            "Aviso!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            TxtQtdeRegistros.Text = Convert.ToString(contador);
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            AnotacaoGeral_AD anotacaoGeral_AD = new();
            DtgDados.ItemsSource = anotacaoGeral_AD.SelecionarTodos().OrderByDescending(an => an.Id);
            TxtConsultar.Text = "0";
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            AlterarAnotacaoGeral_UI alterarAG = new(AnotacaoGeral);
            try
            {
                if (TxtConsultar.Text != "")
                    AnotacaoGeral.Id = Convert.ToInt32(TxtConsultar.Text);

                AnotacaoGeral_AD anotacaoGeral_AD = new();
                AnotacaoGeral anotacaoGeral = new();
                bool retorno = anotacaoGeral_AD.VerificarRegistros(AnotacaoGeral.Id);
                if (retorno)
                {
                    anotacaoGeral.Id = AnotacaoGeral.Id;
                    var linha = AnotacaoGeral_AD.ObterAnotacoesGeraisPorId(anotacaoGeral.Id);
                    if (AnotacaoGeral.Id >= 0)
                    {
                        if (linha.Count >= 0)
                        {
                            if (linha[0].GetType() == typeof(AnotacaoGeral))
                            {
                                anotacaoGeral = linha[0];
                                alterarAG.TxtId.Text = Convert.ToString(anotacaoGeral.Id);
                                alterarAG.CbxCategoria.Text = anotacaoGeral.NomeDaCategoria.ToString();
                                alterarAG.CbxSubCategoria.Text = anotacaoGeral.NomeDaSubCategoria.ToString();
                                alterarAG.TxtDescricao.Text = anotacaoGeral.Descricao.ToString();
                                alterarAG.DtpData.Text = anotacaoGeral.Data.ToString();
                            }
                        }
                    }
                    alterarAG.Show();
                }
                else
                {
                    _nomeDoMetodo = "ConsultarAnotacaoGeral";
                    GerenciarMensagens.MensagemDeErroDeObterId(AnotacaoGeral.Id, _nomeDoMetodo);
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show($"Erro ao conectar-se com o Banco de Dados.\nDetalhes do ex: {ex.Message}");
                return;
            }
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (TxtConsultar.Text != "0" && TxtConsultar.Text != "" && TxtConsultar.Text != null)
            {
                MessageBoxResult resultado = GerenciarMensagens.ConfirmarExcluir(Convert.ToInt32(TxtConsultar.Text));
                if (resultado == MessageBoxResult.No)
                {
                    TxtConsultar.Text = "0";
                    CarregarDataGrid();
                    return;
                }
                try
                {
                    AnotacaoGeral_AD anotacaoGeral_AD = new();
                    AnotacaoGeral anotacaoGeral = new()
                    {
                        Id = Convert.ToInt32(TxtConsultar.Text)
                    };
                    anotacaoGeral_AD.Excluir(anotacaoGeral);
                    GerenciarMensagens.SucessoAoExcluir(anotacaoGeral.Id);

                    CarregarDataGrid();
                    TxtConsultar.Text = "0";
                    return;
                }
                catch (Exception ex)
                {
                    _nomeDoMetodo = "Excluir";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    return;
                }
            }
            else if (TxtConsultar.Text == "0" || TxtConsultar.Text != "")
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
    }
}
