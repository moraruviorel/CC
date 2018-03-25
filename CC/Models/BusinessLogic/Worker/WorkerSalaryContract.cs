using System.Linq;
using CC.Models.Classes.Worker;
using CC.Models.Database;

namespace CC.Models.BusinessLogic.Worker
{
    public class WorkerSalaryContract
    {
        public static WorkerSalaryContractModel GetWorkerSalaryContractModel(int workerId)
        {
            return new WorkerSalaryContractModel()
            {
                WorkerContractTypeList = WorkerContract.GetWorkerContractTypes().WorkerContractList,

                WorkerSalaryContractList = new WorkerSalaryContractEntities().WorkerSalaryContracts.ToList().
                    Where(x=>x.worker_id == workerId).ToList()
            };
        }

        public static Database.WorkerSalaryContract GetCurrentWorkerContract(int workerId, Enums.WorkerContractType type)
        {
            //WorkerSalaryContractEntities dbWorkerSalaryContract = new WorkerSalaryContractEntities();
            var workerSalaryContracts = GetWorkerSalaryContractModel(workerId).WorkerSalaryContractList;

            return workerSalaryContracts
                .Where(x => x.worker_id == workerId && x.contract_type_id == (int)type)
                .OrderByDescending(x => x.new_contract_date).FirstOrDefault();
        }
    }
}