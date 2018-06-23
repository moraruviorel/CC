using System.Collections.Generic;
using System.Linq;
using CC.Models.Classes;
using CC.Models.Classes.Worker;

namespace CC.Models.BusinessLogic.Worker
{
    public class Worker
    {
        
        public static IQueryable<Database.Worker> GetWokerById(int workerId, Database.ExcelentConstructWorkers dbWorkers)
        {
            return dbWorkers.Workers.AsQueryable().Where(x => x.Id == workerId);
        }

        public static List<Database.Worker> GetWorkerList()
        {
            var userId = MySession.Current.UserGuid;
            //
            return new Database.ExcelentConstructWorkers().Workers.ToList().Where(x => x.UserId == userId).ToList();
        }

        public static WorkerModel GetWorkerModel()
        {
            var workerModel = new WorkerModel
            {
                WorkerList = GetWorkerList(),
                UserPermission = User.UserPermissions.GetUserPermissionByModuleType(Enums.ModuleTypes.Workers),
                WorkerContractList = WorkerContract.GetWorkerContractTypes().WorkerContractList,
                ObjectList = Object.Object.GetObjectModel().ObjectList
            };

            return workerModel;
        }
    }
}