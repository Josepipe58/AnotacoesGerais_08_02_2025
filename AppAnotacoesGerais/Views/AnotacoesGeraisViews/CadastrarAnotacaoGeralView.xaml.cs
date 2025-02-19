using AcessarDadosDoBanco.Entities;
using AppAnotacoesGerais.Models;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System.Threading.Channels;
using System.Windows;
using System.Windows.Controls;

namespace AppAnotacoesGerais.Views.AnotacoesGeraisViews
{
    public partial class CadastrarAnotacaoGeralView : UserControl
    {
        public AnotacaoGeralModel AnotacaoGeralModel { get; set; }
        public AnotacaoGeral AnotacaoGeral { get; set; }
        public string _nomeDoMetodo = string.Empty;

        public CadastrarAnotacaoGeralView()
        {
            InitializeComponent();

            //Atualizar com a Data do Sistema
            if (DtpData.Text == "")
            {
                DtpData.Text = Convert.ToString(DateTime.Today);
            }
            else
            {
                DtpData.Text = Convert.ToString(DateTime.Today);
            }
            AnotacaoGeralModel = new AnotacaoGeralModel();
            AnotacaoGeral = new AnotacaoGeral();
            ComboBoxCategoria();
            ContadorDeRegistros();
        }

        public CadastrarAnotacaoGeralView(AnotacaoGeralModel anotacaoGeralModel) : this()
        {
            AnotacaoGeralModel = anotacaoGeralModel;
        }

        private void ComboBoxCategoria()
        {
            try
            {
                //Combobox de Categorias
                Categoria_AD categoria_AD = new();
                CbxCategoria.ItemsSource = categoria_AD.SelecionarTodos();
                CbxCategoria.DisplayMemberPath = "NomeDaCategoria";
                CbxCategoria.SelectedValuePath = "Id";
                CbxCategoria.SelectedIndex = 0;
                TxtDescricao.Focus();
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ComboBoxCategoria";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }
        }

        private void CbxCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CbxSubCategoria.ItemsSource = SubCategoria_AD.ObterSubCategoriasPorId(Convert.ToInt32(CbxCategoria.SelectedValue));
            CbxSubCategoria.DisplayMemberPath = "NomeDaSubCategoria";
            CbxSubCategoria.SelectedValuePath = "Id";
            CbxSubCategoria.SelectedIndex = 0;
            TxtDescricao.Focus();
        }

        private void CbxSubCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CbxNomeDaDescricao.ItemsSource = NomeDaDescricao_AD.ObterNomeDaDescricaoPorId(Convert.ToInt32(CbxSubCategoria.SelectedValue));
            CbxNomeDaDescricao.DisplayMemberPath = "Nome";
            CbxNomeDaDescricao.SelectedValuePath = "Id";
            CbxNomeDaDescricao.SelectedIndex = 0;
            TxtDescricao.Focus();
        }
        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtConsultar.Text != "")
            {
                AnotacaoGeral.Id = Convert.ToInt32(TxtConsultar.Text);
                try
                {
                    AnotacaoGeral_AD anotacaoGeral_AD = new();
                    bool retorno = anotacaoGeral_AD.VerificarRegistros(AnotacaoGeral.Id);
                    if (retorno)
                    {
                        var linha = AnotacaoGeral_AD.ObterAnotacoesGeraisPorId(AnotacaoGeral.Id);
                        if (AnotacaoGeral.Id >= 0)
                        {
                            if (linha.Count >= 0)
                            {
                                if (linha[0].GetType() == typeof(AnotacaoGeral))
                                {
                                    AnotacaoGeral = linha[0];
                                    TxtId.Text = Convert.ToString(AnotacaoGeral.Id);
                                    CbxCategoria.Text = AnotacaoGeral.NomeDaCategoria.ToString();
                                    CbxSubCategoria.Text = AnotacaoGeral.NomeDaSubCategoria.ToString();
                                    TxtDescricao.Text = AnotacaoGeral.Descricao.ToString();
                                    DtpData.Text = AnotacaoGeral.Data.ToString();
                                }
                            }
                        }
                    }
                    else
                    {
                        _nomeDoMetodo = "BtnConsultar_Click";
                        GerenciarMensagens.MensagemDeErroDeObterId(AnotacaoGeral.Id, _nomeDoMetodo);
                    }
                }
                catch (Exception erro)
                {
                    _ = MessageBox.Show($"Erro ao conectar-se com o Banco de Dados.\nDetalhes do erro: {erro.Message}");
                    return;
                }
            }
            else if (TxtConsultar.Text == "")
            {
                _nomeDoMetodo = "BtnConsultar_Click";
                GerenciarMensagens.PreencherCampoVazio();
                return;
            }
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

        private void BtnSair_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
