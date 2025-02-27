using AcessarDadosDoBanco.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace AcessarDadosDoBanco.ContextoDeDados
{ 
    public class Contexto : DbContext
    {
        public Contexto() { }

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public virtual DbSet<AnotacaoGeral> TAnotacaoGeral { get; set; }
        public virtual DbSet<Categoria> TCategoria { get; set; }
        public virtual DbSet<ConsumoDeGas> TConsumoDeGas { get; set; }
        public virtual DbSet<InformacaoPessoal> TInformacaoPessoal { get; set; }
        public virtual DbSet<NomeDaDescricao> TNomeDaDescricao { get; set; }
        public virtual DbSet<SubCategoria> TSubCategoria { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlServer(" Data Source = JOSEPIPE-PC\\FINANCEIRO; Initial Catalog = AnotacoesGerais; " +
                    "Integrated Security = True; TrustServerCertificate=True");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
