using CC.Models.Classes;
using CC.Models.Classes.Object;
using CC.Models.Enums;
using System.Linq;

namespace CC.Models.BusinessLogic.Object
{
    public class ObjectMaterial
    {        
        public static ObjectMaterialModel GetObjectMaterialModel()
        {
            var objectMaterialList = new Database.ExcelentConstructObjectMaterial().ObjectMaterials
                .AsQueryable()
                .Where(x => x.object_id == MySession.Current.ObjectId).ToList();

            //Find into filter table 
            var filterTable = new Database.FiltersEntities().Filters
                .ToList()
                .Where(x => x.user_id == MySession.Current.UserGuid)
                .Where(x => x.table_name_id == (int)FilterTableName.ObjectMaterial).ToList();
                

            foreach(var item in filterTable)
            {
                switch (item.operation_id)
                {
                    case (int)Operations.Bigger:
                        objectMaterialList = objectMaterialList
                            .Where(x => x.buyed_date >= MyConvert.ToDateTime(item.compare_value))
                            .ToList();
                        break;
                    case (int)Operations.Smaller:
                        objectMaterialList = objectMaterialList
                            .Where(x => x.buyed_date <= MyConvert.ToDateTime(item.compare_value))
                            .ToList();
                        break;
                }
            }

            var objectMaterialModel = new ObjectMaterialModel
            {
                ObjectList = Object.GetObjectsByParentId(),
                ObjectMaterialList = objectMaterialList,
                UnitList = new Database.ExcelentConstructUnit().Units.ToList()
            };

            return objectMaterialModel;
        }
    }
}