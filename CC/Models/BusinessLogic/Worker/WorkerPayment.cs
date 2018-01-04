using CC.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models.BusinessLogic.Worker
{
    public class WorkerPayment
    {

        public static double GetSalary(int workerId)
        {
            double salary = 0.0;

            ExcelentConstructWorkers dbWorkers = new ExcelentConstructWorkers();
            WorkerSalaryContractEntities dbWorkerSalaryContract = new WorkerSalaryContractEntities();
            WorkDayEntities workDays = new WorkDayEntities();
            var worker = dbWorkers.Workers.ToList().FirstOrDefault(x => x.Id == workerId);
            var contractTypeId = worker.contract_type_id ?? 0;

            switch (contractTypeId)
            {
                case (int)Enums.WorkerContractType.Lunar:
                    var lastSalaryContract = dbWorkerSalaryContract.WorkerSalaryContracts.ToList()?.Where(x => x.worker_id == workerId)
                                                                                        .OrderByDescending(x => x.new_contract_date).FirstOrDefault();
                    if (lastSalaryContract != null)
                        salary = lastSalaryContract.worker_sum ?? 0.0;
                    break;
                case (int)Enums.WorkerContractType.Zi:
                    var workDayList = workDays.WorkDays.Where(x => x.worker_id == workerId && Convert.ToDateTime(x.work_date).Month == DateTime.Now.Month);
                    lastSalaryContract = dbWorkerSalaryContract.WorkerSalaryContracts.ToList()?.Where(x => x.worker_id == workerId)
                                                                                        .OrderByDescending(x => x.new_contract_date).FirstOrDefault();
                    if (lastSalaryContract != null)
                        salary = workDayList.Count() * (lastSalaryContract.worker_sum ?? 0.0); //Convert.ToDouble(workDayList.Count())
                    break;
                case (int)Enums.WorkerContractType.Ore:
                    lastSalaryContract = dbWorkerSalaryContract.WorkerSalaryContracts.ToList()?.Where(x => x.worker_id == workerId)
                                                                                        .OrderByDescending(x => x.new_contract_date).FirstOrDefault();
                    workDayList = workDays.WorkDays.Where(x => x.worker_id == workerId && Convert.ToDateTime(x.work_date).Month == DateTime.Now.Month);
                    if (lastSalaryContract != null)
                        salary = (workDayList.Sum(x => x.work_hours) ?? 0) * (lastSalaryContract.worker_sum ?? 0.0);
                    break;
                case (int)Enums.WorkerContractType.Volum:
                    ExcelentConstructWorks works = new ExcelentConstructWorks();
                    var firstWorkFinished = works.Works.ToList().OrderBy(x => x.date_end).ToList().FirstOrDefault(x => x.worker_id == workerId && x.is_paid == 0);
                    //foreach (var item in workList)
                    //{
                    //    salary = salary + (Convert.ToDouble(item.surface) * Convert.ToDouble(item.unit_price));
                    //}
                    if (firstWorkFinished != null)
                    {
                        salary = salary + (Convert.ToDouble(firstWorkFinished.surface) * Convert.ToDouble(firstWorkFinished.unit_price));
                        MySession.Current.WorkId = firstWorkFinished.id;
                    }
                    break;
            }

            return salary;


        }

        public static Classes.Worker.WorkerPayment GetWorkerPaymentModel(ExcelentConstructWorks dbWorks, ECWorkerPayment dbWorkerPayment)
        {
            var model = new Classes.Worker.WorkerPayment();


            model.WorkId = MySession.Current.WorkId;
            model.CurrentDate = DateTime.Today;
            model.Amount = GetSalary(MySession.Current.WorkerId);
            model.WorkerWorkList = dbWorks.Works.AsQueryable()
                .Where(x => x.worker_id == MySession.Current.WorkerId && x.is_paid == 0).ToList();
            model.WorkerPayments = dbWorkerPayment.WorkerPayments.ToList().Where(x => x.worker_id == MySession.Current.WorkerId).ToList();

            return model;
        }
    }
}