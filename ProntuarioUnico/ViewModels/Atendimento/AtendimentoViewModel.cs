using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProntuarioUnico.ViewModels.Atendimento
{
    public class AtendimentoViewModel
    {
        public Int32? CodigoPessoaFisica { get; set; }
        public Int32? CodigoTipoAtendimento { get; set; }
        public Int32? CodigoEspecialidade { get; set; }

        public String Sintomas { get; set; }
        public String Diagnostico { get; set; }
        public String Prescricao { get; set; }

        public String Observacao { get; set; }

        public AtendimentoViewModel()
        {

        }

        public bool Valido()
        {
            if (!CodigoPessoaFisica.HasValue)
                return false;

            if (!CodigoTipoAtendimento.HasValue)
                return false;

            if (!CodigoEspecialidade.HasValue)
                return false;

            return true;
        }
    }
}