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
    public class EspecialidadeAtendimentoRepository : IEspecialidadeAtendimentoRepository
    {
        private readonly ProntuarioUnicoContext Context;

        public EspecialidadeAtendimentoRepository()
        {
            this.Context = new ProntuarioUnicoContext();
        }

        public List<EspecialidadeAtendimento> ListarAtivos()
        {
            return this.Context.EspecialidadesAtendimento.Where(_ => _.Ativo == true).OrderBy(_ => _.DescricaoEspecialidade).ToList();
        }

        public EspecialidadeAtendimento Obter(int codigoEspecialidade)
        {
            return this.Context.EspecialidadesAtendimento.SingleOrDefault(_ => _.CodigoEspecialidade == codigoEspecialidade);
        }
    }
}
