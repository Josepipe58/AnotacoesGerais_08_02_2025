using AppAnotacoesGerais.Comandos;
using System.Windows.Input;

namespace AppAnotacoesGerais.ViewModels.CategoriasVM
{
    public partial class CategoriaViewModel//Comandos
    {
        //|Cadastrar 
        private ICommand _comandoDeCadastrarCategoria;
        public ICommand ComandoDeCadastrarCategoria
        {
            get
            {
                _comandoDeCadastrarCategoria ??= new RelayCommand(param => Cadastrar(CategoriaModel));
                return _comandoDeCadastrarCategoria;
            }
        }

        //Alterar 
        private ICommand _comandoDeAlterarCategoria;
        public ICommand ComandoDeDeAlterarCategoria
        {
            get
            {
                _comandoDeAlterarCategoria ??= new RelayCommand(param => Alterar(CategoriaModel));
                return _comandoDeAlterarCategoria;
            }
        }

        //Excluir 
        private ICommand _comandoDeExcluirCategoria;
        public ICommand ComandoDeDeExcluirCategoria
        {
            get
            {
                _comandoDeExcluirCategoria ??= new RelayCommand(param => Excluir(CategoriaModel));
                return _comandoDeExcluirCategoria;
            }
        }

        //Atualizar
        private ICommand _comandoDeAtualizarCategoria;
        public ICommand ComandoDeDeAtualizarCategoria
        {
            get
            {
                _comandoDeAtualizarCategoria ??= new RelayCommand(param => AtualizarDados());
                return _comandoDeAtualizarCategoria;
            }
        }
    }
}
