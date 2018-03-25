using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models.Classes.Home
{
    [Serializable]
    public class IndexModel
    {
        public bool LoanMoneyCanView { get; set; }
        public bool SettingsCanView { get; set; }
        public bool UnitiesCanView { get; set; }
        public bool SpecialitiesCanView { get; set; }
        public bool FiltersCanView { get; set; }
        public bool UsersCanView { get; set; }

    }
}