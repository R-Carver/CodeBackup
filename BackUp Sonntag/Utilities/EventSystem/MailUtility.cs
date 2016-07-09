using Postal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Utilities.EventSystem
{
    public class MailUtility
    {
        private static string applicationEmail = "localHost@myApp.com";

        public static void OnDispatcherSet(object source, EventArgs e)
        {
            Contract tempContract = (Contract)source;

            //Notify Dispatcher
            dynamic email = new Email("DispatcherMail");
            //email.to = tempContract.Dispatcher.Email;
            email.to = "davidmakowski00@gmail.com";
            //email.from = applicationEmail;
            email.from = "davidmakowski00@gmx.de";
            email.contractId = tempContract.Id;

            email.Send();
            System.Diagnostics.Debug.WriteLine("Email wurde abgeschickt");
        }
    }
}