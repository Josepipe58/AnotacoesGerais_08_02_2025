using AcessarDadosDoBanco.Modelos;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System.Windows;

namespace AppAnotacoesGerais.Telas.InformacoesPessoais
{
    public partial class AlterarInformacaoPessoal_UI : Window
    {
        public InformacaoPessoal InformacaoPessoal { get; set; }

        public string _nomeDoMetodo = string.Empty;

        public AlterarInformacaoPessoal_UI()
        {
            InitializeComponent();
            InformacaoPessoal = new InformacaoPessoal();
        }

        public AlterarInformacaoPessoal_UI(InformacaoPessoal informacaoPessoal) :this()
        {
            InformacaoPessoal = informacaoPessoal;  
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
                    Close();
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

        public void LimparEAtualizarDados()
        {
            TxtId.Text = "";
            TxtTitulo.Text = "";
            TxtDescricao.Text = "";
        }

        private void BtnSair_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
