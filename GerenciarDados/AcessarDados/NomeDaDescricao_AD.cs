using AcessarDadosDoBanco.Context;
using AcessarDadosDoBanco.Entities;
using GerenciarDados.Mensagens;

namespace GerenciarDados.AcessarDados
{
    public class NomeDaDescricao_AD(bool Save = true) : Repositorio<NomeDaDescricao>(Save)
    {        
        public static List<NomeDaDescricao> ObterNomeDaDescricao()
        {
            try
            {
                using AppDbContexto contexto = new();
                var listaDoNomeDaDescricao = contexto.TSubCategoria.Join(contexto.TCategoria,
                    sc => sc.CategoriaId,
                    c => c.Id,
                    (sc, c) => new { sc, c })
                    .Join(contexto.TNomeDaDescricao,
                    scc => scc.sc.Id,
                    nd => nd.SubCategoriaId,
                    (scc, nd) => new NomeDaDescricao
                    {
                        Id = nd.Id,
                        Nome = nd.Nome,
                        CategoriaId = nd.CategoriaId,
                        NomeDaCategoria = nd.Categoria.NomeDaCategoria,
                        SubCategoriaId = nd.SubCategoriaId,
                        NomeDaSubCategoria = nd.SubCategoria.NomeDaSubCategoria
                    }).OrderByDescending(sc => sc.Id).ToList();

                return [.. listaDoNomeDaDescricao];
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "CarregarDataGrid";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);

                return [];
            }
        }

        public static List<NomeDaDescricao> ObterNomeDaDescricaoPorId(int id)
        {
            try
            {
                using AppDbContexto contexto = new();
                var listaDoNomeDaDescricao = contexto.TSubCategoria.Join(contexto.TCategoria,
                    sc => sc.CategoriaId,
                    c => c.Id,
                    (sc, c) => new { sc, c })
                    .Join(contexto.TNomeDaDescricao,
                    scc => scc.sc.Id,
                    nd => nd.CategoriaId,
                    (scc, nd) => new NomeDaDescricao
                    {
                        Id = nd.Id,
                        Nome = nd.Nome,
                        CategoriaId = nd.CategoriaId,
                        NomeDaCategoria = nd.NomeDaCategoria,
                        SubCategoriaId = nd.SubCategoriaId,
                        NomeDaSubCategoria = nd.NomeDaSubCategoria
                    }).Where(sc => sc.SubCategoriaId == id).OrderByDescending(sc => sc.Id).ToList();

                return [.. listaDoNomeDaDescricao];
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ObterNomeDaDescricaoPorId";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);

                return [];
            }
        }
    }
}
