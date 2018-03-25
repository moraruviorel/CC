using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models.Classes.Worker
{
    public class WorkerPaymentModel
    {
        public int WorkId { get; set; }

        public DateTime CurrentDate { get; set; }

        public decimal Amount { get; set; }

        public List<Database.Work> WorkerWorkList { get; set; }

        public List<Database.WorkerPayment> WorkerPayments { get; set; }

        public Dictionary<int, string> PaymentTypeList { get; set; }
    }
}