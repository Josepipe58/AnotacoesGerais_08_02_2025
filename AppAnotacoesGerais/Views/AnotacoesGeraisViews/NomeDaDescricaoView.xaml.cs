using AcessarDadosDoBanco.Entities;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppAnotacoesGerais.Views.AnotacoesGeraisViews
{
    public partial class NomeDaDescricaoView : UserControl
    {
        public string _nomeDoMetodo = string.Empty;
        public NomeDaDescricaoView()
        {
            InitializeComponent();
            ComboBoxDeCategorias();
        }

        private void ComboBoxDeCategorias()
        {
            try
            {
                // Combobox Categorias.
                Categoria_AD categoria_AD = new();
                CbxCategoria.ItemsSource = categoria_AD.SelecionarTodos();
                CbxCategoria.DisplayMemberPath = "NomeDaCategoria";
                CbxCategoria.SelectedValuePath = "Id";
                CbxCategoria.SelectedIndex = 0;
                TxtNomeDaDescricao.Focus();
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ComboBoxDeCategorias";
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
        }

        private void TxtPesquisar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text != "")
            {
                var listafiltrada = NomeDaDescricao_AD.ObterNomeDaDescricao()
                    .Where(nd => nd.Nome.ToLower().Contains(textBox.Text.ToLower()));
                DtgDados.ItemsSource = null;
                DtgDados.ItemsSource = listafiltrada;
            }
            else
            {
                DtgDados.ItemsSource = NomeDaDescricao_AD.ObterNomeDaDescricao();
            }
        }

        private void DtgDados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DtgDados.SelectedItems.Count >= 0)
            {
                if (DtgDados.SelectedItems[0].GetType() == typeof(NomeDaDescricao))
                {
                    NomeDaDescricao nomeDaDescricao = (NomeDaDescricao)DtgDados.SelectedItems[0];

                    TxtIdCategoria.Text = nomeDaDescricao.CategoriaId.ToString();
                    CbxCategoria.Text = nomeDaDescricao.NomeDaCategoria;
                    TxtIdSubCategoria.Text = nomeDaDescricao.SubCategoriaId.ToString();
                    CbxSubCategoria.Text = nomeDaDescricao.NomeDaSubCategoria;
                    TxtIdNomeDaDescricao.Text = nomeDaDescricao.Id.ToString();
                    TxtNomeDaDescricao.Text = nomeDaDescricao.Nome;
                    TxtNomeDaDescricao.Focus();
                }
            }
        }

        private void BtnLimpar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            TxtPesquisar.Text = null;
            DtgDados.ItemsSource = NomeDaDescricao_AD.ObterNomeDaDescricao();
        }

        private void BtnAtualizar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            TxtPesquisar.Text = null;
            TxtNomeDaDescricao.Focus();
            ComboBoxDeCategorias();
        }
    }
}
