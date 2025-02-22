using AcessarDadosDoBanco.Entities;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppAnotacoesGerais.Telas
{
    public partial class ConsumoDeGas_UI : UserControl
    {
        public string _nomeDoMetodo = string.Empty;

        public ConsumoDeGas_UI()
        {
            InitializeComponent();

            //Atualizar Datas.
            DtpDataDaTroca.Text = Convert.ToString(DateTime.Now.ToString("d"));
            DtpDataDaCompra.Text = Convert.ToString(DateTime.Now.ToString("d"));
            ComboBoxDeCategorias();
        }

        private void ComboBoxDeCategorias()
        {
            try
            {
                // Combobox da Data Anterior.
                ConsumoDeGas_AD consumoDeGas_AD = new();
                CbxDataAnterior.ItemsSource = consumoDeGas_AD.SelecionarTodos().OrderByDescending(cg => cg.DataDaTroca);
                CbxDataAnterior.DisplayMemberPath = "DataDaTroca";
                CbxDataAnterior.SelectedValuePath = "Id";
                CbxDataAnterior.SelectedIndex = 0;
                TxtPreco.Focus();
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ComboBoxDeCategorias";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }
            LimparEAtualizarDados();
        }

        private void CarregarDataGrid()
        {
            try
            {
                ConsumoDeGas_AD consumoDeGas_AD = new();
                DtgDados.ItemsSource = consumoDeGas_AD.SelecionarTodos().OrderByDescending(cg=>cg.Id);
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "CarregarDataGrid";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }
            TxtPreco.Focus();
            VerificarGasDeReserva();           
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtId.Text == "" && TxtConsumoEmDias.Text != "" && TxtPreco.Text != "" && TxtFornecedor.Text != "")
            {
                try
                {
                    ConsumoDeGas_AD consumoDeGas_AD = new();
                    ConsumoDeGas consumoDeGas = new()
                    {
                        DataDaTroca = Convert.ToDateTime(DtpDataDaTroca.Text),
                        DiasDeConsumo = Convert.ToInt32(TxtConsumoEmDias.Text),
                        DataDaCompra = Convert.ToDateTime(DtpDataDaCompra.Text),
                        Preco = Convert.ToDecimal(TxtPreco.Text.Replace("R$", "")),
                        Fornecedor = TxtFornecedor.Text
                    };
                    consumoDeGas_AD.Cadastrar(consumoDeGas);

                    GerenciarMensagens.SucessoAoCadastrar(consumoDeGas.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception ex)
                {
                    _nomeDoMetodo = "BtnCadastrar_Click";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    return;
                }
            }
            else if (TxtId.Text != "" && TxtConsumoEmDias.Text != "" && TxtPreco.Text != "" && TxtFornecedor.Text != "")
            {
                GerenciarMensagens.ErroAoCadastrar();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                return;
            }
        }
        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtId.Text != "" && TxtConsumoEmDias.Text != "" && TxtPreco.Text != "" && TxtFornecedor.Text != "")
            {
                try
                {
                    ConsumoDeGas_AD consumoDeGas_AD = new();
                    ConsumoDeGas consumoDeGas = new()
                    {
                        Id = Convert.ToInt32(TxtId.Text),
                        DataDaTroca = Convert.ToDateTime(DtpDataDaTroca.Text),
                        DiasDeConsumo = Convert.ToInt32(TxtConsumoEmDias.Text),
                        DataDaCompra = Convert.ToDateTime(DtpDataDaCompra.Text),
                        Preco = Convert.ToDecimal(TxtPreco.Text.Replace("R$", "")),
                        Fornecedor = TxtFornecedor.Text
                    };
                    consumoDeGas_AD.Alterar(consumoDeGas);

                    GerenciarMensagens.SucessoAoAlterar(consumoDeGas.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception ex)
                {
                    _nomeDoMetodo = "BtnAlterar_Click";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    return;
                }
            }
            else if (TxtId.Text == "" && TxtConsumoEmDias.Text != "" && TxtPreco.Text != "" && TxtFornecedor.Text != "")
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
        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (TxtId.Text != "" && TxtConsumoEmDias.Text != "" && TxtPreco.Text != "" && TxtFornecedor.Text != "")
            {
                MessageBoxResult resultado = GerenciarMensagens.ConfirmarExcluir(Convert.ToInt32(TxtId.Text));
                if (resultado == MessageBoxResult.No)
                {
                    LimparEAtualizarDados();
                    return;
                }
                try
                {
                    ConsumoDeGas_AD consumoDeGas_AD = new();
                    ConsumoDeGas consumoDeGas = new()
                    {
                        Id = Convert.ToInt32(TxtId.Text)
                    };
                    consumoDeGas_AD.Excluir(consumoDeGas);
                    GerenciarMensagens.SucessoAoExcluir(consumoDeGas.Id);

                    LimparEAtualizarDados();
                    return;
                }
                catch (Exception ex)
                {
                    _nomeDoMetodo = "BtnExcluir_Click";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    return;
                }
            }
            else if (TxtId.Text == "" && TxtConsumoEmDias.Text != "" && TxtPreco.Text != "" && TxtFornecedor.Text != "")
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
                    if (DtgDados.SelectedItems[0].GetType() == typeof(ConsumoDeGas))
                    {
                        ConsumoDeGas consumoDeGas = (ConsumoDeGas)DtgDados.SelectedItems[0];

                        TxtId.Text = consumoDeGas.Id.ToString();
                        CbxDataAnterior.Text = consumoDeGas.DataDaTroca.ToString();
                        DtpDataDaTroca.Text = consumoDeGas.DataDaTroca.ToString();
                        TxtConsumoEmDias.Text = consumoDeGas.DiasDeConsumo.ToString();
                        DtpDataDaCompra.Text = consumoDeGas.DataDaCompra.ToString();
                        TxtPreco.Text = consumoDeGas.Preco.ToString();
                        TxtFornecedor.Text = consumoDeGas.Fornecedor.ToString();
                        TxtPreco.Focus();
                    }
                }
            }
        }

        private void TxtCodigoDataAnterior_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DateTime dataAnterior, dataDaTroca;
                TimeSpan diasDeConsumo;
                dataAnterior = Convert.ToDateTime(CbxDataAnterior.Text);
                dataDaTroca = Convert.ToDateTime(DtpDataDaTroca.Text);
                diasDeConsumo = dataDaTroca - dataAnterior;
                TxtConsumoEmDias.Text = Convert.ToString(diasDeConsumo.Days);

                string quantidade = $"O consumo de gás, entre {dataAnterior.ToShortDateString()} e " +
                    $"{dataDaTroca.ToShortDateString()} foi de {diasDeConsumo.Days} dias.";
                LblDiasConsumo.Content = quantidade;
                _ = TxtPreco.Focus();
            }
        }

        private void VerificarGasDeReserva()
        {
            try
            {
                ConsumoDeGas_AD consumoDeGas_AD = new();
                var consumo = consumoDeGas_AD.SelecionarTodos().OrderByDescending(cg => cg.Id).ToList();
                if (consumo[0].Preco > 0)
                {
                    TxtBotijaoReserva.Text = "Sim";
                }
                else
                {
                    TxtBotijaoReserva.Text = "Não";
                }
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "VerificarGasDeReserva";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }

        }

        private void TxtPreco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                double formatValor = Convert.ToDouble(TxtPreco.Text.ToString().Replace("R$", ""));
                TxtPreco.Text = string.Format("{0:c}", formatValor);
            }
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CbxDataAnterior.SelectedIndex = 0;
            ComboBoxDeCategorias();
            LimparEAtualizarDados();
        }

        public void LimparEAtualizarDados()
        {
            TxtId.Text = "";
            TxtConsumoEmDias.Text = "";
            TxtPreco.Text = "";
            TxtFornecedor.Text = "";
            DtpDataDaTroca.Text = Convert.ToString(DateTime.Now.ToString("d"));
            DtpDataDaCompra.Text = Convert.ToString(DateTime.Now.ToString("d"));
            CbxDataAnterior.SelectedIndex = 0;
            CarregarDataGrid();
        }
    }
}
