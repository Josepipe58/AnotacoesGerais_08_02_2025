using AcessarDadosDoBanco.Entities;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System.Windows;
using System.Windows.Controls;

namespace AppAnotacoesGerais.Telas.AnotacoesGerais
{
    public partial class CadastrarAnotacaoGeral_UI : UserControl
    {
        public AnotacaoGeral AnotacaoGeral { get; set; }
        public string _nomeDoMetodo = string.Empty;

        public CadastrarAnotacaoGeral_UI()
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
            AnotacaoGeral = new AnotacaoGeral();
            AnotacaoGeral = new AnotacaoGeral();
            ComboBoxCategoria();
            ContadorDeRegistros();
        }

        public CadastrarAnotacaoGeral_UI(AnotacaoGeral anotacaoGeralModel) : this()
        {
            AnotacaoGeral = anotacaoGeralModel;
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
            SubCategoria_AD subCategoria_AD = new();
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

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtId.Text == "" && TxtDescricao.Text != "")
            {
                try
                {
                    AnotacaoGeral_AD anotacaoGeral_AD = new();
                    AnotacaoGeral anotacaoGeral = new()
                    {
                        NomeDaCategoria = CbxCategoria.Text,
                        NomeDaSubCategoria = CbxSubCategoria.Text,
                        NomeDaDescricao = CbxNomeDaDescricao.Text,
                        Descricao = TxtDescricao.Text,
                        Data = Convert.ToDateTime(DtpData.Text),
                    };
                    anotacaoGeral_AD.Cadastrar(anotacaoGeral);

                    GerenciarMensagens.SucessoAoCadastrar(anotacaoGeral.Id);
                    LimparDados();
                }
                catch (Exception ex)
                {
                    _nomeDoMetodo = "BtnCadastrar_Click";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    return;
                }
            }
            else if (TxtId.Text != "" && TxtDescricao.Text != "")
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
            if (TxtId.Text != "" && TxtDescricao.Text != "")
            {
                try
                {
                    AnotacaoGeral_AD anotacaoGeral_AD = new();
                    AnotacaoGeral anotacaoGeral = new()
                    {
                        Id = Convert.ToInt32(TxtId.Text),
                        NomeDaCategoria = CbxCategoria.Text,
                        NomeDaSubCategoria = CbxSubCategoria.Text,
                        NomeDaDescricao = CbxNomeDaDescricao.Text,
                        Descricao = TxtDescricao.Text,
                        Data = Convert.ToDateTime(DtpData.Text),
                    };
                    anotacaoGeral_AD.Alterar(anotacaoGeral);

                    GerenciarMensagens.SucessoAoCadastrar(anotacaoGeral.Id);
                    LimparDados();
                }
                catch (Exception ex)
                {
                    _nomeDoMetodo = "BtnAlterar_Click";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    return;
                }
            }
            else if (TxtId.Text == "" && TxtDescricao.Text != "")
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
                catch (Exception ex)
                {
                    _ = MessageBox.Show($"Erro ao conectar-se com o Banco de Dados.\nDetalhes do ex: {ex.Message}");
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

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CbxCategoria.Text = "";
            CbxCategoria.SelectedIndex = 0;
            CbxSubCategoria.Text = "";
            CbxSubCategoria.SelectedIndex = 0;
            CbxNomeDaDescricao.Text = "";
            CbxNomeDaDescricao.SelectedIndex = 0;
            DtpData.Text = Convert.ToString(DateTime.Today);
            LimparDados();
        }

        //Limpar
        public void LimparDados()
        {
            TxtId.Text = "";
            TxtDescricao.Text = "";
        }
    }
}
