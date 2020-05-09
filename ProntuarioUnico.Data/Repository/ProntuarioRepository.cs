using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.Business.Interfaces.Data;
using ProntuarioUnico.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioUnico.Data.Repository
{
    public class ProntuarioRepository : IProntuarioRepository
    {
        private readonly ProntuarioUnicoContext Context;

        public ProntuarioRepository()
        {
            this.Context = new ProntuarioUnicoContext();
        }

        public List<Prontuario> Listar(int codigo)
        {
            return this.Context.Prontuarios.Where(_ => _.CodigoPessoaFisica == codigo).ToList();
        }

        public List<Prontuario> ListarDetalhado(DateTime dataInicial, DateTime dataFinal, int? numeroAtendimento, int? codigoEspecialidade, int? codigoTipoAtendimento)
        {
            DateTime dataFim = dataFinal.Date.AddDays(1);

            List<Prontuario> prontuarios = this.Context.Prontuarios.Where(_ => _.DataAtendimento >= dataInicial && _.DataAtendimento < dataFim).ToList();

            if (numeroAtendimento.HasValue)
            {
                int nrAtendimento = numeroAtendimento.Value;
                prontuarios = prontuarios.Where(_ => _.NumeroAtendimento == nrAtendimento).ToList();
            }

            if (codigoEspecialidade.HasValue)
            {
                int cdEspecialidade = codigoEspecialidade.Value;
                prontuarios = prontuarios.Where(_ => _.CodigoEspecialidade == cdEspecialidade).ToList();
            }

            if (codigoTipoAtendimento.HasValue)
            {
                int cdTipoAtendimento = codigoTipoAtendimento.Value;
                prontuarios = prontuarios.Where(_ => _.CodigoTipoAtendimento == cdTipoAtendimento).ToList();
            }

            return prontuarios.OrderByDescending(_ =>_.DataAtendimento).ToList();
        }
    }
}
