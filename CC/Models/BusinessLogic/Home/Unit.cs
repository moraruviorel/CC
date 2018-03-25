using CC.Models.Classes.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models.BusinessLogic.Home
{
    public class Unit
    {
        public static UnitModel GetUnitModel()
        {
            var unitModel = new UnitModel();

            unitModel.UnitList = new Database.ExcelentConstructUnit().Units.ToList();
            unitModel.UserPermission = User.UserPermissions.GetUserPermissionByModuleType(Enums.ModuleTypes.Units);

            return unitModel;
        }
    }
}