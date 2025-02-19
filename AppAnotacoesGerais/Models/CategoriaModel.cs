using AcessarDadosDoBanco.Entities;

namespace AppAnotacoesGerais.Models
{
    public class CategoriaModel : ModelBase
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _nomeDaCategoria;
        public string NomeDaCategoria
        {
            get { return _nomeDaCategoria; }
            set
            {
                _nomeDaCategoria = value;
                OnPropertyChanged(nameof(NomeDaCategoria));
            }
        }

        public CategoriaModel() { }

        public CategoriaModel(Categoria categoria)
        {
            Id = categoria.Id;
            NomeDaCategoria = categoria.NomeDaCategoria;
        }
    }
}
