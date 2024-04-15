using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;

namespace Presentacion.Reportes.Inventario
{
    public partial class xrpt_movimientos_inventario:DevExpress.XtraReports.UI.XtraReport
    {
        public string[]tipos_movimientos;
        public string[]Tipo_Movimientos  { get=>tipos_movimientos; set=>tipos_movimientos=value; }
        public xrpt_movimientos_inventario( )
        {
            InitializeComponent();
            PrintingSystem.AfterMarginsChange += PrintingSystem_AfterMarginsChange;
            PrintingSystem.PageSettingsChanged += PrintingSystem_PageSettingsChanged;
            DevExpress.XtraReports.Expressions.ExpressionBindingDescriptor.SetPropertyDescription(typeof(XtraReport),"Landscape",new DevExpress.XtraReports.Expressions.ExpressionBindingDescription(new[] { "BeforePrint" },1000,new string[0]));
        }
        void PrintingSystem_PageSettingsChanged(object sender,EventArgs e)
        {
            var ps = (PrintingSystemBase)sender;
            XtraPageSettingsBase pageSettings = ps.PageSettings;

            PaperKind = pageSettings.PaperKind;
            Landscape = pageSettings.Landscape;
            Horizontal.Value = pageSettings.Landscape;

            CreateDocument();
        }
        void PrintingSystem_AfterMarginsChange(object sender,MarginsChangeEventArgs e)
        {
            switch(e.Side)
            {
                case MarginSide.Left:
                    Margins = new System.Drawing.Printing.Margins((int) e.Value,Margins.Right,Margins.Top,Margins.Bottom);
                    CreateDocument();
                    break;
                case MarginSide.Right:
                    Margins = new System.Drawing.Printing.Margins(Margins.Left,(int) e.Value,Margins.Top,Margins.Bottom);
                    CreateDocument();
                    break;
                case MarginSide.All:
                    Margins = ((PrintingSystemBase) sender).PageSettings.Margins;
                    CreateDocument();
                    break;
            }
        }
        private void xrpt_movimientos_inventario_BeforePrint(object sender,System.Drawing.Printing.PrintEventArgs e)
        {
            DetailReport.FilterString = "[tipo_ajuste] In (?Tipo_Movimiento)";
            DetailReport2.FilterString = "[tipo_ajuste] In (?Tipo_Movimiento)";
            Landscape = (bool)Horizontal.Value;
        }

        private void xrpt_movimientos_inventario_ParametersRequestBeforeShow(object sender,DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            if(Tipo_Movimiento.Value.ToString()!=string.Empty)
            {
                Array.Clear(tipos_movimientos,0,Tipo_Movimientos.Length);
                Tipo_Movimientos[0] = Tipo_Movimiento.Value.ToString();
            }
            e.ParametersInformation[3].Parameter.Value = Tipo_Movimientos;
        }
    }
}
