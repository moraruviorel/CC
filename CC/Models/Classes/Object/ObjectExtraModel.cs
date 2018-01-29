using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models.Classes.Object
{
    public class ObjectExtraModel
    {

        public List<Database.Object> ObjectList { get; set; }

        public List<Database.Worker> WorkerList { get; set; }

        public List<Database.ObjectExtra> ObjectExtraList { get; set; }
    }
}