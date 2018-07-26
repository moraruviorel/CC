using CC.Models.Classes;
using DevExpress.Web.Mvc;
using System;

namespace CC.Models.ExportData
{
    public class ExportDataGridView
    {
        public static GridViewSettings GetGridSettings(string action, string reportName)
        {
            var settings = new GridViewSettings();
            settings.Name = "GridView";
            settings.CallbackRouteValues = new { Controller = "Home", Action = "_" + action };
            settings.Width = System.Web.UI.WebControls.Unit.Percentage(100);
            // Export-specific settings  
            settings.SettingsExport.ExportSelectedRowsOnly = false;
            //settings.SettingsExport. = "Report.pdf";
            //settings.SettingsExport.PageHeader = new DevExpress.Web.GridViewExporterHeaderFooter;
            settings.SettingsExport.PageHeader.Center = BusinessLogic.Home.TranslateWord.GetWord(reportName);

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
                    settings.Columns.Add(nameof(Database.Work.name), "Denumire");
                    settings.Columns.Add(nameof(Database.Work.date_start), "Data început").PropertiesEdit.DisplayFormatString = Const.DateTimeFormat;
                    settings.Columns.Add(nameof(Database.Work.date_end), "Data finisării").PropertiesEdit.DisplayFormatString = Const.DateTimeFormat;
                    settings.Columns.Add(nameof(Database.Work.surface_work), "Cantitatea");
                    settings.Columns.Add(c=>
                    {
                        c.FieldName = nameof(Database.Work.unit_id);
                        c.Caption = "Unitate";
                        c.EditorProperties().ComboBox(p =>
                        {                            
                            p.TextField = "Name";
                            p.ValueField = "Id";
                            p.ValueType = typeof(int);
                            p.DataSource = MySession.Current.Units;
                        });
                    });
                    settings.Columns.Add(nameof(Database.Work.unit_price), "Preț unitate");                    
                    MVCxGridViewColumn column = settings.Columns.Add("Total");
                    column.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;                    
                    settings.CustomUnboundColumnData = (sender, e) => {
                        if (e.Column.FieldName == "Total")
                        {
                            decimal price = MyConvert.ToDecimal(e.GetListSourceFieldValue(nameof(Database.Work.unit_price_worker)).ToString());
                            decimal surface = MyConvert.ToDecimal(e.GetListSourceFieldValue(nameof(Database.Work.surface_work)).ToString());
                            e.Value = price * surface;
                        }
                    };                    
                    settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Total");
                    settings.Settings.ShowFooter = true;
                    break;
                case "GridViewMaterial":
                    settings.KeyFieldName = "id";
                    settings.Columns.Add(nameof(Database.ObjectMaterial.material_description), "Denumire material");
                    settings.Columns.Add(nameof(Database.ObjectMaterial.buyed_date), "Data procurării").PropertiesEdit.DisplayFormatString = Const.DateTimeFormat;                    
                    settings.Columns.Add(nameof(Database.ObjectMaterial.quantity), "Cantitatea");
                    MVCxGridViewColumn col = settings.Columns.Add("Preț total");
                    col.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
                    settings.CustomUnboundColumnData = (sender, e) => {
                        if (e.Column.FieldName == "Preț total")
                        {
                            decimal price = MyConvert.ToDecimal(
                                e.GetListSourceFieldValue(nameof(Database.ObjectMaterial.unit_price)).ToString());
                            decimal quantity = MyConvert.ToDecimal(
                                e.GetListSourceFieldValue(nameof(Database.ObjectMaterial.quantity)).ToString());
                            e.Value = price * quantity;
                        }
                    };
                    settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Preț total");
                    settings.Settings.ShowFooter = true;
                    break;
                case "GridViewExtra":
                    settings.KeyFieldName = "id";
                    settings.Columns.Add(nameof(Database.ObjectExtra.description), "Descrierea");
                    settings.Columns.Add(nameof(Database.ObjectExtra.create_date), "Data creării").PropertiesEdit.DisplayFormatString = Const.DateTimeFormat;                    
                    settings.Columns.Add(nameof(Database.ObjectExtra.price), "Prețul");
                    settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, nameof(Database.ObjectExtra.price));
                    settings.Settings.ShowFooter = true;
                    break;
                case "GridViewInstrument":
                    settings.KeyFieldName = "id";
                    settings.Columns.Add(nameof(Database.ObjectInstrument.model), "Model");                                        
                    settings.Columns.Add(nameof(Database.ObjectInstrument.first_day), "Data împrumut").PropertiesEdit.DisplayFormatString = Const.DateTimeFormat;
                    settings.Columns.Add(nameof(Database.ObjectInstrument.last_day), "Data predării").PropertiesEdit.DisplayFormatString = Const.DateTimeFormat;
                    settings.Columns.Add(nameof(Database.ObjectInstrument.quantity), "Cantitatea");                    
                    settings.Columns.Add(nameof(Database.ObjectInstrument.total_price), "Preț total");
                    settings.Columns.Add(nameof(Database.ObjectInstrument.responsabile_person), "Responsabil");
                    settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, nameof(Database.ObjectInstrument.total_price));
                    settings.Settings.ShowFooter = true;
                    break;
                case "GridViewPayments":
                    settings.KeyFieldName = nameof(Database.WorkerPayment.id);
                    settings.Columns.Add(nameof(Database.WorkerPayment.payment_date), Const.PaymentDate);
                    settings.Columns.Add(nameof(Database.WorkerPayment.payment_type), Const.PaymentType);
                    settings.Columns.Add(c =>
                    {
                        c.FieldName = nameof(Database.WorkerPayment.payment_type);
                        c.Caption = "Tip Achitare";
                        c.EditorProperties().ComboBox(p =>
                        {
                            p.DataSource = MySession.Current.PaymentTypes;
                            p.TextField = "Value";
                            p.ValueField = "Key";
                            p.ValueType = typeof(string);
                        });
                    });
                    //settings.Columns.Add(nameof(Database.WorkerPayment.work_id), Const.Work);
                    settings.Columns.Add(c =>
                    {
                        c.FieldName = nameof(Database.WorkerPayment.work_id);
                        c.Caption = Const.Work;
                        c.EditorProperties().ComboBox(p =>
                        {
                            p.TextField = nameof(Database.Work.name);
                            p.ValueField = "Id";
                            p.ValueType = typeof(int);
                            p.DataSource = MySession.Current.Works;
                        });
                    });
                    settings.Columns.Add(nameof(Database.WorkerPayment.amount), Const.Amount);
                    settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, nameof(Database.WorkerPayment.amount));
                    settings.Settings.ShowFooter = true;
                    break;
            }
            return settings;
        }
    }
}