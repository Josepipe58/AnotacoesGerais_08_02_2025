using AcessarDadosDoBanco.Entities;
using AppAnotacoesGerais.Models;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System.Windows;

namespace AppAnotacoesGerais.ViewModels.SubCategoriasVM
{
    public partial class SubCategoriaViewModel//Gerenciar
    {
        //Cadastrar
        public void Cadastrar(SubCategoriaModel subCategoriaModel)
        {
            if (subCategoriaModel.Id == 0 && subCategoriaModel.NomeDaSubCategoria != null && subCategoriaModel.NomeDaSubCategoria != "")
            {
                try
                {
                    SubCategoria_AD subCategoria_AD = new();
                    SubCategoria subCategoria = new()
                    {
                        NomeDaSubCategoria = subCategoriaModel.NomeDaSubCategoria,
                        CategoriaId = subCategoriaModel.CategoriaId
                    };
                    subCategoria_AD.Cadastrar(subCategoria);
                    GerenciarMensagens.SucessoAoCadastrar(subCategoria.Id);
                    LimparDados();
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Cadastrar";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
            else if (subCategoriaModel.Id > 0 && subCategoriaModel.NomeDaSubCategoria != null)
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
        public void Alterar(SubCategoriaModel subCategoriaModel)
        {
            if (subCategoriaModel.Id > 0 && subCategoriaModel.NomeDaSubCategoria != null && subCategoriaModel.NomeDaSubCategoria != "")
            {
                try
                {
                    SubCategoria_AD subCategoria_AD = new();
                    SubCategoria subCategoria = new()
                    {
                        Id = subCategoriaModel.Id,
                        NomeDaSubCategoria = subCategoriaModel.NomeDaSubCategoria,
                        CategoriaId = subCategoriaModel.CategoriaId
                    };
                    subCategoria_AD.Alterar(subCategoria);
                    GerenciarMensagens.SucessoAoAlterar(subCategoria.Id);
                    LimparDados();
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Alterar";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
            else if (subCategoriaModel.Id == 0 && subCategoriaModel.NomeDaSubCategoria != null)
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
        public void Excluir(SubCategoriaModel subCategoriaModel)
        {
            if (subCategoriaModel.Id > 0 && subCategoriaModel.NomeDaSubCategoria != null && subCategoriaModel.NomeDaSubCategoria != "")
            {
                MessageBoxResult resultado = GerenciarMensagens.ConfirmarExcluir(subCategoriaModel.Id);
                if (resultado == MessageBoxResult.No)
                {
                    LimparDados();
                    return;
                }
                try
                {
                    SubCategoria_AD subCategoria_AD = new();
                    SubCategoria subCategoria = new()
                    {
                        Id = subCategoriaModel.Id
                    };

                    subCategoria_AD.Excluir(subCategoria);

                    GerenciarMensagens.SucessoAoExcluir(subCategoria.Id);
                    LimparDados();
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Excluir";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
            else if (subCategoriaModel.Id == 0 && subCategoriaModel.NomeDaSubCategoria != null)
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
            SubCategoriaModel.Id = 0;
            SubCategoriaModel.NomeDaSubCategoria = null;
            SubCategoriaModel.CategoriaModel.Id = 0;
            ListaDeSubCategorias = SubCategoria_AD.ObterSubCategorias();
        }

        //Limpar e Atualizar Dados
        public void AtualizarDados()
        {
            LimparDados();
        }
    }
}
