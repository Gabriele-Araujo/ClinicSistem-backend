using MimeKit;
using System.Collections.Generic;
using System.Linq;

namespace ClinicSistem_backend.Models
{
    public class Mensagem
    {
        public List<MailboxAddress> Destinatario { get; set; }
        public string Assunto { get; set;}
        public string Conteudo { get; set;}

        
        public Mensagem(IEnumerable<string>destinatario, string assunto, int userId,string activationCode)
        {
            Destinatario = new List<MailboxAddress>();
            Destinatario.AddRange(destinatario.Select(d => new MailboxAddress("",d)));
            Assunto = assunto;
            Conteudo = $"https://localhost:5001/confirm?UserId={userId}&ConfirmationCode={activationCode}";

        }
    }
} 
