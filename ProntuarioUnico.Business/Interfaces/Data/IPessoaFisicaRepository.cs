using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProntuarioUnico.Business.Entities;

namespace ProntuarioUnico.Business.Interfaces.Data
{
    public interface IPessoaFisicaRepository
    {
        PessoaFisica Obter(Int32 codigo);

        PessoaFisica Obter(String cpf);

        PessoaFisica Alterar(PessoaFisica novaPessoaFisica);

        PessoaFisica Cadastrar(PessoaFisica novaPessoaFisica);

        Boolean CPFExistente(String cpf);
    }
}
