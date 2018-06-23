using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CC.Models.Enums;

namespace CC.Models.Classes.Setting
{
    public class Setting
    {
        public int GridRows { get; set; }

        public bool IsPageLandscape { get; set; }

        public bool ShowWorkerPrice { get; set; }
        
        public LanguageTypes Language { get; set; }

        //public DateTime? EndDate { get; set; }
    }
}