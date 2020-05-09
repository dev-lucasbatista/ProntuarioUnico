using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.Business.Interfaces.Data;
using ProntuarioUnico.Data.Context;
using System;
using System.Data.Entity;
using System.Linq;

namespace ProntuarioUnico.Data.Repository
{
    public class PessoaFisicaRepository : IPessoaFisicaRepository
    {
        private readonly ProntuarioUnicoContext Context;

        public PessoaFisicaRepository()
        {
            this.Context = new ProntuarioUnicoContext();
        }

        public PessoaFisica Obter(Int32 codigo)
        {
            return this.Context.Pessoas.SingleOrDefault(_ => _.Codigo == codigo);
        }

        public PessoaFisica Obter(string cpf)
        {
            return this.Context.Pessoas.SingleOrDefault(_ => _.CPF == cpf);
        }

        public PessoaFisica Alterar(PessoaFisica novaPessoaFisica)
        {
            PessoaFisica pessoa = this.Obter(novaPessoaFisica.Codigo);

            if (pessoa == default(PessoaFisica))
                throw new Exception("Pessoa Física não encontrada");

            pessoa.Alterar(novaPessoaFisica.CPF, novaPessoaFisica.DataNascimento, novaPessoaFisica.Nome, novaPessoaFisica.Email, novaPessoaFisica.Senha);

            var entry = Context.Entry(pessoa);
            entry.State = EntityState.Modified;
            this.Context.SaveChanges();

            return pessoa;
        }

        public PessoaFisica Cadastrar(PessoaFisica novaPessoaFisica)
        {
            PessoaFisica pessoa = new PessoaFisica(novaPessoaFisica.Nome, novaPessoaFisica.DataNascimento, novaPessoaFisica.Email, novaPessoaFisica.CPF, novaPessoaFisica.Senha);

            this.Context.Pessoas.Add(pessoa);
            this.Context.SaveChanges();

            return pessoa;
        }

        public Boolean CPFExistente(string cpf)
        {
            return this.Context.Pessoas.Any(_ => _.CPF == cpf);
        }
    }
}
