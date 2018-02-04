using CC.Models.Classes;
using CC.Models.Database;
using CC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CC.Models.BusinessLogic.Setting
{
    public class Setting
    {
        public static List<Database.Setting> GetSettingForCurrentUserList(ExcelentConstructSetting dbSettings)
        {
            var settingList = dbSettings.Settings.AsQueryable().Where(x => x.UserId == MySession.Current.UserGuid).ToList();
            //
            return settingList;
        }

        public static List<Database.Setting> GetAllSettingList(ExcelentConstructSetting dbSettings)
        {
            var settingList = dbSettings.Settings.OrderBy(x => x.UserId).ToList();
            //
            return settingList;
        }

        public static void SetSetting(List<Database.Setting> dbSetting)
        {
            MySession.Current.MySetting = new Classes.Setting.Setting();
            try
            {
                MySession.Current.MySetting.GridRows =
                    short.Parse(dbSetting.FirstOrDefault(x => x.SettingStatus == (int)Enums.SettingStatus.GridRows)?.Value);
                MySession.Current.MySetting.IsPageLandscape = dbSetting
                    .FirstOrDefault(x => x.SettingStatus == (int)Enums.SettingStatus.IsPageLandscape)
                    ?.Value.ToLower() == "da" ? true : false;
                MySession.Current.MySetting.ShowWorkerPrice = dbSetting
                    .FirstOrDefault(x => x.SettingStatus == (int)Enums.SettingStatus.ShowWorkerPrice)
                    ?.Value.ToLower() == "da" ? true : false;
                
            }
            catch (Exception ex)
            {
                MySession.Current.MySetting.GridRows = 20;
                MySession.Current.MySetting.IsPageLandscape = false;
                MySession.Current.MySetting.ShowWorkerPrice = true;
            }




            //return setting;
        }

        public static Classes.Setting.SettingModel GetSettingModel(
            AspNetUsersEntities aspNetUsersEntities, 
            ExcelentConstructSetting dbSetting)
        {
            var settingModel = new Classes.Setting.SettingModel();
            //
            var setList = MySession.Current.IsUserAdmin ? GetAllSettingList(dbSetting) :
                GetSettingForCurrentUserList(dbSetting);

            settingModel.SettingList = setList;
            var settingStatuses = new SettingStatusEntities();
            settingModel.SettingStatuses = settingStatuses.SettingStatuses.ToList();
            settingModel.AspNetUsers = aspNetUsersEntities.AspNetUsers.ToList();

            return settingModel;
        }
    }
}