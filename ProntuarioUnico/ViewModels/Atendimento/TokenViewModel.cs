using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProntuarioUnico.ViewModels.Atendimento
{
    public class TokenViewModel
    {
        public Int32? NumeroAtendimento { get; set; }
        public String Token { get; set; }

        public TokenViewModel()
        {

        }

        public bool Valido()
        {
            if (!NumeroAtendimento.HasValue)
                return false;

            if (string.IsNullOrEmpty(Token) || string.IsNullOrWhiteSpace(Token))
                return false;

            return true;
        }
    }
}