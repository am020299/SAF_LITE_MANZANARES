using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.Caja
{
    public partial class XtraReportCheques : DevExpress.XtraReports.UI.XtraReport
    {
        bool ventana;

        DateTime fechaTRF;
        DateTime fechaHasta;
        int tipo;
        public XtraReportCheques(BindingSource source, DateTime fecha, int tipo)
        {
            InitializeComponent();
            this.DataSource = source;
            this.fechaTRF = fecha;
            this.ventana = false;
            this.tipo = tipo;
        }

        public XtraReportCheques(BindingSource source, DateTime fechaDesde, DateTime fechaHasta)
        {
            InitializeComponent();
            this.DataSource = source;
            this.fechaTRF = fechaDesde;
            this.fechaHasta = fechaHasta;
            this.ventana = true;
        }

        private void XtraReportTrasnferencias_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (ventana)
            {
                if (int.Parse(seleccionTRF.Value.ToString()) == 1)
                {
                    xrLabel1.Text = "REPORTE DE CHEQUES";
                    this.DataSource = Negocio.ClasesCN.CajaCN.CHEQUES_rango_SELECT(fechaTRF, fechaHasta, 1);
                    //xrTableCell6.Visible = false;
                    //xrtablecellTIPO.Visible = false;
                }
                else if (int.Parse(seleccionTRF.Value.ToString()) == 2)
                {
                    xrLabel1.Text = "REPORTE DE CHEQUES";
                    this.DataSource = Negocio.ClasesCN.CajaCN.CHEQUES_rango_SELECT(fechaTRF, fechaHasta, 2);
                    //xrTableCell6.Visible = false;
                    //xrtablecellTIPO.Visible = false;
                }
                else if (int.Parse(seleccionTRF.Value.ToString()) == 3)
                {
                    xrLabel1.Text = "REPORTE DE CHEQUES";
                    this.DataSource = Negocio.ClasesCN.CajaCN.CHEQUES_rango_SELECT(fechaTRF, fechaHasta, 3);
                    //xrTableCell6.Visible = false;
                    //xrtablecellTIPO.Visible = false;
                }
                else
                {
                    xrLabel1.Text = "REPORTE DE TODOS LOS CHEQUES";
                    this.DataSource = Negocio.ClasesCN.CajaCN.CHEQUES_rango_SELECT(fechaTRF, fechaHasta, 0);
                    //xrTableCell6.Visible = true;
                    //xrtablecellTIPO.Visible = true;

                }

            }
            else
            {
                if (tipo == 0)
                {
                    xrLabel1.Text = "REPORTE DE CHEQUES";
                    //this.DataSource = Negocio.ClasesCN.CajaCN.TRANSFERENCIA_SELECT(fechaTRF, 3);
                }
                else if (tipo == 1)
                {
                    xrLabel1.Text = "REPORTE DE CHEQUES EN CÓRDOBAS";
                    //this.DataSource = Negocio.ClasesCN.CajaCN.TRANSFERENCIA_SELECT(fechaTRF, 3);
                }
                else if (tipo == 2)
                {
                    xrLabel1.Text = "REPORTE DE CHEQUES EN DÓLARES";
                    //this.DataSource = Negocio.ClasesCN.CajaCN.TRANSFERENCIA_SELECT(fechaTRF, 4);
                }
                //if (int.Parse(seleccionTRF.Value.ToString()) == 3)
                //{
                //    xrLabel1.Text = "REPORTE DE TRANSFERENCIAS EN CÓRDOBAS";
                //    this.DataSource = Negocio.ClasesCN.CajaCN.TRANSFERENCIA_SELECT(fechaTRF, 3);
                //    xrTableCell6.Visible = false;
                //    xrtablecellTIPO.Visible = false;
                //}
                //else if (int.Parse(seleccionTRF.Value.ToString()) == 4)
                //{
                //    xrLabel1.Text = "REPORTE DE TRANSFERENCIAS EN DÓLARES";
                //    this.DataSource = Negocio.ClasesCN.CajaCN.TRANSFERENCIA_SELECT(fechaTRF, 4);
                //    xrTableCell6.Visible = false;
                //    xrtablecellTIPO.Visible = false;
                //}
                //else
                //{
                //    xrLabel1.Text = "REPORTE DE TODAS LAS TRANSFERENCIAS";
                //    this.DataSource = Negocio.ClasesCN.CajaCN.TRANSFERENCIA_SELECT(fechaTRF, 0);
                //    xrTableCell6.Visible = true;
                //    xrtablecellTIPO.Visible = true;

                //}
            }
        }

    }
}
