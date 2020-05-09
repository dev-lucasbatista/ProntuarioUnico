using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProntuarioUnico.ViewModels.Relatorio
{
    public class AtendimentoPDFView
    {
        public String NumeroAtendimento { get; set; }
        public String TipoAtendimento { get; set; }
        public String DataAtendimento { get; set; }
        public String NomeMedico { get; set; }
        public String Especialidade { get; set; }
        public String Sintomas { get; set; }
        public String Diagnostico { get; set; }
        public String Prescricao { get; set; }
        public String Observacoes { get; set; }

        public AtendimentoPDFView()
        {

        }
    }
}