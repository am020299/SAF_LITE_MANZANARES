namespace Presentacion.Formularios.Inventario
{
    partial class xfrm_KardexConsultaTienda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xfrm_KardexConsultaTienda));
            this.gridKardex = new DevExpress.XtraGrid.GridControl();
            this.bindingSourceKardex = new System.Windows.Forms.BindingSource(this.components);
            this.viewKardex = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.id_lote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_lote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.click_derecho = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportarExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verMovimientoPorProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarVentanaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.toggleSwitch1 = new DevExpress.XtraEditors.ToggleSwitch();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridKardex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceKardex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewKardex)).BeginInit();
            this.click_derecho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridKardex
            // 
            this.gridKardex.DataSource = this.bindingSourceKardex;
            this.gridKardex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridKardex.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridKardex.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridKardex.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridKardex.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridKardex.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridKardex.Location = new System.Drawing.Point(0, 0);
            this.gridKardex.MainView = this.viewKardex;
            this.gridKardex.Name = "gridKardex";
            this.gridKardex.Size = new System.Drawing.Size(784, 561);
            this.gridKardex.TabIndex = 0;
            this.gridKardex.UseEmbeddedNavigator = true;
            this.gridKardex.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewKardex});
            // 
            // viewKardex
            // 
            this.viewKardex.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.viewKardex.Appearance.FooterPanel.Options.UseFont = true;
            this.viewKardex.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.viewKardex.Appearance.HeaderPanel.Options.UseFont = true;
            this.viewKardex.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.viewKardex.Appearance.Row.Options.UseFont = true;
            this.viewKardex.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn14,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn8,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.id_lote,
            this.col_lote,
            this.gridColumn15});
            this.viewKardex.GridControl = this.gridKardex;
            this.viewKardex.GroupCount = 1;
            this.viewKardex.Name = "viewKardex";
            this.viewKardex.OptionsBehavior.AutoExpandAllGroups = true;
            this.viewKardex.OptionsView.EnableAppearanceEvenRow = true;
            this.viewKardex.OptionsView.ShowAutoFilterRow = true;
            this.viewKardex.OptionsView.ShowFooter = true;
            this.viewKardex.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn14, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.viewKardex.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.viewKardex_RowUpdated);
            this.viewKardex.MouseUp += new System.Windows.Forms.MouseEventHandler(this.viewKardex_MouseUp);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "CODIGO";
            this.gridColumn1.FieldName = "codigo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "SUB GRUPO";
            this.gridColumn14.FieldName = "subgrupo";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "DESCRIPCIÓN PRODUCTO";
            this.gridColumn2.FieldName = "producto";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "BODEGA";
            this.gridColumn3.FieldName = "bodega";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "SALDO INICIAL";
            this.gridColumn4.DisplayFormat.FormatString = "n2";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "saldo_inicial";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "saldo_inicial", "{0:n2}")});
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "ENTRADAS";
            this.gridColumn5.DisplayFormat.FormatString = "n2";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "entradas";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "entradas", "{0:n2}")});
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "SALIDAS";
            this.gridColumn6.DisplayFormat.FormatString = "n2";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "salidas";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "salidas", "{0:n2}")});
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "AJUSTES";
            this.gridColumn7.DisplayFormat.FormatString = "n2";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "ajuste";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ajuste", "{0:n2}")});
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "REMITIDOS";
            this.gridColumn9.DisplayFormat.FormatString = "n2";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.FieldName = "comprometido";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "comprometido", "{0:n2}")});
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 2;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "DISPONIBLE";
            this.gridColumn10.DisplayFormat.FormatString = "n2";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "disponible";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "disponible", "{0:n2}")});
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 4;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "SALDO ACTUAL";
            this.gridColumn8.DisplayFormat.FormatString = "n2";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "saldo_actual";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "saldo_actual", "{0:n2}")});
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "MODULO";
            this.gridColumn11.DisplayFormat.FormatString = "n0";
            this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn11.FieldName = "ubicacion";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
            this.gridColumn11.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "ID PRODUCTO";
            this.gridColumn12.FieldName = "id_producto";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowShowHide = false;
            this.gridColumn12.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn12.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "ID BODEGA";
            this.gridColumn13.FieldName = "id_bodega";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowShowHide = false;
            this.gridColumn13.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn13.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // id_lote
            // 
            this.id_lote.Caption = "id_lote";
            this.id_lote.FieldName = "id_lote";
            this.id_lote.Name = "id_lote";
            this.id_lote.OptionsColumn.AllowEdit = false;
            // 
            // col_lote
            // 
            this.col_lote.Caption = "LOTE";
            this.col_lote.DisplayFormat.FormatString = "MMM-yyyy";
            this.col_lote.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_lote.FieldName = "lote";
            this.col_lote.Name = "col_lote";
            this.col_lote.OptionsColumn.AllowEdit = false;
            // 
            // click_derecho
            // 
            this.click_derecho.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarExcelToolStripMenuItem,
            this.verMovimientoPorProductoToolStripMenuItem,
            this.actualizarVentanaToolStripMenuItem});
            this.click_derecho.Name = "click_derecho";
            this.click_derecho.Size = new System.Drawing.Size(232, 70);
            // 
            // exportarExcelToolStripMenuItem
            // 
            this.exportarExcelToolStripMenuItem.Image = global::Presentacion.Properties.Resources.excel_16;
            this.exportarExcelToolStripMenuItem.Name = "exportarExcelToolStripMenuItem";
            this.exportarExcelToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.exportarExcelToolStripMenuItem.Text = "Exportar Excel";
            this.exportarExcelToolStripMenuItem.Click += new System.EventHandler(this.exportarExcelToolStripMenuItem_Click);
            // 
            // verMovimientoPorProductoToolStripMenuItem
            // 
            this.verMovimientoPorProductoToolStripMenuItem.Image = global::Presentacion.Properties.Resources.archivo16x16_;
            this.verMovimientoPorProductoToolStripMenuItem.Name = "verMovimientoPorProductoToolStripMenuItem";
            this.verMovimientoPorProductoToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.verMovimientoPorProductoToolStripMenuItem.Text = "Ver Movimiento Por Producto";
            this.verMovimientoPorProductoToolStripMenuItem.Click += new System.EventHandler(this.verMovimientoPorProductoToolStripMenuItem_Click);
            // 
            // actualizarVentanaToolStripMenuItem
            // 
            this.actualizarVentanaToolStripMenuItem.Name = "actualizarVentanaToolStripMenuItem";
            this.actualizarVentanaToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.actualizarVentanaToolStripMenuItem.Text = "Actualizar Ventana";
            this.actualizarVentanaToolStripMenuItem.Click += new System.EventHandler(this.actualizarVentanaToolStripMenuItem_Click);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Images = this.imageCollection1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(784, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 561);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(784, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 561);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(784, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 561);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertGalleryImage("exporttoxlsx_16x16.png", "office2013/export/exporttoxlsx_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("office2013/export/exporttoxlsx_16x16.png"), 0);
            this.imageCollection1.Images.SetKeyName(0, "exporttoxlsx_16x16.png");
            // 
            // toggleSwitch1
            // 
            this.toggleSwitch1.Location = new System.Drawing.Point(128, 12);
            this.toggleSwitch1.MenuManager = this.barManager1;
            this.toggleSwitch1.Name = "toggleSwitch1";
            this.toggleSwitch1.Properties.OffText = "OCULTAR PRODUCTOS CON STOCK = 0";
            this.toggleSwitch1.Properties.OnText = "MOSTRAR PRODUCTOS CON STOCK = 0";
            this.toggleSwitch1.Size = new System.Drawing.Size(265, 18);
            this.toggleSwitch1.TabIndex = 5;
            this.toggleSwitch1.Visible = false;
            this.toggleSwitch1.Toggled += new System.EventHandler(this.toggleSwitch1_Toggled);
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "PRESTADOS";
            this.gridColumn15.DisplayFormat.FormatString = "n2";
            this.gridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn15.FieldName = "prestamos";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 3;
            // 
            // xfrm_KardexConsultaTienda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.toggleSwitch1);
            this.Controls.Add(this.gridKardex);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "xfrm_KardexConsultaTienda";
            this.Text = "CONSULTA INVENTARIO TIENDA";
            this.Activated += new System.EventHandler(this.xfrm_Kardex_Activated);
            this.Load += new System.EventHandler(this.xfrm_Kardex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridKardex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceKardex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewKardex)).EndInit();
            this.click_derecho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridKardex;
        private DevExpress.XtraGrid.Views.Grid.GridView viewKardex;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private System.Windows.Forms.BindingSource bindingSourceKardex;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private System.Windows.Forms.ContextMenuStrip click_derecho;
        private System.Windows.Forms.ToolStripMenuItem exportarExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verMovimientoPorProductoToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn id_lote;
        private DevExpress.XtraGrid.Columns.GridColumn col_lote;
        private System.Windows.Forms.ToolStripMenuItem actualizarVentanaToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitch1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
    }
}