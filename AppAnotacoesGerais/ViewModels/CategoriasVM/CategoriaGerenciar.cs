using AcessarDadosDoBanco.Entities;
using AppAnotacoesGerais.Models;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System.Windows;

namespace AppAnotacoesGerais.ViewModels.CategoriasVM
{
    public partial class CategoriaViewModel//Gerenciar
    {
        //Cadastrar
        public void Cadastrar(CategoriaModel categoriaModel)
        {
            if (categoriaModel.Id == 0 && categoriaModel.NomeDaCategoria != null && categoriaModel.NomeDaCategoria != "")
            {
                try
                {
                    Categoria_AD categoria_AD = new();
                    Categoria categoria = new()
                    {
                        NomeDaCategoria = categoriaModel.NomeDaCategoria
                    };

                    categoria_AD.Cadastrar(categoria);
                    GerenciarMensagens.SucessoAoCadastrar(categoria.Id);
                    LimparDados();
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Cadastrar";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
            else if (categoriaModel.Id > 0 && categoriaModel.NomeDaCategoria != null)
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
        public void Alterar(CategoriaModel categoriaModel)
        {
            if (categoriaModel.Id > 0 && categoriaModel.NomeDaCategoria != null && categoriaModel.NomeDaCategoria != "")
            {
                try
                {
                    Categoria_AD categoria_AD = new();
                    Categoria categoria = new()
                    {
                        Id = categoriaModel.Id,
                        NomeDaCategoria = categoriaModel.NomeDaCategoria
                    };  
                    categoria_AD.Alterar(categoria);
                    GerenciarMensagens.SucessoAoAlterar(categoria.Id);
                    LimparDados();
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Alterar";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
            else if (categoriaModel.Id == 0 && categoriaModel.NomeDaCategoria != null)
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
        public void Excluir(CategoriaModel categoriaModel)
        {
            if (categoriaModel.Id > 0 && categoriaModel.NomeDaCategoria != null && categoriaModel.NomeDaCategoria != "")
            {
                MessageBoxResult resultado = GerenciarMensagens.ConfirmarExcluir(categoriaModel.Id);
                if (resultado == MessageBoxResult.No)
                {
                    LimparDados();
                    return;
                }
                try
                {
                    Categoria_AD categoria_AD = new();
                    Categoria categoria = new()
                    {
                        Id = categoriaModel.Id                       
                    };
                    categoria_AD.Excluir(categoria);
                    GerenciarMensagens.SucessoAoExcluir(categoria.Id);

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
            else if (categoriaModel.Id == 0 && categoriaModel.NomeDaCategoria != null)
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
            CategoriaModel.Id = 0;
            CategoriaModel.NomeDaCategoria = null;
            ListaDeCategorias = Categoria_AD.ObterCategorias();
        }

        //Atualizar
        public void AtualizarDados()
        {            
            LimparDados();
        }
    }
}
