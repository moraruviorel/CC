using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CC.Models;

namespace CC.Models.BusinessLogic.Worker
{
    public class Workers
    {
        
        public static IQueryable<CC.Models.Worker> GetWokerById(int workerId)
        {
            CC.Models.ExcelentConstructWorkers dbWorkers = new ExcelentConstructWorkers();
            return dbWorkers.Workers.AsQueryable().Where(x => x.Id == workerId);
        }
    }
}