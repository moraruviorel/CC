using CC.Models.Database;
using CC.Models.Enums;
using DevExpress.Web.Mvc;
using System.Collections.Generic;
using System.Web;
using CC.Models.Classes.Setting;

namespace CC.Models.Classes
{
    public class MySession
    {
        // Private constructor (use MySession.Current to access the current instance).
        private MySession() { }

        // Gets the current session.
        public static MySession Current
        {
            get
            {
                MySession session = HttpContext.Current.Session["__MySession__"] as MySession;
                if (session == null)
                {
                    session = new MySession();
                    HttpContext.Current.Session["__MySession__"] = session;
                }
                return session;
            }
        }

        // My session data goes here:
        public int ObjectId { get; set; }

        public bool IsUserAdmin { get; set; }

        public string UserGuid { get; set; }

        public int ParentId { get; set; }

        public int WorkerId { get; set; }

        public string TabAction { get; set; }

        public GridViewExtension GridReport { get; set; }

        public int WorksForm { get; set; }

        public List<Unit> Units { get; set; }

        public UserRole UserRole { get; set; }

        public int CustomerId { get; set; }

        public int CustomerForm { get; set; }

		public int WorkId { get; set; }

        public Setting.Setting MySetting { get; set; }

        public int LoanMoneyId { get; set; }

    }
}