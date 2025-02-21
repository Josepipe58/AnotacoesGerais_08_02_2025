using AcessarDadosDoBanco.Entities;

namespace AppAnotacoesGerais.Models
{
    public class ConsumoDeGasModel : ModelBase
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

        private DateTime _dataAnterior;
        public DateTime DataAnterior
        {
            get { return _dataAnterior; }
            set
            {
                _dataAnterior = value;
                OnPropertyChanged(nameof(DataAnterior));
            }
        }

        private DateTime _dataDaTroca;
        public DateTime DataDaTroca
        {
            get { return _dataDaTroca; }
            set
            {
                _dataDaTroca = value;
                OnPropertyChanged(nameof(DataDaTroca));
            }
        }

        private int _diasDeConsumo;
        public int DiasDeConsumo
        {
            get { return _diasDeConsumo; }
            set
            {
                _diasDeConsumo = value;
                OnPropertyChanged(nameof(DiasDeConsumo));
            }
        }

        private DateTime _dataDaCompra;
        public DateTime DataDaCompra
        {
            get { return _dataDaCompra; }
            set
            {
                _dataDaCompra = value;
                OnPropertyChanged(nameof(DataDaCompra));
            }
        }

        private decimal _preco;
        public decimal Preco
        {
            get { return _preco; }
            set
            {
                _preco = value;
                OnPropertyChanged(nameof(Preco));
            }
        }

        private string _fornecedor;
        public string Fornecedor
        {
            get { return _fornecedor; }
            set
            {
                _fornecedor = value;
                OnPropertyChanged(nameof(Fornecedor));
            }
        }

        public ConsumoDeGasModel() { }

        public ConsumoDeGasModel(ConsumoDeGas consumoDeGas)
        {
            Id = consumoDeGas.Id;
            DataDaTroca = consumoDeGas.DataDaTroca;
            DiasDeConsumo = consumoDeGas.DiasDeConsumo;
            DataDaCompra = consumoDeGas.DataDaCompra;
            Preco = consumoDeGas.Preco;
            Fornecedor = consumoDeGas.Fornecedor;
        }
    }
}
