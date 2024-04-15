namespace Presentacion.Formularios.Catalogos
{
    partial class xfrm_Historico_clientes
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
            if(disposing && (components != null))
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
        private void InitializeComponent( )
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xfrm_Historico_clientes));
            this.gviewFacturas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_id_cliente_factura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_id_factura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_numero_factura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_fecha_factura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_total = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_moneda_factura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_empleados = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridClientes = new DevExpress.XtraGrid.GridControl();
            this.gviewDetalles = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gview_Clientes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_id_cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ruc_cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_nombre_cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_telefono = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_celular = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_direccion_cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.col_correo_cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbi_actualizar = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_exportar_Excel = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.gviewFacturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gviewDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview_Clientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // gviewFacturas
            // 
            this.gviewFacturas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_id_cliente_factura,
            this.col_id_factura,
            this.col_numero_factura,
            this.col_fecha_factura,
            this.col_total,
            this.col_moneda_factura,
            this.col_empleados});
            this.gviewFacturas.GridControl = this.gridClientes;
            this.gviewFacturas.Name = "gviewFacturas";
            this.gviewFacturas.OptionsBehavior.Editable = false;
            this.gviewFacturas.OptionsMenu.EnableColumnMenu = false;
            this.gviewFacturas.OptionsView.ShowAutoFilterRow = true;
            this.gviewFacturas.OptionsView.ShowGroupPanel = false;
            // 
            // col_id_cliente_factura
            // 
            this.col_id_cliente_factura.Caption = "id_cliente";
            this.col_id_cliente_factura.FieldName = "id_cliente";
            this.col_id_cliente_factura.Name = "col_id_cliente_factura";
            // 
            // col_id_factura
            // 
            this.col_id_factura.Caption = "id_factura";
            this.col_id_factura.FieldName = "id";
            this.col_id_factura.Name = "col_id_factura";
            // 
            // col_numero_factura
            // 
            this.col_numero_factura.Caption = "NUMERO";
            this.col_numero_factura.FieldName = "numero";
            this.col_numero_factura.Name = "col_numero_factura";
            this.col_numero_factura.Visible = true;
            this.col_numero_factura.VisibleIndex = 0;
            // 
            // col_fecha_factura
            // 
            this.col_fecha_factura.Caption = "FECHA";
            this.col_fecha_factura.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.col_fecha_factura.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_fecha_factura.FieldName = "fecha";
            this.col_fecha_factura.Name = "col_fecha_factura";
            this.col_fecha_factura.Visible = true;
            this.col_fecha_factura.VisibleIndex = 1;
            // 
            // col_total
            // 
            this.col_total.Caption = "TOTAL";
            this.col_total.DisplayFormat.FormatString = "n2";
            this.col_total.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_total.FieldName = "total";
            this.col_total.Name = "col_total";
            this.col_total.Visible = true;
            this.col_total.VisibleIndex = 2;
            // 
            // col_moneda_factura
            // 
            this.col_moneda_factura.Caption = "MONEDA";
            this.col_moneda_factura.FieldName = "moneda_facturas";
            this.col_moneda_factura.Name = "col_moneda_factura";
            this.col_moneda_factura.Visible = true;
            this.col_moneda_factura.VisibleIndex = 3;
            // 
            // col_empleados
            // 
            this.col_empleados.Caption = "EMPLEADO";
            this.col_empleados.FieldName = "empleado";
            this.col_empleados.Name = "col_empleados";
            this.col_empleados.Visible = true;
            this.col_empleados.VisibleIndex = 4;
            // 
            // gridClientes
            // 
            gridLevelNode1.LevelTemplate = this.gviewFacturas;
            gridLevelNode1.RelationName = "Clientes Facturas";
            gridLevelNode2.LevelTemplate = this.gviewDetalles;
            gridLevelNode2.RelationName = "Detalles Facturas";
            this.gridClientes.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2});
            this.gridClientes.Location = new System.Drawing.Point(12, 40);
            this.gridClientes.MainView = this.gview_Clientes;
            this.gridClientes.Name = "gridClientes";
            this.gridClientes.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.gridClientes.Size = new System.Drawing.Size(668, 452);
            this.gridClientes.TabIndex = 4;
            this.gridClientes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gviewDetalles,
            this.gview_Clientes,
            this.gviewFacturas});
            // 
            // gviewDetalles
            // 
            this.gviewDetalles.GridControl = this.gridClientes;
            this.gviewDetalles.Name = "gviewDetalles";
            this.gviewDetalles.OptionsBehavior.Editable = false;
            this.gviewDetalles.OptionsCustomization.AllowSort = false;
            this.gviewDetalles.OptionsMenu.EnableColumnMenu = false;
            this.gviewDetalles.OptionsView.ShowGroupPanel = false;
            // 
            // gview_Clientes
            // 
            this.gview_Clientes.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_id_cliente,
            this.col_ruc_cliente,
            this.col_nombre_cliente,
            this.col_telefono,
            this.col_celular,
            this.col_direccion_cliente,
            this.col_correo_cliente});
            this.gview_Clientes.GridControl = this.gridClientes;
            this.gview_Clientes.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gview_Clientes.Name = "gview_Clientes";
            this.gview_Clientes.OptionsBehavior.Editable = false;
            this.gview_Clientes.OptionsBehavior.SmartVertScrollBar = false;
            this.gview_Clientes.OptionsMenu.EnableColumnMenu = false;
            this.gview_Clientes.OptionsPrint.ExpandAllDetails = true;
            this.gview_Clientes.OptionsPrint.PrintDetails = true;
            this.gview_Clientes.OptionsView.RowAutoHeight = true;
            this.gview_Clientes.OptionsView.ShowAutoFilterRow = true;
            this.gview_Clientes.OptionsView.ShowGroupPanel = false;
            this.gview_Clientes.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // col_id_cliente
            // 
            this.col_id_cliente.Caption = "id";
            this.col_id_cliente.FieldName = "id";
            this.col_id_cliente.Name = "col_id_cliente";
            // 
            // col_ruc_cliente
            // 
            this.col_ruc_cliente.Caption = "RUC";
            this.col_ruc_cliente.FieldName = "ruc";
            this.col_ruc_cliente.Name = "col_ruc_cliente";
            this.col_ruc_cliente.Visible = true;
            this.col_ruc_cliente.VisibleIndex = 0;
            // 
            // col_nombre_cliente
            // 
            this.col_nombre_cliente.Caption = "NOMBRE";
            this.col_nombre_cliente.FieldName = "nombre";
            this.col_nombre_cliente.Name = "col_nombre_cliente";
            this.col_nombre_cliente.Visible = true;
            this.col_nombre_cliente.VisibleIndex = 1;
            // 
            // col_telefono
            // 
            this.col_telefono.Caption = "TELEFONO";
            this.col_telefono.FieldName = "telefono";
            this.col_telefono.Name = "col_telefono";
            this.col_telefono.Visible = true;
            this.col_telefono.VisibleIndex = 2;
            // 
            // col_celular
            // 
            this.col_celular.Caption = "CELULAR";
            this.col_celular.FieldName = "celular";
            this.col_celular.Name = "col_celular";
            this.col_celular.Visible = true;
            this.col_celular.VisibleIndex = 3;
            // 
            // col_direccion_cliente
            // 
            this.col_direccion_cliente.Caption = "DIRECCION";
            this.col_direccion_cliente.ColumnEdit = this.repositoryItemMemoEdit1;
            this.col_direccion_cliente.FieldName = "direccion";
            this.col_direccion_cliente.Name = "col_direccion_cliente";
            this.col_direccion_cliente.Visible = true;
            this.col_direccion_cliente.VisibleIndex = 4;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // col_correo_cliente
            // 
            this.col_correo_cliente.Caption = "CORREO";
            this.col_correo_cliente.FieldName = "correo";
            this.col_correo_cliente.Name = "col_correo_cliente";
            this.col_correo_cliente.Visible = true;
            this.col_correo_cliente.VisibleIndex = 5;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.standaloneBarDockControl1);
            this.layoutControl1.Controls.Add(this.gridClientes);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(692, 504);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(12, 12);
            this.standaloneBarDockControl1.Manager = this.barManager1;
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(668, 24);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockControls.Add(this.standaloneBarDockControl1);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbi_actualizar,
            this.bbi_exportar_Excel});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 2;
            // 
            // bar2
            // 
            this.bar2.BarName = "Menú principal";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbi_actualizar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbi_exportar_Excel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.bar2.Text = "Menú principal";
            // 
            // bbi_actualizar
            // 
            this.bbi_actualizar.Caption = "ACTUALIZAR";
            this.bbi_actualizar.Id = 0;
            this.bbi_actualizar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbi_actualizar.ImageOptions.Image")));
            this.bbi_actualizar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbi_actualizar.ImageOptions.LargeImage")));
            this.bbi_actualizar.Name = "bbi_actualizar";
            this.bbi_actualizar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_actualizar_ItemClick);
            // 
            // bbi_exportar_Excel
            // 
            this.bbi_exportar_Excel.Caption = "EXPORTAR";
            this.bbi_exportar_Excel.Id = 1;
            this.bbi_exportar_Excel.ImageOptions.Image = global::Presentacion.Properties.Resources.excel_16;
            this.bbi_exportar_Excel.Name = "bbi_exportar_Excel";
            this.bbi_exportar_Excel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_exportar_Excel_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(692, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 504);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(692, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 504);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(692, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 504);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(692, 504);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridClientes;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(672, 456);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.standaloneBarDockControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(672, 28);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // xfrm_Historico_clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 504);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "xfrm_Historico_clientes";
            this.Text = "Historial de Clientes";
            this.Load += new System.EventHandler(this.xfrm_Historico_clientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gviewFacturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gviewDetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview_Clientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridClientes;
        private DevExpress.XtraGrid.Views.Grid.GridView gviewFacturas;
        private DevExpress.XtraGrid.Views.Grid.GridView gview_Clientes;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Views.Grid.GridView gviewDetalles;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn col_id_cliente_factura;
        private DevExpress.XtraGrid.Columns.GridColumn col_id_factura;
        private DevExpress.XtraGrid.Columns.GridColumn col_numero_factura;
        private DevExpress.XtraGrid.Columns.GridColumn col_fecha_factura;
        private DevExpress.XtraGrid.Columns.GridColumn col_total;
        private DevExpress.XtraGrid.Columns.GridColumn col_moneda_factura;
        private DevExpress.XtraGrid.Columns.GridColumn col_empleados;
        private DevExpress.XtraGrid.Columns.GridColumn col_id_cliente;
        private DevExpress.XtraGrid.Columns.GridColumn col_ruc_cliente;
        private DevExpress.XtraGrid.Columns.GridColumn col_nombre_cliente;
        private DevExpress.XtraGrid.Columns.GridColumn col_telefono;
        private DevExpress.XtraGrid.Columns.GridColumn col_celular;
        private DevExpress.XtraGrid.Columns.GridColumn col_direccion_cliente;
        private DevExpress.XtraGrid.Columns.GridColumn col_correo_cliente;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem bbi_actualizar;
        private DevExpress.XtraBars.BarButtonItem bbi_exportar_Excel;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}