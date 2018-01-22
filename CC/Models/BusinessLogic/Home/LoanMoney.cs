using CC.Models.Database;
using System.Linq;

namespace CC.Models.BusinessLogic.Home
{
    public class LoanMoney
    {
        public static Database.LoanMoney GetLoanMoneyById(int loanMoneyId)
        {
            LoanMoneyEntities dbLoanMoney = new LoanMoneyEntities();
            return dbLoanMoney.LoanMoney.FirstOrDefault(x => x.id == loanMoneyId);
        }
    }
}