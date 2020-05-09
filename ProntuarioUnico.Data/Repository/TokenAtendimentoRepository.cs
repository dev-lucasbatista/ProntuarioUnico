using ProntuarioUnico.Business.Entities;
using ProntuarioUnico.Business.Interfaces.Data;
using ProntuarioUnico.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioUnico.Data.Repository
{
    public class TokenAtendimentoRepository : ITokenAtendimentoRepository
    {
        private readonly ProntuarioUnicoContext Context;

        public TokenAtendimentoRepository()
        {
            this.Context = new ProntuarioUnicoContext();
        }

        public TokenAtendimento Cadastrar(TokenAtendimento novoTokenAtendimento)
        {
            TokenAtendimento tokenAtendimento = new TokenAtendimento(novoTokenAtendimento.NumeroAtendimento, novoTokenAtendimento.Token);

            this.Context.Tokens.Add(tokenAtendimento);
            this.Context.SaveChanges();

            return tokenAtendimento;
        }

        public TokenAtendimento Obter(string token, int codigoAtendimento)
        {
            return this.Context.Tokens.SingleOrDefault(_ => _.Token == token && _.NumeroAtendimento == codigoAtendimento);
        }

        public TokenAtendimento ConfirmarToken(int codigo)
        {
            TokenAtendimento token = this.Context.Tokens.SingleOrDefault(_ => _.CodigoTokenAtendimento == codigo);

            if (token == default(TokenAtendimento))
                throw new Exception("Token não encontrado.");

            token.ConfirmarToken();

            var entry = Context.Entry(token);
            entry.State = EntityState.Modified;
            this.Context.SaveChanges();

            return token;
        }
    }
}
