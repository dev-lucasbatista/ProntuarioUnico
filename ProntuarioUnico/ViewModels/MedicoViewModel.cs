using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProntuarioUnico.ViewModels
{
    public class MedicoViewModel
    {
        public Int32 Codigo { get; set; }
        public String CRM { get; set; }
        public Int32 CodigoPessoaFisica { get; set; }
        public String NomeGuerra { get; set; }
        public String Email { get; set; }
        public bool AlterarSenha { get; set; }
        public String SenhaAntiga { get; set; }
        public String NovaSenha { get; set; }
        public String ConfirmarSenhaNova { get; set; }

        public MedicoViewModel()
        {

        }

        public bool Valido()
        {
            if (string.IsNullOrEmpty(CRM) && string.IsNullOrWhiteSpace(CRM))
                return false;

            if (string.IsNullOrEmpty(NomeGuerra) && string.IsNullOrWhiteSpace(NomeGuerra))
                return false;

            if (string.IsNullOrEmpty(Email) && string.IsNullOrWhiteSpace(Email))
                return false;

            if (AlterarSenha)
            {
                bool vazio = !string.IsNullOrEmpty(SenhaAntiga) && !string.IsNullOrWhiteSpace(SenhaAntiga) &&
                                !string.IsNullOrEmpty(NovaSenha) && !string.IsNullOrWhiteSpace(NovaSenha) &&
                                    !string.IsNullOrEmpty(ConfirmarSenhaNova) && !string.IsNullOrWhiteSpace(ConfirmarSenhaNova);

                return vazio;
            }

            return true;
        }
    }
}