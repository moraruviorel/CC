
using System.ComponentModel;

namespace CC.Models.Enums
{
    public enum ModuleTypes
    {
        [Description("Obiecte")]
        Objects = 1,
        [Description("Lucrători")]
        Workers = 2,
        [Description("Clienți")]
        Customers = 3,
        [Description("Împrumuturi")]
        LoanMoney = 4,
        [Description("Setări")]
        Settings = 5,
        Users = 6,
        Speciality = 7,
        Filters = 8,
        Units = 9
    }
}