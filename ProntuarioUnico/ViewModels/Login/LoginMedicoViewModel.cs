using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProntuarioUnico.ViewModels.Login
{
    public class LoginMedicoViewModel
    {
        public String CRM { get; set; }
        public String Senha { get; set; }

        public LoginMedicoViewModel()
        {

        }

        public bool Valido()
        {
            return !String.IsNullOrEmpty(this.CRM) && !String.IsNullOrWhiteSpace(this.CRM) &&
                    !String.IsNullOrEmpty(this.Senha) && !String.IsNullOrWhiteSpace(this.Senha);
        }
    }
}