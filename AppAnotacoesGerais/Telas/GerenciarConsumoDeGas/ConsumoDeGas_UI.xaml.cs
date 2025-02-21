using GerenciarDados.AcessarDados;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppAnotacoesGerais.Telas.GerenciarConsumoDeGas
{
    public partial class ConsumoDeGas_UI : UserControl
    {
        public ConsumoDeGas_UI()
        {
            InitializeComponent();
            DtpDataDaTroca.Text = Convert.ToString(DateTime.Now.ToString("d"));
            DtpDataDaCompra.Text = Convert.ToString(DateTime.Now.ToString("d"));
            MainTest();
        }

        private void MainTest()
        {
            
            
            
            //DateTime dataAnterior = new DateTime(2006, 5, 17);//06/08/2006	17/05/2006

            //DateTime dataAtual = new DateTime(2006, 8, 6);

            //TimeSpan diferenca = dataAtual - dataAnterior;
            //int quantidadeDias = diferenca.Days;
            //string quantidade = $"O consumo de gás, entre {dataAnterior.ToShortDateString()} e {dataAtual.ToShortDateString()} foi de {quantidadeDias} dias.";
            //LblDiasConsumo.Content = quantidade;
            //=========================================================================
            /*
            TextBox textBoxData = new TextBox();
            textBoxData.Text = "01/03/2024"; // Exemplo de data no formato DD/MM/YYYY

            try
            {
                DateTime dataConvertida = DateTime.Parse(TxtDiaTroca.Text);
                Console.WriteLine($"Data convertida: {dataConvertida.ToShortDateString()}");
                LblDiasConsumo.Content = $"Data convertida: {dataConvertida.ToShortDateString()}";
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato de data inválido.");
            }*/
        }

        private void TxtPreco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Double formatValor = Convert.ToDouble(TxtPreco.Text.ToString().Replace("R$", ""));
                TxtPreco.Text = String.Format("{0:c}", formatValor);
            }
        }

        private void TxtCodigoDataAnterior_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ConsumoDeGas_AD consumoDeGas_AD = new();
                _ = TxtPreco.Focus();
                int buscarData = Convert.ToInt32(TxtCodigoDataAnterior.Text) - 1;
                CbxDataAnterior.ItemsSource = consumoDeGas_AD.SelecionarTodos();
                CbxDataAnterior.DisplayMemberPath = "DataAnterior";
                CbxDataAnterior.SelectedValuePath = "Id";
                CbxDataAnterior.SelectedIndex = buscarData;
                _ = TxtPreco.Focus();

                if (CbxDataAnterior.Text != "")
                {
                    DateTime dataAnterior, dataDaTroca;
                    TimeSpan diasDeConsumo;
                    dataAnterior = Convert.ToDateTime(CbxDataAnterior.Text);
                    dataDaTroca = Convert.ToDateTime(DtpDataDaTroca.Text);
                    diasDeConsumo = dataDaTroca - dataAnterior;
                    TxtConsumoEmDias.Text = Convert.ToString(diasDeConsumo.Days);
                    //TbxDiasConsumo.Text = Convert.ToString(diasDeConsumo.Days);

                    string quantidade = $"O consumo de gás, entre {dataAnterior.ToShortDateString()} e " +
                        $"{dataDaTroca.ToShortDateString()} foi de {diasDeConsumo.Days} dias.";
                    LblDiasConsumo.Content = quantidade;
                }
            }
            
        }



        private void BtnCadastrarSalvar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSelecionarAlterar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAlterarSalvar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnLimparDados_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMenuInicial_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnFechar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DtgDados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void BtnCadastrarSalvar_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
