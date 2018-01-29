using CC.Models;
using CC.Models.Classes;
using CC.Models.Enums;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using static CC.Models.BusinessLogic.Functions;
using Database = CC.Models.Database;
using BLWorkers = CC.Models.BusinessLogic.Worker;

namespace CC.Controllers
{
    public class WorkerController : Controller
    {

        public ActionResult WorkerDetail(int workerId)
        {
            MySession.Current.WorksForm = (int)FormName.WorkerForm;
            MySession.Current.WorkerId = workerId;
            var worker = dbWorkers.Workers.ToList().FirstOrDefault(x => x.Id == workerId);
            ViewBag.Workers = worker.first_name + " " + worker.last_name;
            return View();
        }

        public ActionResult WorkerCallback()
        {
            object test = Request.Params["tabIndex"];
            string partialView = "Objects";
            switch (test.ToString())
            {
                case "0":
                    partialView = "_WorkWorksPartial";
                    break;
                case "1":
                    partialView = "WorkerDetail/WorkerWorks";
                    break;
                case "2":
                    partialView = "WorkerDetail/WorkerPayment";
                    break;
                case "3":
                    partialView = "WorkerDetail/WorkerSpecialities";
                    break;
                case "4":
                    partialView = "WorkerDetail/WorkDays";
                    break;
                case "5":
                    partialView = "WorkerDetail/WorkerSalaryContract";
                    break;
            }

            return PartialView(partialView);
        }

        #region Workers

