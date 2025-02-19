using AcessarDadosDoBanco.Context;
using AcessarDadosDoBanco.Entities;
using GerenciarDados.Mensagens;

namespace GerenciarDados.AcessarDados
{
    public class Categoria_AD(bool Save = true) : Repositorio<Categoria>(Save)
    {
        public static ListaDeCategorias ObterCategorias()
        {
            try
            {
                using AppDbContexto contexto = new();
                var listaDeCategorias = contexto.TCategoria.ToList();

                return [.. listaDeCategorias];
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ObterCategorias";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }
    }
}
