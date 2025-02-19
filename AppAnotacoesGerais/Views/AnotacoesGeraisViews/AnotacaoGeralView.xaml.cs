using AcessarDadosDoBanco.Entities;
using AppAnotacoesGerais.Models;
using GerenciarDados.AcessarDados;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppAnotacoesGerais.Views.AnotacoesGeraisViews
{
    public partial class AnotacaoGeralView : UserControl
    {
        public AnotacaoGeralModel AnotacaoGeralModel { get; set; }
        public string _nomeDoMetodo = string.Empty;
        public AnotacaoGeralView()
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

        private void DtgDados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DtgDados.SelectedIndex >= 0)
            {
                if (DtgDados.SelectedItems.Count >= 0)
                {
                    if (DtgDados.SelectedItems[0].GetType() == typeof(AnotacaoGeral))
                    {
                        AnotacaoGeral anotacaoGeral = (AnotacaoGeral)DtgDados.SelectedItems[0];

                        TxtConsultar.Text = Convert.ToString(anotacaoGeral.Id);
                        TxtConsultar.Focus();
                    }
                }
            }
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            AnotacaoGeral_AD anotacaoGeral_AD = new();
            DtgDados.ItemsSource = anotacaoGeral_AD.SelecionarTodos().OrderByDescending(an=>an.Id);
            TxtConsultar.Text = "0";
        }
    }
}
