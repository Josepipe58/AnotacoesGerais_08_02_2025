using AcessarDadosDoBanco.Entities;
using AppAnotacoesGerais.Comandos;
using AppAnotacoesGerais.Models;
using GerenciarDados.AcessarDados;

namespace AppAnotacoesGerais.ViewModels.AnotacoesGeraisVM
{
    public partial class AnotacaoGeralViewModel : RelayCommand//Classe Principal
    {
        public string _nomeDoMetodo = string.Empty;

        public AnotacaoGeralModel AnotacaoGeralModel { get; set; }

        //Lista do DataGrid Dados
        private ListaDeAnotacoesGerais _listaDeAnotacoesGerais;
        public ListaDeAnotacoesGerais ListaDeAnotacoesGerais
        {
            get { return _listaDeAnotacoesGerais; }
            set
            {
                if (_listaDeAnotacoesGerais != value)
                {
                    _listaDeAnotacoesGerais = value;
                    OnPropertyChanged(nameof(ListaDeAnotacoesGerais));
                }
            }
        }

        public AnotacaoGeralViewModel()
        {
            //Categoria = new Categoria();
            AnotacaoGeralModel = new AnotacaoGeralModel();
            ListaDeAnotacoesGerais = [];

            //DataGrid Dados           
            ListaDeAnotacoesGerais = AnotacaoGeral_AD.ObterAnotacoesGerais();
        }
    }
}
