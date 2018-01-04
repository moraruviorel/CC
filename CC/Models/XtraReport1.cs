using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for XtraReport1
/// </summary>
public class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
{
    #region controler

    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrLabel1;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell7;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell8;
    private XRLabel xrLabel2;
    private XRPictureBox xrPictureBox2;
    private XRPictureBox xrPictureBox1;
    private XRLine xrLine1;
    private XRTable xrTable2;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell11;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTable2Cell1_1;
    private XRTableCell xrTable2Cell1_2;
    private XRTableCell xrTable2Cell1_3;
    private XRTableCell xrTable2Cell1_4;
    private XRTableRow xrTableRow6;
    private XRTableCell xrTable2Cell2_1;
    private XRTableCell xrTable2Cell2_2;
    private XRTableCell xrTable2Cell2_3;
    private XRTableCell xrTable2Cell2_4;
    private XRTableRow xrTableRow7;
    private XRTableCell xrTable2Cell3_1;
    private XRTableCell xrTable2Cell3_2;
    private XRTableCell xrTable2Cell3_3;
    private XRTableCell xrTable2Cell3_4;
    private XRTableRow xrTableRow10;
    private XRTableCell xrTable2Cell4_1;
    private XRTableCell xrTable2Cell4_2;
    private XRTableCell xrTableCell39;
    private XRTableCell xrTableCell40;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell18;
    private XRTableCell xrTableCell19;
    private XRTableCell xrTableCell20;
    private XRTableRow xrTableRow11;
    private XRTableCell xrTableCell41;
    private XRTableCell xrTableCell42;
    private XRTableCell xrTableCell43;
    private XRTableCell xrTableCell44;
    private XRTableRow xrTableRow9;
    private XRTableCell xrTableCell33;
    private XRTableCell xrTableCell34;
    private XRTableCell xrTableCell35;
    private XRTableCell xrTableCell36;
    private XRTableRow xrTableRow8;
    private XRTableCell xrTableCell29;
    private XRTableCell xrTableCell30;
    private XRTableCell xrTableCell31;
    private XRTableCell xrTableCell32;
    private ReportFooterBand ReportFooter;
    private XRPictureBox xrPictureBox3;
    private XRTable xrTable3;
    private XRTableRow xrTableRow16;
    private XRTableCell xrTableCell62;
    private XRTableCell xrTableCell63;
    private XRTableRow xrTableRow17;
    private XRTableCell xrTableCell61;
    private XRTableCell xrTableCell64;
    private XRTableRow xrTableRow18;
    private XRTableCell xrTableCell65;
    private XRTableCell xrTableCell66;
    private XRTableRow xrTableRow12;
    private XRTableCell xrTableCell45;
    private XRTableCell xrTableCell46;
    private XRTableCell xrTableCell47;
    private XRTableCell xrTableCell48;
    private XRTableRow xrTableRow14;
    private XRTableCell xrTableCell53;
    private XRTableCell xrTableCell54;
    private XRTableCell xrTableCell55;
    private XRTableCell xrTableCell56;
    private XRTableRow xrTableRow13;
    private XRTableCell xrTableCell49;
    private XRTableCell xrTableCell50;
    private XRTableCell xrTableCell51;
    private XRTableCell xrTableCell52;
    private XRTableRow xrTableRow15;
    private XRTableCell xrTableCell57;
    private XRTableCell xrTableCell58;
    private XRTableCell xrTableCell59;
    private XRTableCell xrTableCell60;
    private XRTable xrTable4;
    private XRTableRow xrTableRow22;
    private XRTableCell xrTableCell79;
    private XRTableCell xrTableCell80;
    private XRTableCell xrTableCell82;
    private XRTableCell xrTableCell81;
    private XRTableRow xrTableRow19;
    private XRTableCell xrTableCell67;
    private XRTableCell xrTableCell68;
    private XRTableCell xrTableCell69;
    private XRTableCell xrTableCell70;
    private XRTableRow xrTableRow20;
    private XRTableCell xrTableCell71;
    private XRTableCell xrTableCell72;
    private XRTableCell xrTableCell73;
    private XRTableCell xrTableCell74;
    private XRTableRow xrTableRow21;
    private XRTableCell xrTableCell75;
    private XRTableCell xrTableCell76;
    private XRTableCell xrTableCell77;
    private XRTableCell xrTableCell78;

