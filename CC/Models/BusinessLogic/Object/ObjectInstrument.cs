using CC.Models.Classes;
using CC.Models.Classes.Object;
using CC.Models.Enums;
using System.Linq;

namespace CC.Models.BusinessLogic.Object
{
    public class ObjectInstrument
    {

        public static ObjectInstrumentModel GetObjectInstrumentModel()
        {
            var objectInstrumentModel = new ObjectInstrumentModel();

            objectInstrumentModel.ObjectList = Object.GetObjectsByParentId();
            //
            objectInstrumentModel.WorkerList = BusinessLogic.Worker.Worker.GetWorkerList();
            //
            var objectInstrumentList = new Database.ExcelentConstructObjectInstruments().ObjectInstruments.ToList()
                .Where(x => x.object_id == MySession.Current.ObjectId).ToList();
            //
            var filterTable = new Database.FiltersEntities().Filters
                .ToList()
                .Where(x => x.user_id == MySession.Current.UserGuid)
                .Where(x => x.table_name_id == (int)FilterTableName.ObjectInstruments).ToList();
            //
            foreach (var item in filterTable)
            {
                switch (item.operation_id)
                {
                    case (int)Operations.Equal:
                        break;
                    case (int)Operations.Bigger:
                        objectInstrumentList = objectInstrumentList
                            .Where(x => x.first_day >= MyConvert.ToDateTime(item.compare_value))
                            .ToList();
                        break;
                    case (int)Operations.Smaller:
                        objectInstrumentList = objectInstrumentList
                            .Where(x => x.first_day <= MyConvert.ToDateTime(item.compare_value))
                            .ToList();
                        break;
                }
            }
            objectInstrumentModel.ObjectInstrumentList = objectInstrumentList;
            //

            return objectInstrumentModel;
        }
    }
}