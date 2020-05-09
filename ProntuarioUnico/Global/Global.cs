using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using System.Xml;

namespace ProntuarioUnico
{
    public class Global
    {
        public string Monta_GlobalPath(HttpRequestBase vobjRequest)
        {
            //Retorno
            String lstrRetorno = String.Empty;

            try
            {
                if (vobjRequest.Url.PathAndQuery.Trim() != "/")
                {
                    lstrRetorno = vobjRequest.Url.AbsoluteUri.Replace(vobjRequest.Url.PathAndQuery, "") + (vobjRequest.ApplicationPath.Trim().Length > 1 ? vobjRequest.ApplicationPath.Trim() : "") + "/";
                }
                else
                {
                    lstrRetorno = vobjRequest.Url.AbsoluteUri;
                }
            }
            catch (Exception)
            {
            }

            return lstrRetorno;
        }

        public Boolean AutenticaUsuarioSenha( ref Exception rexcMensagem, String vstrCPF, String vstrSenha )
        {
            Boolean lblnRetorno = false;
            dynamic lobjLogin = null;
            try
            {
                #region Chamada banco

                //Passar ao banco usuário e senha para validar lá

                #endregion Chamada banco

                lobjLogin = new 
                {
                    Login = "admin",
                    Senha = "admin"
                };
                if (lobjLogin.Login == vstrCPF && lobjLogin.Senha == vstrSenha){ lblnRetorno = true; }
            }
            catch (Exception ex)
            {
                if (rexcMensagem == null)
                {
                    rexcMensagem = ex;
                }
            }
            finally
            {
                lobjLogin = null;
            }

            return lblnRetorno;
        }

        #region Conversões

        public object ConverterParaJson(object vobjEntrada)
        {
            return JsonConvert.SerializeObject(vobjEntrada, Newtonsoft.Json.Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
        }

        public object CriarException(Exception vobjException, string vstrMensagem)
        {
            String lstrMensagem = TratarString_JSON(vstrMensagem);
            String lstrException = TratarString_JSON(vobjException.ToString());

            return new { Message = lstrMensagem, Exception = lstrException };
        }

        public String TratarString_JSON(String vstrTexto)
        {
            String lstrRetorno = vstrTexto;

            lstrRetorno = lstrRetorno.Replace(((char)34).ToString(), "''"); //Altera aspas duplas por duas aspas simples
            lstrRetorno = lstrRetorno.Replace(((char)10).ToString(), "").Replace(((char)13).ToString(), " "); //Altera quebra de linha por um espaço em branco
            lstrRetorno = lstrRetorno.Replace(((char)9).ToString(), "  "); //Altera tab por dois espaços em branco
            lstrRetorno = lstrRetorno.Replace("\\", "\\\\"); //Altera barra por barra dupla (BUG do JSON.parse)

            return lstrRetorno;
        }

        #endregion Conversões
    }
}