using AppAnotacoesGerais.Comandos;
using AppAnotacoesGerais.Views.AnotacoesGeraisViews;
using System.Windows.Input;

namespace AppAnotacoesGerais.ViewModels.AnotacoesGeraisVM
{
    public partial class AnotacaoGeralViewModel//Comandos
    {
        //|Cadastrar 
        private ICommand _comandoDeCadastrarAnotacaoGeral;
        public ICommand ComandoDeCadastrarAnotacaoGeral
        {
            get
            {
                _comandoDeCadastrarAnotacaoGeral ??= new RelayCommand(param => Cadastrar(AnotacaoGeralModel));
                return _comandoDeCadastrarAnotacaoGeral;
            }
        }

        //Alterar 
        private ICommand _comandoDeAlterarAnotacaoGeral;
        public ICommand ComandoDeDeAlterarAnotacaoGeral
        {
            get
            {
                _comandoDeAlterarAnotacaoGeral ??= new RelayCommand(param => Alterar(AnotacaoGeralModel));
                return _comandoDeAlterarAnotacaoGeral;
            }
        }

        //Excluir 
        private ICommand _comandoDeExcluirAnotacaoGeral;
        public ICommand ComandoDeDeExcluirAnotacaoGeral
        {
            get
            {
                _comandoDeExcluirAnotacaoGeral ??= new RelayCommand(param => Excluir(AnotacaoGeralModel));
                return _comandoDeExcluirAnotacaoGeral;
            }
        }

        //Atualizar
        private ICommand _comandoDeAtualizarAnotacaoGeral;
        public ICommand ComandoDeDeAtualizarAnotacaoGeral
        {
            get
            {
                _comandoDeAtualizarAnotacaoGeral ??= new RelayCommand(param => AtualizarDados());
                return _comandoDeAtualizarAnotacaoGeral;
            }
        }

        //Consultar AnotacaoGeral 
        private ICommand _comandoDeConsultarAnotacaoGeral;
        public ICommand ComandoDeDeConsultarAnotacaoGeral
        {
            get
            {
                _comandoDeConsultarAnotacaoGeral ??= new RelayCommand(param => ConsultarAnotacaoGeral());
                return _comandoDeConsultarAnotacaoGeral;
            }
        }
    }
}