        [AuthorizeRoles(UserRole.Admin, UserRole.Manager)]
        public ActionResult Workers()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewWorkers()
        {
            ViewBag.ContractTypes = dbWorkerContract.WorkerContractTypes.ToList();

            var model = dbWorkers.Workers.ToList()?.Where(x => x.UserId == MySession.Current.UserGuid);
            return PartialView("_GridViewWorkers", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewWorkersAddNew(Database.Worker item)
        {
            var model = dbWorkers.Workers;
            if (ModelState.IsValid)
            {
                try
                {
                    item.UserId = MySession.Current.UserGuid;
                    model.Add(item);
                    dbWorkers.SaveChanges();
                }
                catch (System.Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var modelShow = dbWorkers.Workers.ToList().Where(x => x.UserId == MySession.Current.UserGuid);
            return PartialView("_GridViewWorkers", modelShow.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewWorkersUpdate(Database.Worker item)
        {
            var model = dbWorkers.Workers;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        dbWorkers.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var modelShow = dbWorkers.Workers.ToList().Where(x => x.UserId == MySession.Current.UserGuid);
            return PartialView("_GridViewWorkers", modelShow.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewWorkersDelete(System.Int32 Id)
        {
            var model = dbWorkers.Workers;
            if (Id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Id == Id);
                    if (item != null)
                        model.Remove(item);
                    dbWorkers.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var modelShow = dbWorkers.Workers.ToList().Where(x => x.UserId == MySession.Current.UserGuid);
            return PartialView("_GridViewWorkers", modelShow.ToList());
        }

#endregion

        #region WorkerContract

        [AuthorizeRoles(UserRole.Admin, UserRole.Manager)]
        public ActionResult WorkerContract()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult WorkerContractPartial()
        {
            var model = dbWorkerContract.WorkerContractTypes.Where(x => x.user_id == MySession.Current.UserGuid);
            return PartialView("_WorkerContractPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult WorkerContractPartialAddNew(Database.WorkerContractType item)
        {
            var model = dbWorkerContract.WorkerContractTypes;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    dbWorkerContract.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_WorkerContractPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult WorkerContractPartialUpdate(Database.WorkerContractType item)
        {
            var model = dbWorkerContract.WorkerContractTypes;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        dbWorkerContract.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_WorkerContractPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult WorkerContractPartialDelete(System.Int32 id)
        {
            var model = dbWorkerContract.WorkerContractTypes;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    dbWorkerContract.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_WorkerContractPartial", model.ToList());
        }


        #endregion

        #region Worker Payment

        [ValidateInput(false)]
        public ActionResult GridViewWorkerPayment()
        {
            var viewModel = GridViewExtension.GetViewModel("GridView");

            var model = Models.BusinessLogic.Worker.WorkerPayment.GetWorkerPaymentModel(dbWorks, dbWorkerPayment);
            return PartialView("_GridViewWorkerPayment", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewWorkerPaymentAddNew(Database.WorkerPayment item)
        {
            var model = dbWorkerPayment.WorkerPayments;
            if (ModelState.IsValid)
            {
                try
                {
                    var salary = Models.BusinessLogic.Worker.WorkerPayment.GetSalary(MySession.Current.WorkerId);
                    if ((double)item.amount == salary)
                    {
                        var works = dbWorks.Works;
                        var work = dbWorks.Works.ToList().FirstOrDefault(x => x.id == MySession.Current.WorkId);

                        if (work != null && work.is_paid == 0)
                        {
                            work.is_paid = 1;
                            this.UpdateModel(work);
                            dbWorks.SaveChanges();
                        }
                    }
                    item.worker_id = MySession.Current.WorkerId;
                    item.userId = MySession.Current.UserGuid;
                    model.Add(item);
                    dbWorkerPayment.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            var modelToShow = Models.BusinessLogic.Worker.WorkerPayment.GetWorkerPaymentModel(dbWorks, dbWorkerPayment);
            return PartialView("_GridViewWorkerPayment", modelToShow);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewWorkerPaymentUpdate(Database.WorkerPayment item)
        {
            var model = dbWorkerPayment.WorkerPayments;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        dbWorkerPayment.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            //
            var modelToShow = Models.BusinessLogic.Worker.WorkerPayment.GetWorkerPaymentModel(dbWorks, dbWorkerPayment);
            return PartialView("_GridViewWorkerPayment", modelToShow);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewWorkerPaymentDelete(System.Int32 id)
        {
            var model = dbWorkerPayment.WorkerPayments;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    dbWorkerPayment.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var modelToShow = Models.BusinessLogic.Worker.WorkerPayment.GetWorkerPaymentModel(dbWorks, dbWorkerPayment);
            return PartialView("_GridViewWorkerPayment", modelToShow);
        }
        #endregion

        #region WorkerSpeciality

        [ValidateInput(false)]
        public ActionResult GridViewWorkerSpecialityPartial()
        {
            var model = dbWorkerSpeciality.WorkerSpecialities.ToList().Where(x => x.worker_id == MySession.Current.WorkerId);
            ViewBag.Specialities = dbSpecialities.Specialities.ToList().Where(x => x.UserId == MySession.Current.UserGuid);
            return PartialView("_GridViewWorkerSpecialityPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewWorkerSpecialityPartialAddNew(Database.WorkerSpeciality item)
        {
            var model = dbWorkerSpeciality.WorkerSpecialities;
            if (ModelState.IsValid)
            {
                try
                {
                    item.worker_id = MySession.Current.WorkerId;
                    model.Add(item);
                    dbWorkerSpeciality.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            //
            var model1 = dbWorkerSpeciality.WorkerSpecialities.ToList().Where(x => x.worker_id == MySession.Current.WorkerId);
            return PartialView("_GridViewWorkerSpecialityPartial", model1.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewWorkerSpecialityPartialUpdate(Database.WorkerSpeciality item)
        {
            var model = dbWorkerSpeciality.WorkerSpecialities;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.worker_id == item.worker_id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        dbWorkerSpeciality.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            //
            var model1 = dbWorkerSpeciality.WorkerSpecialities.ToList().Where(x => x.worker_id == MySession.Current.WorkerId);
            return PartialView("_GridViewWorkerSpecialityPartial", model1.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewWorkerSpecialityPartialDelete(System.Int32 speciality_id)
        {
            var model = dbWorkerSpeciality.WorkerSpecialities;
            if (speciality_id >= 0)
            {
                try
                {
                    var item = model.ToList().FirstOrDefault(it => it.speciality_id == speciality_id && it.worker_id == MySession.Current.WorkerId);
                    if (item != null)
                        model.Remove(item);
                    dbWorkerSpeciality.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            //
            var model1 = dbWorkerSpeciality.WorkerSpecialities.ToList().Where(x => x.worker_id == MySession.Current.WorkerId);
            return PartialView("_GridViewWorkerSpecialityPartial", model1.ToList());
        }

        #endregion

        #region WorkerWorks

        [ValidateInput(false)]
        public ActionResult WorkerWorksPartial()
        {
            ViewBag.Workers = BLWorkers.Worker.GetWorkerList();
            ViewBag.Unites = dbUnits.Units.ToList();
            //
            ViewBag.Objects = dbObjects.Objects.ToList().Where(x => x.UserId == MySession.Current.UserGuid);
            List<Database.Work> workList = dbWorks.Works.ToList().Where(x => x.worker_id == MySession.Current.WorkerId).ToList();
            //                        
            return PartialView("_WorkerWorksPartial", workList);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult WorkerWorksPartialAddNew(Database.Work item)
        {
            var model = dbWorks.Works;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    dbWorks.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_WorkerWorksPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult WorkerWorksPartialUpdate(Database.Work item)
        {
            var model = dbWorks.Works;
            if (ModelState.IsValid)
            {
                try
                {
                    if (item.is_paid == 1)
                    {
                        var modelPayments = dbWorkerPayment.WorkerPayments;
                        Database.WorkerPayment workerPayment = new Database.WorkerPayment();
                        //
                        workerPayment.payment_date = DateTime.Now;
                        workerPayment.worker_id = MySession.Current.WorkerId;
                        workerPayment.work_id = item.id;
                        workerPayment.amount = Convert.ToDouble(item.unit_price) * Convert.ToDouble(item.surface);
                        workerPayment.userId = MySession.Current.UserGuid;
                        modelPayments.Add(workerPayment);
                        dbWorkerPayment.SaveChanges();
                    }
                    else
                    {
                        var payments = dbWorkerPayment.WorkerPayments;
                        var payment = dbWorkerPayment.WorkerPayments.FirstOrDefault(x => x.work_id == item.id);
                        if (payment != null)
                            payments.Remove(payment);
                        dbWorkerPayment.SaveChanges();
                    }
                    //
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        dbWorks.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model1 = dbWorks.Works.ToList().Where(x => x.worker_id == MySession.Current.WorkerId);
            return PartialView("_WorkerWorksPartial", model1.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult WorkerWorksPartialDelete(System.Int32 id)
        {
            var model = dbWorks.Works;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    dbWorks.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_WorkerWorksPartial", model.ToList());
        }

        #endregion

        #region WorkerSalaryContract

        public ActionResult WorkerSalaryContract()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult WorkerSalaryContractPartial()
        {
            var model = dbWorkerSalaryContract.WorkerSalaryContracts.ToArray().Where(x => x.worker_id == MySession.Current.WorkerId);
            return PartialView("_WorkerSalaryContractPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult WorkerSalaryContractPartialAddNew(Database.WorkerSalaryContract item)
        {
            var model = dbWorkerSalaryContract.WorkerSalaryContracts;
            if (ModelState.IsValid)
            {
                try
                {
                    item.worker_id = MySession.Current.WorkerId;
                    model.Add(item);
                    dbWorkerSalaryContract.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            var model1 = dbWorkerSalaryContract.WorkerSalaryContracts.ToArray().Where(x => x.worker_id == MySession.Current.WorkerId);
            return PartialView("_WorkerSalaryContractPartial", model1.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult WorkerSalaryContractPartialUpdate(Database.WorkerSalaryContract item)
        {
            var model = dbWorkerSalaryContract.WorkerSalaryContracts;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        dbWorkerSalaryContract.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            var model1 = dbWorkerSalaryContract.WorkerSalaryContracts.ToArray().Where(x => x.worker_id == MySession.Current.WorkerId);
            return PartialView("_WorkerSalaryContractPartial", model1.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult WorkerSalaryContractPartialDelete(System.Int32 id)
        {
            var model = dbWorkerSalaryContract.WorkerSalaryContracts;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    dbWorkerSalaryContract.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }

            var model1 = dbWorkerSalaryContract.WorkerSalaryContracts.ToArray().Where(x => x.worker_id == MySession.Current.WorkerId);
            return PartialView("_WorkerSalaryContractPartial", model1.ToList());
        }


        #endregion

        #region WorkDays

        public ActionResult WorkDays()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult WorkDaysPartial()
        {
            var model = dbWorkDay.WorkDays.ToList().Where(x => x.worker_id == MySession.Current.WorkerId);
            return PartialView("_WorkDaysPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult WorkDaysPartialAddNew(Database.WorkDay item)
        {
            var model = dbWorkDay.WorkDays;
            if (ModelState.IsValid)
            {
                try
                {
                    item.worker_id = MySession.Current.WorkerId;
                    model.Add(item);
                    dbWorkDay.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            var model1 = dbWorkDay.WorkDays.ToList().Where(x => x.worker_id == MySession.Current.WorkerId);
            return PartialView("_WorkDaysPartial", model1.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult WorkDaysPartialUpdate(Database.WorkDay item)
        {
            var model = dbWorkDay.WorkDays;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        dbWorkDay.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            var model1 = dbWorkDay.WorkDays.ToList().Where(x => x.worker_id == MySession.Current.WorkerId);
            return PartialView("_WorkDaysPartial", model1.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult WorkDaysPartialDelete(System.Int32 id)
        {
            var model = dbWorkDay.WorkDays;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    dbWorkDay.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }

            var model1 = dbWorkDay.WorkDays.ToList().Where(x => x.worker_id == MySession.Current.WorkerId);
            return PartialView("_WorkDaysPartial", model1.ToList());
        }

        #endregion


        Database.WorkDayEntities dbWorkDay = new Database.WorkDayEntities();

        Database.ExcelentConstructWorkers dbWorkers = new Database.ExcelentConstructWorkers();

        Database.WorkerContractEntities dbWorkerContract = new Database.WorkerContractEntities();

        Database.WorksEntities dbWorks = new Database.WorksEntities();

        Database.ECWorkerPayment dbWorkerPayment = new Database.ECWorkerPayment();

        Database.WorkerSpecialityEntities dbWorkerSpeciality = new Database.WorkerSpecialityEntities();

        Database.SpecialityEntities dbSpecialities = new Database.SpecialityEntities();

        Database.ExcelentConstructUnit dbUnits = new Database.ExcelentConstructUnit();

        Database.WorkerSalaryContractEntities dbWorkerSalaryContract = new Database.WorkerSalaryContractEntities();

        Database.ExcelentConstructEntitiesObjects dbObjects = new Database.ExcelentConstructEntitiesObjects();
    }
}