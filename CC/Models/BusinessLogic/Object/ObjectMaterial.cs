using CC.Models.Classes;
using CC.Models.Classes.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models.BusinessLogic.Object
{
    public class ObjectMaterial
    {        
        public static ObjectMaterialModel GetObjectMaterialModel(
            Database.ExcelentConstructObjectMaterial dbObjectMaterial,
            Database.ExcelentConstructEntitiesObjects dbObjects)
        {
            var objectMaterialModel = new ObjectMaterialModel();

            objectMaterialModel.ObjectList = Object.GetObjectsByParentId(dbObjects);
            var objectMaterialList = dbObjectMaterial.ObjectMaterials
                .AsQueryable()
                .Where(x => x.object_id == MySession.Current.ObjectId).ToList();

            if (MySession.Current.MySetting.StartDate != null && MySession.Current.MySetting.EndDate != null)
            {
                objectMaterialList = objectMaterialList
                    .Where(x => x.buyed_date >= MySession.Current.MySetting.StartDate
                    && x.buyed_date <= MySession.Current.MySetting.EndDate).ToList();
            }

            objectMaterialModel.ObjectMaterialList = objectMaterialList;

            return objectMaterialModel;
        }
    }
}