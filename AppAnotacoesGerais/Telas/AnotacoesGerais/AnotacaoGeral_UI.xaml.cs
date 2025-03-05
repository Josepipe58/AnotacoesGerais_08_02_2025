using AcessarDadosDoBanco.Modelos;
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
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Carregar ComboBox da Categoria
            Categoria_AD categoria_AD = new();
            CbxCategoria.ItemsSource = categoria_AD.SelecionarTodos();
            CbxCategoria.DisplayMemberPath = "NomeDaCategoria";
            CbxCategoria.SelectedValuePath = "Id";
            CbxCategoria.SelectedIndex = -1;

            ConsultasDeAnotacoesGerais();
            ContadorDeRegistros();
        }

        private void CbxCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Carregar ComboBox da SubCategoria
            CbxSubCategoria.ItemsSource = SubCategoria_AD.ObterSubCategoriasPorId(Convert.ToInt32(CbxCategoria.SelectedValue));
            CbxSubCategoria.DisplayMemberPath = "NomeDaSubCategoria";
            CbxSubCategoria.SelectedValuePath = "Id";
            CbxSubCategoria.SelectedIndex = -1;
        }

        private void CbxSubCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CbxNomeDaDescricao.ItemsSource = NomeDaDescricao_AD.ObterNomeDaDescricaoPorId(Convert.ToInt32(CbxSubCategoria.SelectedValue));
            CbxNomeDaDescricao.DisplayMemberPath = "Nome";
            CbxNomeDaDescricao.SelectedValuePath = "Id";
            CbxNomeDaDescricao.SelectedIndex = -1;
        }

        public void ConsultasDeAnotacoesGerais()
        {
            try
            {
                if (CbxCategoria.Text == "" && CbxSubCategoria.Text == "" && CbxNomeDaDescricao.Text == "")
                {
                    DtgDados.ItemsSource = AnotacaoGeral_AD.ObterAnotacoesGerais();
                    TxtConsultar.Focus();
                }
                else if (CbxCategoria.Text != "" && CbxSubCategoria.Text == "" && CbxNomeDaDescricao.Text == "")
                {
                    DtgDados.ItemsSource = AnotacaoGeral_AD.ObterAnotacoesGerais().Where(dp => dp.NomeDaCategoria == CbxCategoria.Text);
                }
                else if (CbxCategoria.Text != "" && CbxSubCategoria.Text != "" && CbxNomeDaDescricao.Text == "")
                {
                    DtgDados.ItemsSource = AnotacaoGeral_AD.ObterAnotacoesGerais().Where(dp => dp.NomeDaCategoria == CbxCategoria.Text
                    && dp.NomeDaSubCategoria == CbxSubCategoria.Text);
                }
                else if (CbxCategoria.Text != "" && CbxSubCategoria.Text != "" && CbxNomeDaDescricao.Text != "")
                {
                    DtgDados.ItemsSource = AnotacaoGeral_AD.ObterAnotacoesGerais().Where(dp => dp.NomeDaCategoria == CbxCategoria.Text
                    && dp.NomeDaSubCategoria == CbxSubCategoria.Text && dp.NomeDaDescricao == CbxNomeDaDescricao.Text);
                }
                else
                {
                    MessageBox.Show("Não foi possível fazer nenhum tipo de consulta de Despesas.", "Mensagem de Erro!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultasDeDespesas";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }
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
                                alterarAG.CbxNomeDaDescricao.Text = anotacaoGeral.NomeDaDescricao.ToString();
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
                _nomeDoMetodo = "BtnAlterar_Click";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
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
                    ConsultasDeAnotacoesGerais();
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

                    ConsultasDeAnotacoesGerais();
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

        private void CbxCategoria_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ConsultasDeAnotacoesGerais();
        }

        private void CbxSubCategoria_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ConsultasDeAnotacoesGerais();
        }

        private void CbxNomeDaDescricao_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ConsultasDeAnotacoesGerais();
        }

        private void DtgDados_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (DtgDados.SelectedIndex >= 0)
            {
                if (DtgDados.SelectedItems.Count >= 0)
                {
                    if (DtgDados.SelectedItems[0].GetType() == typeof(AnotacaoGeral))
                    {
                        AnotacaoGeral anotacaoGeral = (AnotacaoGeral)DtgDados.SelectedItems[0];
                        TxtConsultar.Text = anotacaoGeral.Id.ToString();
                        //CbxCategoria.Text = anotacaoGeral.NomeDaCategoria.ToString();
                        //CbxSubCategoria.Text = anotacaoGeral.NomeDaSubCategoria.ToString();
                        //CbxNomeDaDescricao.Text = anotacaoGeral.NomeDaDescricao.ToString();                        
                        TxtConsultar.Focus();
                    }
                }
            }
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            AnotacaoGeral_AD anotacaoGeral_AD = new();
            ConsultasDeAnotacoesGerais();
            //DtgDados.ItemsSource = anotacaoGeral_AD.SelecionarTodos().OrderByDescending(an => an.Id);
            UserControl_Loaded(sender, e);
            TxtConsultar.Text = "0";
        }
    }
}
