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
    public class MedicoConfig : EntityTypeConfiguration<Medico>
    {
        public MedicoConfig()
        {
            ToTable("MEDICO", "DBO");
            HasKey(p => p.Codigo);
            Property(p => p.Codigo).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Codigo).HasColumnName("CD_MEDICO");
            Property(p => p.CRM).HasColumnName("CRM_MEDICO");
            Property(p => p.CodigoPessoaFisica).HasColumnName("CD_PESSOA_FISICA");
            Property(p => p.NomeGuerra).HasColumnName("NM_GUERRA");
            Property(p => p.Email).HasColumnName("DS_EMAIL");
            Property(p => p.Senha).HasColumnName("DS_SENHA");
            Property(p => p.Ativo).HasColumnName("IE_ATIVO");
            Property(p => p.DataAtualizacao).HasColumnName("DT_ATUALIZACAO");
        }
    }
}
