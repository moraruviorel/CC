using CC.Models.Classes;
using CC.Models.Classes.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models.BusinessLogic.Home
{
    public class Filter
    {
        public static FilterModel GetFilterModel()
        {
            var filterModel = new FilterModel();

            filterModel.TableList = new List<TableName>();
            filterModel.TableList.Add(new TableName { Id = 1, Name = "Lucrari efectuate" });
            filterModel.TableList.Add(new TableName { Id = 2, Name = "Materiale utilizate" });
            filterModel.TableList.Add(new TableName { Id = 3, Name = "Instrumente utilizate" });
            filterModel.TableList.Add(new TableName { Id = 4, Name = "Alte cheltuieli" });

            filterModel.OperationList = new Database.OperationEntities().Operations.ToList();

            filterModel.FilterList = new Database.FiltersEntities().Filters.AsQueryable()
                .Where(x => x.user_id == MySession.Current.UserGuid).ToList();
            
            return filterModel;
        }
    }
}