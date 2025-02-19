using AppAnotacoesGerais.Comandos;
using System.Windows.Input;

namespace AppAnotacoesGerais.ViewModels.SubCategoriasVM
{
    public partial class SubCategoriaViewModel//Comandos
    {
        //Cadastrar 
        private ICommand _comandoDeCadastrarSubCategoria;
        public ICommand ComandoDeCadastrarSubCategoria
        {
            get
            {
                _comandoDeCadastrarSubCategoria ??= new RelayCommand(param => Cadastrar(SubCategoriaModel));
                return _comandoDeCadastrarSubCategoria;
            }
        }

        //Alterar 
        private ICommand _comandoDeAlterarSubCategoria;
        public ICommand ComandoDeDeAlterarSubCategoria
        {
            get
            {
                _comandoDeAlterarSubCategoria ??= new RelayCommand(param => Alterar(SubCategoriaModel));
                return _comandoDeAlterarSubCategoria;
            }
        }

        //Excluir 
        private ICommand _comandoDeExcluirSubCategoria;
        public ICommand ComandoDeDeExcluirSubCategoria
        {
            get
            {
                _comandoDeExcluirSubCategoria ??= new RelayCommand(param => Excluir(SubCategoriaModel));
                return _comandoDeExcluirSubCategoria;
            }
        }

        //Atualizar
        private ICommand _comandoDeAtualizarSubCategoria;
        public ICommand ComandoDeDeAtualizarSubCategoria
        {
            get
            {
                _comandoDeAtualizarSubCategoria ??= new RelayCommand(param => AtualizarDados());
                return _comandoDeAtualizarSubCategoria;
            }
        }
    }
}
