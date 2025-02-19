using AcessarDadosDoBanco.Entities;
using AppAnotacoesGerais.Comandos;
using AppAnotacoesGerais.Models;
using GerenciarDados.AcessarDados;

namespace AppAnotacoesGerais.ViewModels.CategoriasVM
{
    public partial class CategoriaViewModel : RelayCommand
    {
        public string _nomeDoMetodo = string.Empty;

        public CategoriaModel CategoriaModel { get; set; }

        //Lista do DataGrid Dados
        private ListaDeCategorias _listaDeCategorias;
        public ListaDeCategorias ListaDeCategorias
        {
            get { return _listaDeCategorias; }
            set
            {
                if (_listaDeCategorias != value)
                {
                    _listaDeCategorias = value;
                    OnPropertyChanged(nameof(ListaDeCategorias));
                }
            }
        }

        public CategoriaViewModel()
        {
            //Categoria = new Categoria();
            CategoriaModel = new CategoriaModel();
            ListaDeCategorias = [];

            //DataGrid Dados           
            ListaDeCategorias = Categoria_AD.ObterCategorias();
        }
    }
}
