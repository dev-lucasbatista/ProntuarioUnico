

using System;
using System.Net;
using System.Net.Mail;

namespace ProntuarioUnico.AuxiliaryClasses
{
    public static class Utils
    {
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static bool CPFValido(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;
            string digito;

            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        public static void SendEmail(string email, string content, string title)
        {
            var senderEmail = new MailAddress("prontuariounico.ihc2019@gmail.com", "Prontuário Único - Administração");
            var receiverEmail = new MailAddress(email, "Paciente");
            var password = "Fatecihc2019";
            var body = content;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };

            using (var mess = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = title,
                Body = body
            })
            {
                smtp.Send(mess);
            }
        }

        public static string GenerateRandomNumber()
        {
            int n1, n2, n3, n4, n5, n6;

            Random random = new Random();
            n1 = random.Next(0, 9);
            n2 = random.Next(0, 9);
            n3 = random.Next(0, 9);
            n4 = random.Next(0, 9);
            n5 = random.Next(0, 9);
            n6 = random.Next(0, 9);

            return $"{n1}{n2}{n3}{n4}{n5}{n6}";
        }
    }
}