using System.Collections.Generic;
using System.Linq;
using CC.Models.Classes.Worker;

namespace CC.Models.BusinessLogic.Worker
{
    public class WorkersGroupDetail
    {
        public static WorkersGroupDetailModel GetWorkersGroupDetailModel(int workersGroupId)
        {
            var dbWorkersGroupDetail = new Database.WorkersGroupDetailEntities().WorkersGroupDetails.ToList();

            var workersGroupDetailModel = new WorkersGroupDetailModel
            {
                WorkerList = Worker.GetWorkerList(),
                WorkersGroupDetailList = dbWorkersGroupDetail.Where(x=>x.workers_groups_id == workersGroupId).ToList()
            };

            return workersGroupDetailModel;
        }

        public static decimal GetWorksGroupSum(int workerId)
        {
            decimal sum = 0;

            var groupDetails = new Database.WorkersGroupDetailEntities().WorkersGroupDetails.ToList()
                .Where(x => x.worker_id == workerId);

            foreach (var item in groupDetails)
            {
                var worksSum = Object.ObjectWorks.GetWorksSum(item.workers_groups_id);
                sum = sum + worksSum * (item.work_part ?? 0) / 100;
            }

            return sum;
        }

        public static List<int> GetWorkerGroupIds(int workerId)
        {
            return (from my in new Database.WorkersGroupDetailEntities().WorkersGroupDetails
                where my.worker_id == workerId
                select my.workers_groups_id).ToList();
        }
    }
}