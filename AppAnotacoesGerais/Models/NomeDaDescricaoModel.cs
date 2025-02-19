using AcessarDadosDoBanco.Entities;

namespace AppAnotacoesGerais.Models
{
    public class NomeDaDescricaoModel : ModelBase
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

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set
            {
                _nome = value;
                OnPropertyChanged(nameof(Nome));
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
        private int _subCategoriaId;
        public int SubCategoriaId
        {
            get { return _subCategoriaId; }
            set
            {
                _subCategoriaId = value;
                OnPropertyChanged(nameof(SubCategoriaId));
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
        public virtual SubCategoriaModel SubCategoriaModel { get; set; } = new SubCategoriaModel();

        public NomeDaDescricaoModel() { }

        public NomeDaDescricaoModel(NomeDaDescricao nomeDaDescricao)
        {
            Id = nomeDaDescricao.Id;
            Nome = nomeDaDescricao.Nome;
            CategoriaId = nomeDaDescricao.CategoriaId;
            SubCategoriaId = nomeDaDescricao.SubCategoriaId;
            NomeDaCategoria = nomeDaDescricao.NomeDaCategoria;
            NomeDaSubCategoria = nomeDaDescricao.NomeDaSubCategoria;
        }
    }
}
