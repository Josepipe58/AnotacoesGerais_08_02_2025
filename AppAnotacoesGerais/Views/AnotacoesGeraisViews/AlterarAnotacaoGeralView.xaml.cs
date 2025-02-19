using AcessarDadosDoBanco.Entities;
using AppAnotacoesGerais.Models;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System.Windows;
using System.Windows.Controls;

namespace AppAnotacoesGerais.Views.AnotacoesGeraisViews
{
    public partial class AlterarAnotacaoGeralView : Window
    {
        public AnotacaoGeralModel AnotacaoGeralModel { get; set; }
        public string _nomeDoMetodo = string.Empty;
        public AlterarAnotacaoGeralView()
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
            ComboBoxCategoria();
            ContadorDeRegistros();
        }
        public AlterarAnotacaoGeralView(AnotacaoGeralModel anotacaoGeralModel) : this()
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
            AnotacaoGeralModel = new();
            if (TxtConsultar.Text != "")
            {
                AnotacaoGeralModel.Id = Convert.ToInt32(TxtConsultar.Text);

                AnotacaoGeral_AD anotacaoGeral_AD = new();
                AnotacaoGeral anotacaoGeral = new();
                bool retorno = anotacaoGeral_AD.VerificarRegistros(Convert.ToInt32(TxtConsultar.Text));
                if (retorno)
                {
                    if (AnotacaoGeralModel.Id > 0)
                        Close();
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
            Close();
        }
    }
}
