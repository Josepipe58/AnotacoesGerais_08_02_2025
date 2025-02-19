using AcessarDadosDoBanco.Entities;
using AppAnotacoesGerais.Comandos;
using AppAnotacoesGerais.Models;
using GerenciarDados.AcessarDados;

namespace AppAnotacoesGerais.ViewModels.ConsumoDeGasVM
{
    public partial class ConsumoDeGasViewModel : RelayCommand
    {
        public string _nomeDoMetodo = string.Empty;

        public ConsumoDeGasModel ConsumoDeGasModel { get; set; }

        //Lista do DataGrid Dados
        private ListaDeConsumoDeGas _listaDeConsumoDeGas;
        public ListaDeConsumoDeGas ListaDeConsumoDeGas
        {
            get { return _listaDeConsumoDeGas; }
            set
            {
                if (_listaDeConsumoDeGas != value)
                {
                    _listaDeConsumoDeGas = value;
                    OnPropertyChanged(nameof(ListaDeConsumoDeGas));
                }
            }
        }

        public ConsumoDeGasViewModel()
        {
            //ConsumaDeGas = new ConsumaDeGas();
            ConsumoDeGasModel = new ConsumoDeGasModel();
            ListaDeConsumoDeGas = [];

            //DataGrid Dados
            ConsumoDeGas_AD consumoDeGas_AD = new();
            ListaDeConsumoDeGas = ConsumoDeGas_AD.ObterConsumoDeGas();
        }
    }
}
