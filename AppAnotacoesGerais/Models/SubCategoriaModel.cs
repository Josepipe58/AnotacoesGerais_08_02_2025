using AcessarDadosDoBanco.Entities;

namespace AppAnotacoesGerais.Models
{
    public class SubCategoriaModel : ModelBase
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

        private string _nomeSubCategoria;
        public string NomeDaSubCategoria
        {
            get { return _nomeSubCategoria; }
            set
            {
                _nomeSubCategoria = value;
                OnPropertyChanged(nameof(NomeDaSubCategoria));
            }
        }

        private int _categoriaId;
        public int CategoriaId
        {
            get { return _categoriaId; }
            set
            {
                _categoriaId = value;
                OnPropertyChanged(nameof(CategoriaId));
            }
        }

        //Essas propriedades são usadas como objeto de transferência ou variáveis.
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

        //Essa propriedade pertence ao TextBox de pesquisar por SubCategorias.
        private string _pesquisar;
        public string Pesquisar
        {
            get { return _pesquisar; }
            set
            {
                _pesquisar = value;
                OnPropertyChanged(nameof(Pesquisar));
            }
        }
        public virtual CategoriaModel CategoriaModel { get; set; } = new CategoriaModel();

        public SubCategoriaModel() { }

        public SubCategoriaModel(SubCategoria subCategoria)
        {
            Id = subCategoria.Id;
            NomeDaSubCategoria = subCategoria.NomeDaSubCategoria;
            CategoriaId = subCategoria.CategoriaId;
            NomeDaCategoria = subCategoria.NomeDaCategoria;
        }
    }
}
