using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CC.Models.Database;

namespace CC.Models.Classes.Users
{
    public class AspNetUserModel
    {
        public List<AspNetUser> AspNetUserList { get; set; }
       
        public string RoleName { get; set; }

        //public List<LocalUserRoles> UserRoleList { get; set; }


    }

    public class LocalUserRoles
    {
        public string UserID { get; set; }

        public string UserRoleID { get; set; }

        public string RoleName { get; set; }
    }
}