using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CC.Models.Enums
{
    public enum UserRoleType
    {
        [Description("Admin")]
        Admin = 10,
        [Description("Manager")]
        Manager = 20,
        [Description("Dentistry")]
        Dentistry = 30,
        [Description("Driver")]
        Driver = 40,
        [Description("Worker")]
        Worker = 50,
        [Description("User")]
        User = 60
        
    }
}