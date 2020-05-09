using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProntuarioUnico.ViewModels.Filtros
{
    public class FiltroProntuarioViewModel
    {
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public Int32? NumeroAtendimento { get; set; }
        public Int32? CodigoEspecialidade { get; set; }
        public Int32? CodigoTipoAtendimento { get; set; }

        public FiltroProntuarioViewModel()
        {

        }

        public bool Valido()
        {
            if(DataInicial == DateTime.MinValue)
                return false;

            if (DataFinal == DateTime.MinValue)
                return false;

            if (DataInicial > DataFinal)
                return false;

            return true;
        }
    }
}