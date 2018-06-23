using System.Collections.Generic;
using System.Linq;
using CC.Models.Classes;

namespace CC.Models.BusinessLogic.Object
{
    public class ObjectPayment
    {

        public static List<Database.ObjectPayments> GetObjectPaymentList()
        {
            return new Database.ObjectPaymentEntities().ObjectPayments.AsQueryable()
                .Where(x => x.object_id == MySession.Current.ObjectId).ToList();
        }
    }
}