using CC.Models.Classes;
using CC.Models.Enums;
using System;
using System.Linq;
using System.Web.Mvc;
using CC.Models.BusinessLogic.Role;
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
            var worker = _dbWorkers.Workers.ToList().FirstOrDefault(x => x.Id == workerId);
            ViewBag.Workers = worker?.first_name + " " + worker?.last_name;
            return View();
        }

        public ActionResult WorkersActionResult()
        {
            return View();
        }

        public ActionResult WorkersTabControl()
        {
            object test = Request.Params["tabIndex"];
            string partialView = "Objects";
            switch (test.ToString())
            {
                case "0":
                    partialView = "_WorkWorksPartial";
                    break;
                case "1":
                    partialView = "Workers";
                    break;
                case "2":
                    partialView = "WorkersGroups";
                    break;
               
            }

            return PartialView(partialView);
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

        [AuthorizeRoles.AuthorizeRolesAttribute(UserRoleType.Admin, UserRoleType.Manager)]
        public ActionResult Workers()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewWorkers()
        {
            return PartialView("_GridViewWorkers", BLWorkers.Worker.GetWorkerModel());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewWorkersAddNew(Database.Worker item)
        {
            var model = _dbWorkers.Workers;
            if (ModelState.IsValid)
            {
                try
                {
                    item.UserId = MySession.Current.UserGuid;
                    model.Add(item);
                    _dbWorkers.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            
            return PartialView("_GridViewWorkers", BLWorkers.Worker.GetWorkerModel());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewWorkersUpdate(Database.Worker item)
        {
            var model = _dbWorkers.Workers;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
                    if (modelItem != null)
                    {
                        UpdateModel(modelItem);
                        _dbWorkers.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
           
            return PartialView("_GridViewWorkers", BLWorkers.Worker.GetWorkerModel());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewWorkersDelete(Int32 id)
        {
            var model = _dbWorkers.Workers;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Id == id);
                    if (item != null)
                        model.Remove(item);
                    _dbWorkers.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            
            return PartialView("_GridViewWorkers", BLWorkers.Worker.GetWorkerModel());
        }

        #endregion

        #region WorkerContract

        [AuthorizeRoles.AuthorizeRolesAttribute(UserRoleType.Admin, UserRoleType.Manager)]
        public ActionResult WorkerContract()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult WorkerContractPartial()
        {
            var model = DbWorkerContract.WorkerContractTypes.Where(x => x.user_id == MySession.Current.UserGuid);
            return PartialView("_WorkerContractPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult WorkerContractPartialAddNew(Database.WorkerContractType item)
        {
            var model = DbWorkerContract.WorkerContractTypes;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    DbWorkerContract.SaveChanges();
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
            var model = DbWorkerContract.WorkerContractTypes;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        UpdateModel(modelItem);
                        DbWorkerContract.SaveChanges();
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
        public ActionResult WorkerContractPartialDelete(Int32 id)
        {
            var model = DbWorkerContract.WorkerContractTypes;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    DbWorkerContract.SaveChanges();
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
            return PartialView("_GridViewWorkerPayment", BLWorkers.WorkerPayment.GetWorkerPaymentModel(dbWorks, dbWorkerPayment));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewWorkerPaymentAddNew(Database.WorkerPayment item)
        {
            var model = dbWorkerPayment.WorkerPayments;
            if (ModelState.IsValid && item.amount > 0)
            {
                try
                {
                    item.worker_id = MySession.Current.WorkerId;
                    item.userId = MySession.Current.UserGuid;
                    item.is_advance_excluded = false;

                    var salary = BLWorkers.WorkerPayment.GetSalary(item.worker_id);
                    if (Convert.ToDecimal(item.amount) == Convert.ToDecimal(salary))
                    {
                        var works = dbWorks.Works.ToList()
                            .Where(x => (x.worker_id == item.worker_id 
                                         || BLWorkers.WorkersGroupDetail.GetWorkerGroupIds(item.worker_id).Contains(x.workers_group_id ?? 0)) 
                                        && x.is_paid == 0)
                            .ToList();
                        if(works.Count > 0)
                        {
                            works.ToList().ForEach(x => x.is_paid = 1);
                            UpdateModel(works);
                            dbWorks.SaveChanges();
                        }

                        var payments = dbWorkerPayment.WorkerPayments.ToList().Where(x => 
                                           x.worker_id == item.worker_id
                                        && x.payment_type == (int) PaymentTypes.advance 
                                        && x.is_advance_excluded == false).ToList();
                        if (payments.Count > 0)
                        {
                            payments.ToList().ForEach(c => c.is_advance_excluded = true);
                            UpdateModel(payments);
                            dbWorkerPayment.SaveChanges();
                        }
                        
                        var notice = string.Concat("lucrări: ", String.Join(",", works.Select(x => x.date_end)));
                        notice = string.Concat(notice, " avansuri: ", String.Join(",", payments.Select(x => x.payment_date)));

                        item.notice = notice.Replace("12:00:00 AM", "");
                    }

                    model.Add(item);
                    dbWorkerPayment.SaveChanges();
                }
                catch (Exception e)
                { 
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Corectați toate erorile, suma trebuie sa fie mai mare decit 0";

            var modelToShow = BLWorkers.WorkerPayment.GetWorkerPaymentModel(dbWorks, dbWorkerPayment);
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
                        UpdateModel(modelItem);
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
        public ActionResult GridViewWorkerPaymentDelete(Int32 id)
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
                        UpdateModel(modelItem);
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
        public ActionResult GridViewWorkerSpecialityPartialDelete(Int32 specialityId)
        {
            var model = dbWorkerSpeciality.WorkerSpecialities;
            if (specialityId >= 0)
            {
                try
                {
                    var item = model.ToList().FirstOrDefault(it => it.speciality_id == specialityId && it.worker_id == MySession.Current.WorkerId);
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
            return PartialView("_WorkerWorksPartial", BLWorkers.Works.GetWorkerWorksModel());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult WorkerWorksPartialAddNew(Database.Work item)
        {
            var model = dbWorks.Works;
            if (ModelState.IsValid)
            {
                try
                {
                    if (item.unit_price_worker == null)
                        item.unit_price_worker = item.unit_price;

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
            return PartialView("_WorkerWorksPartial", BLWorkers.Works.GetWorkerWorksModel());
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
                        Database.WorkerPayment workerPayment = new Database.WorkerPayment
                        {
                            //
                            payment_date = DateTime.Now,
                            worker_id = MySession.Current.WorkerId,
                            work_id = item.id,
                            amount = Convert.ToDecimal(item.unit_price_worker) * Convert.ToDecimal(item.surface_work),
                            userId = MySession.Current.UserGuid
                        };
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
                        UpdateModel(modelItem);
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
            
            return PartialView("_WorkerWorksPartial", BLWorkers.Works.GetWorkerWorksModel());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult WorkerWorksPartialDelete(Int32 id)
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
            return PartialView("_WorkerWorksPartial", BLWorkers.Works.GetWorkerWorksModel());
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
            return PartialView("_WorkerSalaryContractPartial",
                BLWorkers.WorkerSalaryContract.GetWorkerSalaryContractModel(MySession.Current.WorkerId));
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
            
            return PartialView("_WorkerSalaryContractPartial",
                BLWorkers.WorkerSalaryContract.GetWorkerSalaryContractModel(MySession.Current.WorkerId));
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
                        UpdateModel(modelItem);
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

            return PartialView("_WorkerSalaryContractPartial",
                BLWorkers.WorkerSalaryContract.GetWorkerSalaryContractModel(MySession.Current.WorkerId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult WorkerSalaryContractPartialDelete(Int32 id)
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

            return PartialView("_WorkerSalaryContractPartial",
                BLWorkers.WorkerSalaryContract.GetWorkerSalaryContractModel(MySession.Current.WorkerId));
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
            return PartialView("_WorkDaysPartial", BLWorkers.WorkDays.GetWorkDaysModel());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult WorkDaysPartialAddNew(Database.WorkDay item)
        {
            var model = _dbWorkDay.WorkDays;
            if (ModelState.IsValid)
            {
                try
                {
                    item.worker_id = MySession.Current.WorkerId;
                    model.Add(item);
                    _dbWorkDay.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            
            return PartialView("_WorkDaysPartial", BLWorkers.WorkDays.GetWorkDaysModel());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult WorkDaysPartialUpdate(Database.WorkDay item)
        {
            var model = _dbWorkDay.WorkDays;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        UpdateModel(modelItem);
                        _dbWorkDay.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            
            return PartialView("_WorkDaysPartial", BLWorkers.WorkDays.GetWorkDaysModel());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult WorkDaysPartialDelete(Int32 id)
        {
            var model = _dbWorkDay.WorkDays;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    _dbWorkDay.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            
            return PartialView("_WorkDaysPartial", BLWorkers.WorkDays.GetWorkDaysModel());
        }

        #endregion

        #region Worker Group

        public ActionResult WorkersGroups()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewWorkerGroupPartial()
        {
            return PartialView("_GridViewWorkerGroupPartial", BLWorkers.WorkersGroups.GetWorkersGroupsModel());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewWorkerGroupPartialAddNew(Database.WorkersGroup item)
        {
            var model = dbWorkersGroups.WorkersGroups;
            if (ModelState.IsValid)
            {
                try
                {
                    item.user_id = MySession.Current.UserGuid;

                    model.Add(item);
                    dbWorkersGroups.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            return PartialView("_GridViewWorkerGroupPartial", BLWorkers.WorkersGroups.GetWorkersGroupsModel());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewWorkerGroupPartialUpdate(Database.WorkersGroup item)
        {
            var model = dbWorkersGroups.WorkersGroups;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        UpdateModel(modelItem);
                        dbWorkersGroups.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewWorkerGroupPartial", BLWorkers.WorkersGroups.GetWorkersGroupsModel());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewWorkerGroupPartialDelete(Int32 id)
        {
            var model = dbWorkersGroups.WorkersGroups;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    dbWorkersGroups.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewWorkerGroupPartial", BLWorkers.WorkersGroups.GetWorkersGroupsModel());
        }

        #endregion

        #region WorkersGroupDetail

        public ActionResult WorkersGroupDetail(int workersGroupId)
        {
            MySession.Current.WorkerGroupId = workersGroupId;
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewWorkersGroupDetail()
        {
            int wgId = MySession.Current.WorkerGroupId;
            return PartialView("_GridViewWorkersGroupDetail", BLWorkers.WorkersGroupDetail.GetWorkersGroupDetailModel(wgId));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewWorkersGroupDetailAddNew(Database.WorkersGroupDetail item)
        {
            var model = dbWorkersGroupDetail.WorkersGroupDetails;
            if (ModelState.IsValid)
            {
                try
                {
                    item.workers_groups_id = MySession.Current.WorkerGroupId;

                    model.Add(item);
                    dbWorkersGroupDetail.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewWorkersGroupDetail", 
                BLWorkers.WorkersGroupDetail.GetWorkersGroupDetailModel(MySession.Current.WorkerGroupId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewWorkersGroupDetailUpdate(Database.WorkersGroupDetail item)
        {
            var model = dbWorkersGroupDetail.WorkersGroupDetails;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.workers_groups_id == item.workers_groups_id);
                    if (modelItem != null)
                    {
                        UpdateModel(modelItem);
                        dbWorkersGroupDetail.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewWorkersGroupDetail", 
                BLWorkers.WorkersGroupDetail.GetWorkersGroupDetailModel(MySession.Current.WorkerGroupId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewWorkersGroupDetailDelete(int worker_id)
        {
            var model = dbWorkersGroupDetail.WorkersGroupDetails;
            if (worker_id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.workers_groups_id == MySession.Current.WorkerGroupId 
                                && it.worker_id == worker_id);
                    if (item != null)
                        model.Remove(item);
                    dbWorkersGroupDetail.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewWorkersGroupDetail", 
                BLWorkers.WorkersGroupDetail.GetWorkersGroupDetailModel(MySession.Current.WorkerGroupId));
        }


        #endregion

        
        Database.WorkersGroupDetailEntities dbWorkersGroupDetail = new Database.WorkersGroupDetailEntities();

        private readonly Database.WorkDayEntities _dbWorkDay = new Database.WorkDayEntities();

        private readonly Database.ExcelentConstructWorkers _dbWorkers = new Database.ExcelentConstructWorkers();

        private Database.WorkerContractEntities _dbWorkerContract = new Database.WorkerContractEntities();

        Database.WorksEntities dbWorks = new Database.WorksEntities();

        Database.WorkerPaymentsEntities dbWorkerPayment = new Database.WorkerPaymentsEntities();

        Database.WorkerSpecialityEntities dbWorkerSpeciality = new Database.WorkerSpecialityEntities();

        Database.SpecialityEntities dbSpecialities = new Database.SpecialityEntities();

        Database.WorkerSalaryContractEntities dbWorkerSalaryContract = new Database.WorkerSalaryContractEntities();

        public Database.WorkerContractEntities DbWorkerContract { get => _dbWorkerContract; set => _dbWorkerContract = value; }

        Database.WorkersGroupsEntities dbWorkersGroups = new Database.WorkersGroupsEntities();

    }
}