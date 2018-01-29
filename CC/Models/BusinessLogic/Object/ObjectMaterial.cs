﻿using CC.Models.Classes;
using CC.Models.Classes.Object;
using CC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models.BusinessLogic.Object
{
    public class ObjectMaterial
    {        
        public static ObjectMaterialModel GetObjectMaterialModel()
        {
            var objectMaterialModel = new ObjectMaterialModel();

            objectMaterialModel.ObjectList = Object.GetObjectsByParentId();
            var objectMaterialList = new Database.ExcelentConstructObjectMaterial().ObjectMaterials
                .AsQueryable()
                .Where(x => x.object_id == MySession.Current.ObjectId).ToList();

            //Find into filter table 
            var filterTable = new Database.FiltersEntities().Filters
                .ToList().Where(x => x.table_name_id == (int)FilterTableName.ObjectMaterial).ToList();
                

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

            objectMaterialModel.ObjectMaterialList = objectMaterialList;

            return objectMaterialModel;
        }
    }
}