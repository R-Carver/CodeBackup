using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Utilities.EventSystem
{
    public class EventUtility
    {
        
        //DAVID TaskTest *************************************************************************************
        public static void OnTestEvent(object source, EventArgs e)
        {
            MyDbContext db = new MyDbContext();

            var contract = (Contract)source;

            string tempUserId = contract.OwnerId;  //Get the user from the passed contract obejct
            var TempUser = db.Users.Find(tempUserId);

            contract = db.Contracts.Find(contract.Id);

            var tempTask = new ContractTask();

            tempTask.Description = "tolle Aufgabe";
            tempTask.TaskType = TaskTypes.DispatcherZuweisen;
            tempTask.Contract = contract;
            tempTask.User = TempUser;

            db.ContractTasks.Add(tempTask);
            db.SaveChanges();     

            System.Diagnostics.Debug.WriteLine("Aufgabe erstellt");

        }
        //DAVID TaskTest *********************************************************************************ENDE
    }
}