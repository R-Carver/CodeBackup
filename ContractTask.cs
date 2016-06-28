using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ContractTask
    {


        public int Id { get; set; }
        public string Description { get; set; }
        public TaskTypes TaskType { get; set; }
        private bool isDone;
        public bool IsDone {
            get
            {
                return this.isDone;
            }
            set
            {
                if(value != isDone)
                {
                    if(value == true)
                    {
                        OnPropertyChanged("IsDone");
                    }
                }
            }
        }

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


        //Events
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        public static event PropertyChangedEventHandler PropertyChanged;

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