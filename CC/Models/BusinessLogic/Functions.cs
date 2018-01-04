
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using CC.Models.Enums;
using System.Reflection;
using System.ComponentModel;
using CC.Models.Classes;
//using DevExpress.CodeParser;

namespace CC.Models.BusinessLogic
{
    public static class Functions
    {
        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(field,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return string.Empty;
        }

        public class AuthorizeRolesAttribute : AuthorizeAttribute
        {
            public AuthorizeRolesAttribute(params UserRole[] roles) : base()
            {
                string[] rolesName = new string[roles.Length];
                for (int i = 0; i < roles.Length; i++)
                {                    
                    rolesName[i] = GetDescription(roles[i]);
                }
                var res = string.Join(",", rolesName);
                Roles = string.Join(",", rolesName);
            }
        }
        
        

        /*public Boolean isAdminUser
        {
            get {
                if (User.Identity.IsAuthenticated)
                {
        //            var user = User.Identity;
        //            ApplicationDbContext context = new ApplicationDbContext();
        //            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        //            var s = UserManager.GetRoles(user.GetUserId());
        //            if (s[0].ToString() == "Admin")
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
                }
                return false;
            }
        }*/
    }
}