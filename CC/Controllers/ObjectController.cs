using CC.Models;
using CC.Models.Classes;
using CC.Models.Enums;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static CC.Models.Classes.Enums;
using static CC.Models.BusinessLogic.Functions;

namespace CC.Controllers
{
    public class ObjectController : Controller
    {
        public ActionResult ObjectDetail(int objectId)
        {
            MySession.Current.WorksForm = (int)FormName.ObjectForm;
            MySession.Current.ObjectId = objectId;
            return View();
        }

        public ActionResult OnCallback()
        {
            object test = Request.Params["tabIndex"];
            string partialView = "Objects";
            switch (test.ToString())
            {
                case "0":
                    partialView = "ObjectDetail/ObjectTotal";
                    break;
                case "1":
                    partialView = "ObjectDetail/ObjectWorks";
                    break;
                case "2":
                    partialView = "ObjectDetail/ObjectMaterials";
                    break;
                case "3":
                    partialView = "ObjectDetail/ObjectInstruments";
                    break;
                case "4":
                    partialView = "ObjectDetail/ObjectExtras";
                    break;
                case "5":
                    partialView = "ObjectDetail/ObjectPayments";
                    break;
                case "6":
                    ViewBag.Works = dbWorks.Works.ToList().Where(x => x.object_id == MySession.Current.ObjectId).ToList();
                    ViewBag.MaterialSum = dbMaterial.ObjectMaterials.ToList().Where(x => x.object_id == MySession.Current.ObjectId)
                                                                             .Sum(x => x.total_price);
                    ViewBag.InstrumentSum = dbInstruments.ObjectInstruments.ToList().Where(x => x.object_id == MySession.Current.ObjectId)
                                                                                    .Sum(x => x.total_price);
                    ViewBag.ExtraSum = dbObjectExtras.ObjectExtras.ToList().Where(x => x.object_id == MySession.Current.ObjectId).Sum(x => x.price);
                    partialView = "ObjectDetail/ObjectTotal";
                    break;
            }

            return PartialView(partialView);
        }

        public ActionResult ExportTo(string name)
        {
            switch (name)
            {
                case "GridViewWorks":
                    MySession.Current.TabAction = name;
                    MySession.Current.Units = dbUnits.Units.ToList();
                    var list = MySession.Current.GridReport;
                    var modelToShow = dbWorks.Works.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
                    return GridViewExtension.ExportToPdf(CC.Models.ExportDataGridView.ExportDataGridView.GetGridSettings(name), modelToShow.ToList());
                case "GridViewMaterial":
                    MySession.Current.TabAction = name;
                    list = MySession.Current.GridReport;
                    var materials = dbMaterial.ObjectMaterials.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
                    return GridViewExtension.ExportToPdf(CC.Models.ExportDataGridView.ExportDataGridView.GetGridSettings(name), materials.ToList());
                case "GridViewExtra":
                    MySession.Current.TabAction = name;
                    list = MySession.Current.GridReport;
                    var extras = dbObjectExtras.ObjectExtras.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
                    return GridViewExtension.ExportToPdf(CC.Models.ExportDataGridView.ExportDataGridView.GetGridSettings(name), extras.ToList());
                case "GridViewInstrument":
                    MySession.Current.TabAction = name;
                    list = MySession.Current.GridReport;
                    var instruments = dbInstruments.ObjectInstruments.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
                    return GridViewExtension.ExportToPdf(CC.Models.ExportDataGridView.ExportDataGridView.GetGridSettings(name), instruments.ToList());
                default:
                    modelToShow = dbWorks.Works.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
                    return GridViewExtension.ExportToPdf(CC.Models.ExportDataGridView.ExportDataGridView.GetGridSettings(name), modelToShow.ToList());
            }

        }

        #region Objects

