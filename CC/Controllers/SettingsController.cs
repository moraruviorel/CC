using CC.Models.Classes;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CC.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Setting()
        {
            return View();
        }
        
        CC.Models.ExcelentConstructSetting db = new CC.Models.ExcelentConstructSetting();
        Models.AspNetUsersEntities aspNetUsersEntities = new Models.AspNetUsersEntities();
        //CC.Models.Asp ExcelentConstructAspNetUsers dbAspNetUsers = new CC.Models.ExcelentConstructAspNetUsers();        
        
        [ValidateInput(false)]
        public ActionResult GridViewSettingPartial()
        {
            if (MySession.Current.IsUserAdmin)
            {
                var model = db.Settings.ToList();                
                ViewBag.AspNetUsers = aspNetUsersEntities.AspNetUsers.ToList(); //AspNetUser.ToList();                
                return PartialView("_GridViewSettingPartial", model.ToList());
            }
            else
            {
                var model = db.Settings.ToList().Where(x => x.UserId == MySession.Current.UserGuid);
                //ViewBag.AspNetUsers = new CC.Models.AspNetUsers();
                return PartialView("_GridViewSettingPartial", model.ToList());
            }                      
            
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewSettingPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] CC.Models.Setting item)
        {
            var model = db.Settings;
            if (ModelState.IsValid)
            {
                try
                {                    
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var modelToShow = db.Settings.ToList().Where(x => x.UserId == MySession.Current.UserGuid);
            return PartialView("_GridViewSettingPartial", modelToShow.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewSettingPartialUpdate(CC.Models.Setting item)
        {
            var model = db.Settings;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.ID == item.ID);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var modelToShow = db.Settings.ToList().Where(x => x.UserId == MySession.Current.UserGuid);
            return PartialView("_GridViewSettingPartial", modelToShow.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewSettingPartialDelete(System.Int32 ID)
        {
            var model = db.Settings;
            if (ID >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.ID == ID);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var modelToShow = db.Settings.ToList().Where(x => x.UserId == MySession.Current.UserGuid);
            return PartialView("_GridViewSettingPartial", modelToShow.ToList());
        }
    }
}