    #endregion

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public XtraReport1()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow22 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell79 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell80 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell82 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell81 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow16 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell62 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell63 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow17 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell61 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell64 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow18 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell65 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell66 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTable2Cell1_1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2Cell1_2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2Cell1_3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2Cell1_4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTable2Cell2_1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2Cell2_2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2Cell2_3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2Cell2_4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTable2Cell3_1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2Cell3_2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2Cell3_3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2Cell3_4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTable2Cell4_1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2Cell4_2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow11 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell43 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell44 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow12 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell46 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell47 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow14 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell53 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell54 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell55 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell56 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow13 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell49 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell50 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell51 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell52 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow15 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell57 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell58 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell59 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell60 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow19 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell67 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell68 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell69 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell70 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow20 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell71 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell72 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell73 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell74 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow21 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell75 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell76 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell77 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell78 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox2 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrPictureBox3 = new DevExpress.XtraReports.UI.XRPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4,
            this.xrTable3,
            this.xrTable2,
            this.xrLabel1,
            this.xrTable1});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 723.5416F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable4
            // 
            this.xrTable4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable4.Dpi = 100F;
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(8.95834F, 580.0694F);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow22});
            this.xrTable4.SizeF = new System.Drawing.SizeF(624.375F, 66.66675F);
            this.xrTable4.StylePriority.UseBorders = false;
            // 
            // xrTableRow22
            // 
            this.xrTableRow22.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell79,
            this.xrTableCell80,
            this.xrTableCell82,
            this.xrTableCell81});
            this.xrTableRow22.Dpi = 100F;
            this.xrTableRow22.Name = "xrTableRow22";
            this.xrTableRow22.Weight = 1D;
            // 
            // xrTableCell79
            // 
            this.xrTableCell79.Dpi = 100F;
            this.xrTableCell79.Name = "xrTableCell79";
            this.xrTableCell79.Weight = 0.57390711023523522D;
            // 
            // xrTableCell80
            // 
            this.xrTableCell80.Dpi = 100F;
            this.xrTableCell80.Multiline = true;
            this.xrTableCell80.Name = "xrTableCell80";
            this.xrTableCell80.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 50, 0, 0, 100F);
            this.xrTableCell80.StylePriority.UsePadding = false;
            this.xrTableCell80.Text = "Règlement par ESPECE:\r\nBANQUE BRD\r\nIBAN : RO31BRDE130SV13370831300\r\nSWIFT : BRDER" +
    "OBU\r\n";
            this.xrTableCell80.Weight = 1.9045713682432433D;
            // 
            // xrTableCell82
            // 
            this.xrTableCell82.Dpi = 100F;
            this.xrTableCell82.Name = "xrTableCell82";
            this.xrTableCell82.Weight = 0.90757300269019014D;
            // 
            // xrTableCell81
            // 
            this.xrTableCell81.Dpi = 100F;
            this.xrTableCell81.Name = "xrTableCell81";
            this.xrTableCell81.Weight = 0.61394851883133128D;
            // 
            // xrTable3
            // 
            this.xrTable3.Bookmark = "2";
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.Dpi = 100F;
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(395.8333F, 646.7361F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow16,
            this.xrTableRow17,
            this.xrTableRow18});
            this.xrTable3.SizeF = new System.Drawing.SizeF(237.5001F, 75F);
            this.xrTable3.StylePriority.UseBorders = false;
            // 
            // xrTableRow16
            // 
            this.xrTableRow16.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell62,
            this.xrTableCell63});
            this.xrTableRow16.Dpi = 100F;
            this.xrTableRow16.Name = "xrTableRow16";
            this.xrTableRow16.Weight = 1D;
            // 
            // xrTableCell62
            // 
            this.xrTableCell62.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell62.Dpi = 100F;
            this.xrTableCell62.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell62.ForeColor = System.Drawing.Color.Orange;
            this.xrTableCell62.Name = "xrTableCell62";
            this.xrTableCell62.StylePriority.UseBorderColor = false;
            this.xrTableCell62.StylePriority.UseFont = false;
            this.xrTableCell62.StylePriority.UseForeColor = false;
            this.xrTableCell62.StylePriority.UseTextAlignment = false;
            this.xrTableCell62.Text = "Sous-total  HT";
            this.xrTableCell62.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell62.Weight = 1.3140092987783882D;
            // 
            // xrTableCell63
            // 
            this.xrTableCell63.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell63.Dpi = 100F;
            this.xrTableCell63.Multiline = true;
            this.xrTableCell63.Name = "xrTableCell63";
            this.xrTableCell63.StylePriority.UseBorderColor = false;
            this.xrTableCell63.StylePriority.UseTextAlignment = false;
            this.xrTableCell63.Text = "\r\n";
            this.xrTableCell63.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell63.Weight = 0.88888981806943745D;
            this.xrTableCell63.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrTableCell63_BeforePrint);
            // 
            // xrTableRow17
            // 
            this.xrTableRow17.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell61,
            this.xrTableCell64});
            this.xrTableRow17.Dpi = 100F;
            this.xrTableRow17.Name = "xrTableRow17";
            this.xrTableRow17.Weight = 1D;
            // 
            // xrTableCell61
            // 
            this.xrTableCell61.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell61.Dpi = 100F;
            this.xrTableCell61.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell61.ForeColor = System.Drawing.Color.Orange;
            this.xrTableCell61.Name = "xrTableCell61";
            this.xrTableCell61.StylePriority.UseBorderColor = false;
            this.xrTableCell61.StylePriority.UseFont = false;
            this.xrTableCell61.StylePriority.UseForeColor = false;
            this.xrTableCell61.StylePriority.UseTextAlignment = false;
            this.xrTableCell61.Text = "TVA";
            this.xrTableCell61.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell61.Weight = 1.3140092987783882D;
            // 
            // xrTableCell64
            // 
            this.xrTableCell64.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell64.Dpi = 100F;
            this.xrTableCell64.Name = "xrTableCell64";
            this.xrTableCell64.StylePriority.UseBorderColor = false;
            this.xrTableCell64.StylePriority.UseTextAlignment = false;
            this.xrTableCell64.Text = "20%";
            this.xrTableCell64.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell64.Weight = 0.88888981806943745D;
            this.xrTableCell64.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrTableCell64_BeforePrint);
            // 
            // xrTableRow18
            // 
            this.xrTableRow18.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell65,
            this.xrTableCell66});
            this.xrTableRow18.Dpi = 100F;
            this.xrTableRow18.Name = "xrTableRow18";
            this.xrTableRow18.Weight = 1D;
            // 
            // xrTableCell65
            // 
            this.xrTableCell65.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell65.Dpi = 100F;
            this.xrTableCell65.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell65.ForeColor = System.Drawing.Color.Orange;
            this.xrTableCell65.Name = "xrTableCell65";
            this.xrTableCell65.StylePriority.UseBorderColor = false;
            this.xrTableCell65.StylePriority.UseFont = false;
            this.xrTableCell65.StylePriority.UseForeColor = false;
            this.xrTableCell65.StylePriority.UseTextAlignment = false;
            this.xrTableCell65.Text = "Total TTC";
            this.xrTableCell65.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell65.Weight = 1.3140098649015768D;
            // 
            // xrTableCell66
            // 
            this.xrTableCell66.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell66.Dpi = 100F;
            this.xrTableCell66.Name = "xrTableCell66";
            this.xrTableCell66.StylePriority.UseBorderColor = false;
            this.xrTableCell66.StylePriority.UseTextAlignment = false;
            this.xrTableCell66.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell66.Weight = 0.88888925194624913D;
            this.xrTableCell66.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrTableCell66_BeforePrint);
            // 
            // xrTable2
            // 
            this.xrTable2.Bookmark = "4";
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Dpi = 100F;
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(8.95834F, 223.9583F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3,
            this.xrTableRow4,
            this.xrTableRow6,
            this.xrTableRow7,
            this.xrTableRow10,
            this.xrTableRow5,
            this.xrTableRow11,
            this.xrTableRow9,
            this.xrTableRow8,
            this.xrTableRow12,
            this.xrTableRow14,
            this.xrTableRow13,
            this.xrTableRow15,
            this.xrTableRow19,
            this.xrTableRow20,
            this.xrTableRow21});
            this.xrTable2.SizeF = new System.Drawing.SizeF(624.375F, 356.1111F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell9,
            this.xrTableCell10,
            this.xrTableCell12,
            this.xrTableCell11});
            this.xrTableRow3.Dpi = 100F;
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.BackColor = System.Drawing.Color.Orange;
            this.xrTableCell9.Dpi = 100F;
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseBackColor = false;
            this.xrTableCell9.Text = "Qté ou Forfait";
            this.xrTableCell9.Weight = 0.57390711023523522D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.BackColor = System.Drawing.Color.Orange;
            this.xrTableCell10.Dpi = 100F;
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.StylePriority.UseBackColor = false;
            this.xrTableCell10.Text = "Description";
            this.xrTableCell10.Weight = 1.9045713682432433D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.BackColor = System.Drawing.Color.Orange;
            this.xrTableCell12.Dpi = 100F;
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.StylePriority.UseBackColor = false;
            this.xrTableCell12.Text = "Prix unitaire";
            this.xrTableCell12.Weight = 0.90757300269019014D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.BackColor = System.Drawing.Color.Orange;
            this.xrTableCell11.Dpi = 100F;
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.StylePriority.UseBackColor = false;
            this.xrTableCell11.Text = "Total de la ligne";
            this.xrTableCell11.Weight = 0.61394851883133128D;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTable2Cell1_1,
            this.xrTable2Cell1_2,
            this.xrTable2Cell1_3,
            this.xrTable2Cell1_4});
            this.xrTableRow4.Dpi = 100F;
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1D;
            // 
            // xrTable2Cell1_1
            // 
            this.xrTable2Cell1_1.Dpi = 100F;
            this.xrTable2Cell1_1.Name = "xrTable2Cell1_1";
            this.xrTable2Cell1_1.Weight = 0.57390711023523522D;
            // 
            // xrTable2Cell1_2
            // 
            this.xrTable2Cell1_2.Dpi = 100F;
            this.xrTable2Cell1_2.Name = "xrTable2Cell1_2";
            this.xrTable2Cell1_2.Weight = 1.9045713682432433D;
            // 
            // xrTable2Cell1_3
            // 
            this.xrTable2Cell1_3.Dpi = 100F;
            this.xrTable2Cell1_3.Name = "xrTable2Cell1_3";
            this.xrTable2Cell1_3.Weight = 0.90757300269019014D;
            // 
            // xrTable2Cell1_4
            // 
            this.xrTable2Cell1_4.Dpi = 100F;
            this.xrTable2Cell1_4.Name = "xrTable2Cell1_4";
            this.xrTable2Cell1_4.Weight = 0.61394851883133128D;
            // 
            // xrTableRow6
            // 
            this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTable2Cell2_1,
            this.xrTable2Cell2_2,
            this.xrTable2Cell2_3,
            this.xrTable2Cell2_4});
            this.xrTableRow6.Dpi = 100F;
            this.xrTableRow6.Name = "xrTableRow6";
            this.xrTableRow6.Weight = 1D;
            // 
            // xrTable2Cell2_1
            // 
            this.xrTable2Cell2_1.Dpi = 100F;
            this.xrTable2Cell2_1.Name = "xrTable2Cell2_1";
            this.xrTable2Cell2_1.Weight = 0.57390711023523522D;
            // 
            // xrTable2Cell2_2
            // 
            this.xrTable2Cell2_2.Dpi = 100F;
            this.xrTable2Cell2_2.Name = "xrTable2Cell2_2";
            this.xrTable2Cell2_2.Weight = 1.9045713682432433D;
            // 
            // xrTable2Cell2_3
            // 
            this.xrTable2Cell2_3.Dpi = 100F;
            this.xrTable2Cell2_3.Name = "xrTable2Cell2_3";
            this.xrTable2Cell2_3.Weight = 0.90757300269019014D;
            // 
            // xrTable2Cell2_4
            // 
            this.xrTable2Cell2_4.Dpi = 100F;
            this.xrTable2Cell2_4.Name = "xrTable2Cell2_4";
            this.xrTable2Cell2_4.Weight = 0.61394851883133128D;
            // 
            // xrTableRow7
            // 
            this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTable2Cell3_1,
            this.xrTable2Cell3_2,
            this.xrTable2Cell3_3,
            this.xrTable2Cell3_4});
            this.xrTableRow7.Dpi = 100F;
            this.xrTableRow7.Name = "xrTableRow7";
            this.xrTableRow7.Weight = 1D;
            // 
            // xrTable2Cell3_1
            // 
            this.xrTable2Cell3_1.Dpi = 100F;
            this.xrTable2Cell3_1.Name = "xrTable2Cell3_1";
            this.xrTable2Cell3_1.Weight = 0.57390711023523522D;
            // 
            // xrTable2Cell3_2
            // 
            this.xrTable2Cell3_2.Dpi = 100F;
            this.xrTable2Cell3_2.Name = "xrTable2Cell3_2";
            this.xrTable2Cell3_2.Weight = 1.9045713682432433D;
            // 
            // xrTable2Cell3_3
            // 
            this.xrTable2Cell3_3.Dpi = 100F;
            this.xrTable2Cell3_3.Name = "xrTable2Cell3_3";
            this.xrTable2Cell3_3.Weight = 0.90757300269019014D;
            // 
            // xrTable2Cell3_4
            // 
            this.xrTable2Cell3_4.Dpi = 100F;
            this.xrTable2Cell3_4.Name = "xrTable2Cell3_4";
            this.xrTable2Cell3_4.Weight = 0.61394851883133128D;
            // 
            // xrTableRow10
            // 
            this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTable2Cell4_1,
            this.xrTable2Cell4_2,
            this.xrTableCell39,
            this.xrTableCell40});
            this.xrTableRow10.Dpi = 100F;
            this.xrTableRow10.Name = "xrTableRow10";
            this.xrTableRow10.Weight = 1D;
            // 
            // xrTable2Cell4_1
            // 
            this.xrTable2Cell4_1.Dpi = 100F;
            this.xrTable2Cell4_1.Name = "xrTable2Cell4_1";
            this.xrTable2Cell4_1.Weight = 0.57390711023523522D;
            // 
            // xrTable2Cell4_2
            // 
            this.xrTable2Cell4_2.Dpi = 100F;
            this.xrTable2Cell4_2.Name = "xrTable2Cell4_2";
            this.xrTable2Cell4_2.Weight = 1.9045713682432433D;
            // 
            // xrTableCell39
            // 
            this.xrTableCell39.Dpi = 100F;
            this.xrTableCell39.Name = "xrTableCell39";
            this.xrTableCell39.Weight = 0.90757300269019014D;
            // 
            // xrTableCell40
            // 
            this.xrTableCell40.Dpi = 100F;
            this.xrTableCell40.Name = "xrTableCell40";
            this.xrTableCell40.Weight = 0.61394851883133128D;
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell17,
            this.xrTableCell18,
            this.xrTableCell19,
            this.xrTableCell20});
            this.xrTableRow5.Dpi = 100F;
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Weight = 1D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Dpi = 100F;
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Weight = 0.57390711023523522D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Dpi = 100F;
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Weight = 1.9045713682432433D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.Dpi = 100F;
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Weight = 0.90757300269019014D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Dpi = 100F;
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Weight = 0.61394851883133128D;
            // 
            // xrTableRow11
            // 
            this.xrTableRow11.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell41,
            this.xrTableCell42,
            this.xrTableCell43,
            this.xrTableCell44});
            this.xrTableRow11.Dpi = 100F;
            this.xrTableRow11.Name = "xrTableRow11";
            this.xrTableRow11.Weight = 1D;
            // 
            // xrTableCell41
            // 
            this.xrTableCell41.Dpi = 100F;
            this.xrTableCell41.Name = "xrTableCell41";
            this.xrTableCell41.Weight = 0.57390711023523522D;
            // 
            // xrTableCell42
            // 
            this.xrTableCell42.Dpi = 100F;
            this.xrTableCell42.Name = "xrTableCell42";
            this.xrTableCell42.Weight = 1.9045713682432433D;
            // 
            // xrTableCell43
            // 
            this.xrTableCell43.Dpi = 100F;
            this.xrTableCell43.Name = "xrTableCell43";
            this.xrTableCell43.Weight = 0.90757300269019014D;
            // 
            // xrTableCell44
            // 
            this.xrTableCell44.Dpi = 100F;
            this.xrTableCell44.Name = "xrTableCell44";
            this.xrTableCell44.Weight = 0.61394851883133128D;
            // 
            // xrTableRow9
            // 
            this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell33,
            this.xrTableCell34,
            this.xrTableCell35,
            this.xrTableCell36});
            this.xrTableRow9.Dpi = 100F;
            this.xrTableRow9.Name = "xrTableRow9";
            this.xrTableRow9.Weight = 1D;
            // 
            // xrTableCell33
            // 
            this.xrTableCell33.Dpi = 100F;
            this.xrTableCell33.Name = "xrTableCell33";
            this.xrTableCell33.Weight = 0.57390711023523522D;
            // 
            // xrTableCell34
            // 
            this.xrTableCell34.Dpi = 100F;
            this.xrTableCell34.Name = "xrTableCell34";
            this.xrTableCell34.Weight = 1.9045713682432433D;
            // 
            // xrTableCell35
            // 
            this.xrTableCell35.Dpi = 100F;
            this.xrTableCell35.Name = "xrTableCell35";
            this.xrTableCell35.Weight = 0.90757300269019014D;
            // 
            // xrTableCell36
            // 
            this.xrTableCell36.Dpi = 100F;
            this.xrTableCell36.Name = "xrTableCell36";
            this.xrTableCell36.Weight = 0.61394851883133128D;
            // 
            // xrTableRow8
            // 
            this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell29,
            this.xrTableCell30,
            this.xrTableCell31,
            this.xrTableCell32});
            this.xrTableRow8.Dpi = 100F;
            this.xrTableRow8.Name = "xrTableRow8";
            this.xrTableRow8.Weight = 1D;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.Dpi = 100F;
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.Weight = 0.57390711023523522D;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.Dpi = 100F;
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.Weight = 1.9045713682432433D;
            // 
            // xrTableCell31
            // 
            this.xrTableCell31.Dpi = 100F;
            this.xrTableCell31.Name = "xrTableCell31";
            this.xrTableCell31.Weight = 0.90757300269019014D;
            // 
            // xrTableCell32
            // 
            this.xrTableCell32.Dpi = 100F;
            this.xrTableCell32.Name = "xrTableCell32";
            this.xrTableCell32.Weight = 0.61394851883133128D;
            // 
            // xrTableRow12
            // 
            this.xrTableRow12.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell45,
            this.xrTableCell46,
            this.xrTableCell47,
            this.xrTableCell48});
            this.xrTableRow12.Dpi = 100F;
            this.xrTableRow12.Name = "xrTableRow12";
            this.xrTableRow12.Weight = 1D;
            // 
            // xrTableCell45
            // 
            this.xrTableCell45.Dpi = 100F;
            this.xrTableCell45.Name = "xrTableCell45";
            this.xrTableCell45.Weight = 0.57390711023523522D;
            // 
            // xrTableCell46
            // 
            this.xrTableCell46.Dpi = 100F;
            this.xrTableCell46.Name = "xrTableCell46";
            this.xrTableCell46.Weight = 1.9045713682432433D;
            // 
            // xrTableCell47
            // 
            this.xrTableCell47.Dpi = 100F;
            this.xrTableCell47.Name = "xrTableCell47";
            this.xrTableCell47.Weight = 0.90757300269019014D;
            // 
            // xrTableCell48
            // 
            this.xrTableCell48.Dpi = 100F;
            this.xrTableCell48.Name = "xrTableCell48";
            this.xrTableCell48.Weight = 0.61394851883133128D;
            // 
            // xrTableRow14
            // 
            this.xrTableRow14.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell53,
            this.xrTableCell54,
            this.xrTableCell55,
            this.xrTableCell56});
            this.xrTableRow14.Dpi = 100F;
            this.xrTableRow14.Name = "xrTableRow14";
            this.xrTableRow14.Weight = 1D;
            // 
            // xrTableCell53
            // 
            this.xrTableCell53.Dpi = 100F;
            this.xrTableCell53.Name = "xrTableCell53";
            this.xrTableCell53.Weight = 0.57390711023523522D;
            // 
            // xrTableCell54
            // 
            this.xrTableCell54.Dpi = 100F;
            this.xrTableCell54.Name = "xrTableCell54";
            this.xrTableCell54.Weight = 1.9045713682432433D;
            // 
            // xrTableCell55
            // 
            this.xrTableCell55.Dpi = 100F;
            this.xrTableCell55.Name = "xrTableCell55";
            this.xrTableCell55.Weight = 0.90757300269019014D;
            // 
            // xrTableCell56
            // 
            this.xrTableCell56.Dpi = 100F;
            this.xrTableCell56.Name = "xrTableCell56";
            this.xrTableCell56.Weight = 0.61394851883133128D;
            // 
            // xrTableRow13
            // 
            this.xrTableRow13.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell49,
            this.xrTableCell50,
            this.xrTableCell51,
            this.xrTableCell52});
            this.xrTableRow13.Dpi = 100F;
            this.xrTableRow13.Name = "xrTableRow13";
            this.xrTableRow13.Weight = 1D;
            // 
            // xrTableCell49
            // 
            this.xrTableCell49.Dpi = 100F;
            this.xrTableCell49.Name = "xrTableCell49";
            this.xrTableCell49.Weight = 0.57390711023523522D;
            // 
            // xrTableCell50
            // 
            this.xrTableCell50.Dpi = 100F;
            this.xrTableCell50.Name = "xrTableCell50";
            this.xrTableCell50.Weight = 1.9045713682432433D;
            // 
            // xrTableCell51
            // 
            this.xrTableCell51.Dpi = 100F;
            this.xrTableCell51.Name = "xrTableCell51";
            this.xrTableCell51.Weight = 0.90757300269019014D;
            // 
            // xrTableCell52
            // 
            this.xrTableCell52.Dpi = 100F;
            this.xrTableCell52.Name = "xrTableCell52";
            this.xrTableCell52.Weight = 0.61394851883133128D;
            // 
            // xrTableRow15
            // 
            this.xrTableRow15.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell57,
            this.xrTableCell58,
            this.xrTableCell59,
            this.xrTableCell60});
            this.xrTableRow15.Dpi = 100F;
            this.xrTableRow15.Name = "xrTableRow15";
            this.xrTableRow15.Weight = 1D;
            // 
            // xrTableCell57
            // 
            this.xrTableCell57.Dpi = 100F;
            this.xrTableCell57.Name = "xrTableCell57";
            this.xrTableCell57.Weight = 0.57390711023523522D;
            // 
            // xrTableCell58
            // 
            this.xrTableCell58.Dpi = 100F;
            this.xrTableCell58.Name = "xrTableCell58";
            this.xrTableCell58.Weight = 1.9045713682432433D;
            // 
            // xrTableCell59
            // 
            this.xrTableCell59.Dpi = 100F;
            this.xrTableCell59.Name = "xrTableCell59";
            this.xrTableCell59.Weight = 0.90757300269019014D;
            // 
            // xrTableCell60
            // 
            this.xrTableCell60.Dpi = 100F;
            this.xrTableCell60.Name = "xrTableCell60";
            this.xrTableCell60.Weight = 0.61394851883133128D;
            // 
            // xrTableRow19
            // 
            this.xrTableRow19.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell67,
            this.xrTableCell68,
            this.xrTableCell69,
            this.xrTableCell70});
            this.xrTableRow19.Dpi = 100F;
            this.xrTableRow19.Name = "xrTableRow19";
            this.xrTableRow19.Weight = 1D;
            // 
            // xrTableCell67
            // 
            this.xrTableCell67.Dpi = 100F;
            this.xrTableCell67.Name = "xrTableCell67";
            this.xrTableCell67.Weight = 0.57390711023523522D;
            // 
            // xrTableCell68
            // 
            this.xrTableCell68.Dpi = 100F;
            this.xrTableCell68.Name = "xrTableCell68";
            this.xrTableCell68.Weight = 1.9045713682432433D;
            // 
            // xrTableCell69
            // 
            this.xrTableCell69.Dpi = 100F;
            this.xrTableCell69.Name = "xrTableCell69";
            this.xrTableCell69.Weight = 0.90757300269019014D;
            // 
            // xrTableCell70
            // 
            this.xrTableCell70.Dpi = 100F;
            this.xrTableCell70.Name = "xrTableCell70";
            this.xrTableCell70.Weight = 0.61394851883133128D;
            // 
            // xrTableRow20
            // 
            this.xrTableRow20.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell71,
            this.xrTableCell72,
            this.xrTableCell73,
            this.xrTableCell74});
            this.xrTableRow20.Dpi = 100F;
            this.xrTableRow20.Name = "xrTableRow20";
            this.xrTableRow20.Weight = 1D;
            // 
            // xrTableCell71
            // 
            this.xrTableCell71.Dpi = 100F;
            this.xrTableCell71.Name = "xrTableCell71";
            this.xrTableCell71.Weight = 0.57390711023523522D;
            // 
            // xrTableCell72
            // 
            this.xrTableCell72.Dpi = 100F;
            this.xrTableCell72.Name = "xrTableCell72";
            this.xrTableCell72.Weight = 1.9045713682432433D;
            // 
            // xrTableCell73
            // 
            this.xrTableCell73.Dpi = 100F;
            this.xrTableCell73.Name = "xrTableCell73";
            this.xrTableCell73.Weight = 0.90757300269019014D;
            // 
            // xrTableCell74
            // 
            this.xrTableCell74.Dpi = 100F;
            this.xrTableCell74.Name = "xrTableCell74";
            this.xrTableCell74.Weight = 0.61394851883133128D;
            // 
            // xrTableRow21
            // 
            this.xrTableRow21.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell75,
            this.xrTableCell76,
            this.xrTableCell77,
            this.xrTableCell78});
            this.xrTableRow21.Dpi = 100F;
            this.xrTableRow21.Name = "xrTableRow21";
            this.xrTableRow21.Weight = 1D;
            // 
            // xrTableCell75
            // 
            this.xrTableCell75.Dpi = 100F;
            this.xrTableCell75.Name = "xrTableCell75";
            this.xrTableCell75.Weight = 0.57390711023523522D;
            // 
            // xrTableCell76
            // 
            this.xrTableCell76.Dpi = 100F;
            this.xrTableCell76.Multiline = true;
            this.xrTableCell76.Name = "xrTableCell76";
            this.xrTableCell76.Weight = 1.9045713682432433D;
            // 
            // xrTableCell77
            // 
            this.xrTableCell77.Dpi = 100F;
            this.xrTableCell77.Name = "xrTableCell77";
            this.xrTableCell77.Weight = 0.90757300269019014D;
            // 
            // xrTableCell78
            // 
            this.xrTableCell78.Dpi = 100F;
            this.xrTableCell78.Name = "xrTableCell78";
            this.xrTableCell78.Weight = 0.61394851883133128D;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.ForeColor = System.Drawing.Color.Orange;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(333.3333F, 6.25F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(300F, 141.25F);
            this.xrLabel1.StylePriority.UseForeColor = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Date : 19.10.2016\r\nN° Fact ELFR0082\r\nÀ                                 SARL BENIN" +
    "ATI Christian\r\n6 Chemin de garibony\r\nLE CANNET, 06110\r\nTéléphone : NC\r\nRéf clien" +
    "t AND1502\r\n";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrLabel1_BeforePrint);
            // 
            // xrTable1
            // 
            this.xrTable1.Bookmark = "5";
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.BorderWidth = 1F;
            this.xrTable1.Dpi = 100F;
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(8.95834F, 158.9583F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1,
            this.xrTableRow2});
            this.xrTable1.SizeF = new System.Drawing.SizeF(624.375F, 50F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseBorderWidth = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell7});
            this.xrTableRow1.Dpi = 100F;
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.BackColor = System.Drawing.Color.Orange;
            this.xrTableCell1.Dpi = 100F;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseBackColor = false;
            this.xrTableCell1.Text = "Vendeur";
            this.xrTableCell1.Weight = 0.8958331298828125D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.BackColor = System.Drawing.Color.Orange;
            this.xrTableCell2.Dpi = 100F;
            this.xrTableCell2.Multiline = true;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseBackColor = false;
            this.xrTableCell2.Text = "Tâche";
            this.xrTableCell2.Weight = 2.9729168701171873D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.BackColor = System.Drawing.Color.Orange;
            this.xrTableCell3.Dpi = 100F;
            this.xrTableCell3.Multiline = true;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseBackColor = false;
            this.xrTableCell3.Text = "Modalités de paiement";
            this.xrTableCell3.Weight = 1.4166647338867193D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.BackColor = System.Drawing.Color.Orange;
            this.xrTableCell7.Dpi = 100F;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.StylePriority.UseBackColor = false;
            this.xrTableCell7.Text = "Échéance";
            this.xrTableCell7.Weight = 0.958335266113281D;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell8});
            this.xrTableRow2.Dpi = 100F;
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Dpi = 100F;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "ANDREI";
            this.xrTableCell4.Weight = 0.8958331298828125D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Dpi = 100F;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Text = "DOSSIER NICE";
            this.xrTableCell5.Weight = 2.9729168701171877D;
            this.xrTableCell5.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrTableCell5_BeforePrint);
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Dpi = 100F;
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = "CHEQUE";
            this.xrTableCell6.Weight = 1.4166647338867184D;
            this.xrTableCell6.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrTableCell6_BeforePrint);
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Dpi = 100F;
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Text = "19.10.2016";
            this.xrTableCell8.Weight = 0.958335266113281D;
            this.xrTableCell8.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrTableCell8_BeforePrint);
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrPictureBox2,
            this.xrPictureBox1,
            this.xrLine1});
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 135.4166F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.ForeColor = System.Drawing.Color.Orange;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(472.9167F, 87.24994F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(160.4167F, 28.20834F);
            this.xrLabel2.StylePriority.UseForeColor = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "FACTURE N° ELFR0082";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrLabel2.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrLabel2_BeforePrint);
            // 
            // xrPictureBox2
            // 
            this.xrPictureBox2.Dpi = 100F;
            this.xrPictureBox2.ImageUrl = "~\\Images\\elite1.png";
            this.xrPictureBox2.LocationFloat = new DevExpress.Utils.PointFloat(20.83333F, 67.45827F);
            this.xrPictureBox2.Name = "xrPictureBox2";
            this.xrPictureBox2.SizeF = new System.Drawing.SizeF(88.12501F, 48F);
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Dpi = 100F;
            this.xrPictureBox1.ImageUrl = "~\\Images\\logo.png";
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(188.5417F, 26.4166F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(217.7083F, 43.75F);
            // 
            // xrLine1
            // 
            this.xrLine1.BorderColor = System.Drawing.Color.Orange;
            this.xrLine1.Dpi = 100F;
            this.xrLine1.ForeColor = System.Drawing.Color.Orange;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(2.083333F, 121.4583F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(644.7917F, 2.083336F);
            this.xrLine1.StylePriority.UseBorderColor = false;
            this.xrLine1.StylePriority.UseForeColor = false;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 61.45833F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox3});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 160.4167F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrPictureBox3
            // 
            this.xrPictureBox3.Dpi = 100F;
            this.xrPictureBox3.ImageUrl = "~\\Images\\footerpng.png";
            this.xrPictureBox3.LocationFloat = new DevExpress.Utils.PointFloat(8.95834F, 9F);
            this.xrPictureBox3.Name = "xrPictureBox3";
            this.xrPictureBox3.SizeF = new System.Drawing.SizeF(624.375F, 140F);
            // 
            // XtraReport1
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter});
            this.Margins = new System.Drawing.Printing.Margins(100, 100, 135, 61);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
    
    private void xrLabel2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        var oldText = (sender as XRLabel).Text; //FACTURE N° ELFR0082        
        (sender as XRLabel).Text = oldText.Replace("0082", Parameters["Numar contract"].Value.ToString());
    }

    private void xrLabel1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        //Date: 19.10.2016
        //N° Fact ELFR0082
        /*var oldText = (sender as XRLabel).Text;        var sNumber = Parameters["Numar contract"].Value.ToString();        var sDate = Parameters["Data"].Value.ToString();        (sender as XRLabel).Text = oldText.Replace("0082", sNumber).Replace("19.10.2016", sDate);*/


        var sDateClient = Parameters["Date client"].Value.ToString();        (sender as XRLabel).Text = sDateClient;


    }

    private void xrTableCell8_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        //19.10.2016        
        (sender as XRTableCell).Text = Parameters["Data"].Value.ToString();

        for (int row = 1; row < 15; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                if (Parameters[row + ":" + col]?.Value == null)
                    continue;
                xrTable2.Rows[row].Cells[col-1].Text = Parameters[row + ":" + col]?.Value.ToString();
            }
        }        
    }

    private void xrTableCell63_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        if (Parameters["suma totala"]?.Value == null)
            return;
        (sender as XRTableCell).Text = Parameters["suma totala"].Value.ToString();
    }

    private void xrTableCell66_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        if (Parameters["suma totala"]?.Value == null)
            return;
        (sender as XRTableCell).Text = Parameters["suma totala"].Value.ToString();
    }

    private void xrTableCell6_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        //Modalités de paiement
        if (Parameters["modalites de paiement"]?.Value == null)
            return;
        (sender as XRTableCell).Text = Parameters["modalites de paiement"].Value.ToString();
    }

    private void xrTableCell5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        //Tâche
        if (Parameters["tache"]?.Value == null)
            return;
        (sender as XRTableCell).Text = Parameters["tache"].Value.ToString();
    }

    private void xrTableCell64_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        //TVA
        if (Parameters["TVA"]?.Value == null)
            return;
        (sender as XRTableCell).Text = Parameters["TVA"].Value.ToString();
    }
}
