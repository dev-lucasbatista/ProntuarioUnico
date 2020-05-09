using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProntuarioUnico.ViewModels.Login
{
    public class NovoUsuarioPessoaFisicaViewModel
    {
        public String Nome { get; set; }
        public String CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
        public String ConfirmarSenha { get; set; }

        public NovoUsuarioPessoaFisicaViewModel()
        {

        }

        public bool Valido()
        {
            if (string.IsNullOrEmpty(Nome) || string.IsNullOrWhiteSpace(Nome))
                return false;

            if (string.IsNullOrEmpty(CPF) || string.IsNullOrWhiteSpace(CPF))
                return false;

            if (DataNascimento == default(DateTime) || DataNascimento == DateTime.MinValue)
                return false;

            if (string.IsNullOrEmpty(Email) || string.IsNullOrWhiteSpace(Email))
                return false;

            if (string.IsNullOrEmpty(Senha) || string.IsNullOrWhiteSpace(Senha))
                return false;

            if (string.IsNullOrEmpty(ConfirmarSenha) || string.IsNullOrWhiteSpace(ConfirmarSenha))
                return false;

            if (!Senha.Equals(ConfirmarSenha))
                return false;

            return true;
        }
    }
}