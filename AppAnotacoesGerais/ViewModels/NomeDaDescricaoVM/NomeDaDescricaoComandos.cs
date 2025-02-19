using AppAnotacoesGerais.Comandos;
using System.Windows.Input;

namespace AppAnotacoesGerais.ViewModels.NomeDaDescricaoVM
{
    public partial class NomeDaDescricaoVielModel//Comandos
    {
        //Cadastrar 
        private ICommand _comandoDeCadastrarNomeDaDescricao;
        public ICommand ComandoDeCadastrarNomeDaDescricao
        {
            get
            {
                _comandoDeCadastrarNomeDaDescricao ??= new RelayCommand(param => Cadastrar(NomeDaDescricaoModel));
                return _comandoDeCadastrarNomeDaDescricao;
            }
        }

        //Alterar 
        private ICommand _comandoDeAlterarNomeDaDescricao;
        public ICommand ComandoDeDeAlterarNomeDaDescricao
        {
            get
            {
                _comandoDeAlterarNomeDaDescricao ??= new RelayCommand(param => Alterar(NomeDaDescricaoModel));
                return _comandoDeAlterarNomeDaDescricao;
            }
        }

        //Excluir 
        private ICommand _comandoDeExcluirNomeDaDescricao;
        public ICommand ComandoDeDeExcluirNomeDaDescricao
        {
            get
            {
                _comandoDeExcluirNomeDaDescricao ??= new RelayCommand(param => Excluir(NomeDaDescricaoModel));
                return _comandoDeExcluirNomeDaDescricao;
            }
        }

        //Atualizar
        private ICommand _comandoDeAtualizarNomeDaDescricao;
        public ICommand ComandoDeDeAtualizarNomeDaDescricao
        {
            get
            {
                _comandoDeAtualizarNomeDaDescricao ??= new RelayCommand(param => AtualizarDados());
                return _comandoDeAtualizarNomeDaDescricao;
            }
        }
    }
}
