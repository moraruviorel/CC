using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.ClipboardSource.SpreadsheetML;

namespace CC.Models.Classes.Worker
{
    public class WorkerWorksModel
    {
        public List<Database.Work> WorksList { get; set; }

        public List<Database.Unit> UnitList { get; set; } 

        public List<Database.Object> ObjectList { get; set; }

    }
}