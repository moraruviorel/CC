using CC.Models.Enums;
using System.Collections.Generic;

namespace CC.Models.Classes.Users
{
    public class UserPermissionsModel
    {
        public List<Database.UserPermission> UserPermissionList { get; set; }

        public Dictionary<int, string> ModuleList { get; set; }

        public Dictionary<int, string> ItemList { get; set; }
    }
}