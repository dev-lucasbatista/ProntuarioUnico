using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioUnico.Business.Entities.Base
{
    public class BaseEntity
    {
        public bool Ativo { get; set; }
        public DateTime DataAtualizacao { get; set; }

        internal BaseEntity()
        {

        }
    }
}
