using ProntuarioUnico.Business.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioUnico.Data.Context.EntityConfig
{
    public class AtendimentoConfig : EntityTypeConfiguration<Atendimento>
    {
        public AtendimentoConfig()
        {
            ToTable("ATENDIMENTO_PACIENTE", "DBO");
            HasKey(p => p.NumeroAtendimento);
            Property(p => p.NumeroAtendimento).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.NumeroAtendimento).HasColumnName("NR_ATENDIMENTO");
            Property(p => p.CodigoPessoaFisica).HasColumnName("CD_PESSOA_FISICA");
            Property(p => p.CodigoMedico).HasColumnName("CD_MEDICO");
            Property(p => p.CodigoTipoAtendimento).HasColumnName("ID_TIPO_ATENDIMENTO");
            Property(p => p.CodigoEspecialidade).HasColumnName("ID_ESPECIALIDADE");
            Property(p => p.DataAtendimento).HasColumnName("DT_ATENDIMENTO");

            Property(p => p.Token).HasColumnName("CD_TOKEN");

            Property(p => p.Sintomas).HasColumnName("DS_SINTOMA");
            Property(p => p.Diagnostico).HasColumnName("DS_DIAGNOSTICO");
            Property(p => p.Prescricao).HasColumnName("DS_PRESCRICAO");

            Property(p => p.Observacao).HasColumnName("DS_OBSERVACAO");
            Property(p => p.Ativo).HasColumnName("IE_ATIVO");
            Property(p => p.DataAtualizacao).HasColumnName("DT_ATUALIZACAO");
        }
    }
}
