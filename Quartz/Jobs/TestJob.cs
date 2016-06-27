using Quartz;
using Quartz.Impl.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Quartz.Jobs
{
    public class TestJob : IJob 
    {
        public void Execute(IJobExecutionContext context)
        {
            System.Diagnostics.Debug.WriteLine("Aufgabe wird geloescht ");

            JobDataMap dataMap = context.JobDetail.JobDataMap;

            int taskKey = dataMap.GetInt("TaskId");

            MyDbContext db = new MyDbContext();

            ContractTask task = db.ContractTasks.Find(taskKey);
            db.ContractTasks.Remove(task);
            db.SaveChanges();

            System.Diagnostics.Debug.WriteLine("Aufgabe wurde geloescht ");
        }

    }
}