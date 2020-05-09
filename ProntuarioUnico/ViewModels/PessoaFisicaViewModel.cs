using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProntuarioUnico.ViewModels
{
    public class PessoaFisicaViewModel
    {
        public Int32 Codigo { get; set; }
        public String Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public String Email { get; set; }
        public String CPF { get; set; }
        public bool AlterarSenha { get; set; }
        public String SenhaAntiga { get; set; }
        public String NovaSenha { get; set; }
        public String ConfirmarSenhaNova { get; set; }

        public PessoaFisicaViewModel()
        {

        }

        public bool Valido()
        {
            if (string.IsNullOrEmpty(Nome) && string.IsNullOrWhiteSpace(Nome))
                return false;

            if (DataNascimento == default(DateTime) || DataNascimento == DateTime.MinValue)
                return false;

            if (string.IsNullOrEmpty(Email) && string.IsNullOrWhiteSpace(Email))
                return false;

            if (string.IsNullOrEmpty(CPF) && string.IsNullOrWhiteSpace(CPF))
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