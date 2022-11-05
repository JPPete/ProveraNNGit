using System;
using System.IO;
using System.Net.Mail;
using System.Net;

//Returns the amount of files in the folder specified
static int HowManyFiles(string f)
{
    int fileCount = Directory.GetFiles(f, "*", SearchOption.TopDirectoryOnly).Length;

    return fileCount;
}

//Sends and email from me to me with the string passed through (first string is subject, secodn is body)
static void SendEmail(string s, string b, string to)
{


    var smtpClinet = new SmtpClient("MAILSERVER.lilly.rs")
    {
        Port = 587,
        Credentials = new NetworkCredential("EMAIL@lilly.rs", "PASSWORD"),
        EnableSsl = true,

    };

    smtpClinet.Send("EMAIL@lilly.rs", to, s, b);
}

//What folder to check
string folderPath = @"C:\rip\from_app";

//number of files in the folder
int files = HowManyFiles(folderPath);

//What will be the subject and body of the email
string subject = "NISU PROSLE NARUDZBENICU DO PANETEONA";
string body = $"NISU OTISLI FILE-OVI!!!\nOstalo je {files} u folderu {folderPath}";
string petar = "EMAIL1@lilly.rs";
string it = "EMAIL2@lilly.rs";

if (files != 0)
{
    SendEmail(subject, body, petar);
    Console.WriteLine("PROVERA NARUDZBENICA!\nSALJE SE MAIL");

    System.Threading.Thread.Sleep(1000);
    Console.WriteLine($"Ima {files} file-ova");
}
else { Console.WriteLine("PROVERA NARUDZBENICA"); Console.WriteLine($"Ima {files} file-ova"); }

if (files > 10)
{
    SendEmail(subject, body, it);

    Thread.Sleep(2000);
}