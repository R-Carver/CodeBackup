using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Quartz;
using WebApplication1.Quartz.Jobs;

namespace WebApplication1.Utilities.EventSystem
{
    public class EventUtility
    {
        
        //DAVID TaskTest *************************************************************************************
        public static void OnTestEvent(object source, EventArgs e)
        {
            MyDbContext db = new MyDbContext();

            var contract = (Contract)source;

            //Get contract from db to check wheter the saving worked and the status is set
            contract = db.Contracts.Find(contract.Id);

            if(contract != null && contract.ContractStatus.Id == 1)
            {
                var tempTask = new ContractTask();

                tempTask.Description = "tolle Aufgabe";
                tempTask.TaskType = TaskTypes.DispatcherZuweisen;
                tempTask.Contract = contract;
                tempTask.User = contract.Owner;
                tempTask.IsDone = false;

                tempTask.DateCreated = DateTime.Now;
                tempTask.Expiring = DateTime.Now.AddSeconds(30);

                db.ContractTasks.Add(tempTask);
                db.SaveChanges();

                System.Diagnostics.Debug.WriteLine("Aufgabe erstellt");

                
            }

        }

        public static void OnDispatcherSet(object source, EventArgs e)
        {
            //Not implemented yet
            
        }

        public static void OnTaskDone(object source, EventArgs e)
        {
            //when task is marked as done schedule the remove process some time after
            ContractTask tempTask = (ContractTask)source;

            //Call the Scheduler Singleton and Instantiate the job
            IScheduler scheduler = Scheduler.Instance();
            IJobDetail job = JobBuilder.Create<RemoveTaskWhenDone>().Build();

            //Pass the Id of the task to the job for deleting it
            job.JobDataMap["TaskId"] = tempTask.Id;

            scheduler.ScheduleJob(job, Triggers.GetTriggerWithSecondOffset(30));
        }
        //DAVID TaskTest *********************************************************************************ENDE
    }
}