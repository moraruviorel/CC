using CC.Models.Classes;
using CC.Models.Classes.Object;
using CC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models.BusinessLogic.Object
{
    public class ObjectWorks
    {

        public static ObjectWorksModel GetObjectWorkModel()
        {
            var objectWorksModel = new ObjectWorksModel();
            //
            objectWorksModel.ObjectList = Object.GetObjectsByParentId();
            //
            objectWorksModel.UnitList = new Database.ExcelentConstructUnit().Units.ToList();
            //
            objectWorksModel.WorkerList = new Database.ExcelentConstructWorkers()
                .Workers.ToList().Where(x => x.UserId == MySession.Current.UserGuid).ToList();
            //
            var filterTable = new Database.FiltersEntities().Filters
                .ToList().Where(x => x.table_name_id == (int)FilterTableName.ObjectWorks).ToList();

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
            objectWorksModel.ObjectWorksList = objectWorksList;


            return objectWorksModel;
        }


    }
}