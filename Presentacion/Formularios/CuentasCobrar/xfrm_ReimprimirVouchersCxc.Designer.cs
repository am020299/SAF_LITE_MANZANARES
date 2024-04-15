
namespace Presentacion.Formularios.CuentasCobrar
{
    partial class xfrm_ReimprimirVouchersCxc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xfrm_ReimprimirVouchersCxc));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControlDocumentos = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.VertoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reimprimirVoucherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewDetalle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Column_IdDocto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_nombre_documento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_fecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_nombreCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_concepto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_moneda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column_monto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbi_Actualizar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.anularReciboToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDocumentos)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ViewDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControlDocumentos);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 24);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(734, 327);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControlDocumentos
            // 
            this.gridControlDocumentos.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControlDocumentos.Location = new System.Drawing.Point(12, 12);
            this.gridControlDocumentos.MainView = this.ViewDetalle;
            this.gridControlDocumentos.Name = "gridControlDocumentos";
            this.gridControlDocumentos.Size = new System.Drawing.Size(710, 303);
            this.gridControlDocumentos.TabIndex = 4;
            this.gridControlDocumentos.UseEmbeddedNavigator = true;
            this.gridControlDocumentos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ViewDetalle});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VertoolStripMenuItem,
            this.reimprimirVoucherToolStripMenuItem,
            this.anularReciboToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(197, 92);
            // 
            // VertoolStripMenuItem
            // 
            this.VertoolStripMenuItem.Image = global::Presentacion.Properties.Resources.archivo16x16_;
            this.VertoolStripMenuItem.Name = "VertoolStripMenuItem";
            this.VertoolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.VertoolStripMenuItem.Text = "Reimprimir Voucher C$";
            this.VertoolStripMenuItem.Click += new System.EventHandler(this.VertoolStripMenuItem_Click);
            // 
            // reimprimirVoucherToolStripMenuItem
            // 
            this.reimprimirVoucherToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reimprimirVoucherToolStripMenuItem.Image")));
            this.reimprimirVoucherToolStripMenuItem.Name = "reimprimirVoucherToolStripMenuItem";
            this.reimprimirVoucherToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.reimprimirVoucherToolStripMenuItem.Text = "Reimprimir Voucher $";
            this.reimprimirVoucherToolStripMenuItem.Click += new System.EventHandler(this.reimprimirVoucherToolStripMenuItem_Click);
            // 
            // ViewDetalle
            // 
            this.ViewDetalle.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewDetalle.Appearance.HeaderPanel.Options.UseFont = true;
            this.ViewDetalle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Column_IdDocto,
            this.Column_nombre_documento,
            this.Column_fecha,
            this.Column_nombreCliente,
            this.Column_concepto,
            this.Column_moneda,
            this.Column_monto});
            this.ViewDetalle.GridControl = this.gridControlDocumentos;
            this.ViewDetalle.GroupCount = 1;
            this.ViewDetalle.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "id_documento", this.Column_nombre_documento, "CONTEO: {0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "monto_total", this.Column_monto, "{0:n2}")});
            this.ViewDetalle.Name = "ViewDetalle";
            this.ViewDetalle.OptionsBehavior.AutoExpandAllGroups = true;
            this.ViewDetalle.OptionsBehavior.Editable = false;
            this.ViewDetalle.OptionsView.ShowAutoFilterRow = true;
            this.ViewDetalle.OptionsView.ShowGroupPanel = false;
            this.ViewDetalle.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.Column_moneda, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // Column_IdDocto
            // 
            this.Column_IdDocto.Caption = "ID DOCUMENTO";
            this.Column_IdDocto.FieldName = "id_documento";
            this.Column_IdDocto.Name = "Column_IdDocto";
            // 
            // Column_nombre_documento
            // 
            this.Column_nombre_documento.Caption = "TIPO DOCUMENTO";
            this.Column_nombre_documento.FieldName = "nombre_documento";
            this.Column_nombre_documento.Name = "Column_nombre_documento";
            this.Column_nombre_documento.Visible = true;
            this.Column_nombre_documento.VisibleIndex = 0;
            // 
            // Column_fecha
            // 
            this.Column_fecha.Caption = "FECHA APLICACION";
            this.Column_fecha.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.Column_fecha.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Column_fecha.FieldName = "fecha_documento";
            this.Column_fecha.Name = "Column_fecha";
            this.Column_fecha.Visible = true;
            this.Column_fecha.VisibleIndex = 1;
            // 
            // Column_nombreCliente
            // 
            this.Column_nombreCliente.Caption = "CLIENTE";
            this.Column_nombreCliente.FieldName = "nombre_cliente";
            this.Column_nombreCliente.Name = "Column_nombreCliente";
            this.Column_nombreCliente.Visible = true;
            this.Column_nombreCliente.VisibleIndex = 2;
            // 
            // Column_concepto
            // 
            this.Column_concepto.Caption = "CONCEPTO";
            this.Column_concepto.FieldName = "concepto_documento";
            this.Column_concepto.Name = "Column_concepto";
            this.Column_concepto.Visible = true;
            this.Column_concepto.VisibleIndex = 3;
            // 
            // Column_moneda
            // 
            this.Column_moneda.Caption = "MONEDA";
            this.Column_moneda.FieldName = "moneda_factura";
            this.Column_moneda.Name = "Column_moneda";
            this.Column_moneda.Visible = true;
            this.Column_moneda.VisibleIndex = 4;
            // 
            // Column_monto
            // 
            this.Column_monto.Caption = "MONTO";
            this.Column_monto.DisplayFormat.FormatString = "n2";
            this.Column_monto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Column_monto.FieldName = "monto_total";
            this.Column_monto.Name = "Column_monto";
            this.Column_monto.Visible = true;
            this.Column_monto.VisibleIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(734, 327);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControlDocumentos;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(714, 307);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbi_Actualizar});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 1;
            // 
            // bar2
            // 
            this.bar2.BarName = "Menú principal";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbi_Actualizar)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menú principal";
            // 
            // bbi_Actualizar
            // 
            this.bbi_Actualizar.Caption = "ACTUALIZAR";
            this.bbi_Actualizar.Id = 0;
            this.bbi_Actualizar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbi_Actualizar.ImageOptions.Image")));
            this.bbi_Actualizar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbi_Actualizar.ImageOptions.LargeImage")));
            this.bbi_Actualizar.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.bbi_Actualizar.ItemAppearance.Normal.Options.UseFont = true;
            this.bbi_Actualizar.Name = "bbi_Actualizar";
            this.bbi_Actualizar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbi_Actualizar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Actualizar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(734, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 351);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(734, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 327);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(734, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 327);
            // 
            // anularReciboToolStripMenuItem
            // 
            this.anularReciboToolStripMenuItem.Image = global::Presentacion.Properties.Resources.invalido;
            this.anularReciboToolStripMenuItem.Name = "anularReciboToolStripMenuItem";
            this.anularReciboToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.anularReciboToolStripMenuItem.Text = "Anular Recibo";
            this.anularReciboToolStripMenuItem.Click += new System.EventHandler(this.anularReciboToolStripMenuItem_Click);
            // 
            // xfrm_ReimprimirVouchersCxc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 351);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "xfrm_ReimprimirVouchersCxc";
            this.Text = "REIMPRIMIR ABONOS/CANCELACION";
            this.Load += new System.EventHandler(this.xfrm_ReimprimirVouchersCxc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDocumentos)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ViewDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl gridControlDocumentos;
        private DevExpress.XtraGrid.Views.Grid.GridView ViewDetalle;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn Column_IdDocto;
        private DevExpress.XtraGrid.Columns.GridColumn Column_nombre_documento;
        private DevExpress.XtraGrid.Columns.GridColumn Column_fecha;
        private DevExpress.XtraGrid.Columns.GridColumn Column_nombreCliente;
        private DevExpress.XtraGrid.Columns.GridColumn Column_concepto;
        private DevExpress.XtraGrid.Columns.GridColumn Column_monto;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem VertoolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn Column_moneda;
        private System.Windows.Forms.ToolStripMenuItem reimprimirVoucherToolStripMenuItem;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem bbi_Actualizar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.ToolStripMenuItem anularReciboToolStripMenuItem;
    }
}