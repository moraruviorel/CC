using CC.Models.Classes;
using CC.Models.Classes.Users;
using CC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CC.Models.BusinessLogic.User
{
    public class AspNetUser
    {
        public static AspNetUserModel GetUserModel()
        {
            AspNetUserModel aspNetUserModel = new AspNetUserModel();

            switch (MySession.Current.IsUserAdmin)
            {
                case true:
                    aspNetUserModel.AspNetUserList = new Database.AspNetUsersEntities().AspNetUsers.ToList();                                                        
                    break;
                case false:
                    aspNetUserModel.AspNetUserList = new Database.AspNetUsersEntities().AspNetUsers
                                                        .ToList()
                                                        .Where(x => x.UserParentId == new Guid(MySession.Current.UserGuid))
                                                        .ToList();
                    break;
            }

            var result = new Database.AspNetUsersEntities().AspNetUsers.ToList();

            //result.First().AspNetRoles.First().Name;

            //aspNetUserModel.UserRoleList = GetUserRoleList();
                        
            return aspNetUserModel;
        }

        public static string GetUserRoleName(string userId)
        {
            var users = new Database.AspNetUsersEntities().AspNetUsers.ToList();

            return users.FirstOrDefault(x => x.Id == userId)?.AspNetRoles.FirstOrDefault()?.Name;
        }

        //private static List<LocalUserRoles> GetUserRoleList()
        //{
        //    var dbRoles = new Database.AspNetUserRoleEntities().AspNetRoles.ToList();
        //    var dbUserRoles = new Database.AspNetUserRoleEntities().AspNetUserRoles.ToList();

        //    var userRoleList = new List<LocalUserRoles>();
        //    LocalUserRoles lur;
        //    foreach (var item in dbUserRoles)
        //    {
        //        lur = new LocalUserRoles();

        //        if (MySession.Current.UserRole == UserRoleType.Admin
        //            || item.AspNetRole.Name == UserRoleType.Manager.ToString()
        //            || item.AspNetRole.Name == UserRoleType.User.ToString())
        //        {
        //            lur.UserRoleID = item.RoleId;
        //            lur.UserID = item.UserId;
        //            lur.RoleName = item.AspNetRole.Name;

        //            if (lur.UserID != null)
        //                userRoleList.Add(lur);
        //        }
        //    }

        //    return userRoleList;
        //}
        
    }
}