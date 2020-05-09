using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProntuarioUnico.ViewModels.Relatorio
{
    public class AtendimentoSimplificadoPDFViewModel
    {
        public String Especialidade { get; set; }
        public String TotalEspecialidade { get; set; }

        public String TotalConsulta { get; set; }
        public String TotalExame { get; set; }
        public String TotalCirurgia { get; set; }

        public AtendimentoSimplificadoPDFViewModel()
        {

        }
    }
}