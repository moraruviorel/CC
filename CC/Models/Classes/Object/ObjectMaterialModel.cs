using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models.Classes.Object
{
    public class ObjectMaterialModel
    {
        public List<Database.Object> ObjectList { get; set; }

        public List<Database.ObjectMaterial> ObjectMaterialList { get; set; }

        public List<Database.Unit> UnitList { get; set; }
    }
}