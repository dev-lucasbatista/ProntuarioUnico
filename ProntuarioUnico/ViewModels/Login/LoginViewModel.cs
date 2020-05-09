using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProntuarioUnico.ViewModels.Login
{
    public class LoginViewModel
    {
        public String CPF { get; set; }
        public String Senha { get; set; }

        public LoginViewModel()
        {

        }

        public bool Valido()
        {
            return !String.IsNullOrEmpty(this.CPF) && !String.IsNullOrWhiteSpace(this.CPF) &&
                    !String.IsNullOrEmpty(this.Senha) && !String.IsNullOrWhiteSpace(this.Senha);
        }
    }
}