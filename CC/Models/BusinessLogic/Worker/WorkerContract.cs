using CC.Models.Classes;
using CC.Models.Classes.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models.BusinessLogic.Worker
{
    public class WorkerContract
    {
        public static WorkerContractModel GetWorkerContractTypes()
        {
            return new WorkerContractModel()
            {
                WorkerContractList = new Database.WorkerContractEntities().WorkerContractTypes.ToList()
            };
            //.Where(x => x.user_id == MySession.Current.UserGuid).ToList();
        }

    }
}