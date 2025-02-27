using AppAnotacoesGerais.Comandos;
using System.Windows;
using System.Windows.Controls;

namespace AppAnotacoesGerais.Telas.InformacoesPessoais
{
    public partial class Login_UI : UserControl
    {
        ComandosDaTelaPrincipal ComandosDaTelaPrincipal { get; set; }
        public Login_UI()
        {
            InitializeComponent();
            ComandosDaTelaPrincipal = new ComandosDaTelaPrincipal();
        }
    }
}
