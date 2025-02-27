using System.Windows;
using System.Windows.Controls;

namespace AppAnotacoesGerais.Telas.InformacoesPessoais
{
    public partial class CaixaDeSenha : UserControl
    {

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(CaixaDeSenha), new PropertyMetadata(string.Empty));

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public CaixaDeSenha()
        {
            InitializeComponent();
        }

        private void CaixaDeSenha_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = CxaDeSenha.Password;
        }
    }
}
