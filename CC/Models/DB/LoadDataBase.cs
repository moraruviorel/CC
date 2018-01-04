using CC.Models.Classes;
using System.Collections.Generic;
using System.Linq;

namespace CC.Models.DB
{
    public abstract class LoadDataBase
    {
        
        public static List<Object> GetObjectsByParentId()
        {
            ExcelentConstructEntitiesObjects db4 = new ExcelentConstructEntitiesObjects();
            var user_id = MySession.Current.UserGuid;
            var parent_id = MySession.Current.ObjectId;
            return db4.Objects.Where(x => x.UserId == user_id && x.Parent_Id == parent_id).ToList();            
        }
                
        public static List<Object> GetObjectsByParentId(int parentId)
        {
            ExcelentConstructEntitiesObjects db4 = new ExcelentConstructEntitiesObjects();
            var user_id = MySession.Current.UserGuid;            
            return db4.Objects.Where(x => x.UserId == user_id && x.Parent_Id == parentId).ToList();
        }

        public static List<Object> GetObjectsById(int objectId)
        {
            ExcelentConstructEntitiesObjects db4 = new ExcelentConstructEntitiesObjects();
            var user_id = MySession.Current.UserGuid;
            return db4.Objects.Where(x => x.UserId == user_id && x.ID == objectId).ToList();
        }

        public static List<Worker> GetWorkerList()
        {
            ExcelentConstructWorkers dbWorkers = new ExcelentConstructWorkers();
            var user_id = MySession.Current.UserGuid;
            //
            return dbWorkers.Workers.ToList().Where(x => x.UserId == user_id).ToList();
        }
                       
        
    }
}