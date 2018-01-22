using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CC.Models;
using CC.Models.Classes;

namespace CC.Models.BusinessLogic.Worker
{
    public class Worker
    {
        
        public static IQueryable<Database.Worker> GetWokerById(int workerId, Database.ExcelentConstructWorkers dbWorkers)
        {
            return dbWorkers.Workers.AsQueryable().Where(x => x.Id == workerId);
        }

        public static List<Database.Worker> GetWorkerList(Database.ExcelentConstructWorkers dbWorkers)
        {
            var user_id = MySession.Current.UserGuid;
            //
            return dbWorkers.Workers.ToList().Where(x => x.UserId == user_id).ToList();
        }
    }
}