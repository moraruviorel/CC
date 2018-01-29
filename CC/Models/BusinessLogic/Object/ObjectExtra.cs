using CC.Models.Classes;
using CC.Models.Classes.Object;
using CC.Models.Enums;
using System.Linq;

namespace CC.Models.BusinessLogic.Object
{
    public class ObjectExtra
    {
        public static ObjectExtraModel GetObjectExtraModel()
        {
            var objectExtraModel = new ObjectExtraModel();

            objectExtraModel.ObjectList = Object.GetObjectsByParentId();
            //
            objectExtraModel.WorkerList = BusinessLogic.Worker.Worker.GetWorkerList();
            //
            var objectExtraList = new Database.ExcelentConstructObjectExtras().ObjectExtras.ToList()
                .Where(x => x.object_id == MySession.Current.ObjectId).ToList();
            //
            var filterTable = new Database.FiltersEntities().Filters
                .ToList().Where(x => x.table_name_id == (int)FilterTableName.ObjectExtra).ToList();
            //
            foreach (var item in filterTable)
            {
                switch (item.operation_id)
                {
                    case (int)Operations.Equal:
                        objectExtraList = objectExtraList
                           .Where(x => x.create_date == MyConvert.ToDateTime(item.compare_value))
                           .ToList();
                        break;
                    case (int)Operations.Bigger:
                        objectExtraList = objectExtraList
                            .Where(x => x.create_date >= MyConvert.ToDateTime(item.compare_value))
                            .ToList();
                        break;
                    case (int)Operations.Smaller:
                        objectExtraList = objectExtraList
                            .Where(x => x.create_date <= MyConvert.ToDateTime(item.compare_value))
                            .ToList();
                        break;
                }
            }
            objectExtraModel.ObjectExtraList = objectExtraList;
            //
            return objectExtraModel;
        }
    }
}