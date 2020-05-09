using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.Business.Interfaces.Data;
using ProntuarioUnico.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioUnico.Data.Repository
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        private readonly ProntuarioUnicoContext Context;

        public AtendimentoRepository()
        {
            this.Context = new ProntuarioUnicoContext();
        }

        public Atendimento Alterar(Atendimento atendimentoAlterado)
        {
            int numeroAtendimento = atendimentoAlterado.NumeroAtendimento;
            Atendimento atendimento = this.Context.Atendimentos.SingleOrDefault(_ => _.NumeroAtendimento == numeroAtendimento);

            if(atendimento == default(Atendimento))
                throw new Exception("Atendimento não encontrada");

            atendimento.Alterar(atendimentoAlterado.Sintomas, atendimentoAlterado.Diagnostico, atendimentoAlterado.Prescricao, atendimentoAlterado.Observacao);

            var entry = Context.Entry(atendimento);
            entry.State = EntityState.Modified;
            this.Context.SaveChanges();

            return atendimento;
        }

        public Atendimento AlterarToken(Atendimento atendimentoAlterado)
        {
            int numeroAtendimento = atendimentoAlterado.NumeroAtendimento;
            Atendimento atendimento = this.Context.Atendimentos.SingleOrDefault(_ => _.NumeroAtendimento == numeroAtendimento);

            if (atendimento == default(Atendimento))
                throw new Exception("Atendimento não encontrada");

            atendimento.AlterarToken(atendimentoAlterado.Token);

            var entry = Context.Entry(atendimento);
            entry.State = EntityState.Modified;
            this.Context.SaveChanges();

            return atendimento;
        }

        public Atendimento Cadastrar(Atendimento novoAtendimento)
        {
            Atendimento atendimento = new Atendimento(novoAtendimento.CodigoPessoaFisica, novoAtendimento.CodigoMedico, novoAtendimento.CodigoTipoAtendimento, 
                                        novoAtendimento.CodigoEspecialidade, novoAtendimento.DataAtendimento, novoAtendimento.Sintomas, novoAtendimento.Diagnostico, 
                                        novoAtendimento.Prescricao, novoAtendimento.Observacao);

            this.Context.Atendimentos.Add(atendimento);
            this.Context.SaveChanges();

            return atendimento;
        }

        public Atendimento Obter(int numeroAtendimento)
        {
            return this.Context.Atendimentos.SingleOrDefault(_ => _.NumeroAtendimento == numeroAtendimento);
        }
    }
}
