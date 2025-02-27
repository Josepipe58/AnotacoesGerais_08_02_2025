using AcessarDadosDoBanco.ContextoDeDados;
using GerenciarDados.Mensagens;
using Microsoft.EntityFrameworkCore;

namespace GerenciarDados.AcessarDados
{
    public class Repositorio<T> : IDisposable where T : class
    {
        public static string _nomeDoMetodo = string.Empty;
        private readonly Contexto _contexto;

        public bool Salvar { get; set; } = true;

        public Repositorio(bool save = true)
        {
            Salvar = save;
            _contexto = new Contexto();
        }

        public T Cadastrar(T objeto)
        {
            _contexto.Set<T>().Add(objeto);
            if (Salvar)
            {                
                SaveChanges();
            }
            return objeto;
        }

        public T Alterar(T objeto)
        {
            _contexto.Entry(objeto).State = EntityState.Modified;
            if (Salvar)
            {
                SaveChanges();
            }
            return objeto;
        }

        public void Excluir(T objeto)
        {
            _contexto.Set<T>().Remove(objeto);
            if (Salvar)
            {
                SaveChanges();
            }
        }

        public void Excluir(params object[] variavel)
        {
            var obj = SelecionarPK(variavel);
            Excluir(obj);
        }

        public void SaveChanges()
        {
            _contexto.SaveChanges();
        }

        public List<T> SelecionarTodos()
        {
            try
            {
                return _contexto.Set<T>().ToList();
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "SelecionarTodos";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public T SelecionarPK(params object[] variavel)
        {
            try
            {
                return _contexto.Set<T>().Find(variavel);
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "SelecionarPK";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return null;
            }
        }

        public void Dispose()
        {
            // limpar conexões do Banco de Dados.
            _contexto.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
