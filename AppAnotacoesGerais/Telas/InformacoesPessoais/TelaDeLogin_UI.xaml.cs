using AppAnotacoesGerais.Comandos;
using System.Windows;

namespace AppAnotacoesGerais.Telas.InformacoesPessoais
{
    public partial class TelaDeLogin_UI : Window
    {
        public TelaDeLogin_UI()
        {
            InitializeComponent();
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            ComandosDaTelaPrincipal comandosDaTelaPrincipal = new();

            if (PbSenha.Password == "bj250281")
            {              
                PbSenha.Password = null;
                Close();
            }
            else if (PbSenha.Password == "")
            {
                MessageBox.Show($"Digite sua senha para logar.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                PbSenha.Password = null;
            }
            else if (PbSenha.Password != "bj250281")
            {
                MessageBox.Show($"Senha inválida, tente novamente.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                PbSenha.Password = null;
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            PbSenha.Password = null;
            _ = PbSenha.Focus();
        }

        private void BtnSair_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
