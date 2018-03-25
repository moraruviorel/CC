using CC.Models.Enums;
using System.Collections.Generic;

namespace CC.Models.Classes.Setting
{
    public class SettingModel : Common
    {
        public List<Database.SettingStatus> SettingStatuses { get; set; }

        public List<Database.AspNetUser> AspNetUsers { get; set; }

        public List<Database.Setting> SettingList { get; set; }
    }
}