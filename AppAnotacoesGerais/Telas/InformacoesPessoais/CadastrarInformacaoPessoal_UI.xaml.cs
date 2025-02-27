using AcessarDadosDoBanco.Modelos;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System.Windows;
using System.Windows.Controls;

namespace AppAnotacoesGerais.Telas.InformacoesPessoais
{
    public partial class CadastrarInformacaoPessoal_UI : UserControl
    {
        public InformacaoPessoal InformacaoPessoal { get; set; }
        public string _nomeDoMetodo = string.Empty;

        public CadastrarInformacaoPessoal_UI()
        {
            InitializeComponent();
            InformacaoPessoal = new InformacaoPessoal();
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtId.Text == "" && TxtTitulo.Text != "" && TxtDescricao.Text != "")
            {
                try
                {
                    InformacaoPessoal_AD informacaoPessoal_AD = new();
                    InformacaoPessoal informacaoPessoal = new()
                    {
                        Titulo = TxtTitulo.Text,
                        Descricao = TxtDescricao.Text
                    };
                    informacaoPessoal_AD.Cadastrar(informacaoPessoal);

                    GerenciarMensagens.SucessoAoCadastrar(informacaoPessoal.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception ex)
                {
                    _nomeDoMetodo = "BtnCadastrar_Click";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    return;
                }
                LimparEAtualizarDados();
            }
            else if (TxtId.Text != "" && TxtTitulo.Text != "" && TxtDescricao.Text != "")
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
            if (TxtId.Text != "" && TxtTitulo.Text != "" && TxtDescricao.Text != "")
            {
                try
                {
                    InformacaoPessoal_AD informacaoPessoal_AD = new();
                    InformacaoPessoal informacaoPessoal = new()
                    {
                        Id = Convert.ToInt32(TxtId.Text),
                        Titulo = TxtTitulo.Text,
                        Descricao = TxtDescricao.Text
                    };
                    informacaoPessoal_AD.Alterar(informacaoPessoal);

                    GerenciarMensagens.SucessoAoAlterar(informacaoPessoal.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception ex)
                {
                    _nomeDoMetodo = "BtnAlterar_Click";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    return;
                }
                LimparEAtualizarDados();
            }
            else if (TxtId.Text == "" && TxtTitulo.Text != "" && TxtDescricao.Text != "")
            {
                GerenciarMensagens.ErroAoAlterarOuExcluir();
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
                try
                {
                    InformacaoPessoal.Id = Convert.ToInt32(TxtConsultar.Text);

                    InformacaoPessoal_AD informacaoPessoal_AD = new(); 
                    bool retorno = informacaoPessoal_AD.VerificarRegistros(InformacaoPessoal.Id);
                    if (retorno)
                    {
                        var linha = InformacaoPessoal_AD.ObterInformacaoPessoalPorId(InformacaoPessoal.Id);
                        if (InformacaoPessoal.Id >= 0)
                        {
                            if (linha.Count >= 0)
                            {
                                if (linha[0].GetType() == typeof(InformacaoPessoal))
                                {
                                    InformacaoPessoal = linha[0];
                                    TxtId.Text = Convert.ToString(InformacaoPessoal.Id);
                                    TxtTitulo.Text = InformacaoPessoal.Titulo;
                                    TxtDescricao.Text = InformacaoPessoal.Descricao;
                                }
                            }
                        }
                    }
                    else
                    {
                        _nomeDoMetodo = "BtnConsultar_Click";
                        GerenciarMensagens.MensagemDeErroDeObterId(InformacaoPessoal.Id, _nomeDoMetodo);
                    }
                }
                catch (Exception ex)
                {
                    _nomeDoMetodo = "BtnCadastrar_Click";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
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

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            LimparEAtualizarDados();
        }

        public void LimparEAtualizarDados()
        {
            TxtId.Text = "";
            TxtTitulo.Text = "";
            TxtDescricao.Text = "";
        }
    }
}
