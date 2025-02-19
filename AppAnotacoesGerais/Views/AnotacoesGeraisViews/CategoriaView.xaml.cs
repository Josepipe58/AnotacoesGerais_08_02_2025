using AcessarDadosDoBanco.Entities;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppAnotacoesGerais.Views.AnotacoesGeraisViews
{
    public partial class CategoriaView : UserControl
    {
        public string _nomeDoMetodo = string.Empty;
        public CategoriaView()
        {
            InitializeComponent();
        }

        private void DtgDados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DtgDados.SelectedIndex >= 0)
            {
                if (DtgDados.SelectedItems.Count >= 0)
                {
                    if (DtgDados.SelectedItems[0].GetType() == typeof(Categoria))
                    {
                        Categoria categoria = (Categoria)DtgDados.SelectedItems[0];

                        TxtId.Text = categoria.Id.ToString();
                        TxtCategoria.Text = categoria.NomeDaCategoria;
                        TxtCategoria.Focus();
                    }
                }
            }
        }
    }
}
