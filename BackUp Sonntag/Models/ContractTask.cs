using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplication1.Utilities.EventSystem;

namespace WebApplication1.Models
{
    public class ContractTask
    {


        public int Id { get; set; }
        public string Description { get; set; }
        public TaskTypes TaskType { get; set; }
        private bool isDone;
        public bool IsDone { get; set; }

        //Dates
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)] 
        public Nullable<DateTime> DateCreated { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> Expiring { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> EscalationDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> NotificationDate { get; set; }

        public virtual Contract Contract { get; set; }
        public virtual ContractUser User { get; set; }


        //Events when task is done
        public delegate void TaskDoneEventHandler(object source, EventArgs args);
        public event TaskDoneEventHandler TaskDone;

        protected virtual void OnTaskDone()
        {
            if (TaskDone != null)
            {
                TaskDone(this, EventArgs.Empty);
            }
        }

        //Add Listeners here
        public void TriggerTaskDoneEvent()
        {
            this.TaskDone += EventUtility.OnTaskDone;
            OnTaskDone();
            this.TaskDone -= EventUtility.OnTaskDone;
        }

        //Events when task is done
        public delegate void TaskCreatedEventHandler(object source, EventArgs args);
        public event TaskCreatedEventHandler TaskCreated;

        protected virtual void OnTaskCreated()
        {
            if (TaskCreated != null)
            {
                TaskCreated(this, EventArgs.Empty);
            }
        }

        public void TriggerTaskCreatedEvent()
        {
            this.TaskCreated += EventUtility.OnTaskCreated;
            OnTaskCreated();
            this.TaskCreated -= EventUtility.OnTaskCreated;
        }

    }

    public enum TaskTypes
    {
        DispatcherZuweisen,
        VertragVervollstaendigen,
        DokumenteHochladen,
        KostenAktualisieren,
        VertragsKuendigungChecken
    }

   
}