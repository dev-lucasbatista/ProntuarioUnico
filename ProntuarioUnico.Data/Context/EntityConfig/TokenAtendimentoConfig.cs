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
    public class TokenAtendimentoConfig : EntityTypeConfiguration<TokenAtendimento>
    {
        public TokenAtendimentoConfig()
        {
            ToTable("TOKEN_ATENDIMENTO", "DBO");
            HasKey(p => p.CodigoTokenAtendimento);
            Property(p => p.CodigoTokenAtendimento).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.CodigoTokenAtendimento).HasColumnName("ID_TOKEN_ATENDIMENTO");
            Property(p => p.NumeroAtendimento).HasColumnName("NR_ATENDIMENTO");
            Property(p => p.Token).HasColumnName("CD_TOKEN");
            Property(p => p.DataCriacao).HasColumnName("DT_CRIACAO");
            Property(p => p.DataExpiracao).HasColumnName("DT_EXPIRACAO");
            Property(p => p.DataConfirmacao).HasColumnName("DT_CONFIRMACAO");
            Property(p => p.Ativo).HasColumnName("IE_ATIVO");
            Property(p => p.DataAtualizacao).HasColumnName("DT_ATUALIZACAO");
        }
    }
}
