using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
namespace HADESvn
{
    public class Email
    {
        public static void sendMail(string FirstName,string LastName,string EmailAddress,string MobileNumber,string Message)
        {
            string NoiDung = "Email: " + EmailAddress + "\n" + 
                             "Họ Tên: " + FirstName + " " + LastName + "\n" +
                             "Số Điện Thoại: " + MobileNumber + "\n" +
                             "Nội Dung: "+ Message;

            string tieuDe = "Liên Hệ Từ Khác Hàng Đến Shop Hades";
            string from = "trankhanhduy.180509@gmail.com";
            string to = EmailAddress;
            MailMessage mail = new MailMessage();
            SmtpClient server = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(from);
            mail.To.Add(from);
            mail.Subject = tieuDe;
            mail.Body = NoiDung;
            server.Port = 587;
            server.Credentials = new NetworkCredential(from, "krqxbzcanxpbwuxf");
            server.EnableSsl = true;
            server.Send(mail);
        }
        public static bool IsEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            return Regex.IsMatch(email, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}