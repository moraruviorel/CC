using CC.Models.Classes;
using CC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models.BusinessLogic
{
    public class DefaultData
    {
        public static void SetSetting(IQueryable<Setting> dbSetting)
        {
            MySession.Current.MySetting = new Classes.Setting();
            //var setting = new Setting();
            try
            {
                MySession.Current.MySetting.GridRows =
                    Int16.Parse(dbSetting.FirstOrDefault(x => x.SettingStatus == (int)SettingStatuses.GridRows)?.Value);
                MySession.Current.MySetting.IsPageLandscape =
                    dbSetting.FirstOrDefault(x => x.SettingStatus == (int)SettingStatuses.IsPageLandscape)?.Value == "true" ? true : false;
            }
            catch (Exception ex)
            {
                MySession.Current.MySetting.GridRows = 20;
                MySession.Current.MySetting.IsPageLandscape = false;
                
               // throw ex;
            }


           

            //return setting;
        }
    }
}