using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.ClipboardSource.SpreadsheetML;

namespace CC.Models.Classes.Worker
{
    public class WorkersGroupDetailModel
    {
        public List<Database.Worker> WorkerList { get; set; }

        public List<Database.WorkersGroupDetail> WorkersGroupDetailList { get; set; }

    }
}