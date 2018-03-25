using CC.Models.Classes;
using CC.Models.Classes.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models.BusinessLogic.Object
{
    public class Object
    {
        public static List<Database.Object> GetObjectsByParentId()
        {
            var user_id = MySession.Current.UserGuid;
            var parent_id = MySession.Current.ObjectId;
            return new Database.ExcelentConstructEntitiesObjects().Objects
                .Where(x => x.UserId == user_id && x.Parent_Id == parent_id).ToList();
        }

        public static List<Database.Object> GetObjectsByParentId(int parentId)
        {
            Database.ExcelentConstructEntitiesObjects db4 = new Database.ExcelentConstructEntitiesObjects();
            var user_id = MySession.Current.UserGuid;
            return db4.Objects.Where(x => x.UserId == user_id && x.Parent_Id == parentId).ToList();
        }

        public static List<Database.Object> GetObjectsById(int objectId)
        {
            Database.ExcelentConstructEntitiesObjects db4 = new Database.ExcelentConstructEntitiesObjects();
            var user_id = MySession.Current.UserGuid;
            return db4.Objects.Where(x => x.UserId == user_id && x.ID == objectId).ToList();
        }


        public static ObjectModel GetObjectModel()
        {
            var objectModel = new ObjectModel();

            objectModel.ObjectList = GetObjectsByParentId();
            objectModel.UserPermissionObject = User.UserPermissions.GetUserPermissionByModuleType(Enums.ModuleTypes.Objects);
            objectModel.ObjectParentList = GetObjectsById(MySession.Current.ObjectId);

            return objectModel;
        }
        
    }
}