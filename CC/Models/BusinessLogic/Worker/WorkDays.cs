using CC.Models.Database;
using System.Collections.Generic;
using System.Linq;
using CC.Models.Classes;
using CC.Models.Classes.Worker;

namespace CC.Models.BusinessLogic.Worker
{
    public class WorkDays
    {
        public static List<WorkDay> GetWorksDay(int workerId)
        {
            WorkDayEntities workDays = new WorkDayEntities();

            var workDayList = workDays.WorkDays.ToList().Where(x => x.worker_id == workerId).ToList();
            //&& Convert.ToDateTime(x.work_date).Month == DateTime.Now.Month

            return workDayList;
        }

        public static WorkDaysModel GetWorkDaysModel()
        {
            return new WorkDaysModel
            {
                WorkDayList = new Database.WorkDayEntities().WorkDays.ToList()
                    .Where(x => x.worker_id == MySession.Current.WorkerId).ToList()
            };
        }
    }
}