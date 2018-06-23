using CC.Models.Classes;
using CC.Models.Classes.Object;
using CC.Models.Enums;
using System.Linq;

namespace CC.Models.BusinessLogic.Object
{
    public class ObjectWorks
    {

        public static ObjectWorksModel GetObjectWorkModel()
        {
            
            //
            var filterTable = new Database.FiltersEntities().Filters
                .ToList()
                .Where(x => x.user_id == MySession.Current.UserGuid)
                .Where(x => x.table_name_id == (int)FilterTableName.ObjectWorks)
                .ToList();

            var objectWorksList = new Database.WorksEntities().Works
                .Where(x=>x.object_id == MySession.Current.ObjectId).ToList();

            foreach (var item in filterTable)
            {
                switch (item.operation_id)
                {
                    case (int)Operations.Equal:
                        objectWorksList = objectWorksList
                            .Where(x => x.date_start == MyConvert.ToDateTime(item.compare_value))
                            .ToList();
                        break;
                    case (int)Operations.Bigger:
                        objectWorksList = objectWorksList
                            .Where(x => x.date_start >= MyConvert.ToDateTime(item.compare_value))
                            .ToList();
                        break;
                    case (int)Operations.Smaller:
                        objectWorksList = objectWorksList
                            .Where(x => x.date_start <= MyConvert.ToDateTime(item.compare_value))
                            .ToList();
                        break;
                }
            }

            var objectWorksModel = new ObjectWorksModel
            {
                //
                ObjectList = Object.GetObjectsByParentId(),
                //
                UnitList = new Database.ExcelentConstructUnit().Units.ToList(),
                //
                WorkerList = new Database.ExcelentConstructWorkers()
                    .Workers.ToList().Where(x => x.UserId == MySession.Current.UserGuid).ToList(),
                
                ObjectWorksList = objectWorksList,

                WorkersGroupList = Worker.WorkersGroups.GetWorkersGroupsModel().WorkersGroupList
            };
            
            return objectWorksModel;
        }

        public static decimal GetWorksSum(int workerGroupId)
        {
            var works = new Database.WorksEntities().Works.ToList()
                .Where(x => x.workers_group_id == workerGroupId && x.is_paid == 0).ToList();

            //decimal sumDecimal = 0;
            //foreach (var item in works)
            //{
            //    sumDecimal = sumDecimal + (item.unit_price_worker ?? 0) * (item.surface_work ?? 0);
            //}

            return works.Sum(x => (x.unit_price_worker ?? 0) * (x.surface_work ?? 0));
        }
    }
 }