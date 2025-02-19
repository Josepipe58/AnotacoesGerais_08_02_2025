using AcessarDadosDoBanco.Entities;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppAnotacoesGerais.Views.AnotacoesGeraisViews
{
    public partial class SubCategoriaView : UserControl
    {
        public string _nomeDoMetodo = string.Empty;
        public SubCategoriaView()
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
                TxtSubCategoria.Focus();
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ComboBoxDeCategorias";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }
        }

        private void TxtPesquisar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text != "")
            {
                var listafiltrada = SubCategoria_AD.ObterSubCategorias()
                    .Where(sc => sc.NomeDaSubCategoria.ToLower().Contains(textBox.Text.ToLower()));
                DtgDados.ItemsSource = null;
                DtgDados.ItemsSource = listafiltrada;
            }
            else
            {
                DtgDados.ItemsSource = SubCategoria_AD.ObterSubCategorias();
            }
        }

        private void DtgDados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DtgDados.SelectedItems.Count >= 0)
            {
                if (DtgDados.SelectedItems[0].GetType() == typeof(SubCategoria))
                {
                    SubCategoria subCategoria = (SubCategoria)DtgDados.SelectedItems[0];

                    TxtIdSubCategoria.Text = subCategoria.Id.ToString();
                    TxtSubCategoria.Text = subCategoria.NomeDaSubCategoria;
                    TxtIdCategoria.Text = subCategoria.CategoriaId.ToString();
                    CbxCategoria.Text = subCategoria.NomeDaCategoria;                   
                    TxtSubCategoria.Focus();
                }
            }
        }

        private void BtnLimpar_Click(object sender, RoutedEventArgs e)
        {
            TxtPesquisar.Text = null;
            DtgDados.ItemsSource = SubCategoria_AD.ObterSubCategorias();
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            TxtPesquisar.Text = null;            
            TxtSubCategoria.Focus();
            ComboBoxDeCategorias();
        }
    }
}
