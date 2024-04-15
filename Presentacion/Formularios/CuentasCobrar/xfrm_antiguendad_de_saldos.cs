using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace Presentacion.Formularios.CuentasCobrar
{
    public partial class xfrm_antiguendad_de_saldos:DevExpress.XtraEditors.XtraForm
    {
        public xfrm_antiguendad_de_saldos( )
        {
            InitializeComponent();
        }
        private void Cargar( )
        {
            try
            {
                var Antiguedades= Negocio.ClasesCN.CuentasCobrarCN.Antiguedad_de_saldos_cuentas_por_cobrar().ToList();
                if(Antiguedades.Count() > 0)
                {
                    var primera_fila= Antiguedades.FirstOrDefault();
                    var C1= $"DE {primera_fila.minimo_cl1} a {primera_fila.maximo_cl1}";
                    var C2= $"DE {primera_fila.minimo_cl2} a {primera_fila.maximo_cl2}";
                    var C3= $"DE {primera_fila.minimo_cl3} a {primera_fila.maximo_cl3}";
                    var C4= $"DE {primera_fila.minimo_cl4} a {primera_fila.maximo_cl4}";
                    var C5= $"DE {primera_fila.minimo_cl5} a MAS";
                    binding_antiguendad.DataSource = Antiguedades.Select(X =>
                    new
                    {
                    X.id_documento,//[0]
                    CANTIDAD_DIAS_VENCIDOS = X.cantidad_dias_vencidos??0,//[1]
                    NOMBRE_CLIENTE = X.nombre_cliente,//[2]
                    TIPO_DOC = X.documento,//[3]
                    NÚMERO_DOC = X.numero_documento,//[4]
                    FECHA_EMISION = X.fecha_emision,//[5]
                    FECHA_VENCIMIENTO = X.fecha_vencimiento,//[6]
                    DIAS_DOC = X.dias_documento,//[7]
                    MONTO = X.monto_documento,//[8]
                    SIN_VENCER = X.sin_vencer,//[9]
                    C1 = X.cl1,//[10]
                    C2 = X.cl2,//[11]
                    C3 = X.cl3,//[12]
                    C4 = X.cl4,//[13]
                    C5 = X.cl5,//[14]
                    COBRADOR = X.cobrador//[15]
                }
                    ).ToList();
                    grid_antiguedad.DataSource = binding_antiguendad;
                    if(gview_antiguedad.Columns.Count > 0)
                    {                        
                        gview_antiguedad.Columns[0].Visible = false;
                        // Agrupar por cliente
                        gview_antiguedad.Columns[2].Group();

                        for (int i = 0;i < gview_antiguedad.Columns.Count;i++)
                        {
                            gview_antiguedad.Columns[i].FieldName = gview_antiguedad.Columns[i].FieldName.ToUpper();
                            gview_antiguedad.Columns[i].Caption = gview_antiguedad.Columns[i].FieldName.Replace('_',' ');
                            gview_antiguedad.Columns[i].Summary.Clear();
                        }
                        gview_antiguedad.Columns[4].DisplayFormat.FormatString = "n0";
                        //Poner Cabeceras
                        gview_antiguedad.Columns[10].Caption = C1;
                        gview_antiguedad.Columns[11].Caption = C2;
                        gview_antiguedad.Columns[12].Caption = C3;
                        gview_antiguedad.Columns[13].Caption = C4;
                        gview_antiguedad.Columns[14].Caption = C5;
                        //Formato 
                        gview_antiguedad.Columns[8].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gview_antiguedad.Columns[8].DisplayFormat.FormatString = "{0:n2}";
                        gview_antiguedad.Columns[9].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gview_antiguedad.Columns[9].DisplayFormat.FormatString = "{0:n2}";
                        gview_antiguedad.Columns[10].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gview_antiguedad.Columns[10].DisplayFormat.FormatString = "{0:n2}";
                        gview_antiguedad.Columns[11].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gview_antiguedad.Columns[11].DisplayFormat.FormatString = "{0:n2}";
                        gview_antiguedad.Columns[12].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gview_antiguedad.Columns[12].DisplayFormat.FormatString = "{0:n2}";
                        gview_antiguedad.Columns[13].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gview_antiguedad.Columns[13].DisplayFormat.FormatString = "{0:n2}";
                        gview_antiguedad.Columns[14].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                        gview_antiguedad.Columns[14].DisplayFormat.FormatString = "{0:n2}";
                        //Poner Totales
                        DevExpress.XtraGrid.GridColumnSummaryItem MONTO = new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum,"MONTO","{0:n2}");
                        DevExpress.XtraGrid.GridColumnSummaryItem SIN_VENCER = new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum,"SIN_VENCER","{0:n2}");
                        DevExpress.XtraGrid.GridColumnSummaryItem TotalC1 = new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum,"C1","{0:n2}");
                        DevExpress.XtraGrid.GridColumnSummaryItem TotalC2 = new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum,"C2","{0:n2}");
                        DevExpress.XtraGrid.GridColumnSummaryItem TotalC3 = new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum,"C3","{0:n2}");
                        DevExpress.XtraGrid.GridColumnSummaryItem TotalC4 = new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum,"C4","{0:n2}");
                        DevExpress.XtraGrid.GridColumnSummaryItem TotalC5 = new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum,"C5","{0:n2}");
                        gview_antiguedad.Columns[8].Summary.Add(MONTO);
                        gview_antiguedad.Columns[9].Summary.Add(SIN_VENCER);
                        gview_antiguedad.Columns[10].Summary.Add(TotalC1);
                        gview_antiguedad.Columns[11].Summary.Add(TotalC2);
                        gview_antiguedad.Columns[12].Summary.Add(TotalC3);
                        gview_antiguedad.Columns[13].Summary.Add(TotalC4);
                        gview_antiguedad.Columns[14].Summary.Add(TotalC5);

                    }
                }
            }
            catch(Exception ex)
            {
            }
   
        }

        private void xfrm_antiguendad_de_saldos_Load(object sender,EventArgs e)
        {
            Cargar();
        }

        private void bbi_cargar_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cargar();
        }

        private void bbi_reporte_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var report = new Reportes.CuentasCobrar.xrpt_antiguedad_saldos();
            report.DataSource = Negocio.ClasesCN.CuentasCobrarCN.Antiguedad_de_saldos_cuentas_por_cobrar().ToList();
            report.ShowPrintMarginsWarning = false;
            report.ShowPreview();
        }

        private void bbi_exportar_excel_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Clases.Exportar().Exportar_Grid_A_Excel(grid_antiguedad);
        }
    }
}