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
    public class TipoAtendimentoRepository : ITipoAtendimentoRepository
    {
        private readonly ProntuarioUnicoContext Context;

        public TipoAtendimentoRepository()
        {
            this.Context = new ProntuarioUnicoContext();
        }

        public List<TipoAtendimento> ListarAtivos()
        {
            return this.Context.TiposAtendimento.Where(_ => _.Ativo == true).OrderBy(_ => _. DescricaoTipoAtendimento).ToList();
        }

        public TipoAtendimento Obter(int codigo)
        {
            return this.Context.TiposAtendimento.SingleOrDefault(_ => _.CodigoTipoAtendimento == codigo);
        }
    }
}
