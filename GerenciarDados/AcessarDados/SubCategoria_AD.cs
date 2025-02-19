using AcessarDadosDoBanco.Context;
using AcessarDadosDoBanco.Entities;
using GerenciarDados.Mensagens;

namespace GerenciarDados.AcessarDados
{
    public class SubCategoria_AD(bool Save = true) : Repositorio<SubCategoria>(Save)
    {
        public static ListaDeSubCategorias ObterSubCategorias()
        {
            try
            {
                using AppDbContexto contexto = new();
                var listaDeSubCategorias = contexto.TSubCategoria.Join(contexto.TCategoria,
                    sc => sc.CategoriaId,
                    c => c.Id,
                    (sc, c) => new SubCategoria
                    {
                        Id = sc.Id,
                        NomeDaSubCategoria = sc.NomeDaSubCategoria,
                        CategoriaId = sc.CategoriaId,
                        NomeDaCategoria = c.NomeDaCategoria,

                    }).OrderByDescending(sc => sc.Id).ToList();

                return [.. listaDeSubCategorias];

            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ObterSubCategorias";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);

                return [];
            }
        }

        public static ListaDeSubCategorias ObterSubCategoriasPorId(int id)
        {
            try
            {
                using AppDbContexto contexto = new();
                var listaDeSubCategorias = contexto.TSubCategoria.Join(contexto.TCategoria,
                    sc => sc.CategoriaId,
                    c => c.Id,
                    (sc, c) => new SubCategoria
                    {
                        Id = sc.Id,
                        NomeDaSubCategoria = sc.NomeDaSubCategoria,
                        CategoriaId = sc.CategoriaId,
                        NomeDaCategoria = sc.Categoria.NomeDaCategoria,

                    }).Where(sc => sc.CategoriaId == id).ToList();

                return [.. listaDeSubCategorias];
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ObterSubCategoriasPorId";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);

                return [];
            }
        }
    }
}
