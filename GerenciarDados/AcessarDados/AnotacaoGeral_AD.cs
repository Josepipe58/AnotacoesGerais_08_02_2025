using AcessarDadosDoBanco.ContextoDeDados;
using AcessarDadosDoBanco.Modelos;
using GerenciarDados.Mensagens;
using System.Data;

namespace GerenciarDados.AcessarDados
{
    public class AnotacaoGeral_AD(bool Save = true) : Repositorio<AnotacaoGeral>(Save)
    {

        public static List<AnotacaoGeral> ObterAnotacoesGerais()
        {
            try
            {
                using Contexto contexto = new();
                var listaDeAnotacoesGerais = contexto.TAnotacaoGeral.Select(d => new AnotacaoGeral()
                {
                    Id = d.Id,
                    NomeDaCategoria = d.NomeDaCategoria,
                    NomeDaSubCategoria = d.NomeDaSubCategoria,
                    NomeDaDescricao = d.NomeDaDescricao,
                    Descricao = d.Descricao,
                    Data = d.Data,
                }).OrderByDescending(d => d.Id);

                return [.. listaDeAnotacoesGerais];
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ObterAnotacoesGerais";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static List<AnotacaoGeral> ObterAnotacoesGeraisPorId(int id)
        {
            try
            {
                using Contexto contexto = new();
                var listaDeAnotacoesGerais = contexto.TAnotacaoGeral.Select(d => new AnotacaoGeral()
                {
                    Id = d.Id,
                    NomeDaCategoria = d.NomeDaCategoria,
                    NomeDaSubCategoria = d.NomeDaSubCategoria,
                    NomeDaDescricao = d.NomeDaDescricao,
                    Descricao = d.Descricao,
                    Data = d.Data,
                }).Where(an => an.Id == id).OrderByDescending(d => d.Id);

                return [.. listaDeAnotacoesGerais];
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ObterAnotacoesGeraisPorId";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public bool VerificarRegistros(int id)
        {
            try
            {
                var verificarConsulta = SelecionarPK(id);
                if (verificarConsulta is not null)
                {
                    int retorno = Convert.ToInt32(verificarConsulta.Id);
                    return retorno != 0 && retorno > 0;
                }
                else
                {
                    //_nomeDoMetodo = "VerificarRegistros";
                    //GerenciarMensagens.MensagemDeErroDeObterId(id, _nomeDoMetodo);
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (id <= 0)
                {
                    _nomeDoMetodo = "VerificarRegistros";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    return false;
                }
                return true;
            }
        }

        public int ContadorRegistros()
        {
            try
            {
                int retorno = SelecionarTodos().Count;
                return retorno;

            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ContadorRegistros";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return 0;
            }
        }
    }
}
