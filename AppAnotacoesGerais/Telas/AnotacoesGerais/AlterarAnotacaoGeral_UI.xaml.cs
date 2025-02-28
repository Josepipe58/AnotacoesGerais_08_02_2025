using AcessarDadosDoBanco.Modelos;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System.Windows;
using System.Windows.Controls;

namespace AppAnotacoesGerais.Telas.AnotacoesGerais
{
    public partial class AlterarAnotacaoGeral_UI : Window
    {
        public AnotacaoGeral AnotacaoGeral { get; set; }
        public string _nomeDoMetodo = string.Empty;
        public AlterarAnotacaoGeral_UI()
        {
            InitializeComponent();
            ComboBoxCategoria();
        }
        public AlterarAnotacaoGeral_UI(AnotacaoGeral anotacaoGeral) : this()
        {
            AnotacaoGeral = anotacaoGeral;
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
                    GerenciarMensagens.SucessoAoAlterar(anotacaoGeral.Id);
                    Close();
                }
                catch (Exception ex)
                {
                    _nomeDoMetodo = "Alterar";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    return;
                }
            }
            else if (TxtId.Text == "" && TxtDescricao.Text != "")
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

        private void BtnSair_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
