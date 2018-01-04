using CC.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models.BusinessLogic.Home
{
    public class LoanMoneyDetail
    {

        public static IQueryable<Models.LoanMoneyDetail> GetLoanMoneyDetails()
        {
            LoanMoneyDetailsEntities dbLoanMoneyDetails = new LoanMoneyDetailsEntities();

            var model = dbLoanMoneyDetails.LoanMoneyDetails.AsQueryable()
                .Where(x => x.LoanMoneyId == MySession.Current.LoanMoneyId);

            return model;
        }

        //public static Models.LoanMoney
    }
}