using AcessarDadosDoBanco.Entities;

namespace AppAnotacoesGerais.Models
{
    public class InformacaoPessoalModel : ModelBase
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

        private string _titulo;
        public string Titulo
        {
            get { return _titulo; }
            set
            {
                _titulo = value;
                OnPropertyChanged(nameof(Titulo));
            }
        }

        private string _descricao;
        public string Descricao
        {
            get { return _descricao; }
            set
            {
                _descricao = value;
                OnPropertyChanged(nameof(Descricao));
            }
        }

        public InformacaoPessoalModel() { }

        public InformacaoPessoalModel(InformacaoPessoal informacaoPessoal)
        {
             Id = informacaoPessoal.Id;
            Titulo = informacaoPessoal.Titulo;
            Descricao = informacaoPessoal.Descricao;
        }
    }
}
