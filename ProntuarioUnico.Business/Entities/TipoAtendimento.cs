using ProntuarioUnico.Business.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioUnico.Business.Entities
{
    public class TipoAtendimento : BaseEntity
    {
        public Int32 CodigoTipoAtendimento { get; set; }
        public String DescricaoTipoAtendimento { get; set; }

        internal TipoAtendimento()
        {

        }
    }
}
