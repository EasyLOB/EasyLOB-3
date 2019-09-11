using EasyLOB.Extensions.Mail;
using System;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void EMailDemo()
        {
            Console.WriteLine("\ne-mail Demo");

            try
            {
                MailManager mailManager = new MailManager();

                mailManager.Mail("siegmar@siegmar.com.br", "Subject", "<b>Body</b>", true);
            }
            catch (Exception exception)
            {
                WriteException(exception);
            }
        }
    }
}