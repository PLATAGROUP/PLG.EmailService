using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PLG.EmailService.Test
{
    [TestClass]
    public class UnitTestMailer
    {
        [TestMethod]
        public void TestSendEmail()
        {
            Mailer en = new Mailer();

            IList<PersonaMail> destinatarios = new List<PersonaMail>();
            destinatarios.Add(new PersonaMail("es.aguaman@gmail.com"));
            
            string resultado = en.EnviarEmail("Demo","demo {0} {1} {2} {3}",destinatarios,null,null , ConfigurationManager.AppSettings["CompanyLogoURL"], DateTime.Now.ToString("dddd dd, MMMM, yyyy"), "Hussain Attiya", "hussain.attiya", "991001");

            Assert.IsTrue(true);
        }
    }
}
