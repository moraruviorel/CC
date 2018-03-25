using System.Collections.Generic;

namespace CC.Models.Classes.Home
{
    public class LoanMoneyModel : Common
    {
        public List<Database.LoanMoney> LoanMoneyList { get; set; }

        public List<Database.Currency> CurrencyList { get; set; }
    }
}