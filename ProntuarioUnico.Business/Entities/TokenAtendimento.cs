using ProntuarioUnico.Business.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioUnico.Business.Entities
{
    public class TokenAtendimento : BaseEntity
    {
        public Int32 CodigoTokenAtendimento { get; set; }
        public Int32 NumeroAtendimento { get; set; }
        public String Token { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataExpiracao { get; set; }
        public DateTime? DataConfirmacao { get; set; }

        internal TokenAtendimento()
        {

        }

        public TokenAtendimento(int numeroAtendimento, string token)
        {
            this.NumeroAtendimento = numeroAtendimento;
            this.Token = token;
            this.DataCriacao = DateTime.Now;
            this.DataExpiracao = this.DataCriacao.AddHours(3);
            this.Ativo = true;
            this.DataAtualizacao = DateTime.Now;
        }

        public void ConfirmarToken()
        {
            this.DataConfirmacao = DateTime.Now;
            this.Ativo = true;
            this.DataAtualizacao = DateTime.Now;
        }

        public bool Valido()
        {
            return !DataConfirmacao.HasValue && DateTime.Now <= DataExpiracao;
        }
    }
}
