using AcessarDadosDoBanco.Entities;
using AppAnotacoesGerais.Models;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System.Windows;

namespace AppAnotacoesGerais.ViewModels.NomeDaDescricaoVM
{
    public partial class NomeDaDescricaoVielModel//Gerenciar
    {
        //Cadastrar
        public void Cadastrar(NomeDaDescricaoModel nomeDaDescricaoModel)
        {
            if (nomeDaDescricaoModel.Id == 0 && nomeDaDescricaoModel.Nome != null && nomeDaDescricaoModel.Nome != "")
            {
                try
                {
                    NomeDaDescricao_AD nomeDaDescricao_AD = new();
                    NomeDaDescricao nomeDaDescricao = new()
                    {
                        Nome = nomeDaDescricaoModel.Nome,
                        CategoriaId = nomeDaDescricaoModel.CategoriaId,
                        SubCategoriaId = nomeDaDescricaoModel.SubCategoriaId
                    };

                    nomeDaDescricao_AD.Cadastrar(nomeDaDescricao);


                    GerenciarMensagens.SucessoAoCadastrar(nomeDaDescricao.Id);
                    LimparDados();
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Cadastrar";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
            else if (nomeDaDescricaoModel.Id > 0 && nomeDaDescricaoModel.Nome != null)
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
        public void Alterar(NomeDaDescricaoModel nomeDaDescricaoModel)
        {
            if (nomeDaDescricaoModel.Id > 0 && nomeDaDescricaoModel.Nome != null && nomeDaDescricaoModel.Nome != "")
            {
                try
                {
                    NomeDaDescricao_AD nomeDaDescricao_AD = new();
                    NomeDaDescricao nomeDaDescricao = new()
                    {
                        Id = nomeDaDescricaoModel.Id,
                        Nome = nomeDaDescricaoModel.Nome,
                        CategoriaId = nomeDaDescricaoModel.CategoriaId,
                        SubCategoriaId = nomeDaDescricaoModel.SubCategoriaId
                    };
                    nomeDaDescricao_AD.Alterar(nomeDaDescricao);
                    GerenciarMensagens.SucessoAoAlterar(nomeDaDescricao.Id);
                    LimparDados();
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Alterar";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
            else if (nomeDaDescricaoModel.Id == 0 && nomeDaDescricaoModel.Nome != null)
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
        public void Excluir(NomeDaDescricaoModel nomeDaDescricaoModel)
        {
            if (nomeDaDescricaoModel.Id > 0 && nomeDaDescricaoModel.Nome != null && nomeDaDescricaoModel.Nome != "")
            {
                MessageBoxResult resultado = GerenciarMensagens.ConfirmarExcluir(nomeDaDescricaoModel.Id);
                if (resultado == MessageBoxResult.No)
                {
                    LimparDados();
                    return;
                }
                try
                {
                    NomeDaDescricao_AD nomeDaDescricao_AD = new();
                    NomeDaDescricao nomeDaDescricao = new()
                    {
                        Id = nomeDaDescricaoModel.Id
                    };

                    nomeDaDescricao_AD.Excluir(nomeDaDescricao);

                    GerenciarMensagens.SucessoAoExcluir(nomeDaDescricao.Id);
                    LimparDados();
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Excluir";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
            else if (nomeDaDescricaoModel.Id == 0 && nomeDaDescricaoModel.Nome != null)
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

        //Limpar Dados 
        public void LimparDados()
        {
            //Atenção! Não juntar esse método com AtualizarDados() para não limpar ComboBoxes ao fazer CRUD.
            //Também não zerar o NomeDaDescricao.CategoriaId para não apagar o ComboBox de Categorias.            
            NomeDaDescricaoModel.Id = 0;
            NomeDaDescricaoModel.Nome = null;
            NomeDaDescricaoModel.CategoriaModel.Id = 0;
            NomeDaDescricaoModel.SubCategoriaModel.Id = 0;
            ListaDeNomeDaDescricao = NomeDaDescricao_AD.ObterNomeDaDescricao();
        }

        //Limpar e Atualizar Dados
        public void AtualizarDados()
        {
            LimparDados();
        }
    }
}
