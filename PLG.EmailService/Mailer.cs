using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PLG.EmailService
{
    /// <summary>
    /// Clase Mailer que me permitirá enviar correos
    /// </summary>
    public class Mailer
    {
        public string from;
        public Mailer()
        {
            SmtpSection section = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            from = section.From;
        }
        protected bool _debugmode = false;

        public bool DebugMode
        {
            set { _debugmode = value; }
        }

        public string EnviarEmail(
            string asunto,
            string body,
            IList<PersonaMail> destinatario,
            IList<PersonaMail> conCopia=null,
            IList<PersonaMail> conCopiaOculta=null, 
            params string[] argumentos)
        {
            string retorno;
            try
            {
                //pasamos los argumentos al cuerpo del correo;
                retorno = string.Format(body, argumentos);
                //creamos el cuerpo del correo
                MailMessage msg = new MailMessage();
                msg.IsBodyHtml = true;
                //seteamos el asunto
                msg.Subject = string.IsNullOrEmpty(asunto) ? "Correo" : asunto;
                msg.Body = retorno;
                //seteamos el correo de envio de lo que se configuro en el Web.config
                msg.From = new MailAddress(this.from);
                //validamos que el destinatario no venga nullo o vacio
                if(destinatario==null && !destinatario.Any())
                {
                    throw new ArgumentException("El campo Destinatario es Obligatorio");
                }
                else
                {
                    foreach (PersonaMail item in destinatario)
                    {
                        msg.To.Add(new MailAddress(item.Email, item.Nombre));
                    }
                }

                //valido que el con copia no venga nulo, no se devuelve la excepción porq
                //este valor no es obligatorio
                if (conCopia != null)
                {
                    foreach (PersonaMail item in conCopia)
                    {
                        msg.CC.Add(new MailAddress(item.Email, item.Nombre));
                    }
                }
                //valido que el con copia oculta no venga nulo, no se devuelve la excepcion 
                //porque este valor no es obligatorio
                if (conCopiaOculta != null)
                {
                    foreach (PersonaMail item in conCopiaOculta)
                    {
                        msg.CC.Add(new MailAddress(item.Email, item.Nombre));
                    }
                }

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Send(msg);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }

        public string EnviarEmail(
            string asunto,
            string body,
            IList<PersonaMail> destinatario,
            IList<PersonaMail> conCopia = null,
            IList<PersonaMail> conCopiaOculta = null,
            IList<AdjuntoMail> stream = null,
            params string[] argumentos)
        {
            return "";
        }
    }
}
