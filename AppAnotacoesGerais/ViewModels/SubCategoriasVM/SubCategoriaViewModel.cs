using AppAnotacoesGerais.Comandos;
using AppAnotacoesGerais.Models;
using AcessarDadosDoBanco.Entities;
using GerenciarDados.AcessarDados;

namespace AppAnotacoesGerais.ViewModels.SubCategoriasVM
{
    public partial class SubCategoriaViewModel : RelayCommand
    {
        public string _nomeDoMetodo = string.Empty;
        public SubCategoriaModel SubCategoriaModel { get; set; }

        //Lista do DataGrid Dados
        private ListaDeSubCategorias _listaDeSubCategorias;
        public ListaDeSubCategorias ListaDeSubCategorias
        {
            get { return _listaDeSubCategorias; }
            set
            {
                if (_listaDeSubCategorias != value)
                {
                    _listaDeSubCategorias = value;
                    OnPropertyChanged(nameof(ListaDeSubCategorias));
                }
            }
        }

        public SubCategoriaViewModel()
        {
            SubCategoriaModel = new SubCategoriaModel();

            //DataGrid Dados
            ListaDeSubCategorias = [];
            ListaDeSubCategorias = SubCategoria_AD.ObterSubCategorias();
        }
    }
}
