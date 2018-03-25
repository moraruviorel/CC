using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models.Classes
{
    public class ActionLinkText
    {
        public static string Workers {
            get {
                switch (MySession.Current.UserRole)
                {
                    case Models.Enums.UserRoleType.Dentistry:
                        return "Clienți";
                    default: return "Lucratori";
                }
            }
        }
    }
}