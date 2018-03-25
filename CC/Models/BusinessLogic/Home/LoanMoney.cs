using CC.Models.Classes;
using CC.Models.Classes.Home;
using CC.Models.Database;
using System.Linq;

namespace CC.Models.BusinessLogic.Home
{
    public class LoanMoney
    {
        public static LoanMoneyModel GetLoanMoneyModel()
        {
            var loanMoneyList = new LoanMoneyModel
            {
                LoanMoneyList = new LoanMoneyEntities().LoanMoney.ToList().Where(x => x.user_id == MySession.Current.UserGuid).ToList(),
                UserPermission = User.UserPermissions.GetUserPermissionByModuleType(Enums.ModuleTypes.LoanMoney),
                CurrencyList = new CurrencyEntities().Currencies.ToList()
            };
            return loanMoneyList;
        }

        public static Database.LoanMoney GetLoanMoneyById(int loanMoneyId)
        {
            LoanMoneyEntities dbLoanMoney = new LoanMoneyEntities();
            return dbLoanMoney.LoanMoney.FirstOrDefault(x => x.id == loanMoneyId);
        }
    }
}