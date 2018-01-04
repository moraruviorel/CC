using CC.Models;
using CC.Models.Classes;
using CC.Models.Enums;
using CC.Models.BusinessLogic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Web.Mvc;
using static CC.Models.BusinessLogic.Functions;
using BLHome = CC.Models.BusinessLogic.Home;
using static CC.Models.Classes.Enums;

namespace CC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
                
        public ActionResult Index()
        {
            
            MySession.Current.IsUserAdmin = false;
            //var res = UserManager.GetRoles(user.GetUserId());
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var role = UserManager.GetRoles(user.GetUserId());
                MySession.Current.UserGuid = user.GetUserId();
                switch (role[0])
                {
                    case "Admin":
                        MySession.Current.UserRole = UserRole.Admin;
                        break;
                    case "Manager":
                        MySession.Current.UserRole = UserRole.Manager;
                        break;
                    case "Driver":
                        MySession.Current.UserRole = UserRole.Driver;
                        break;
                    case "Worker":
                        MySession.Current.UserRole = UserRole.Worker;
                        break;
                    case "Dentistry":
                        MySession.Current.UserRole = UserRole.Dentistry;
                        break;
                    default:
                        MySession.Current.UserRole = UserRole.Worker;
                        break;
                }
                if (MySession.Current.UserRole == UserRole.Admin)
                {
                    MySession.Current.IsUserAdmin = true;
                }

                var dbSetting = dbSettings.Settings.AsQueryable().Where(x => x.UserId == MySession.Current.UserGuid);
                DefaultData.SetSetting(dbSetting);

            }           
            return View();
        }

        [AuthorizeRoles(UserRole.Admin, UserRole.Manager)]
        public ActionResult Users()
        {
            return View();
        }
               
        #region Unit

        
        public ActionResult Unit()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewUnit()
        {
            var model = dbUnits.Units;
            return PartialView("_GridViewUnit", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewUnitAddNew(CC.Models.Unit item)
        {
            var model = dbUnits.Units;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    dbUnits.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewUnit", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewUnitUpdate(CC.Models.Unit item)
        {
            var model = dbUnits.Units;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        dbUnits.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewUnit", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewUnitDelete(System.Int32 id)
        {
            var model = dbUnits.Units;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    dbUnits.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewUnit", model.ToList());
        }

        #endregion
                
        #region Speciality

        [AuthorizeRoles(UserRole.Admin, UserRole.Manager)]
        public ActionResult Speciality()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewSpecialityPartial()
        {
            var model = dbSpecialities.Specialities.ToList().Where(x => x.UserId == MySession.Current.UserGuid);
            return PartialView("_GridViewSpecialityPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewSpecialityPartialAddNew(CC.Models.Speciality item)
        {
            var model = dbSpecialities.Specialities;
            if (ModelState.IsValid)
            {
                try
                {
                    item.UserId = MySession.Current.UserGuid;
                    model.Add(item);
                    dbSpecialities.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model1 = dbSpecialities.Specialities.ToList().Where(x => x.UserId == MySession.Current.UserGuid);
            return PartialView("_GridViewSpecialityPartial", model1.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewSpecialityPartialUpdate(CC.Models.Speciality item)
        {
            var model = dbSpecialities.Specialities;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        dbSpecialities.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model1 = dbSpecialities.Specialities.ToList().Where(x => x.UserId == MySession.Current.UserGuid);
            return PartialView("_GridViewSpecialityPartial", model1.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewSpecialityPartialDelete(System.Int32 id)
        {
            var model = dbSpecialities.Specialities;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    dbSpecialities.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model1 = dbSpecialities.Specialities.ToList().Where(x => x.UserId == MySession.Current.UserGuid);
            return PartialView("_GridViewSpecialityPartial", model1.ToList());
        }

        #endregion
        
        #region MaterialToBuy

        public ActionResult MaterialToBuy()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult MaterialToBuyDVP()
        {
            var model = dbMaterialToBuy.MaterialToBuy;
            return PartialView("_MaterialToBuyDVP", model.ToList());
        }

        [ValidateInput(false)]
        public ActionResult MaterialToBuyGVP()
        {
            var model = new object[0];
            return PartialView("_MaterialToBuyGVP", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult MaterialToBuyGVPAddNew(CC.Models.MaterialToBuy item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_MaterialToBuyGVP", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MaterialToBuyGVPUpdate(CC.Models.MaterialToBuy item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_MaterialToBuyGVP", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MaterialToBuyGVPDelete(System.Int64? id)
        {
            var model = new object[0];
            if (id != null)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_MaterialToBuyGVP", model);
        }

        #endregion

        #region LoanMoney

        [AuthorizeRoles(UserRole.Admin, UserRole.Manager)]
        public ActionResult LoanMoney()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewLoanMoneyPartial()
        {
            var model = dbLoanMoney.LoanMoney.AsQueryable().Where(x => x.user_id == MySession.Current.UserGuid).ToList();
            return PartialView("_GridViewLoanMoneyPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewLoanMoneyPartialAddNew(CC.Models.LoanMoney item)
        {
            var model = dbLoanMoney.LoanMoney;//.AsQueryable().Where(x => x.user_id == MySession.Current.UserGuid).ToList();
            if (ModelState.IsValid)
            {
                try
                {
                    item.user_id = MySession.Current.UserGuid;
                    model.Add(item);
                    dbLoanMoney.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var modelShow = dbLoanMoney.LoanMoney.AsQueryable().Where(x => x.user_id == MySession.Current.UserGuid);
            return PartialView("_GridViewLoanMoneyPartial", modelShow.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewLoanMoneyPartialUpdate(CC.Models.LoanMoney item)
        {
            var model = dbLoanMoney.LoanMoney;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        dbLoanMoney.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var modelShow = dbLoanMoney.LoanMoney.AsQueryable().Where(x => x.user_id == MySession.Current.UserGuid);
            return PartialView("_GridViewLoanMoneyPartial", modelShow.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewLoanMoneyPartialDelete(System.Int32 id)
        {
            var model = dbLoanMoney.LoanMoney;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    dbLoanMoney.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var modelShow = dbLoanMoney.LoanMoney.AsQueryable().Where(x => x.user_id == MySession.Current.UserGuid);
            return PartialView("_GridViewLoanMoneyPartial", modelShow.ToList());
        }

        #endregion

        #region Customers

        [AuthorizeRoles(UserRole.Admin, UserRole.Dentistry)]
        public ActionResult Customer()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult CustomerPartial()
        {			
			var model = dbCustomer.Customer.ToList()?.Where(x => x.user_id == MySession.Current.UserGuid).ToList();
			return PartialView("_CustomerPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CustomerPartialAddNew(CC.Models.Customer item)
        {
            var model = dbCustomer.Customer;
            if (ModelState.IsValid)
            {
                try
                {
                    item.user_id = MySession.Current.UserGuid;
                    model.Add(item);
                    dbCustomer.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var modelShow = dbCustomer.Customer.ToList().Where(x => x.user_id == MySession.Current.UserGuid);
            return PartialView("_CustomerPartial", modelShow.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CustomerPartialUpdate(CC.Models.Customer item)
        {
            var model = dbCustomer.Customer;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        dbCustomer.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var modelShow = dbCustomer.Customer.ToList().Where(x => x.user_id == MySession.Current.UserGuid);
            return PartialView("_CustomerPartial", modelShow.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CustomerPartialDelete(System.Int32 id)
        {
            var model = dbCustomer.Customer;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    dbCustomer.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var modelShow = dbCustomer.Customer.ToList().Where(x => x.user_id == MySession.Current.UserGuid);
            return PartialView("_CustomerPartial", modelShow.ToList());
        }

        public ActionResult CustomerDetail(int customerId)
        {
            MySession.Current.CustomerForm = (int)FormName.CustomerForm;
            MySession.Current.CustomerId = customerId;
            var customer = dbCustomer.Customer.ToList().FirstOrDefault(x => x.id == customerId);
            ViewBag.Customers = customer.first_name + " " + customer.last_name;
            return View("~/Views/Home/CustomerDetail/CustomerDetail.cshtml");
        }

        public ActionResult CustomerCallback()
        {
            object test = Request.Params["tabIndex"];
            string partialView = "Customers";
            switch (test.ToString())
            {
                case "0":
                    partialView = "CustomerDetail/CustomerTherapy";
                    break;
                case "1":
                    partialView = "CustomerDetail/CustomerTherapy";
                    break;
                case "2":
                    partialView = "CustomerDetail/CustomerSurgery";
                    break;
                case "3":
                    partialView = "CustomerDetail/CustomerProsthesis";
                    break;
            }

            return PartialView(partialView);
        }

        #endregion

        #region CustomerTherapy

        //public ActionResult CustomerTherapy()
        //{
        //    return View();


        //}

        [ValidateInput(false)]
        public ActionResult _GridViewTreatmentPartial()
        {
            var model = dbTreatment.Treatment.ToList().Where(x => x.customer_id == MySession.Current.CustomerId
                                                             && x.treatment_type == (int)TreatmentType.Therapy);
            return PartialView("_GridViewTreatmentPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult _GridViewTreatmentPartialAddNew(Treatment item)
        {
            var model = dbTreatment.Treatment;
            if (ModelState.IsValid)
            {
                try
                {
                    item.customer_id = MySession.Current.CustomerId;
                    item.treatment_type = (int)TreatmentType.Therapy;
                    model.Add(item);
                    dbTreatment.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var modelToShow = dbTreatment.Treatment.ToList().Where(x => x.customer_id == MySession.Current.CustomerId
                                                             && x.treatment_type == (int)TreatmentType.Therapy);
            return PartialView("_GridViewTreatmentPartial", modelToShow.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult _GridViewTreatmentPartialUpdate(Treatment item)
        {
            var model = dbTreatment.Treatment;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        dbTreatment.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var modelToShow = dbTreatment.Treatment.ToList().Where(x => x.customer_id == MySession.Current.CustomerId
                                                             && x.treatment_type == (int)TreatmentType.Therapy);
            return PartialView("_GridViewTreatmentPartial", modelToShow.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult _GridViewTreatmentPartialDelete(int id)
        {
            var model = dbTreatment.Treatment;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    dbTreatment.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var modelToShow = dbTreatment.Treatment.ToList().Where(x => x.customer_id == MySession.Current.CustomerId
                                                             && x.treatment_type == (int)TreatmentType.Therapy);
            return PartialView("_GridViewTreatmentPartial", modelToShow.ToList());
        }

        #endregion
        
        #region Surgery

        [ValidateInput(false)]
        public ActionResult GridViewSurgeryPartial()
        {
            var model = dbTreatment.Treatment.ToList().Where(x => x.customer_id == MySession.Current.CustomerId
                                                             && x.treatment_type == (int)TreatmentType.Surgery);
            return PartialView("_GridViewSurgeryPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewSurgeryPartialAddNew(Treatment item)
        {
            var model = dbTreatment.Treatment;
            if (ModelState.IsValid)
            {
                try
                {
                    item.customer_id = MySession.Current.CustomerId;
                    item.treatment_type = (int)TreatmentType.Surgery;
                    model.Add(item);
                    dbTreatment.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var modelToShow = dbTreatment.Treatment.ToList().Where(x => x.customer_id == MySession.Current.CustomerId
                                                             && x.treatment_type == (int)TreatmentType.Surgery);
            return PartialView("_GridViewSurgeryPartial", modelToShow.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewSurgeryPartialUpdate(CC.Models.Treatment item)
        {
            var model = dbTreatment.Treatment;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        dbTreatment.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var modelToShow = dbTreatment.Treatment.ToList().Where(x => x.customer_id == MySession.Current.CustomerId
                                                             && x.treatment_type == (int)TreatmentType.Surgery);
            return PartialView("_GridViewSurgeryPartial", modelToShow.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewSurgeryPartialDelete(System.Int32 id)
        {
            var model = dbTreatment.Treatment;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    dbTreatment.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var modelToShow = dbTreatment.Treatment.ToList().Where(x => x.customer_id == MySession.Current.CustomerId
                                                             && x.treatment_type == (int)TreatmentType.Surgery);
            return PartialView("_GridViewSurgeryPartial", modelToShow.ToList());
        }


        #endregion

        #region Prosthesis
              

        [ValidateInput(false)]
        public ActionResult GridViewProsthesisPartial()
        {
            var model = dbTreatment.Treatment.ToList().Where(x => x.customer_id == MySession.Current.CustomerId
                                                             && x.treatment_type == (int)TreatmentType.Prosthesis);
            return PartialView("_GridViewProsthesisPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewProsthesisPartialAddNew(Treatment item)
        {
            var model = dbTreatment.Treatment;
            if (ModelState.IsValid)
            {
                try
                {
                    item.customer_id = MySession.Current.CustomerId;
                    item.treatment_type = (int)TreatmentType.Prosthesis;
                    model.Add(item);
                    dbTreatment.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var modelToShow = dbTreatment.Treatment.ToList().Where(x => x.customer_id == MySession.Current.CustomerId
                                                                     && x.treatment_type == (int)TreatmentType.Prosthesis);
            return PartialView("_GridViewProsthesisPartial", modelToShow.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewProsthesisPartialUpdate(Treatment item)
        {
            var model = dbTreatment.Treatment;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        dbTreatment.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var modelToShow = dbTreatment.Treatment.ToList().Where(x => x.customer_id == MySession.Current.CustomerId
                                                                     && x.treatment_type == (int)TreatmentType.Prosthesis);
            return PartialView("_GridViewProsthesisPartial", modelToShow.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewProsthesisPartialDelete(int id)
        {
            var model = dbTreatment.Treatment;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    dbTreatment.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var modelToShow = dbTreatment.Treatment.ToList().Where(x => x.customer_id == MySession.Current.CustomerId
                                                                     && x.treatment_type == (int)TreatmentType.Prosthesis);
            return PartialView("_GridViewProsthesisPartial", modelToShow.ToList());
        }


        #endregion

        #region LoanMoneyDetails
        public ActionResult LoanMoneyDetails(int loanMoneyId)
        {
            MySession.Current.LoanMoneyId = loanMoneyId;
            ViewBag.PersonName = BLHome.LoanMoney.GetLoanMoneyById(loanMoneyId).person_name;
            return View();
        }
                        
        [ValidateInput(false)]
        public ActionResult LoanMoneyDetailsPartial()
        {            
            return PartialView("_LoanMoneyDetailsPartial", BLHome.LoanMoneyDetail.GetLoanMoneyDetails().ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult LoanMoneyDetailsPartialAddNew(CC.Models.LoanMoneyDetail item)
        {
            var model = dbLoanMoneyDetails.LoanMoneyDetails;
            if (ModelState.IsValid)
            {
                try
                {
                    item.LoanMoneyId = MySession.Current.LoanMoneyId;
                    model.Add(item);
                    dbLoanMoneyDetails.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_LoanMoneyDetailsPartial", BLHome.LoanMoneyDetail.GetLoanMoneyDetails().ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult LoanMoneyDetailsPartialUpdate(CC.Models.LoanMoneyDetail item)
        {
            var model = dbLoanMoneyDetails.LoanMoneyDetails;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        dbLoanMoneyDetails.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_LoanMoneyDetailsPartial", BLHome.LoanMoneyDetail.GetLoanMoneyDetails().ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult LoanMoneyDetailsPartialDelete(System.Int32 id)
        {
            var model = dbLoanMoneyDetails.LoanMoneyDetails;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    dbLoanMoneyDetails.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_LoanMoneyDetailsPartial", BLHome.LoanMoneyDetail.GetLoanMoneyDetails().ToList());
        }

#endregion

        #region DB

        ExcelentConstructWorks dbWorks = new ExcelentConstructWorks();

        ExcelentConstructSetting dbSettings = new ExcelentConstructSetting();

        ExcelentConstructUnit dbUnits = new ExcelentConstructUnit();

        SpecialityEntities dbSpecialities = new SpecialityEntities();
        
        AspNetUser dbAspNetUsers = new AspNetUser();

        MaterialToBuyEntities dbMaterialToBuy = new MaterialToBuyEntities();

        CustomerEntities dbCustomer = new CustomerEntities();

        TreatmentEntities dbTreatment = new TreatmentEntities();

        LoanMoneyEntities dbLoanMoney = new LoanMoneyEntities();

        LoanMoneyDetailsEntities dbLoanMoneyDetails = new LoanMoneyDetailsEntities();

        #endregion

    }
}