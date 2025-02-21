using AcessarDadosDoBanco.Entities;
using AppAnotacoesGerais.Models;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System.Windows;

namespace AppAnotacoesGerais.ViewModels.ConsumoDeGasVM
{
    public partial class ConsumoDeGasViewModel//Gerenciar
    {
        //Cadastrar
        public void Cadastrar(ConsumoDeGasModel consumoDeGasModel)
        {
            if (consumoDeGasModel.Id == 0 && consumoDeGasModel.DiasDeConsumo != 0 && consumoDeGasModel.Preco != 0 && consumoDeGasModel.Fornecedor != "")
            {
                try
                {
                    /*
                    DateTime dataInicial, dataFinal;
                    TimeSpan diasConsumo;
                    dataInicial = DateTime.Parse(CbxDataAnterior.Text);
                    dataFinal = DateTime.Parse(TxtDiaTroca.Text);
                    diasConsumo = dataFinal - dataInicial;
                    TbxDiasConsumo.Text = Convert.ToString(diasConsumo.Days);
                    */

                    ConsumoDeGas_AD consumoDeGas_AD = new();
                    ConsumoDeGas consumoDeGas = new()
                    {
                        DataAnterior = consumoDeGasModel.DataAnterior,
                        DataDaTroca = consumoDeGasModel.DataDaTroca,
                        DiasDeConsumo = consumoDeGasModel.DiasDeConsumo,
                        DataDaCompra = consumoDeGasModel.DataDaCompra,
                        Preco = consumoDeGasModel.Preco,
                        Fornecedor = consumoDeGasModel.Fornecedor
                    };
                    consumoDeGas_AD.Cadastrar(consumoDeGas);
                    GerenciarMensagens.SucessoAoCadastrar(consumoDeGas.Id);
                    LimparDados();
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Cadastrar";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
            else if (consumoDeGasModel.Id > 0 && consumoDeGasModel.DiasDeConsumo != 0 && consumoDeGasModel.Preco != 0 && consumoDeGasModel.Fornecedor != "")
            {
                GerenciarMensagens.ErroAoCadastrar();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                return;
            }
        }

        //Alterar
        public void Alterar(ConsumoDeGasModel consumoDeGasModel)
        {
            if (consumoDeGasModel.Id > 0 && consumoDeGasModel.DiasDeConsumo != 0 && consumoDeGasModel.Preco != 0 && consumoDeGasModel.Fornecedor != "")
            {
                try
                {
                    ConsumoDeGas_AD consumoDeGas_AD = new();
                    ConsumoDeGas consumoDeGas = new()
                    {
                        Id = consumoDeGasModel.Id,
                        DataAnterior = consumoDeGasModel.DataAnterior,
                        DataDaTroca = consumoDeGasModel.DataDaTroca,
                        DiasDeConsumo = consumoDeGasModel.DiasDeConsumo,
                        DataDaCompra = consumoDeGasModel.DataDaCompra,
                        Preco = consumoDeGasModel.Preco,
                        Fornecedor = consumoDeGasModel.Fornecedor
                    };
                    consumoDeGas_AD.Alterar(consumoDeGas);
                    GerenciarMensagens.SucessoAoAlterar(consumoDeGas.Id);
                    LimparDados();
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Alterar";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
            else if (consumoDeGasModel.Id == 0 && consumoDeGasModel.DiasDeConsumo != 0 && consumoDeGasModel.Preco != 0 && consumoDeGasModel.Fornecedor != "")
            {
                GerenciarMensagens.ErroAoAlterarOuExcluir();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                return;
            }
        }

        //Excluir
        public void Excluir(ConsumoDeGasModel consumoDeGasModel)
        {
            if (consumoDeGasModel.Id > 0 && consumoDeGasModel.DiasDeConsumo != 0 && consumoDeGasModel.Preco != 0 && consumoDeGasModel.Fornecedor != "")
            {
                MessageBoxResult resultado = GerenciarMensagens.ConfirmarExcluir(consumoDeGasModel.Id);
                if (resultado == MessageBoxResult.No)
                {
                    LimparDados();
                    return;
                }
                try
                {
                    ConsumoDeGas_AD consumoDeGas_AD = new();
                    ConsumoDeGas consumoDeGas = new()
                    {
                        Id = consumoDeGasModel.Id
                    };
                    consumoDeGas_AD.Excluir(consumoDeGas);
                    GerenciarMensagens.SucessoAoExcluir(consumoDeGas.Id);

                    LimparDados();
                    return;
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Excluir";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
            else if (consumoDeGasModel.Id == 0 && consumoDeGasModel.DiasDeConsumo != 0 && consumoDeGasModel.Preco != 0 && consumoDeGasModel.Fornecedor != "")
            {
                GerenciarMensagens.ErroAoAlterarOuExcluir();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                return;
            }
        }

        //Limpar
        public void LimparDados()
        {
            ConsumoDeGasModel.Id = 0;
            ConsumoDeGasModel.DiasDeConsumo = 0;
            ConsumoDeGasModel.Preco = 0;
            ConsumoDeGasModel.Fornecedor = "Digite o Nome da Empresa";
            ListaDeConsumoDeGas = ConsumoDeGas_AD.ObterConsumoDeGas();
        }

        //Atualizar
        public void AtualizarDados()
        {
            ConsumoDeGasModel.DataAnterior = DateTime.Now;
            LimparDados();
        }
    }
}
