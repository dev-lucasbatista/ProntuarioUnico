using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProntuarioUnico.ViewModels
{
    public class NovoPessoaFisicaViewModel
    {
        public String NomePessoaFisica { get; set; }
        public String CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
        public String ConfirmarSenha { get; set; }

        internal NovoPessoaFisicaViewModel()
        {

        }

        public bool CPFValido()
        {
            return Utils.Utils.CPFValido(this.CPF);
        }

        public bool ConfirmaSenha()
        {
            return Senha == ConfirmarSenha;
        }
    }
}