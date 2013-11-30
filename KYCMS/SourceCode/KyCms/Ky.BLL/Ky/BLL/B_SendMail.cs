namespace Ky.BLL
{
    using Ky.Model;
    using System;
    using System.Net;
    using System.Net.Mail;
    using System.Text;

    public class B_SendMail
    {
        private MailMessage mail;

        public B_SendMail(string from, string to, string subject, string body, bool isHtml, Encoding encoding)
        {
            this.mail = new MailMessage(from, to, subject, body);
            this.mail.BodyEncoding = encoding;
            this.mail.IsBodyHtml = isHtml;
            this.mail.SubjectEncoding = encoding;
        }

        public void Send()
        {
            M_Site siteModel = new B_SiteInfo().GetSiteModel();
            if (siteModel != null)
            {
                string host = siteModel.EmailServerAddress.Trim();
                string userName = siteModel.EmailServerUserName.Trim();
                string password = siteModel.EmailServerUserPass.Trim();
                SmtpClient client = new SmtpClient(host);
                client.Credentials = new NetworkCredential(userName, password);
                client.Send(this.mail);
            }
        }
    }
}

