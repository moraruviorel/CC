using CC.Models.Classes;
using DevExpress.Web.Mvc;
using System;
using System.Linq;
using System.Web.Mvc;
using Database = CC.Models.Database;
using BLSetting = CC.Models.BusinessLogic.Setting;

namespace CC.Controllers
{
    public class SettingController : Controller
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

        Database.ExcelentConstructSetting dbSetting = new Database.ExcelentConstructSetting();
        Database.AspNetUsersEntities aspNetUsersEntities = new Database.AspNetUsersEntities();
        Database.SettingStatusEntities settingStatusEntities = new Database.SettingStatusEntities();

        [ValidateInput(false)]
        public ActionResult GridViewSettingPartial()
        {
            var settingModel = BLSetting.Setting.GetSettingModel(aspNetUsersEntities, dbSetting);
            return PartialView("_GridViewSettingPartial", settingModel);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewSettingPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Database.Setting item)
        {
            var model = dbSetting.Settings;
            if (ModelState.IsValid)
            {
                try
                {
                    item.UserId = MySession.Current.UserGuid;
                    //item.Name = 
                    model.Add(item);
                    dbSetting.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else ViewData["EditError"] = "Please, correct all errors.";
            BLSetting.Setting.SetSetting(BLSetting.Setting.GetSettingForCurrentUserList(dbSetting));
            //
            var settingModel = BLSetting.Setting.GetSettingModel(aspNetUsersEntities, dbSetting);
            return PartialView("_GridViewSettingPartial", settingModel);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewSettingPartialUpdate(Database.Setting item)
        {
            var model = dbSetting.Settings;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.ID == item.ID);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        dbSetting.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            BLSetting.Setting.SetSetting(BLSetting.Setting.GetSettingForCurrentUserList(dbSetting));
            //
            var settingModel = BLSetting.Setting.GetSettingModel(aspNetUsersEntities, dbSetting);
            return PartialView("_GridViewSettingPartial", settingModel);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewSettingPartialDelete(System.Int32 ID)
        {
            var model = dbSetting.Settings;
            if (ID >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.ID == ID);
                    if (item != null)
                        model.Remove(item);
                    dbSetting.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            BLSetting.Setting.SetSetting(BLSetting.Setting.GetSettingForCurrentUserList(dbSetting));
            //
            var settingModel = BLSetting.Setting.GetSettingModel(aspNetUsersEntities, dbSetting);
            return PartialView("_GridViewSettingPartial", settingModel);
        }
    }
}