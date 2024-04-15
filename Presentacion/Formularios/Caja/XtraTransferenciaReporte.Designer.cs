namespace Presentacion.Formularios.Caja
{
    partial class XtraTransferenciaReporte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.transferenciasrangoSELECTResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colN_FACTURA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colN_Transferencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFECHA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCLIENTE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEMPLEADO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMONTO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmoneda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colid_forma_pago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaDeposito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.dateEditTRF = new DevExpress.XtraEditors.DateEdit();
            this.btnCargarTRF = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.source = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transferenciasrangoSELECTResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTRF.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTRF.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.source)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.dateEdit1);
            this.layoutControl1.Controls.Add(this.dateEditTRF);
            this.layoutControl1.Controls.Add(this.btnCargarTRF);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(712, 363);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(161, 60);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(430, 22);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 8;
            this.simpleButton1.Text = "CARGAR";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.transferenciasrangoSELECTResultBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(161, 112);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(430, 155);
            this.gridControl1.TabIndex = 7;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // transferenciasrangoSELECTResultBindingSource
            // 
            this.transferenciasrangoSELECTResultBindingSource.DataSource = typeof(Entidades.Transferencias_rango_SELECT_Result);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colN_FACTURA,
            this.colN_Transferencia,
            this.colFECHA,
            this.colCLIENTE,
            this.colEMPLEADO,
            this.colMONTO,
            this.colmoneda,
            this.colid_forma_pago,
            this.colFechaDeposito});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colN_FACTURA
            // 
            this.colN_FACTURA.AppearanceCell.Options.UseTextOptions = true;
            this.colN_FACTURA.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colN_FACTURA.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colN_FACTURA.AppearanceHeader.Options.UseTextOptions = true;
            this.colN_FACTURA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colN_FACTURA.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colN_FACTURA.Caption = "N° Factura";
            this.colN_FACTURA.FieldName = "N_FACTURA";
            this.colN_FACTURA.Name = "colN_FACTURA";
            this.colN_FACTURA.OptionsColumn.AllowEdit = false;
            this.colN_FACTURA.Visible = true;
            this.colN_FACTURA.VisibleIndex = 0;
            // 
            // colN_Transferencia
            // 
            this.colN_Transferencia.AppearanceCell.Options.UseTextOptions = true;
            this.colN_Transferencia.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colN_Transferencia.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colN_Transferencia.AppearanceHeader.Options.UseTextOptions = true;
            this.colN_Transferencia.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colN_Transferencia.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colN_Transferencia.Caption = "N° Transferencia";
            this.colN_Transferencia.FieldName = "N_Transferencia";
            this.colN_Transferencia.Name = "colN_Transferencia";
            this.colN_Transferencia.OptionsColumn.AllowEdit = false;
            this.colN_Transferencia.Visible = true;
            this.colN_Transferencia.VisibleIndex = 2;
            // 
            // colFECHA
            // 
            this.colFECHA.AppearanceCell.Options.UseTextOptions = true;
            this.colFECHA.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFECHA.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colFECHA.AppearanceHeader.Options.UseTextOptions = true;
            this.colFECHA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFECHA.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colFECHA.Caption = "Fecha";
            this.colFECHA.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colFECHA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colFECHA.FieldName = "FECHA";
            this.colFECHA.Name = "colFECHA";
            this.colFECHA.OptionsColumn.AllowEdit = false;
            this.colFECHA.Visible = true;
            this.colFECHA.VisibleIndex = 1;
            // 
            // colCLIENTE
            // 
            this.colCLIENTE.AppearanceCell.Options.UseTextOptions = true;
            this.colCLIENTE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCLIENTE.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCLIENTE.AppearanceHeader.Options.UseTextOptions = true;
            this.colCLIENTE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCLIENTE.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCLIENTE.Caption = "Cliente";
            this.colCLIENTE.FieldName = "CLIENTE";
            this.colCLIENTE.Name = "colCLIENTE";
            this.colCLIENTE.OptionsColumn.AllowEdit = false;
            this.colCLIENTE.Visible = true;
            this.colCLIENTE.VisibleIndex = 4;
            // 
            // colEMPLEADO
            // 
            this.colEMPLEADO.AppearanceCell.Options.UseTextOptions = true;
            this.colEMPLEADO.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEMPLEADO.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colEMPLEADO.AppearanceHeader.Options.UseTextOptions = true;
            this.colEMPLEADO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEMPLEADO.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colEMPLEADO.Caption = "Empleado";
            this.colEMPLEADO.FieldName = "EMPLEADO";
            this.colEMPLEADO.Name = "colEMPLEADO";
            this.colEMPLEADO.OptionsColumn.AllowEdit = false;
            this.colEMPLEADO.Visible = true;
            this.colEMPLEADO.VisibleIndex = 5;
            // 
            // colMONTO
            // 
            this.colMONTO.AppearanceCell.Options.UseTextOptions = true;
            this.colMONTO.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMONTO.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMONTO.AppearanceHeader.Options.UseTextOptions = true;
            this.colMONTO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMONTO.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMONTO.Caption = "Monto";
            this.colMONTO.DisplayFormat.FormatString = "n2";
            this.colMONTO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMONTO.FieldName = "MONTO";
            this.colMONTO.Name = "colMONTO";
            this.colMONTO.OptionsColumn.AllowEdit = false;
            this.colMONTO.Visible = true;
            this.colMONTO.VisibleIndex = 6;
            // 
            // colmoneda
            // 
            this.colmoneda.Caption = "Tipo";
            this.colmoneda.FieldName = "moneda";
            this.colmoneda.Name = "colmoneda";
            // 
            // colid_forma_pago
            // 
            this.colid_forma_pago.FieldName = "id_forma_pago";
            this.colid_forma_pago.Name = "colid_forma_pago";
            // 
            // colFechaDeposito
            // 
            this.colFechaDeposito.AppearanceCell.Options.UseTextOptions = true;
            this.colFechaDeposito.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFechaDeposito.AppearanceHeader.Options.UseTextOptions = true;
            this.colFechaDeposito.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFechaDeposito.Caption = "Fecha Deposito";
            this.colFechaDeposito.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colFechaDeposito.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colFechaDeposito.FieldName = "FECHA_DEPOSITO";
            this.colFechaDeposito.Name = "colFechaDeposito";
            this.colFechaDeposito.OptionsColumn.AllowEdit = false;
            this.colFechaDeposito.Visible = true;
            this.colFechaDeposito.VisibleIndex = 3;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(210, 36);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(381, 20);
            this.dateEdit1.StyleController = this.layoutControl1;
            this.dateEdit1.TabIndex = 6;
            // 
            // dateEditTRF
            // 
            this.dateEditTRF.EditValue = null;
            this.dateEditTRF.Location = new System.Drawing.Point(210, 12);
            this.dateEditTRF.Name = "dateEditTRF";
            this.dateEditTRF.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditTRF.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditTRF.Size = new System.Drawing.Size(381, 20);
            this.dateEditTRF.StyleController = this.layoutControl1;
            this.dateEditTRF.TabIndex = 4;
            // 
            // btnCargarTRF
            // 
            this.btnCargarTRF.Location = new System.Drawing.Point(161, 86);
            this.btnCargarTRF.Name = "btnCargarTRF";
            this.btnCargarTRF.Size = new System.Drawing.Size(430, 22);
            this.btnCargarTRF.StyleController = this.layoutControl1;
            this.btnCargarTRF.TabIndex = 5;
            this.btnCargarTRF.Text = "GENERAR REPORTE";
            this.btnCargarTRF.Click += new System.EventHandler(this.btnCargarTRF_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(712, 363);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dateEditTRF;
            this.layoutControlItem1.CustomizationFormText = "DESDE:";
            this.layoutControlItem1.Location = new System.Drawing.Point(149, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(434, 24);
            this.layoutControlItem1.Text = "DESDE:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(37, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(149, 259);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(434, 84);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnCargarTRF;
            this.layoutControlItem2.Location = new System.Drawing.Point(149, 74);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(434, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(583, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(109, 343);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(149, 343);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dateEdit1;
            this.layoutControlItem3.Location = new System.Drawing.Point(149, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(434, 24);
            this.layoutControlItem3.Text = "HASTA:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(37, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gridControl1;
            this.layoutControlItem4.Location = new System.Drawing.Point(149, 100);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(434, 159);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.simpleButton1;
            this.layoutControlItem5.Location = new System.Drawing.Point(149, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(434, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // XtraTransferenciaReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 363);
            this.Controls.Add(this.layoutControl1);
            this.Name = "XtraTransferenciaReporte";
            this.Text = "REPORTES DE TRANSFERENCIAS";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transferenciasrangoSELECTResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTRF.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTRF.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.source)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.DateEdit dateEditTRF;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton btnCargarTRF;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private System.Windows.Forms.BindingSource source;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private System.Windows.Forms.BindingSource transferenciasrangoSELECTResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colN_FACTURA;
        private DevExpress.XtraGrid.Columns.GridColumn colN_Transferencia;
        private DevExpress.XtraGrid.Columns.GridColumn colFECHA;
        private DevExpress.XtraGrid.Columns.GridColumn colCLIENTE;
        private DevExpress.XtraGrid.Columns.GridColumn colEMPLEADO;
        private DevExpress.XtraGrid.Columns.GridColumn colMONTO;
        private DevExpress.XtraGrid.Columns.GridColumn colmoneda;
        private DevExpress.XtraGrid.Columns.GridColumn colid_forma_pago;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaDeposito;
    }
}