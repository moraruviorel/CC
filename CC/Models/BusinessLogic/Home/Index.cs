using CC.Models.Classes.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models.BusinessLogic.Home
{
    public class Index
    {
        public static IndexModel GetIndexModel()
        {
            var model = new IndexModel
            {
                FiltersCanView = User.UserPermissions.GetUserPermissionByModuleType(Enums.ModuleTypes.Filters).can_view ?? false,
                LoanMoneyCanView = User.UserPermissions.GetUserPermissionByModuleType(Enums.ModuleTypes.LoanMoney).can_view ?? false,
                SettingsCanView = User.UserPermissions.GetUserPermissionByModuleType(Enums.ModuleTypes.Settings).can_view ?? false,
                SpecialitiesCanView = User.UserPermissions.GetUserPermissionByModuleType(Enums.ModuleTypes.Speciality).can_view ?? false,
                UnitiesCanView = User.UserPermissions.GetUserPermissionByModuleType(Enums.ModuleTypes.Units).can_view ?? false,
                UsersCanView = User.UserPermissions.GetUserPermissionByModuleType(Enums.ModuleTypes.Users).can_view ?? false
            };

            return model;
        }
    }
}