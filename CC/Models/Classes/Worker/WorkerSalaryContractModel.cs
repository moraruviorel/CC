using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models.Classes.Worker
{
    public class WorkerSalaryContractModel
    {
        public List<Database.WorkerSalaryContract> WorkerSalaryContractList { get; set; }

        public List<Database.WorkerContractType> WorkerContractTypeList { get; set; }
    }
}