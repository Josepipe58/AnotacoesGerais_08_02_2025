using AcessarDadosDoBanco.Context;
using AcessarDadosDoBanco.Entities;
using GerenciarDados.Mensagens;

namespace GerenciarDados.AcessarDados
{
    public class ConsumoDeGas_AD(bool Save = true) : Repositorio<ConsumoDeGas>(Save)
    {
        public static List<ConsumoDeGas> ObterConsumoDeGas()
        {
            try
            {
                using AppDbContexto contexto = new();
                var listaDeConsumoDeGas = contexto.TConsumoDeGas.ToList();

                return [.. listaDeConsumoDeGas];
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ObterConsumoDeGas";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }
    }
}
