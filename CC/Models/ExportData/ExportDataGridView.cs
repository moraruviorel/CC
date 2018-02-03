using CC.Models.Classes;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models.ExportDataGridView
{
    public class ExportDataGridView
    {
        public static GridViewSettings GetGridSettings(string action)
        {
            var settings = new GridViewSettings();
            settings.Name = "GridView";
            settings.CallbackRouteValues = new { Controller = "Home", Action = "_" + action };
            settings.Width = System.Web.UI.WebControls.Unit.Percentage(100);
            // Export-specific settings  
            settings.SettingsExport.ExportSelectedRowsOnly = false;
            //settings.SettingsExport. = "Report.pdf";
            //settings.SettingsExport.PageHeader = new DevExpress.Web.GridViewExporterHeaderFooter;
            settings.SettingsExport.PageHeader.Center = "Excelent Construct";
            settings.SettingsExport.PageHeader.Font.Name = "segoe ui";
            settings.SettingsExport.PageHeader.Font.Size = 14;
            //
            settings.SettingsExport.Landscape = MySession.Current.MySetting.IsPageLandscape;
            settings.SettingsExport.Styles.Cell.Font.Size = 10;
            settings.SettingsExport.FileName = DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Year.ToString() + ".pdf";
            settings.SettingsExport.PaperKind = System.Drawing.Printing.PaperKind.A4;
            //settings.SettingsPager.Mode = GridViewPagerState.ShowAllRecords;

            switch (action)
            {
                case "GridViewWorks":
                    settings.KeyFieldName = "id";
                    settings.Columns.Add("name", "Denumire");
                    settings.Columns.Add("date_start", "Data început").PropertiesEdit.DisplayFormatString = "dd/MMM/yyyy";
                    settings.Columns.Add("date_end", "Data finisării").PropertiesEdit.DisplayFormatString = "dd/MMM/yyyy";
                    settings.Columns.Add("surface", "Cantitatea");
                    settings.Columns.Add(c=>
                    {
                        c.FieldName = "unit_id";
                        c.Caption = "Unitate";
                        c.EditorProperties().ComboBox(p =>
                        {                            
                            p.TextField = "Name";
                            p.ValueField = "Id";
                            p.ValueType = typeof(int);
                            p.DataSource = MySession.Current.Units;
                        });
                    });
                    settings.Columns.Add("unit_price", "Preț unitate");                    
                    MVCxGridViewColumn column = settings.Columns.Add("Total");
                    column.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;                    
                    settings.CustomUnboundColumnData = (sender, e) => {
                        if (e.Column.FieldName == "Total")
                        {
                            decimal price = MyConvert.ToDecimal(e.GetListSourceFieldValue("unit_price").ToString());
                            decimal surface = MyConvert.ToDecimal(e.GetListSourceFieldValue("surface").ToString());
                            e.Value = price * surface;
                        }
                    };                    
                    settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Total");
                    settings.Settings.ShowFooter = true;
                    break;
                case "GridViewMaterial":
                    settings.KeyFieldName = "id";
                    settings.Columns.Add("material_description", "Denumire material");
                    settings.Columns.Add("buyed_date", "Data procurării").PropertiesEdit.DisplayFormatString = "dd/MMM/yyyy";                    
                    settings.Columns.Add("quantity", "Cantitatea");                    
                    settings.Columns.Add("total_price", "Preț total");                    
                    settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "total_price");
                    settings.Settings.ShowFooter = true;
                    break;
                case "GridViewExtra":
                    settings.KeyFieldName = "id";
                    settings.Columns.Add("description", "Descrierea");
                    settings.Columns.Add("create_date", "Data creării").PropertiesEdit.DisplayFormatString = "dd/MMM/yyyy";                    
                    settings.Columns.Add("price", "Prețul");
                    settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "price");
                    settings.Settings.ShowFooter = true;
                    break;
                case "GridViewInstrument":
                    settings.KeyFieldName = "id";
                    settings.Columns.Add("model", "Model");                                        
                    settings.Columns.Add("first_day", "Data împrumut").PropertiesEdit.DisplayFormatString = "dd/MMM/yyyy";
                    settings.Columns.Add("last_day", "Data predării").PropertiesEdit.DisplayFormatString = "dd/MMM/yyyy";
                    settings.Columns.Add("quantity", "Cantitatea");                    
                    settings.Columns.Add("total_price", "Preț total");
                    settings.Columns.Add("responsabile_person", "Responsabil");
                    settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "total_price");
                    settings.Settings.ShowFooter = true;
                    break;
            }
            return settings;
        }
    }
}