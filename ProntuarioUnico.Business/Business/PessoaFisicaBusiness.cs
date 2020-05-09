using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.Business.Interfaces.Business;
using ProntuarioUnico.Business.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioUnico.Business.Business
{
    public class PessoaFisicaBusiness : IPessoaFisicaBusiness
    {
        private readonly IPessoaFisicaRepository PessoaFisicaRepository;

        public PessoaFisicaBusiness(IPessoaFisicaRepository pessoaFisicaRepository)
        {
            this.PessoaFisicaRepository = pessoaFisicaRepository;
        }
    }
}
