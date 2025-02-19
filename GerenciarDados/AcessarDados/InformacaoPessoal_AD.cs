using AcessarDadosDoBanco.Context;
using AcessarDadosDoBanco.Entities;
using GerenciarDados.Mensagens;

namespace GerenciarDados.AcessarDados
{
    public class InformacaoPessoal_AD(bool Save = true) : Repositorio<InformacaoPessoal>(Save)
    {
        public static List<InformacaoPessoal> ConsultarPorTitulo(string titulo)
        {
            try
            {
                using AppDbContexto contexto = new();
                var listaDeInformacoesPessoais = contexto.TInformacaoPessoal.Select(ip => new InformacaoPessoal()
                {
                    Id = ip.Id,
                    Titulo = ip.Titulo,
                    Descricao = ip.Descricao
                }).Where(ip => ip.Titulo == titulo).OrderByDescending(ip => ip.Id).ToList();

                return [.. listaDeInformacoesPessoais];
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultarPorTitulo";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }
    }
}
