using AcessarDadosDoBanco.Entities;

namespace AppAnotacoesGerais.Models
{
    public class AnotacaoGeralModel : ModelBase
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

        private string _nomeDaDescricao;
        public string NomeDaDescricao
        {
            get { return _nomeDaDescricao; }
            set
            {
                _nomeDaDescricao = value;
                OnPropertyChanged(nameof(NomeDaDescricao));
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
        private DateTime _data;
        public DateTime Data
        {
            get { return _data; }
            set
            {
                _data = value;
                OnPropertyChanged(nameof(Data));
            }
        }

        //Essa propriedade pertence ao TextBox de pesquisar por Anotacão Geral.
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

        //Essa propriedade pertence ao TextBox de contar registros de Anotacões.
        private int _contador;
        public int Contador
        {
            get { return _contador; }
            set
            {
                _contador = value;
                OnPropertyChanged(nameof(Contador));
            }
        }

        public AnotacaoGeralModel() { }

        public AnotacaoGeralModel(AnotacaoGeral anotacaoGeral)
        {
            Id = anotacaoGeral.Id;
            NomeDaCategoria = anotacaoGeral.NomeDaCategoria;
            NomeDaSubCategoria = anotacaoGeral.NomeDaSubCategoria;
            NomeDaDescricao = anotacaoGeral.NomeDaDescricao;
            Descricao = anotacaoGeral.Descricao;
            Data = anotacaoGeral.Data;
        }
    }
}
