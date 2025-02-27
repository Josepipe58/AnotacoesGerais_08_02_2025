using AcessarDadosDoBanco.ContextoDeDados;
using AcessarDadosDoBanco.Modelos;
using GerenciarDados.Mensagens;

namespace GerenciarDados.AcessarDados
{
    public class InformacaoPessoal_AD(bool Save = true) : Repositorio<InformacaoPessoal>(Save)
    {
        public static List<InformacaoPessoal> ObterInformacaoPessoal()
        {
            try
            {
                using Contexto contexto = new();
                var listaDeInformacaoPessoal = contexto.TInformacaoPessoal.ToList();

                return [.. listaDeInformacaoPessoal];
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ObterInformacaoPessoal";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static List<InformacaoPessoal> ObterInformacaoPessoalPorId(int id)
        {
            try
            {
                using Contexto contexto = new();
                var listaDeInformacoesPessoais = contexto.TInformacaoPessoal.Select(d => new InformacaoPessoal()
                {
                    Id = d.Id,
                    Titulo = d.Titulo,
                    Descricao = d.Descricao                   
                }).Where(an => an.Id == id).OrderByDescending(d => d.Id).ToList();

                return [.. listaDeInformacoesPessoais];
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ObterInformacaoPessoalPorId";
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
    }
}
