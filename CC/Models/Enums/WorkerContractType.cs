using System.ComponentModel;

namespace CC.Models.Enums
{
    public enum WorkerContractType
    {
        [Description("Lunar")]
        ByMonth = 1,
        [Description("Volum")]
        ByWork = 2,
        [Description("Ore")]
        ByHours = 3,
        [Description("Zi")]
        ByDay = 4,
    }
}