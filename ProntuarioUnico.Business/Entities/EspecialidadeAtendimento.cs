using ProntuarioUnico.Business.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioUnico.Business.Entities
{
    public class EspecialidadeAtendimento : BaseEntity
    {
        public Int32 CodigoEspecialidade { get; set; }
        public String DescricaoEspecialidade { get; set; }

        internal EspecialidadeAtendimento()
        {

        }
    }
}
