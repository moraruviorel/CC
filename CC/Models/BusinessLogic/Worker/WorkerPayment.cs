using System;
using System.Collections.Generic;
using System.Linq;
using CC.Models.Classes;
using CC.Models.Database;
using CC.Models.Enums;
using WorkerContractType = CC.Models.Enums.WorkerContractType;

namespace CC.Models.BusinessLogic.Worker
{
    public class WorkerPayment
    {
        public static decimal GetSalary(int workerId)
        {
            decimal salary = 0;

            ExcelentConstructWorkers dbWorkers = new ExcelentConstructWorkers();
            var worker = dbWorkers.Workers.ToList().FirstOrDefault(x => x.Id == workerId);

            var contractTypeId = worker?.contract_type_id ?? 0;
            
            switch (contractTypeId)
            {
                case (int)WorkerContractType.ByMonth:
                    var currentWorkerContract =
                        WorkerSalaryContract.GetCurrentWorkerContract(workerId, WorkerContractType.ByMonth);
                    if (currentWorkerContract != null)
                        salary = Convert.ToDecimal(currentWorkerContract.worker_sum);
                    salary = salary - GetAdvancePayment(workerId) + Works.GetSalaryByWork(workerId);
                    break;
                case (int)WorkerContractType.ByDay:
                    currentWorkerContract =
                        WorkerSalaryContract.GetCurrentWorkerContract(workerId, WorkerContractType.ByDay);
                    if (currentWorkerContract != null)
                        salary = WorkDays.GetWorksDay(workerId).Count * Convert.ToDecimal(currentWorkerContract.worker_sum);
                    salary = salary - GetAdvancePayment(workerId) + Works.GetSalaryByWork(workerId);
                    break;
                case (int)WorkerContractType.ByHours:
                    currentWorkerContract =
                        WorkerSalaryContract.GetCurrentWorkerContract(workerId, WorkerContractType.ByHours);
                    if (currentWorkerContract != null)
                        salary = WorkDays.GetWorksDay(workerId).Sum(x => x.worked_hours ?? 0) *
                                 Convert.ToDecimal(currentWorkerContract.worker_sum);
                    salary = salary - GetAdvancePayment(workerId) + Works.GetSalaryByWork(workerId);
                    break;
                case (int)WorkerContractType.ByWork:
                    salary = Works.GetSalaryByWork(workerId) - GetAdvancePayment(workerId);
                    break;
            }

            return salary;
        }

        public static Classes.Worker.WorkerPaymentModel GetWorkerPaymentModel(WorksEntities dbWorks, 
            WorkerPaymentsEntities dbWorkerPayment)
        {
            var model = new Classes.Worker.WorkerPaymentModel
            {
                WorkId = MySession.Current.WorkId,
                CurrentDate = DateTime.Today,
                Amount = GetSalary(MySession.Current.WorkerId),
                WorkerWorkList = dbWorks.Works.AsQueryable().Where(x => x.worker_id == MySession.Current.WorkerId).ToList(),
                PaymentTypeList = GetPaymentTypeList(),
                WorkerPayments = dbWorkerPayment.WorkerPayments.ToList()
                    .Where(x => x.worker_id == MySession.Current.WorkerId).ToList()
            };
            
            return model;
        }

        public static decimal GetAdvancePayment(int workerId)
        {
            var advanceSum = new WorkerPaymentsEntities().WorkerPayments
                                 .ToList().Where(x =>
                                     x.worker_id == workerId &&
                                     x.payment_type == (int) PaymentTypes.advance &&
                                     (x.is_advance_excluded == false || x.is_advance_excluded == null))
                                 .Sum(x => x.amount ?? 0);
            
            return advanceSum;
        }

        public static Dictionary<int, string> GetPaymentTypeList()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            foreach (PaymentTypes item in Enum.GetValues(typeof(PaymentTypes)))
            {
                dict.Add((int)item, $"{Home.TranslateWord.GetWord(item.ToString(), "ro")}");
            }

            return dict;
        }
    }
}