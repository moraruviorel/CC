﻿using CC.Models;
using CC.Models.Classes;
using CC.Models.Enums;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using static CC.Models.BusinessLogic.Functions;
using Database = CC.Models.Database;
using BLObject = CC.Models.BusinessLogic.Object;
using BLWorker = CC.Models.BusinessLogic.Worker;

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
                    ViewBag.MaterialSum = BLObject.ObjectMaterial.GetObjectMaterialModel(dbObjectMaterial, dbObjects)
                        .ObjectMaterialList.Sum(x => x.total_price);
                    ViewBag.InstrumentSum = dbInstruments.ObjectInstruments.ToList()
                        .Where(x => x.object_id == MySession.Current.ObjectId)                                                                                    
                        .Sum(x => x.total_price);
                    ViewBag.ExtraSum = dbObjectExtras.ObjectExtras.ToList()
                        .Where(x => x.object_id == MySession.Current.ObjectId)
                        .Sum(x => x.price);
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
                    var materials = dbObjectMaterial.ObjectMaterials.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
                    return GridViewExtension.ExportToPdf(CC.Models.ExportDataGridView.ExportDataGridView.GetGridSettings(name), materials.ToList());
                case "GridViewExtra":
                    MySession.Current.TabAction = name;
                    list = MySession.Current.GridReport;
                    var extras = dbObjectExtras.ObjectExtras.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
                    return GridViewExtension.ExportToPdf(CC.Models.ExportDataGridView.ExportDataGridView.GetGridSettings(name), extras.ToList());
                case "GridViewPayment":
                    MySession.Current.TabAction = name;
                    list = MySession.Current.GridReport;
                    var payment = dbObjectPayments.ObjectPayments.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
                    return GridViewExtension.ExportToPdf(CC.Models.ExportDataGridView.ExportDataGridView.GetGridSettings(name), payment.ToList());
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

            var model = new Models.Classes.Object.ObjectModel();

            if (objectId == 0)
            {
                MySession.Current.ParentId = objectId ?? 0;
            }
            else
                MySession.Current.ParentId = dbObjects.Objects.ToList().FirstOrDefault(x => x.ID == objectId).Parent_Id ?? 0;
            return View(model);
        }

        [ValidateInput(false)]
        public ActionResult GridViewObjects()
        {
            var model = BLObject.Object.GetObjectsByParentId(dbObjects);
            //
            ViewBag.ObjectsParent = BLObject.Object.GetObjectsById(MySession.Current.ObjectId);
            //
            return PartialView("_GridViewObjects", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewObjectsAddNew(Database.Object item)
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
            var modelToShow = BLObject.Object.GetObjectsByParentId(dbObjects);
            return PartialView("_GridViewObjects", modelToShow.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewObjectsUpdate(Database.Object item)
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
            var modelToShow = BLObject.Object.GetObjectsByParentId(dbObjects);
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
            var modelToShow = BLObject.Object.GetObjectsByParentId(dbObjects);
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
        public ActionResult GridViewObjectPaymentsAddNew(Database.ObjectPayments item)
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
        public ActionResult GridViewObjectPaymentsUpdate(Database.ObjectPayments item)
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

            ViewBag.Workers = BLWorker.Worker.GetWorkerList(dbWorkers);
            ViewBag.Unites = dbUnits.Units.ToList();
            if (MySession.Current.WorksForm == (int)FormName.ObjectForm)
            {
                //ViewBag.Objects = Models.DB.LoadDataBase.GetObjectsByParentId();
                List<Database.Work> workList = dbWorks.Works.ToList().Where(x => x.object_id == MySession.Current.ObjectId).ToList();
                return PartialView("_GridViewWorks", workList);
            }
            else
            {
                ViewBag.Objects = dbObjects.Objects.ToList().Where(x => x.UserId == MySession.Current.UserGuid);
                List<Database.Work> workList = dbWorks.Works.ToList().Where(x => x.worker_id == MySession.Current.WorkerId).ToList();
                return PartialView("_GridViewWorks", workList);
            }


        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewWorksAddNew(Database.Work item)
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
        public ActionResult GridViewWorksUpdate(Database.Work item)
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
            var model = BLObject.ObjectMaterial.GetObjectMaterialModel(dbObjectMaterial, dbObjects);
            return PartialView("_GridViewObjectMaterial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewObjectMaterialAddNew(Database.ObjectMaterial item)
        {
            var model = dbObjectMaterial.ObjectMaterials;
            if (ModelState.IsValid)
            {
                try
                {
                    item.object_id = MySession.Current.ObjectId;
                    model.Add(item);
                    dbObjectMaterial.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var modelToShow = dbObjectMaterial.ObjectMaterials.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
            return PartialView("_GridViewObjectMaterial", modelToShow.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewObjectMaterialUpdate(Database.ObjectMaterial item)
        {
            var model = dbObjectMaterial.ObjectMaterials;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        dbObjectMaterial.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var modelToShow = dbObjectMaterial.ObjectMaterials.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
            return PartialView("_GridViewObjectMaterial", modelToShow.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewObjectMaterialDelete(System.Int32 id)
        {
            var model = dbObjectMaterial.ObjectMaterials;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    dbObjectMaterial.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var modelToShow = dbObjectMaterial.ObjectMaterials.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
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
            ViewBag.Objects = BLObject.Object.GetObjectsByParentId(dbObjects);
            ViewBag.Workers = BLWorker.Worker.GetWorkerList(dbWorkers);
            var modelToShow = dbInstruments.ObjectInstruments.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
            return PartialView("_GridViewObjectInstrument", modelToShow.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewObjectInstrumentAddNew(Database.ObjectInstrument item)
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
        public ActionResult GridViewObjectInstrumentUpdate(Database.ObjectInstrument item)
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
            ViewBag.Objects = BLObject.Object.GetObjectsByParentId(dbObjects);
            ViewBag.Workers = BLWorker.Worker.GetWorkerList(dbWorkers);
            var modelToShow = dbObjectExtras.ObjectExtras.ToList().Where(x => x.object_id == MySession.Current.ObjectId);
            return PartialView("_GridViewObjectExtra", modelToShow.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewObjectExtraAddNew(Database.ObjectExtra item)
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
        public ActionResult GridViewObjectExtraUpdate(Database.ObjectExtra item)
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


        Database.ExcelentConstructObjectMaterial dbObjectMaterial = new Database.ExcelentConstructObjectMaterial();

        Database.ExcelentConstructObjectInstruments dbInstruments = new Database.ExcelentConstructObjectInstruments();

        Database.ExcelentConstructWorks dbWorks = new Database.ExcelentConstructWorks();

        Database.ExcelentConstructEntitiesObjects dbObjects = new Database.ExcelentConstructEntitiesObjects();

        Database.ExcelentConstructObjectExtras dbObjectExtras = new Database.ExcelentConstructObjectExtras();

        Database.ExcelentConstructUnit dbUnits = new Database.ExcelentConstructUnit();

        Database.ObjectPaymentEntities dbObjectPayments = new Database.ObjectPaymentEntities();

        Database.ExcelentConstructWorkers dbWorkers = new Database.ExcelentConstructWorkers();
    }
}