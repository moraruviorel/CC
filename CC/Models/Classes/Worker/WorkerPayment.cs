using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models.Classes.Worker
{
    public class WorkerPayment
    {
        public int WorkId { get; set; }

        public DateTime CurrentDate { get; set; }

        public double Amount { get; set; }

        public List<Database.Work> WorkerWorkList { get; set; }

        //public List<Models.Worker> Workers { get; set; }

        public List<Database.WorkerPayment> WorkerPayments { get; set; }
    }
}