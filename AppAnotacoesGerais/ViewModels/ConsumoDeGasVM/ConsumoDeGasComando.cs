using AppAnotacoesGerais.Comandos;
using System.Windows.Input;

namespace AppAnotacoesGerais.ViewModels.ConsumoDeGasVM
{
    public partial class ConsumoDeGasViewModel//Comandos
    {
        //|Cadastrar 
        private ICommand _comandoDeCadastrarConsumoDeGas;
        public ICommand ComandoDeCadastrarConsumoDeGas
        {
            get
            {
                _comandoDeCadastrarConsumoDeGas ??= new RelayCommand(param => Cadastrar(ConsumoDeGasModel));
                return _comandoDeCadastrarConsumoDeGas;
            }
        }

        //Alterar 
        private ICommand _comandoDeAlterarConsumoDeGas;
        public ICommand ComandoDeDeAlterarConsumoDeGas
        {
            get
            {
                _comandoDeAlterarConsumoDeGas ??= new RelayCommand(param => Alterar(ConsumoDeGasModel));
                return _comandoDeAlterarConsumoDeGas;
            }
        }

        //Excluir 
        private ICommand _comandoDeExcluirConsumoDeGas;
        public ICommand ComandoDeDeExcluirConsumoDeGas
        {
            get
            {
                _comandoDeExcluirConsumoDeGas ??= new RelayCommand(param => Excluir(ConsumoDeGasModel));
                return _comandoDeExcluirConsumoDeGas;
            }
        }

        //Atualizar
        private ICommand _comandoDeAtualizarConsumoDeGas;
        public ICommand ComandoDeDeAtualizarConsumoDeGas
        {
            get
            {
                _comandoDeAtualizarConsumoDeGas ??= new RelayCommand(param => AtualizarDados());
                return _comandoDeAtualizarConsumoDeGas;
            }
        }
    }
}
