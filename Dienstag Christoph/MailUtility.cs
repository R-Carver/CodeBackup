using Postal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Utilities.EventSystem
{
    public class MailUtility
    {
        private static string applicationEmail = "soproteam07@gmx.de";

        public static void OnDispatcherSet(object source, EventArgs e)
        {
            MyDbContext db = new MyDbContext();

            Contract tempContract = (Contract)source;

            //The dispatcher has to be loaded here because the nav property is not set at this point yet
            ContractUser dispatcher = db.Users.Find(tempContract.DispatcherId);

            //Notify Dispatcher
            dynamic email = new Email("DispatcherMail");
            email.to = dispatcher.Email;

            email.from = applicationEmail;
            email.contractId = tempContract.Id;

            email.Send();
            System.Diagnostics.Debug.WriteLine("Email wurde abgeschickt");
        }

        public static void NotifyTaskOwner(ContractTask task)
        {
            dynamic email = new Email("NotificationMail");
            email.to = task.User.Email;
            email.from = applicationEmail;
            
            email.Send();
        }

        public static void SendReportMail(string attachmentPath, ContractUser user)
        {
            dynamic email = new Email("ReportMail");
            email.to = user.Email;
            email.from = applicationEmail;

            email.Attach(new Attachment(attachmentPath));
            email.Send();
        }
    }
}