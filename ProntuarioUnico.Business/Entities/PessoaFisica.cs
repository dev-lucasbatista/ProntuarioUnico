using ProntuarioUnico.Business.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioUnico.Business.Entities
{
    public class PessoaFisica : BaseEntity
    {
        public Int32 Codigo { get; set; }
        public String Nome { get; set; }
        public String CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }

        internal PessoaFisica()
        {

        }

        public PessoaFisica(string nome, DateTime dataNascimento, string Email, string cPF, string senha)
        {
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
            this.Email = Email;
            this.CPF = cPF;
            this.Senha = senha;
            this.Ativo = true;
            this.DataAtualizacao = DateTime.Now;
        }

        public void Alterar(string cPF, DateTime dataNascimento, string nome, string email, string senha)
        {
            if (!string.IsNullOrEmpty(cPF) && !string.IsNullOrWhiteSpace(cPF))
                this.CPF = cPF;

            if (!string.IsNullOrEmpty(senha) && !string.IsNullOrWhiteSpace(senha))
                this.Senha = senha;

            this.DataNascimento = dataNascimento;
            this.Nome = nome;
            this.Email = email;
            this.Ativo = true;
            this.DataAtualizacao = DateTime.Now;
        }
    }
}