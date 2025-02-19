using AcessarDadosDoBanco.Entities;
using AppAnotacoesGerais.Models;
using AppAnotacoesGerais.Views.AnotacoesGeraisViews;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System.Windows;

namespace AppAnotacoesGerais.ViewModels.AnotacoesGeraisVM
{
    public partial class AnotacaoGeralViewModel//Gerenciar
    {
        //Cadastrar
        public void Cadastrar(AnotacaoGeralModel anotacaoGeralModel)
        {
            if (anotacaoGeralModel.Id == 0 && anotacaoGeralModel.NomeDaCategoria != null && anotacaoGeralModel.NomeDaCategoria != "")
            {
                try
                {
                    AnotacaoGeral_AD anotacaoGeral_AD = new();
                    AnotacaoGeral anotacaoGeral = new()
                    {
                        NomeDaCategoria = anotacaoGeralModel.NomeDaCategoria,
                        NomeDaSubCategoria = anotacaoGeralModel.NomeDaSubCategoria,
                        NomeDaDescricao = anotacaoGeralModel.NomeDaDescricao,
                        Descricao = anotacaoGeralModel.Descricao,
                        Data = anotacaoGeralModel.Data,
                    };

                    anotacaoGeral_AD.Cadastrar(anotacaoGeral);
                    GerenciarMensagens.SucessoAoCadastrar(anotacaoGeral.Id);
                    LimparDados();
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Cadastrar";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
            else if (anotacaoGeralModel.Id > 0 && anotacaoGeralModel.NomeDaCategoria != null)
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
        public void Alterar(AnotacaoGeralModel anotacaoGeralModel)
        {
            if (anotacaoGeralModel.Id > 0 && anotacaoGeralModel.NomeDaCategoria != null && anotacaoGeralModel.NomeDaCategoria != "")
            {
                try
                {
                    AnotacaoGeral_AD anotacaoGeral_AD = new();
                    AnotacaoGeral anotacaoGeral = new()
                    {
                        Id = anotacaoGeralModel.Id,
                        NomeDaCategoria = anotacaoGeralModel.NomeDaCategoria,
                        NomeDaSubCategoria = anotacaoGeralModel.NomeDaSubCategoria,
                        NomeDaDescricao = anotacaoGeralModel.NomeDaDescricao,
                        Descricao = anotacaoGeralModel.Descricao,
                        Data = anotacaoGeralModel.Data,
                    };
                    anotacaoGeral_AD.Alterar(anotacaoGeral);
                    GerenciarMensagens.SucessoAoAlterar(anotacaoGeral.Id);
                    LimparDados();
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Alterar";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
            else if (anotacaoGeralModel.Id == 0 && anotacaoGeralModel.NomeDaCategoria != null)
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
        public void Excluir(AnotacaoGeralModel anotacaoGeralModel)
        {
            if (anotacaoGeralModel.Id > 0 && anotacaoGeralModel.NomeDaCategoria != null && anotacaoGeralModel.NomeDaCategoria != "")
            {
                MessageBoxResult resultado = GerenciarMensagens.ConfirmarExcluir(anotacaoGeralModel.Id);
                if (resultado == MessageBoxResult.No)
                {
                    LimparDados();
                    return;
                }
                try
                {
                    AnotacaoGeral_AD anotacaoGeral_AD = new();
                    AnotacaoGeral anotacaoGeral = new()
                    {
                        Id = anotacaoGeralModel.Id
                    };
                    anotacaoGeral_AD.Excluir(anotacaoGeral);
                    GerenciarMensagens.SucessoAoExcluir(anotacaoGeral.Id);

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
            else if (anotacaoGeralModel.Id == 0 && anotacaoGeralModel.NomeDaCategoria != null)
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

        //Consultar
        public void ConsultarAnotacaoGeral()
        {            
            var alterarAG = new AlterarAnotacaoGeralView(AnotacaoGeralModel);
            try
            {
                AnotacaoGeral_AD anotacaoGeral_AD = new();
                AnotacaoGeral anotacaoGeral = new();
                bool retorno = anotacaoGeral_AD.VerificarRegistros(AnotacaoGeralModel.Id);
                if (retorno)
                {
                    anotacaoGeral.Id = AnotacaoGeralModel.Id;
                    var linha = AnotacaoGeral_AD.ObterAnotacoesGeraisPorId(anotacaoGeral.Id);
                    if (AnotacaoGeralModel.Id >= 0)
                    {
                        if (linha.Count >= 0)
                        {
                            if (linha[0].GetType() == typeof(AnotacaoGeral))
                            {
                                anotacaoGeral = linha[0];
                                alterarAG.TxtId.Text = Convert.ToString(anotacaoGeral.Id);                                
                                alterarAG.CbxCategoria.Text = anotacaoGeral.NomeDaCategoria.ToString();
                                alterarAG.CbxSubCategoria.Text = anotacaoGeral.NomeDaSubCategoria.ToString();
                                alterarAG.TxtDescricao.Text = anotacaoGeral.Descricao.ToString();
                                alterarAG.DtpData.Text = anotacaoGeral.Data.ToString();
                            }
                        }
                    }
                    alterarAG.Show();
                }
                else
                {
                    _nomeDoMetodo = "ConsultarAnotacaoGeral";
                    GerenciarMensagens.MensagemDeErroDeObterId(AnotacaoGeralModel.Id, _nomeDoMetodo);
                }
            }
            catch (Exception erro)
            {
                _ = MessageBox.Show($"Erro ao conectar-se com o Banco de Dados.\nDetalhes do erro: {erro.Message}");
                return;
            }
        }

        //Limpar
        public void LimparDados()
        {
            AnotacaoGeralModel.Id = 0;            
            AnotacaoGeralModel.Descricao = null;
            ListaDeAnotacoesGerais = AnotacaoGeral_AD.ObterAnotacoesGerais();
        }

        //Atualizar
        public void AtualizarDados()
        {
            AnotacaoGeralModel.NomeDaCategoria = null;
            AnotacaoGeralModel.NomeDaSubCategoria = null;
            AnotacaoGeralModel.Data = DateTime.Now;
            LimparDados();
        }
    }
}
