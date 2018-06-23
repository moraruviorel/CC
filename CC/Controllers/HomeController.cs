using CC.Models.Enums;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using CC.Models.BusinessLogic.Role;
using BusinessLogic = CC.Models.BusinessLogic;
using Database = CC.Models.Database;
using CC.Models.Classes;
using static CC.Models.BusinessLogic.Role.AuthorizeRoles;

namespace CC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {                
        public ActionResult Index()
        {
            
            if (User.Identity.IsAuthenticated)
            {
                MySession.Current.UserGuid = User.Identity.GetUserId();

                BusinessLogic.User.UserRole.SetUserRole(MySession.Current.UserGuid);
                BusinessLogic.User.UserPermissions.SetUserPermissions();

                if(MySession.Current.MySetting == null)
                {
                    var dbSetting = BusinessLogic.Setting.Setting.GetSettingForCurrentUserList(dbSettings);
                    BusinessLogic.Setting.Setting.SetSetting(dbSetting);
                }                
            }
            var model = BusinessLogic.Home.Index.GetIndexModel();
            
            return View(model);
        }

        [AuthorizeRoles.AuthorizeRolesAttribute(UserRoleType.Admin, UserRoleType.Manager)]
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
            return PartialView("_GridViewUnit", BusinessLogic.Home.Unit.GetUnitModel());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewUnitAddNew(Database.Unit item)
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
            return PartialView("_GridViewUnit", BusinessLogic.Home.Unit.GetUnitModel());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewUnitUpdate(Database.Unit item)
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
            return PartialView("_GridViewUnit", BusinessLogic.Home.Unit.GetUnitModel());
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
            return PartialView("_GridViewUnit", BusinessLogic.Home.Unit.GetUnitModel());
        }

        #endregion
                
        #region Speciality

        [AuthorizeRoles.AuthorizeRolesAttribute(UserRoleType.Admin, UserRoleType.Manager)]
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
        public ActionResult GridViewSpecialityPartialAddNew(Database.Speciality item)
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
        public ActionResult GridViewSpecialityPartialUpdate(Database.Speciality item)
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
        public ActionResult MaterialToBuyGVPAddNew(Database.MaterialToBuy item)
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
        public ActionResult MaterialToBuyGVPUpdate(Database.MaterialToBuy item)
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

        [AuthorizeRoles(UserRoleType.Admin, UserRoleType.Manager)]
        public ActionResult LoanMoney()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewLoanMoneyPartial()
        {
            return PartialView("_GridViewLoanMoneyPartial", BusinessLogic.Home.LoanMoney.GetLoanMoneyModel());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewLoanMoneyPartialAddNew(Database.LoanMoney item)
        {
            var model = dbLoanMoney.LoanMoney;
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
            
            return PartialView("_GridViewLoanMoneyPartial", BusinessLogic.Home.LoanMoney.GetLoanMoneyModel());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewLoanMoneyPartialUpdate(Database.LoanMoney item)
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
            else ViewData["EditError"] = "Please, correct all errors.";
            
            return PartialView("_GridViewLoanMoneyPartial", BusinessLogic.Home.LoanMoney.GetLoanMoneyModel());
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
            
            return PartialView("_GridViewLoanMoneyPartial", BusinessLogic.Home.LoanMoney.GetLoanMoneyModel());
        }

        #endregion

        #region Customers

        [AuthorizeRoles(UserRoleType.Admin, UserRoleType.Dentistry)]
        public ActionResult Customers()
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
        public ActionResult CustomerPartialAddNew(Database.Customer item)
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
        public ActionResult CustomerPartialUpdate(Database.Customer item)
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
        public ActionResult _GridViewTreatmentPartialAddNew(Database.Treatment item)
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
        public ActionResult _GridViewTreatmentPartialUpdate(Database.Treatment item)
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
        public ActionResult GridViewSurgeryPartialAddNew(Database.Treatment item)
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
        public ActionResult GridViewSurgeryPartialUpdate(Database.Treatment item)
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
        public ActionResult GridViewProsthesisPartialAddNew(Database.Treatment item)
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
        public ActionResult GridViewProsthesisPartialUpdate(Database.Treatment item)
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
            ViewBag.PersonName = BusinessLogic.Home.LoanMoney.GetLoanMoneyById(loanMoneyId).person_name;
            return View();
        }
                        
        [ValidateInput(false)]
        public ActionResult LoanMoneyDetailsPartial()
        {            
            return PartialView("_LoanMoneyDetailsPartial", BusinessLogic.Home.LoanMoneyDetail.GetLoanMoneyDetails().ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult LoanMoneyDetailsPartialAddNew(Database.LoanMoneyDetail item)
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
            return PartialView("_LoanMoneyDetailsPartial", BusinessLogic.Home.LoanMoneyDetail.GetLoanMoneyDetails().ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult LoanMoneyDetailsPartialUpdate(Database.LoanMoneyDetail item)
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
            return PartialView("_LoanMoneyDetailsPartial", BusinessLogic.Home.LoanMoneyDetail.GetLoanMoneyDetails().ToList());
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
            return PartialView("_LoanMoneyDetailsPartial", BusinessLogic.Home.LoanMoneyDetail.GetLoanMoneyDetails().ToList());
        }

        #endregion

        #region Filter

        [AuthorizeRoles(UserRoleType.Admin, UserRoleType.Manager)]
        public ActionResult Filter()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewFilterPartial()
        {            
            return PartialView("_GridViewFilterPartial", BusinessLogic.Home.Filter.GetFilterModel());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewFilterPartialAddNew(CC.Models.Database.Filter item)
        {
            var model = dbFilter.Filters;
            if (ModelState.IsValid)
            {
                try
                {
                    item.user_id = MySession.Current.UserGuid;
                    model.Add(item);
                    dbFilter.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewFilterPartial", BusinessLogic.Home.Filter.GetFilterModel());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewFilterPartialUpdate(CC.Models.Database.Filter item)
        {
            var model = dbFilter.Filters;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        dbFilter.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            
            return PartialView("_GridViewFilterPartial", BusinessLogic.Home.Filter.GetFilterModel());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewFilterPartialDelete(System.Int32 id)
        {
            var model = dbFilter.Filters;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    dbFilter.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
           
            return PartialView("_GridViewFilterPartial", BusinessLogic.Home.Filter.GetFilterModel());
        }

        #endregion

        #region TranslateWords

        public ActionResult TranslateWords()
        {
            return View();
        }
    
        [ValidateInput(false)]
        public ActionResult GridViewTranslateWordsPartial()
        {
            var model = dbTranslateWords.TranslateWords;
            return PartialView("_GridViewTranslateWordsPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewTranslateWordsPartialAddNew(CC.Models.Database.TranslateWord item)
        {
            var model = dbTranslateWords.TranslateWords;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    dbTranslateWords.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewTranslateWordsPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewTranslateWordsPartialUpdate(CC.Models.Database.TranslateWord item)
        {
            var model = dbTranslateWords.TranslateWords;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.word == item.word);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        dbTranslateWords.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewTranslateWordsPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewTranslateWordsPartialDelete(string word)
        {
            var model = dbTranslateWords.TranslateWords;
            if (word != string.Empty)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.word== word);
                    if (item != null)
                        model.Remove(item);
                    dbTranslateWords.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewTranslateWordsPartial", model.ToList());
        }

        #endregion

        #region DB

        Database.WorksEntities dbWorks = new Database.WorksEntities();

        Database.ExcelentConstructSetting dbSettings = new Database.ExcelentConstructSetting();

        Database.ExcelentConstructUnit dbUnits = new Database.ExcelentConstructUnit();

        Database.SpecialityEntities dbSpecialities = new Database.SpecialityEntities();

        Database.AspNetUser dbAspNetUsers = new Database.AspNetUser();

        Database.MaterialToBuyEntities dbMaterialToBuy = new Database.MaterialToBuyEntities();

        Database.CustomerEntities dbCustomer = new Database.CustomerEntities();

        Database.TreatmentEntities dbTreatment = new Database.TreatmentEntities();

        Database.LoanMoneyEntities dbLoanMoney = new Database.LoanMoneyEntities();

        Database.LoanMoneyDetailsEntities dbLoanMoneyDetails = new Database.LoanMoneyDetailsEntities();

        Database.FiltersEntities dbFilter = new Database.FiltersEntities();

        Database.TranslateWordEntities dbTranslateWords = new Database.TranslateWordEntities();

        #endregion



    }
}