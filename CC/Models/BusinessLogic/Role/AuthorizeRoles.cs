using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using CC.Models.Classes;
using CC.Models.Enums;
using DevExpress.Printing.Utils.DocumentStoring;
using DevExpress.XtraLayout.Customization;

namespace CC.Models.BusinessLogic.Role
{
    public static class AuthorizeRoles
    {
        public class AuthorizeRolesAttribute : AuthorizeAttribute
        {
            public AuthorizeRolesAttribute(object typeId, params UserRoleType[] roles) : base()
            {
                string[] rolesName = new string[roles.Length];
                for (int i = 0; i < roles.Length; i++)
                {
                    rolesName[i] = GetDescription(roles[i]);
                }

                //if (!roles.Contains(MySession.Current.UserRole))
                //{
                //    if(User.UserPermissions.GetUserPermissionByModuleType(MySession.Current.UserRole)
                //}
                Roles = String.Join(",", rolesName);
            }

            

        }

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
    }
}