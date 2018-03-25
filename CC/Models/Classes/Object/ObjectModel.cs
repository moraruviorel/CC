using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models.Classes.Object
{
    public class ObjectModel
    {
        public DateTime DateTimeStart { get; set; }

        public DateTime DateTimeEnd { get; set; }

        public Database.UserPermission UserPermissionObject { get; set; }

        public List<Database.Object> ObjectList { get; set; }

        public List<Database.Object> ObjectParentList { get; set; }
    }
}