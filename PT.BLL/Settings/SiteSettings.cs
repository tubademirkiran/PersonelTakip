﻿using PT.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PT.BLL.Settings
{
    public class SiteSettings
    {
        public static string SiteMail = "platoakademi2017@gmail.com";
        public static string SiteMailPassword = "plt2016plt";
        public static string SiteMailSmtpHost = "smtp.gmail.com";
        public static int SiteMailSmtpPort = 587;
        public static bool SiteMailEnableSsl = true;

        public async static Task SendMail(MailModel model)
        {
            using (var smtp = new SmtpClient())
            {
                var message = new MailMessage();
                message.To.Add(new MailAddress(model.To)); //kime gidecek
                message.From = new MailAddress(SiteMail); //kimden gidecek
                if(!string.IsNullOrEmpty(model.Bcc))
                message.Bcc.Add(new MailAddress(model.Bcc));
                if (!string.IsNullOrEmpty(model.Cc))
                    message.CC.Add(new MailAddress(model.Cc));
                message.Subject = model.Subject; //konu
                message.IsBodyHtml = true; //html kullanılsın
                message.Body = model.Message; 
                var credential = new NetworkCredential()
                {
                    UserName = SiteMail,
                    Password = SiteMailPassword
                };
                smtp.Credentials = credential;
                smtp.Host = SiteMailSmtpHost;
                smtp.Port = SiteMailSmtpPort;
                smtp.EnableSsl = SiteMailEnableSsl;
                await smtp.SendMailAsync(message); //asenkron çalıştığı için task yapılır
            }

        }

        public static string UrlFormatConverter(string name)
        {
            string sonuc = name;
            sonuc = sonuc.Replace("'", "");
            sonuc = sonuc.Replace(" ", "-");
            sonuc = sonuc.Replace("<", "");
            sonuc = sonuc.Replace(">", "");
            sonuc = sonuc.Replace("&", "");
            sonuc = sonuc.Replace("[", "");
            sonuc = sonuc.Replace("!", "");
            sonuc = sonuc.Replace("]", "");
            sonuc = sonuc.Replace("ı", "i");
            sonuc = sonuc.Replace("ö", "o");
            sonuc = sonuc.Replace("ü", "u");
            sonuc = sonuc.Replace("ş", "s");
            sonuc = sonuc.Replace("ç", "c");
            sonuc = sonuc.Replace("ğ", "g");
            sonuc = sonuc.Replace("İ", "I");
            sonuc = sonuc.Replace("Ö", "O");
            sonuc = sonuc.Replace("Ü", "U");
            sonuc = sonuc.Replace("Ş", "S");
            sonuc = sonuc.Replace("Ç", "C");
            sonuc = sonuc.Replace("Ğ", "G");
            sonuc = sonuc.Replace("|", "");
            sonuc = sonuc.Replace(".", "-");
            sonuc = sonuc.Replace("?", "-");
            sonuc = sonuc.Replace(";", "-");

            return sonuc;
        }
    }
}
