﻿using CC.Models.Database;
using System.Collections.Generic;
using System.Linq;
using CC.Models.Classes;
using CC.Models.Classes.Worker;

namespace CC.Models.BusinessLogic.Worker
{
    public class Works
    {
        public static decimal GetSalaryByWork(int workerId)
        {
            decimal salary = 0;
            List<Work> workList = new WorksEntities().Works.ToList()
                .Where(x => x.worker_id == workerId && x.is_paid == 0).ToList();

            foreach (var item in workList)
            {
                salary = salary + item.surface_work * item.unit_price_worker ?? 0;
            }

            salary += WorkersGroupDetail.GetWorksGroupSum(workerId);

            return salary;
        }

        public static WorkerWorksModel GetWorkerWorksModel()
        {
            List<int> workerGroupsIds = WorkersGroupDetail.GetWorkerGroupIds(MySession.Current.WorkerId);

            var works = new WorksEntities().Works.ToList().Where(x => x.worker_id == MySession.Current.WorkerId).ToList();
            
            foreach(int id in workerGroupsIds)
            {
                works.AddRange(new WorksEntities().Works.AsQueryable().Where(x => x.workers_group_id == id).ToList());                
            }
           
            return new WorkerWorksModel
            {
                ObjectList = Object.Object.GetObjectModel().ObjectList,
                UnitList = Home.Unit.GetUnitModel().UnitList,
                WorksList = works
            };
        }
    }


    
}