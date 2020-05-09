using ProntuarioUnico.Business.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioUnico.Business.Entities
{
    public class Atendimento : BaseEntity
    {
        public Int32 NumeroAtendimento { get; set; }
        public Int32 CodigoPessoaFisica { get; set; }
        public Int32 CodigoMedico { get; set; }
        public Int32 CodigoTipoAtendimento { get; set; }
        public Int32 CodigoEspecialidade { get; set; }
        public DateTime DataAtendimento { get; set; }
        public String Token { get; set; }

        public String Sintomas { get; set; }
        public String Diagnostico { get; set; }
        public String Prescricao { get; set; }

        public String Observacao { get; set; }

        internal Atendimento()
        {

        }

        public Atendimento(int codigoPessoaFisica, int codigoMedico, int codigoTipoAtendimento, int codigoEspecialidade, DateTime dataAtendimento, 
                                string sintomas, string diagnostico, string prescricao, string observacao)
        {
            this.CodigoPessoaFisica = codigoPessoaFisica;
            this.CodigoMedico = codigoMedico;
            this.CodigoTipoAtendimento = codigoTipoAtendimento;
            this.CodigoEspecialidade = codigoEspecialidade;
            this.DataAtendimento = dataAtendimento;
            this.Sintomas = sintomas;
            this.Diagnostico = diagnostico;
            this.Prescricao = prescricao;
            this.Observacao = observacao;
            this.Ativo = true;
            this.DataAtualizacao = DateTime.Now;
        }

        public void Alterar(string sintomas, string diagnostico, string prescricao, string observacao)
        {
            this.Sintomas = sintomas;
            this.Diagnostico = diagnostico;
            this.Prescricao = prescricao;
            this.Observacao = observacao;
            this.Ativo = true;
            this.DataAtualizacao = DateTime.Now;
        }

        public void AlterarToken(string token)
        {
            this.Token = token;
            this.Ativo = true;
            this.DataAtualizacao = DateTime.Now;
        }
    }
}
