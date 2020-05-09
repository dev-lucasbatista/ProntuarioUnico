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
    public class EspecialidadeAtendimentoConfig : EntityTypeConfiguration<EspecialidadeAtendimento>
    {
        public EspecialidadeAtendimentoConfig()
        {
            ToTable("ESPECIALIDADE_ATENDIMENTO", "DBO");
            HasKey(p => p.CodigoEspecialidade);
            Property(p => p.CodigoEspecialidade).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.CodigoEspecialidade).HasColumnName("ID_ESPECIALIDADE");
            Property(p => p.DescricaoEspecialidade).HasColumnName("DS_ESPECIALIDADE");
            Property(p => p.Ativo).HasColumnName("IE_ATIVO");
            Property(p => p.DataAtualizacao).HasColumnName("DT_ATUALIZACAO");
        }
    }
}
