using CC.Models.Classes;
using CC.Models.Classes.Account;
using CC.Models.Enums;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models.BusinessLogic.User
{
    public class UserRole
    { 
        public static void SetUserRole(string userId)
        {
            MySession.Current.IsUserAdmin = false;

            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var role = UserManager.GetRoles(userId);
            
            switch (role[0])
            {
                case "Admin":
                    MySession.Current.UserRole = UserRoleType.Admin;
                    break;
                case "Manager":
                    MySession.Current.UserRole = UserRoleType.Manager;
                    break;
                case "Driver":
                    MySession.Current.UserRole = UserRoleType.Driver;
                    break;
                case "Worker":
                    MySession.Current.UserRole = UserRoleType.Worker;
                    break;
                case "Dentistry":
                    MySession.Current.UserRole = UserRoleType.Dentistry;
                    break;
                default:
                    MySession.Current.UserRole = UserRoleType.User;
                    break;
            }

            if (MySession.Current.UserRole == UserRoleType.Admin)
            {
                MySession.Current.IsUserAdmin = true;
            }
        }
    }
}