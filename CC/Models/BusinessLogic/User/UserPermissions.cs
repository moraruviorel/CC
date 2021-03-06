﻿using CC.Models.Classes;
using CC.Models.Classes.Users;
using CC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using CC.Models.Database;
using DevExpress.Office.Utils;

namespace CC.Models.BusinessLogic.User
{
    public class UserPermissions
    {
        public static UserPermissionsModel GetUserPermissionModel(Guid guid, int moduleId)
        {
            var userPermissionList = new UserPermissionsEntities().UserPermissions.
                                                        AsQueryable().Where(x => x.user_id == guid).ToList();

            if (moduleId == 0)
                userPermissionList = userPermissionList.Where(x => x.item_id == 0).ToList();
            else userPermissionList = userPermissionList.Where(x => x.module_id == moduleId && x.item_id != 0).ToList();
            //
            Dictionary<int, string> dict = new Dictionary<int, string>();
            foreach (ModuleTypes item in Enum.GetValues(typeof(ModuleTypes)))
            {
                var text = string.Format("{0}", Home.TranslateWord.GetWord(item.ToString()));
                dict.Add((int)item, text);
            }

            var userPermissionModel = new UserPermissionsModel
            {
                ModuleList = dict,
                UserPermissionList = userPermissionList,
                ItemList = GetItemList(moduleId)
            };

            return userPermissionModel;
        }

        public static void SetUserPermissions()
        {
            switch (MySession.Current.UserRole)
            {
                case UserRoleType.Admin:
                    MySession.Current.UserPermisionList = SetDefaultUserPermission(true);
                    break;
                case UserRoleType.Manager:
                    MySession.Current.UserPermisionList = SetDefaultUserPermission(true);
                    SetDatabasePermissions();
                    break;
                case UserRoleType.User:
                    MySession.Current.UserPermisionList = SetDefaultUserPermission(false);
                    SetDatabasePermissions();
                    break;
                default:
                    MySession.Current.UserPermisionList = SetDefaultUserPermission(false);
                    SetDatabasePermissions();
                    break;
            }
        }

        private static List<UserPermission> SetDefaultUserPermission(bool up)
        {
            var userPermission = new List<UserPermission>();

            foreach (var item in Enum.GetValues(typeof(ModuleTypes)))
            {
                userPermission.Add(new UserPermission
                {
                    module_id = (int)item,
                    can_view = up,
                    can_add = up,
                    can_delete = up,
                    can_edit = up
                });
            }
            
            return userPermission;
        }
        
        private static void SetDatabasePermissions()
        {
            var userPermissionList = new UserPermissionsEntities().UserPermissions.
                AsQueryable().Where(x => x.user_id == new Guid(MySession.Current.UserGuid)).ToList();

            foreach (var item in userPermissionList)
            {
                var userPermission = MySession.Current.UserPermisionList
                    .FirstOrDefault(x => x.module_id == item.module_id);

                if (userPermission != null)
                {
                    userPermission.can_view = item.can_view;
                    userPermission.can_edit = item.can_edit;
                    userPermission.can_delete = item.can_delete;
                    userPermission.can_add = item.can_add;
                }
            }
        }

        public static UserPermission GetUserPermissionByModuleType(ModuleTypes moduleName)
        {
            if (MySession.Current.UserPermisionList == null) return new UserPermission();

            var up = MySession.Current.UserPermisionList.FirstOrDefault(x => x.module_id == (int)moduleName);
        
            if(up == null)
                up = new UserPermission();

            return up;
        }

        public static Dictionary<int, string> GetItemList(int moduleId)
        {
            var itemList = new Dictionary<int, string>();
            
            switch (moduleId)
            {
                case (int)ModuleTypes.Objects:
                    itemList = Object.Object.GetObjectModel().ObjectList.ToList()
                        .Where(x => x.UserId == MySession.Current.UserGuid)
                        .Select(x => new {id = x.ID, name = x.Address})
                        .AsEnumerable()
                        .ToDictionary(dic => dic.id, dic => dic.name);
                    break;
            }

            return itemList;
        }

        public static List<int> GetModuleItemIds(ModuleTypes moduleType)
        {
            var result = new UserPermissionsEntities().UserPermissions.AsQueryable()
                .Where(x => x.user_id == new Guid(MySession.Current.UserGuid)
                            && x.module_id == (int)moduleType
                            && x.item_id != 0).AsEnumerable()
                .Select(x => x.item_id).ToList();

            return result;
        }
    }

}