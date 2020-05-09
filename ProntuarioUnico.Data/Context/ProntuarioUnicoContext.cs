using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.Data.Context.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioUnico.Data.Context
{
    public class ProntuarioUnicoContext : DbContext
    {
        public DbSet<PessoaFisica> Pessoas { get; set; }
        public DbSet<Prontuario> Prontuarios { get; set; }
        public DbSet<EspecialidadeAtendimento> EspecialidadesAtendimento { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<TokenAtendimento> Tokens { get; set; }
        public DbSet<TipoAtendimento> TiposAtendimento { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PessoaFisicaConfig());
            modelBuilder.Configurations.Add(new ProntuarioConfig());
            modelBuilder.Configurations.Add(new EspecialidadeAtendimentoConfig());
            modelBuilder.Configurations.Add(new AtendimentoConfig());
            modelBuilder.Configurations.Add(new MedicoConfig());
            modelBuilder.Configurations.Add(new TokenAtendimentoConfig());
            modelBuilder.Configurations.Add(new TipoAtendimentoConfig());

            Database.SetInitializer<ProntuarioUnicoContext>(null);
        }
    }
}