        [AuthorizeRoles(UserRole.Admin, UserRole.Manager)]
        public ActionResult Objects(int? objectId)
        {
            objectId = objectId ?? 0;
            MySession.Current.ObjectId = objectId ?? 0;

            if (objectId == 0)
            {
                MySession.Current.ParentId = objectId ?? 0;
            }
            else
                MySession.Current.ParentId = dbObjects.Objects.ToList().FirstOrDefault(x => x.ID == objectId).Parent_Id ?? 0;
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewObjects()
        {
            var model = Models.DB.LoadDataBase.GetObjectsByParentId();
            //
            ViewBag.ObjectsParent = Models.DB.LoadDataBase.GetObjectsById(MySession.Current.ObjectId);
            //
            return PartialView("_GridViewObjects", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewObjectsAddNew(CC.Models.Object item)
        {
            var model = dbObjects.Objects;
            if (ModelState.IsValid)
            {
                try
                {
                    item.UserId = MySession.Current.UserGuid;
                    item.Parent_Id = MySession.Current.ObjectId;
                    model.Add(item);
                    dbObjects.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var modelToShow = Models.DB.LoadDataBase.GetObjectsByParentId();
            return PartialView("_GridViewObjects", modelToShow.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewObjectsUpdate(CC.Models.Object item)
        {
            var model = dbObjects.Objects;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.ID == item.ID);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        dbObjects.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var modelToShow = Models.DB.LoadDataBase.GetObjectsByParentId();
            return PartialView("_GridViewObjects", modelToShow.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewObjectsDelete(System.Int32 ID)
        {
            var model = dbObjects.Objects;
            if (ID >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.ID == ID);
                    if (item != null)
                        model.Remove(item);
                    dbObjects.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var modelToShow = Models.DB.LoadDataBase.GetObjectsByParentId();
            return PartialView("_GridViewObjects", modelToShow.ToList());
        }


        #endregion

        #region ObjectPayments

        [AuthorizeRoles(UserRole.Admin, UserRole.Manager)]
        public ActionResult ObjectPayments()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewObjectPayments()
        {
            var model = dbObjectPayments.ObjectPayments.AsQueryable().Where(x => x.object_id == MySession.Current.ObjectId);
            return PartialView("_GridViewObjectPayments", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewObjectPaymentsAddNew(ObjectPayments item)
        {
            var model = dbObjectPayments.ObjectPayments;
            if (ModelState.IsValid)
            {
                try
                {
                    item.object_id = MySession.Current.ObjectId;
                    model.Add(item);
                    dbObjectPayments.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var modelToShow = dbObjectPayments.ObjectPayments.AsQueryable().Where(x => x.object_id == MySession.Current.ObjectId);
            return PartialView("_GridViewObjectPayments", modelToShow.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewObjectPaymentsUpdate(ObjectPayments item)
        {
            var model = dbObjectPayments.ObjectPayments;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        dbObjectPayments.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var modelToShow = dbObjectPayments.ObjectPayments.AsQueryable().Where(x => x.object_id == MySession.Current.ObjectId);
            return PartialView("_GridViewObjectPayments", modelToShow.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewObjectPaymentsDelete(System.Int32 id)
        {
            var model = dbObjectPayments.ObjectPayments;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    dbObjectPayments.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var modelToShow = dbObjectPayments.ObjectPayments.AsQueryable().Where(x => x.object_id == MySession.Current.ObjectId);
            return PartialView("_GridViewObjectPayments", modelToShow.ToList());
        }

        #endregion

        #region ObjectWorks

        [AuthorizeRoles(UserRole.Admin, UserRole.Manager)]
        public ActionResult ObjectWorks()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewWorks()
        {

            ViewBag.Workers = Models.DB.LoadDataBase.GetWorkerList();
            ViewBag.Unites = dbUnits.Units.ToList();
            if (MySession.Current.WorksForm == (int)FormName.ObjectForm)
            {
                //ViewBag.Objects = Models.DB.LoadDataBase.GetObjectsByParentId();
                List<Work> workList = dbWorks.Works.ToList().Where(x => x.object_id == MySession.Current.ObjectId).ToList();
                return PartialView("_GridViewWorks", workList);
            }
            else
            {
                ViewBag.Objects = dbObjects.Objects.ToList().Where(x => x.UserId == MySession.Current.UserGuid);
                List<Work> workList = dbWorks.Works.ToList().Where(x => x.worker_id == MySession.Current.WorkerId).ToList();
                return PartialView("_GridViewWorks", workList);
            }


        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewWorksAddNew(CC.Models.Work item)
        {
            var model = dbWorks.Works;
            if (ModelState.IsValid)
            {
                try
                {
                    item.object_id = MySession.Current.ObjectId;
                    if (item.date_end == null && item.date_start == null)
                    {
                        item.date_start = DateTime.Now;
                        item.date_end = DateTime.Now;
                    }
                    if (item.surface == null)
                        item.surface = "0";
                    if (item.unit_price == null)
                        item.unit_price = 0;

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
            var modelToShow = dbWorks.Works.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
            return PartialView("_GridViewWorks", modelToShow.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewWorksUpdate(CC.Models.Work item)
        {
            var model = dbWorks.Works;
            if (ModelState.IsValid)
            {
                try
                {
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
            var modelToShow = dbWorks.Works.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
            return PartialView("_GridViewWorks", modelToShow.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewWorksDelete(System.Int32 id)
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
            var modelToShow = dbWorks.Works.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
            return PartialView("_GridViewWorks", modelToShow.ToList());
        }

        #endregion

        #region ObjectMaterial

        [AuthorizeRoles(UserRole.Admin, UserRole.Manager)]
        public ActionResult ObjectMaterials()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewObjectMaterial()
        {
            ViewBag.Objects = Models.DB.LoadDataBase.GetObjectsByParentId();
            var model = dbMaterial.ObjectMaterials.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
            return PartialView("_GridViewObjectMaterial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewObjectMaterialAddNew(ObjectMaterial item)
        {
            var model = dbMaterial.ObjectMaterials;
            if (ModelState.IsValid)
            {
                try
                {
                    item.object_id = MySession.Current.ObjectId;
                    model.Add(item);
                    dbMaterial.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var modelToShow = dbMaterial.ObjectMaterials.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
            return PartialView("_GridViewObjectMaterial", modelToShow.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewObjectMaterialUpdate(ObjectMaterial item)
        {
            var model = dbMaterial.ObjectMaterials;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        dbMaterial.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var modelToShow = dbMaterial.ObjectMaterials.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
            return PartialView("_GridViewObjectMaterial", modelToShow.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewObjectMaterialDelete(System.Int32 id)
        {
            var model = dbMaterial.ObjectMaterials;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    dbMaterial.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var modelToShow = dbMaterial.ObjectMaterials.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
            return PartialView("_GridViewObjectMaterial", modelToShow.ToList());
        }

        #endregion

        #region ObjectInstruments

        [AuthorizeRoles(UserRole.Admin, UserRole.Manager)]
        public ActionResult ObjectInstruments()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewObjectInstrument()
        {
            ViewBag.Objects = Models.DB.LoadDataBase.GetObjectsByParentId();
            ViewBag.Workers = Models.DB.LoadDataBase.GetWorkerList();
            var modelToShow = dbInstruments.ObjectInstruments.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
            return PartialView("_GridViewObjectInstrument", modelToShow.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewObjectInstrumentAddNew(CC.Models.ObjectInstrument item)
        {
            var model = dbInstruments.ObjectInstruments;
            if (ModelState.IsValid)
            {
                try
                {
                    item.object_id = MySession.Current.ObjectId;
                    model.Add(item);
                    dbInstruments.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var modelToShow = dbInstruments.ObjectInstruments.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
            return PartialView("_GridViewObjectInstrument", modelToShow.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewObjectInstrumentUpdate(CC.Models.ObjectInstrument item)
        {
            var model = dbInstruments.ObjectInstruments;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        dbInstruments.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var modelToShow = dbInstruments.ObjectInstruments.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
            return PartialView("_GridViewObjectInstrument", modelToShow.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewObjectInstrumentDelete(System.Int32 id)
        {
            var model = dbInstruments.ObjectInstruments;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    dbInstruments.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var modelToShow = dbInstruments.ObjectInstruments.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
            return PartialView("_GridViewObjectInstrument", modelToShow.ToList());
        }

        #endregion

        #region ObjectExtras

        public ActionResult ObjectExtras()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewObjectExtra()
        {
            ViewBag.Objects = Models.DB.LoadDataBase.GetObjectsByParentId();
            ViewBag.Workers = Models.DB.LoadDataBase.GetWorkerList();
            var modelToShow = dbObjectExtras.ObjectExtras.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
            return PartialView("_GridViewObjectExtra", modelToShow.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewObjectExtraAddNew(ObjectExtra item)
        {
            var model = dbObjectExtras.ObjectExtras;
            if (ModelState.IsValid)
            {
                try
                {
                    item.object_id = MySession.Current.ObjectId;
                    model.Add(item);
                    dbObjectExtras.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var modelToShow = dbObjectExtras.ObjectExtras.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
            return PartialView("_GridViewObjectExtra", modelToShow.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewObjectExtraUpdate(ObjectExtra item)
        {
            var model = dbObjectExtras.ObjectExtras;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        dbObjectExtras.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var modelToShow = dbObjectExtras.ObjectExtras.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
            return PartialView("_GridViewObjectExtra", modelToShow.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewObjectExtraDelete(System.Int32 id)
        {
            var model = dbObjectExtras.ObjectExtras;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    dbObjectExtras.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;

                }
            }
            var modelToShow = dbObjectExtras.ObjectExtras.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
            return PartialView("_GridViewObjectExtra", modelToShow.ToList());
        }

        #endregion


        ExcelentConstructObjectMaterial dbMaterial = new ExcelentConstructObjectMaterial();

        ExcelentConstructObjectInstruments dbInstruments = new ExcelentConstructObjectInstruments();

        ExcelentConstructWorks dbWorks = new ExcelentConstructWorks();

        ExcelentConstructEntitiesObjects dbObjects = new ExcelentConstructEntitiesObjects();

        ExcelentConstructObjectExtras dbObjectExtras = new ExcelentConstructObjectExtras();

        ExcelentConstructUnit dbUnits = new ExcelentConstructUnit();

        ObjectPaymentEntities dbObjectPayments = new ObjectPaymentEntities();
    }
}