using System.Linq;
using CC.Models.Classes;
using CC.Models.Classes.Worker;

namespace CC.Models.BusinessLogic.Worker
{
    public class WorkersGroups
    {
        public static WorkersGroupsModel GetWorkersGroupsModel()
        {
            var workersGroupModel = new WorkersGroupsModel()
            {
                WorkersGroupList = new Database.WorkersGroupsEntities().WorkersGroups.ToList()
                    .Where(x => x.user_id == MySession.Current.UserGuid).ToList()
            };

            return workersGroupModel;
        }

        
    }
}