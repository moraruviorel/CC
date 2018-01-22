using CC.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models.BusinessLogic.Home
{
    public class LoanMoneyDetail
    {

        public static List<Database.LoanMoneyDetail> GetLoanMoneyDetails()
        {
            Database.LoanMoneyDetailsEntities dbLoanMoneyDetails = new Database.LoanMoneyDetailsEntities();

            var model = dbLoanMoneyDetails.LoanMoneyDetails.AsQueryable()
                .Where(x => x.LoanMoneyId == MySession.Current.LoanMoneyId).ToList();

            return model;
        }

    }
}