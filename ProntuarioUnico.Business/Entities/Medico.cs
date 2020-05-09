using ProntuarioUnico.Business.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioUnico.Business.Entities
{
    public class Medico : BaseEntity
    {
        public Int32 Codigo { get; set; }
        public String CRM { get; set; }
        public Int32 CodigoPessoaFisica { get; set; }
        public String NomeGuerra { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }

        internal Medico()
        {

        }

        public Medico(string cRM, string nomeGuerra, string email, string senha)
        {
            this.CRM = cRM;
            this.NomeGuerra = nomeGuerra;
            this.Email = email;
            this.Senha = senha;
        }

        public void Alterar(string cRM, string nomeGuerra, string email, string senha)
        {
            this.CRM = cRM;
            this.NomeGuerra = nomeGuerra;
            this.Email = email;
            this.Senha = senha;
        }
    }
}
