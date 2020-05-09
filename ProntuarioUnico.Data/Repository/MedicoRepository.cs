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
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ProntuarioUnicoContext Context;

        public MedicoRepository()
        {
            this.Context = new ProntuarioUnicoContext();
        }

        public Medico Alterar(Medico medicoAlterado)
        {
            Medico medico = this.Obter(medicoAlterado.Codigo);

            if (medico == default(Medico))
                throw new Exception("Médico não encontrada");

            medico.Alterar(medicoAlterado.CRM, medicoAlterado.NomeGuerra, medicoAlterado.Email, medicoAlterado.Senha);

            var entry = Context.Entry(medico);
            entry.State = EntityState.Modified;
            this.Context.SaveChanges();

            return medico;
        }

        public Medico Obter(int codigo)
        {
            return this.Context.Medicos.SingleOrDefault(_ => _.Codigo == codigo);
        }

        public Medico Obter(string crm)
        {
            return this.Context.Medicos.SingleOrDefault(_ => _.CRM == crm);
        }

        public Boolean CRMExistente(string crm)
        {
            return this.Context.Medicos.Any(_ => _.CRM == crm);
        }
    }
}
