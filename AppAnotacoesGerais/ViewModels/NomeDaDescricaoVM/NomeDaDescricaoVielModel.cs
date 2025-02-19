using AcessarDadosDoBanco.Entities;
using AppAnotacoesGerais.Comandos;
using AppAnotacoesGerais.Models;
using GerenciarDados.AcessarDados;

namespace AppAnotacoesGerais.ViewModels.NomeDaDescricaoVM
{
    public partial class NomeDaDescricaoVielModel : RelayCommand
    {
        public string _nomeDoMetodo = string.Empty;
        public NomeDaDescricaoModel NomeDaDescricaoModel { get; set; }

        //Lista do DataGrid Dados
        private ListaDeNomeDaDescricao _listaDeNomeDaDescricao;
        public ListaDeNomeDaDescricao ListaDeNomeDaDescricao
        {
            get { return _listaDeNomeDaDescricao; }
            set
            {
                if (_listaDeNomeDaDescricao != value)
                {
                    _listaDeNomeDaDescricao = value;
                    OnPropertyChanged(nameof(ListaDeNomeDaDescricao));
                }
            }
        }

        //Lista do ComboBox Categorias.
        //private ListaDeCategorias _listaDeCategorias;
        //public ListaDeCategorias ListaDeCategorias
        //{
        //    get { return _listaDeCategorias; }
        //    set
        //    {
        //        if (_listaDeCategorias != value)
        //        {
        //            _listaDeCategorias = value;
        //            OnPropertyChanged(nameof(ListaDeCategorias));
        //        }
        //    }
        //}

        ////Lista do ComboBox SubCategorias.
        //private ListaDeSubCategorias _listaDeSubCategorias;
        //public ListaDeSubCategorias ListaDeSubCategorias
        //{
        //    get { return _listaDeSubCategorias; }
        //    set
        //    {
        //        if (_listaDeSubCategorias != value)
        //        {
        //            _listaDeSubCategorias = value;
        //            OnPropertyChanged(nameof(ListaDeSubCategorias));
        //        }
        //    }
        //}

        public NomeDaDescricaoVielModel()
        {
            //ComboBox de Categorias.           
            //ListaDeCategorias = Categoria_AD.ObterCategorias();

            //ComboBox de SubCategorias.           
            //ListaDeSubCategorias = SubCategoria_AD.ObterSubCategorias();
            NomeDaDescricaoModel = new NomeDaDescricaoModel();
            //DataGrid Dados
            ListaDeNomeDaDescricao = [];
            ListaDeNomeDaDescricao = NomeDaDescricao_AD.ObterNomeDaDescricao();
        }
    }
}
