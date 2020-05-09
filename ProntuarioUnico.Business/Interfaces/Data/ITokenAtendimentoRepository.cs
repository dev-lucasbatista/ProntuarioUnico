using ProntuarioUnico.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioUnico.Business.Interfaces.Data
{
    public interface ITokenAtendimentoRepository
    {
        TokenAtendimento Cadastrar(TokenAtendimento novoTokenAtendimento);

        TokenAtendimento Obter(String token, Int32 codigoAtendimento);

        TokenAtendimento ConfirmarToken(Int32 codigo);
    }
}
