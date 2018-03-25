using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Web.Mvc;
using CC.Models.Classes.Account;
using CC.Models.BusinessLogic.User;
using CC.Models.Classes;

namespace CC.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;

                ViewBag.displayMenu = "No";

                if (IsAdminUser())
                {
                    ViewBag.displayMenu = "Yes";
                }
                return View();
            }
            else
            {
                ViewBag.Name = "Not Logged IN";
            }
            return View();
        }

        public Boolean IsAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = userManager.GetRoles(user.GetUserId());
                if (s[0] == "Admin")
                {
                    return true;
                }
            }
            return false;
        }

        #region AspNetUser

        public ActionResult Users()
        {
            return View();
        }
        
        [ValidateInput(false)]
        public ActionResult AspNetUserPartial()
        {
            return PartialView("_AspNetUserPartial", AspNetUser.GetUserModel());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AspNetUserPartialAddNew(Models.Database.AspNetUser item)
        {
            var model = dbAspNetUser.AspNetUsers;
            if (ModelState.IsValid)
            {
                try
                {
                    item.UserParentId = new Guid(MySession.Current.UserGuid);
                    item.Id = Guid.NewGuid().ToString();
                    model.Add(item);
                    dbAspNetUser.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_AspNetUserPartial", AspNetUser.GetUserModel());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AspNetUserPartialUpdate(Models.Database.AspNetUser item)
        {
            var model = dbAspNetUser.AspNetUsers;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
                    if (modelItem != null)
                    {
                        UpdateModel(modelItem);
                        dbAspNetUser.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_AspNetUserPartial", AspNetUser.GetUserModel());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AspNetUserPartialDelete(String id)
        {
            var model = dbAspNetUser.AspNetUsers;
            if (id != null)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Id == id);
                    if (item != null)
                        model.Remove(item);
                    dbAspNetUser.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_AspNetUserPartial", AspNetUser.GetUserModel());
        }

        #endregion

        #region UserPermissions

        public ActionResult Permissions(Guid userGuid)
        {
            MySession.Current.UserPermissionGuid = userGuid;
            ViewBag.UserPermissionGuid = userGuid;
            return View();
        }
        
        [ValidateInput(false)]
        public ActionResult UserPermissionPartial()
        {
            int moduleId = (int)TempData["module_id"];
            return PartialView("_UserPermissionPartial", 
                UserPermissions.GetUserPermissionModel(MySession.Current.UserPermissionGuid));//, moduleId
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UserPermissionPartialAddNew(Models.Database.UserPermission item)
        {
            var model = dbUserPermission.UserPermissions;
            if (ModelState.IsValid)
            {
                try
                {
                    item.user_id = MySession.Current.UserPermissionGuid;
                    model.Add(item);
                    dbUserPermission.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            return PartialView("_UserPermissionPartial", UserPermissions.GetUserPermissionModel(MySession.Current.UserPermissionGuid));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UserPermissionPartialUpdate(Models.Database.UserPermission item)
        {
            var model = dbUserPermission.UserPermissions;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        UpdateModel(modelItem);
                        dbUserPermission.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            return PartialView("_UserPermissionPartial", UserPermissions.GetUserPermissionModel(MySession.Current.UserPermissionGuid));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UserPermissionPartialDelete(Int32 id)
        {
            var model = dbUserPermission.UserPermissions;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    dbUserPermission.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_UserPermissionPartial", UserPermissions.GetUserPermissionModel(MySession.Current.UserPermissionGuid));
        }

        #endregion

        #region ModulePermissions

        public ActionResult ModulePermissions(int moduleId)
        {
            TempData["module_id"] = moduleId;
            return View();
        }

        #endregion

        #region Database

        Models.Database.AspNetUsersEntities dbAspNetUser = new Models.Database.AspNetUsersEntities();
        
        Models.Database.UserPermissionsEntities dbUserPermission = new Models.Database.UserPermissionsEntities();

        #endregion
    }

}