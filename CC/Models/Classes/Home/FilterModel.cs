using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models.Classes.Home
{
    public class FilterModel : Common
    {
        public List<Database.Operation> OperationList { get; set; }

        public List<TableName> TableList { get; set; }

        public List<Database.Filter> FilterList { get; set; }
    }

    public class TableName
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    //public class Op
}