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
    class ProntuarioConfig : EntityTypeConfiguration<Prontuario>
    {
        public ProntuarioConfig()
        {
            ToTable("PRONTUARIO", "DBO");
            HasKey(p => p.NumeroAtendimento);
            Property(p => p.NumeroAtendimento).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.NumeroAtendimento).HasColumnName("NR_ATENDIMENTO");
            Property(p => p.CodigoPessoaFisica).HasColumnName("CD_PESSOA_FISICA");
            Property(p => p.TipoAtendimento).HasColumnName("DS_TIPO_ATENDIMENTO");
            Property(p => p.DataAtendimento).HasColumnName("DT_ATENDIMENTO");
            Property(p => p.NomeMedico).HasColumnName("NM_MEDICO");
            Property(p => p.Especialidade).HasColumnName("DS_ESPECIALIDADE");
            Property(p => p.Observacoes).HasColumnName("DS_OBSERVACAO");
            Property(p => p.CodigoTipoAtendimento).HasColumnName("ID_TIPO_ATENDIMENTO");
            Property(p => p.CodigoEspecialidade).HasColumnName("ID_ESPECIALIDADE");
            Property(p => p.Sintomas).HasColumnName("DS_SINTOMA");
            Property(p => p.Diagnostico).HasColumnName("DS_DIAGNOSTICO");
            Property(p => p.Prescricao).HasColumnName("DS_PRESCRICAO");
        }
    }
}