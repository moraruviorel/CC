using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.ClipboardSource.SpreadsheetML;

namespace CC.Models.Classes.Object
{
    public class ObjectWorksModel
    {
        public List<Database.Unit> UnitList { get; set; }

        public List<Database.Worker> WorkerList { get; set; }

        public List<Database.Object> ObjectList { get; set; }

        public List<Database.Work> ObjectWorksList { get; set; }

        public List<Database.WorkersGroup> WorkersGroupList { get; set; }
    }
}