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
    public class TipoAtendimentoConfig : EntityTypeConfiguration<TipoAtendimento>
    {
        public TipoAtendimentoConfig()
        {
            ToTable("TIPO_ATENDIMENTO", "DBO");
            HasKey(p => p.CodigoTipoAtendimento);
            Property(p => p.CodigoTipoAtendimento).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.CodigoTipoAtendimento).HasColumnName("ID_TIPO_ATENDIMENTO");
            Property(p => p.DescricaoTipoAtendimento).HasColumnName("DS_TIPO_ATENDIMENTO");
            Property(p => p.Ativo).HasColumnName("IE_ATIVO");
            Property(p => p.DataAtualizacao).HasColumnName("DT_ATUALIZACAO");
        }
    }
}
