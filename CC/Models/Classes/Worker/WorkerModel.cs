using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models.Classes.Worker
{
    public class WorkerModel
    {
        public List<Database.Worker> WorkerList { get; set; }

        public Database.UserPermission UserPermission { get; set; }

        public List<Database.WorkerContractType> WorkerContractList { get; set; }

    }
}