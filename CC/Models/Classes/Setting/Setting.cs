using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models.Classes.Setting
{
    public class Setting
    {
        public int GridRows { get; set; }

        public bool IsPageLandscape { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}