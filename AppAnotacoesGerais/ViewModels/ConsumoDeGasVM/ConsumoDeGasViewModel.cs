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

        //Lista do DataGrid Dados
        private List<ConsumoDeGas> _listaDeCarregarCombobox;
        public List<ConsumoDeGas> ListaDeCarregarCombobox
        {
            get { return _listaDeCarregarCombobox; }
            set
            {
                if (_listaDeCarregarCombobox != value)
                {
                    _listaDeCarregarCombobox = value;
                    OnPropertyChanged(nameof(ListaDeCarregarCombobox));
                }
            }
        }

        public ConsumoDeGasViewModel()
        {
            //ConsumaDeGas = new ConsumaDeGas();
            ConsumoDeGasModel = new ConsumoDeGasModel();
            ListaDeConsumoDeGas = [];

            // Lista de Carregar Combobox
            ConsumoDeGas_AD consumoDeGas_AD = new();
            ListaDeCarregarCombobox = consumoDeGas_AD.SelecionarTodos();

            //DataGrid Dados            
            ListaDeConsumoDeGas = ConsumoDeGas_AD.ObterConsumoDeGas();
        }
    }
}
