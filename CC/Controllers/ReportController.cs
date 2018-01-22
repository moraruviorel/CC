using DevExpress.Web.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Database = CC.Models.Database;

namespace CC.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Object()
        {
            return View();
        }

        //public ActionResult AndreiRaport()
        //{            
        //    var report = new XtraReport1();

        //    var model = db.ReportSettings.ToList();            
        //    foreach (var item in model)
        //    {
        //        var parameter = new DevExpress.XtraReports.Parameters.Parameter();
        //        parameter.Name = item.name;
        //        parameter.Value = item.value;
        //        report.Parameters.Add(parameter);
        //    }

        //    var stream = new MemoryStream();
        //    report.ExportToPdf(stream);

        //    var cd = new System.Net.Mime.ContentDisposition
        //    {
        //        FileName = DateTime.Today.ToString() + ".pdf",
        //        Inline = false,
        //    };
        //    Response.AppendHeader("Content-Disposition", cd.ToString());
        //    return File(stream.GetBuffer(), "application/pdf");
        //}

        public ActionResult SettingReport()
        {
            return View();
        }

        Database.ReportSettingEntities db = new Database.ReportSettingEntities();

        [ValidateInput(false)]
        public ActionResult ReportSettingPartial()
        {
            var model = db.ReportSettings.ToList();                      
            return PartialView("_ReportSettingPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ReportSettingPartialAddNew(Database.ReportSetting item)
        {
            var model = db.ReportSettings;
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
            return PartialView("_ReportSettingPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ReportSettingPartialUpdate(Database.ReportSetting item)
        {
            var model = db.ReportSettings;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
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
            return PartialView("_ReportSettingPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ReportSettingPartialDelete(System.Int32 id)
        {
            var model = db.ReportSettings;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_ReportSettingPartial", model.ToList());
        }
    }
}