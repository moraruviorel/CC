using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models.BusinessLogic.Home
{
    public class LoanMoney
    {
        public static Models.LoanMoney GetLoanMoneyById(int loanMoneyId)
        {
            LoanMoneyEntities dbLoanMoney = new LoanMoneyEntities();
            return dbLoanMoney.LoanMoney.FirstOrDefault(x => x.id == loanMoneyId);
        }
    }
}