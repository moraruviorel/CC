using CC.Models.Classes;
using CC.Models.Database;
using CC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors.Internal;

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
                var setting = dbSetting.FirstOrDefault(x =>x.UserId == MySession.Current.UserGuid &&
                                                           x.SettingStatus == (int)Enums.SettingStatus.GridRows);
                MySession.Current.MySetting.GridRows = setting == null ? 20 : Int32.Parse(setting.Value);
                //
                setting = dbSetting.FirstOrDefault(x => x.SettingStatus == (int)Enums.SettingStatus.IsPageLandscape);
                MySession.Current.MySetting.IsPageLandscape = GetBoolFromString(setting?.Value);
                //
                setting = dbSetting.FirstOrDefault(x => x.SettingStatus == (int)Enums.SettingStatus.ShowWorkerPrice);
                MySession.Current.MySetting.ShowWorkerPrice = GetBoolFromString(setting?.Value);
                //
                setting = dbSetting.FirstOrDefault(x => x.SettingStatus == (int)Enums.SettingStatus.Language);
                MySession.Current.Language = setting == null ? LanguageTypes.Romanian : GetLanguageType(setting.Value);
            }
            catch (Exception ex)
            {
                MySession.Current.MySetting.GridRows = 20;
                MySession.Current.MySetting.IsPageLandscape = false;
                MySession.Current.MySetting.ShowWorkerPrice = true;
            }
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
            settingModel.UserPermission = User.UserPermissions.GetUserPermissionByModuleType(ModuleTypes.Settings);

            return settingModel;
        }

        public static LanguageTypes GetLanguageType(string lang)
        {
            LanguageTypes languageType = LanguageTypes.Romanian;
            switch (lang)
            {
                case "ru":
                    languageType = LanguageTypes.Russian;
                    break;
                case "en":
                    languageType = LanguageTypes.English;
                    break;
            }

            return languageType;
        }

        public static bool GetBoolFromString(string value)
        {
            if (value == null)
                return false;
            return  value.ToLower() == "da" ? true : false;
        }

    }
}