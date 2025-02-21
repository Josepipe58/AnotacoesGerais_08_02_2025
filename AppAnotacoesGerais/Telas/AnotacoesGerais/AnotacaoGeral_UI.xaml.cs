using AcessarDadosDoBanco.Entities;
using AppAnotacoesGerais.Models;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System.Windows;
using System.Windows.Controls;

namespace AppAnotacoesGerais.Telas.AnotacoesGerais
{
    public partial class AnotacaoGeral_UI : UserControl
    {
        public AnotacaoGeralModel AnotacaoGeralModel { get; set; }
        public string _nomeDoMetodo = string.Empty;
        public AnotacaoGeral_UI()
        {
            InitializeComponent();
            AnotacaoGeralModel = new AnotacaoGeralModel();
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
            AlterarAnotacaoGeral_UI alterarAG = new(AnotacaoGeralModel);
            try
            {
                if (TxtConsultar.Text != "")
                    AnotacaoGeralModel.Id = Convert.ToInt32(TxtConsultar.Text);

                AnotacaoGeral_AD anotacaoGeral_AD = new();
                AnotacaoGeral anotacaoGeral = new();
                bool retorno = anotacaoGeral_AD.VerificarRegistros(AnotacaoGeralModel.Id);
                if (retorno)
                {
                    anotacaoGeral.Id = AnotacaoGeralModel.Id;
                    var linha = AnotacaoGeral_AD.ObterAnotacoesGeraisPorId(anotacaoGeral.Id);
                    if (AnotacaoGeralModel.Id >= 0)
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
                    GerenciarMensagens.MensagemDeErroDeObterId(AnotacaoGeralModel.Id, _nomeDoMetodo);
                }
            }
            catch (Exception erro)
            {
                _ = MessageBox.Show($"Erro ao conectar-se com o Banco de Dados.\nDetalhes do erro: {erro.Message}");
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
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Excluir";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
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
