namespace Presentacion.Formularios.CuentasCobrar
{
    partial class xfrm_CuentasCobrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xfrm_CuentasCobrar));
            this.radialMenu = new DevExpress.XtraBars.Ribbon.RadialMenu(this.components);
            this.bbi_ver_detalles = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbi_nuevo_documento = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbi_aplicar_documento = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.cbb_tipo_saldo = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.grid_detalles = new DevExpress.XtraGrid.GridControl();
            this.binding_Detalles = new System.Windows.Forms.BindingSource(this.components);
            this.gview_detalles_cliente = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grid_idcliente_detalles = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_tipo_doc_detalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_dias_detalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_estado_documento_detalles = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_fecha_documento_detalles = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_nombre_documento_detalles = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_numero_doc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_concepto_doc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_nombre_cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_codigo_cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_debe_Detalles = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_haber_detalles = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_saldo_detalles = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_fecha_vencimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_estatus_detalles = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_usuario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_cobrador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grid_personas = new DevExpress.XtraGrid.GridControl();
            this.binding_cuentasCobrar = new System.Windows.Forms.BindingSource(this.components);
            this.gview_personas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_id_clientePersonas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_nombreCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_tipo_documento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_debe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_haber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_saldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_saldo_vencido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gview_detalles = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.radialMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_detalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding_Detalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview_detalles_cliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_personas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding_cuentasCobrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview_personas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview_detalles)).BeginInit();
            this.SuspendLayout();
            // 
            // radialMenu
            // 
            this.radialMenu.AutoExpand = true;
            this.radialMenu.Glyph = global::Presentacion.Properties.Resources.menu_16;
            this.radialMenu.ItemAutoSize = DevExpress.XtraBars.Ribbon.RadialMenuItemAutoSize.Spring;
            this.radialMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbi_ver_detalles),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbi_nuevo_documento),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbi_aplicar_documento)});
            this.radialMenu.Manager = this.barManager1;
            this.radialMenu.MenuRadius = 140;
            this.radialMenu.Name = "radialMenu";
            // 
            // bbi_ver_detalles
            // 
            this.bbi_ver_detalles.Caption = "Documentos Pendientes";
            this.bbi_ver_detalles.CloseRadialMenuOnItemClick = true;
            this.bbi_ver_detalles.Id = 1;
            this.bbi_ver_detalles.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbi_ver_detalles.ImageOptions.Image")));
            this.bbi_ver_detalles.Name = "bbi_ver_detalles";
            this.bbi_ver_detalles.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbi_ver_detalles.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_ver_detalles_ItemClick);
            // 
            // bbi_nuevo_documento
            // 
            this.bbi_nuevo_documento.Caption = "Nuevo Documento";
            this.bbi_nuevo_documento.CloseRadialMenuOnItemClick = true;
            this.bbi_nuevo_documento.Id = 2;
            this.bbi_nuevo_documento.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbi_nuevo_documento.ImageOptions.Image")));
            this.bbi_nuevo_documento.Name = "bbi_nuevo_documento";
            this.bbi_nuevo_documento.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_nuevo_documento_ItemClick);
            // 
            // bbi_aplicar_documento
            // 
            this.bbi_aplicar_documento.Caption = "Estado de Cuenta";
            this.bbi_aplicar_documento.CloseRadialMenuOnItemClick = true;
            this.bbi_aplicar_documento.Id = 3;
            this.bbi_aplicar_documento.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbi_aplicar_documento.ImageOptions.Image")));
            this.bbi_aplicar_documento.Name = "bbi_aplicar_documento";
            this.bbi_aplicar_documento.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_aplicar_documento_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockManager = this.dockManager1;
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.bbi_ver_detalles,
            this.bbi_nuevo_documento,
            this.bbi_aplicar_documento,
            this.cbb_tipo_saldo});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 6;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemComboBox1});
            // 
            // bar2
            // 
            this.bar2.BarName = "Menú principal";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.cbb_tipo_saldo, "", false, true, true, 141)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menú principal";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Menu";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.ImageOptions.Image = global::Presentacion.Properties.Resources.menu_16;
            this.barButtonItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // cbb_tipo_saldo
            // 
            this.cbb_tipo_saldo.Edit = this.repositoryItemComboBox1;
            this.cbb_tipo_saldo.Id = 5;
            this.cbb_tipo_saldo.Name = "cbb_tipo_saldo";
            this.cbb_tipo_saldo.EditValueChanged += new System.EventHandler(this.cbb_tipo_saldo_EditValueChanged);
            this.cbb_tipo_saldo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.cbb_tipo_saldo_ItemClick);
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.DropDownRows = 3;
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "TODOS",
            "CON SALDO VENCIDO",
            "SIN SALDO VENCIDO"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.repositoryItemComboBox1.EditValueChanged += new System.EventHandler(this.repositoryItemComboBox1_EditValueChanged);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(784, 24);
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
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 537);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(784, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 537);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.MenuManager = this.barManager1;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockPanel1.ID = new System.Guid("22ea1f6e-0fb1-4409-ac56-4918de6dc0b2");
            this.dockPanel1.Location = new System.Drawing.Point(0, 267);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 294);
            this.dockPanel1.Size = new System.Drawing.Size(784, 294);
            this.dockPanel1.Text = "Detalles";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.grid_detalles);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 27);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(778, 264);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // grid_detalles
            // 
            this.grid_detalles.DataSource = this.binding_Detalles;
            this.grid_detalles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_detalles.Location = new System.Drawing.Point(0, 0);
            this.grid_detalles.MainView = this.gview_detalles_cliente;
            this.grid_detalles.MenuManager = this.barManager1;
            this.grid_detalles.Name = "grid_detalles";
            this.grid_detalles.Size = new System.Drawing.Size(778, 264);
            this.grid_detalles.TabIndex = 0;
            this.grid_detalles.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gview_detalles_cliente});
            // 
            // gview_detalles_cliente
            // 
            this.gview_detalles_cliente.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grid_idcliente_detalles,
            this.col_tipo_doc_detalle,
            this.col_dias_detalle,
            this.col_estado_documento_detalles,
            this.col_fecha_documento_detalles,
            this.col_nombre_documento_detalles,
            this.col_numero_doc,
            this.col_concepto_doc,
            this.col_nombre_cliente,
            this.col_codigo_cliente,
            this.col_debe_Detalles,
            this.col_haber_detalles,
            this.col_saldo_detalles,
            this.col_fecha_vencimiento,
            this.col_estatus_detalles,
            this.col_usuario,
            this.col_cobrador});
            this.gview_detalles_cliente.CustomizationFormBounds = new System.Drawing.Rectangle(248, 545, 210, 172);
            this.gview_detalles_cliente.GridControl = this.grid_detalles;
            this.gview_detalles_cliente.GroupCount = 1;
            this.gview_detalles_cliente.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "saldo", null, "Saldo Vencido = {0:n2}", 1),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "saldo", null, "Pendiente ={0:n2}", 2),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "haber", null, "Cancelado ={0:n2}", 3)});
            this.gview_detalles_cliente.Name = "gview_detalles_cliente";
            this.gview_detalles_cliente.OptionsBehavior.AutoExpandAllGroups = true;
            this.gview_detalles_cliente.OptionsMenu.EnableFooterMenu = false;
            this.gview_detalles_cliente.OptionsMenu.EnableGroupPanelMenu = false;
            this.gview_detalles_cliente.OptionsView.ShowFooter = true;
            this.gview_detalles_cliente.OptionsView.ShowGroupPanelColumnsAsSingleRow = true;
            this.gview_detalles_cliente.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.col_nombre_cliente, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gview_detalles_cliente.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gview_detalles_cliente_RowStyle);
            this.gview_detalles_cliente.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.gview_detalles_cliente_CustomSummaryCalculate);
            // 
            // grid_idcliente_detalles
            // 
            this.grid_idcliente_detalles.Caption = "id_cliente";
            this.grid_idcliente_detalles.FieldName = "id_cliente";
            this.grid_idcliente_detalles.Name = "grid_idcliente_detalles";
            this.grid_idcliente_detalles.OptionsColumn.AllowEdit = false;
            this.grid_idcliente_detalles.OptionsColumn.AllowShowHide = false;
            this.grid_idcliente_detalles.OptionsColumn.ShowInCustomizationForm = false;
            this.grid_idcliente_detalles.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // col_tipo_doc_detalle
            // 
            this.col_tipo_doc_detalle.Caption = "tipo_doc";
            this.col_tipo_doc_detalle.FieldName = "tipo_documento";
            this.col_tipo_doc_detalle.Name = "col_tipo_doc_detalle";
            this.col_tipo_doc_detalle.OptionsColumn.AllowEdit = false;
            this.col_tipo_doc_detalle.OptionsColumn.AllowShowHide = false;
            this.col_tipo_doc_detalle.OptionsColumn.ShowInCustomizationForm = false;
            this.col_tipo_doc_detalle.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // col_dias_detalle
            // 
            this.col_dias_detalle.Caption = "DIAS";
            this.col_dias_detalle.FieldName = "dias";
            this.col_dias_detalle.Name = "col_dias_detalle";
            this.col_dias_detalle.OptionsColumn.AllowEdit = false;
            this.col_dias_detalle.Visible = true;
            this.col_dias_detalle.VisibleIndex = 8;
            this.col_dias_detalle.Width = 76;
            // 
            // col_estado_documento_detalles
            // 
            this.col_estado_documento_detalles.Caption = "estado_doc";
            this.col_estado_documento_detalles.FieldName = "estado_documento";
            this.col_estado_documento_detalles.Name = "col_estado_documento_detalles";
            this.col_estado_documento_detalles.OptionsColumn.AllowEdit = false;
            this.col_estado_documento_detalles.OptionsColumn.AllowShowHide = false;
            this.col_estado_documento_detalles.OptionsColumn.ShowInCustomizationForm = false;
            this.col_estado_documento_detalles.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // col_fecha_documento_detalles
            // 
            this.col_fecha_documento_detalles.Caption = "FECHA";
            this.col_fecha_documento_detalles.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.col_fecha_documento_detalles.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_fecha_documento_detalles.FieldName = "fecha_documento";
            this.col_fecha_documento_detalles.Name = "col_fecha_documento_detalles";
            this.col_fecha_documento_detalles.OptionsColumn.AllowEdit = false;
            this.col_fecha_documento_detalles.Visible = true;
            this.col_fecha_documento_detalles.VisibleIndex = 2;
            this.col_fecha_documento_detalles.Width = 88;
            // 
            // col_nombre_documento_detalles
            // 
            this.col_nombre_documento_detalles.Caption = "TIPO DOCUMENTO";
            this.col_nombre_documento_detalles.FieldName = "nombre_documento";
            this.col_nombre_documento_detalles.Name = "col_nombre_documento_detalles";
            this.col_nombre_documento_detalles.OptionsColumn.AllowEdit = false;
            this.col_nombre_documento_detalles.Visible = true;
            this.col_nombre_documento_detalles.VisibleIndex = 0;
            this.col_nombre_documento_detalles.Width = 81;
            // 
            // col_numero_doc
            // 
            this.col_numero_doc.Caption = "NUMERO DOC";
            this.col_numero_doc.FieldName = "numero_doc";
            this.col_numero_doc.Name = "col_numero_doc";
            this.col_numero_doc.OptionsColumn.AllowEdit = false;
            this.col_numero_doc.Visible = true;
            this.col_numero_doc.VisibleIndex = 3;
            this.col_numero_doc.Width = 64;
            // 
            // col_concepto_doc
            // 
            this.col_concepto_doc.Caption = "CONCEPTO";
            this.col_concepto_doc.FieldName = "concepto";
            this.col_concepto_doc.Name = "col_concepto_doc";
            this.col_concepto_doc.OptionsColumn.AllowEdit = false;
            this.col_concepto_doc.Visible = true;
            this.col_concepto_doc.VisibleIndex = 4;
            this.col_concepto_doc.Width = 98;
            // 
            // col_nombre_cliente
            // 
            this.col_nombre_cliente.Caption = "CLIENTE";
            this.col_nombre_cliente.FieldName = "nombre";
            this.col_nombre_cliente.Name = "col_nombre_cliente";
            this.col_nombre_cliente.OptionsColumn.AllowEdit = false;
            this.col_nombre_cliente.Visible = true;
            this.col_nombre_cliente.VisibleIndex = 5;
            // 
            // col_codigo_cliente
            // 
            this.col_codigo_cliente.Caption = "CODIGO CLIENTE";
            this.col_codigo_cliente.FieldName = "codigo_cliente";
            this.col_codigo_cliente.Name = "col_codigo_cliente";
            this.col_codigo_cliente.OptionsColumn.AllowEdit = false;
            this.col_codigo_cliente.Visible = true;
            this.col_codigo_cliente.VisibleIndex = 1;
            this.col_codigo_cliente.Width = 64;
            // 
            // col_debe_Detalles
            // 
            this.col_debe_Detalles.Caption = "DEBE";
            this.col_debe_Detalles.DisplayFormat.FormatString = "n2";
            this.col_debe_Detalles.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_debe_Detalles.FieldName = "debe";
            this.col_debe_Detalles.Name = "col_debe_Detalles";
            this.col_debe_Detalles.OptionsColumn.AllowEdit = false;
            this.col_debe_Detalles.OptionsColumn.AllowMove = false;
            this.col_debe_Detalles.Visible = true;
            this.col_debe_Detalles.VisibleIndex = 5;
            this.col_debe_Detalles.Width = 64;
            // 
            // col_haber_detalles
            // 
            this.col_haber_detalles.Caption = "HABER";
            this.col_haber_detalles.DisplayFormat.FormatString = "n2";
            this.col_haber_detalles.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_haber_detalles.FieldName = "haber";
            this.col_haber_detalles.Name = "col_haber_detalles";
            this.col_haber_detalles.OptionsColumn.AllowEdit = false;
            this.col_haber_detalles.OptionsColumn.AllowMove = false;
            this.col_haber_detalles.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "haber", "VENCIDO", ((short)(1))),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "haber", "PENDIENTE", "2"),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "haber", "CANCELADO", "3")});
            this.col_haber_detalles.Visible = true;
            this.col_haber_detalles.VisibleIndex = 6;
            this.col_haber_detalles.Width = 96;
            // 
            // col_saldo_detalles
            // 
            this.col_saldo_detalles.Caption = "SALDO";
            this.col_saldo_detalles.DisplayFormat.FormatString = "n2";
            this.col_saldo_detalles.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_saldo_detalles.FieldName = "saldo";
            this.col_saldo_detalles.Name = "col_saldo_detalles";
            this.col_saldo_detalles.OptionsColumn.AllowEdit = false;
            this.col_saldo_detalles.OptionsColumn.AllowMove = false;
            this.col_saldo_detalles.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "saldo", "{0:n2}", "1"),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "saldo", "{0:n2}", 2),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "haber", "{0:n2}", "3")});
            this.col_saldo_detalles.Visible = true;
            this.col_saldo_detalles.VisibleIndex = 7;
            this.col_saldo_detalles.Width = 106;
            // 
            // col_fecha_vencimiento
            // 
            this.col_fecha_vencimiento.Caption = "FECHA VENCIMIENTO";
            this.col_fecha_vencimiento.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.col_fecha_vencimiento.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_fecha_vencimiento.FieldName = "fecha_vencimiento";
            this.col_fecha_vencimiento.Name = "col_fecha_vencimiento";
            this.col_fecha_vencimiento.OptionsColumn.AllowEdit = false;
            this.col_fecha_vencimiento.Visible = true;
            this.col_fecha_vencimiento.VisibleIndex = 9;
            this.col_fecha_vencimiento.Width = 108;
            // 
            // col_estatus_detalles
            // 
            this.col_estatus_detalles.Caption = "ESTADO DOC";
            this.col_estatus_detalles.FieldName = "estatus_documento";
            this.col_estatus_detalles.Name = "col_estatus_detalles";
            this.col_estatus_detalles.OptionsColumn.AllowEdit = false;
            this.col_estatus_detalles.Visible = true;
            this.col_estatus_detalles.VisibleIndex = 10;
            this.col_estatus_detalles.Width = 77;
            // 
            // col_usuario
            // 
            this.col_usuario.Caption = "USUARIO";
            this.col_usuario.FieldName = "usuario";
            this.col_usuario.Name = "col_usuario";
            this.col_usuario.OptionsColumn.AllowEdit = false;
            // 
            // col_cobrador
            // 
            this.col_cobrador.Caption = "COBRADOR";
            this.col_cobrador.FieldName = "Cobrador";
            this.col_cobrador.Name = "col_cobrador";
            this.col_cobrador.OptionsColumn.AllowEdit = false;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.DropDownRows = 3;
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // grid_personas
            // 
            this.grid_personas.DataSource = this.binding_cuentasCobrar;
            this.grid_personas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_personas.Location = new System.Drawing.Point(0, 24);
            this.grid_personas.MainView = this.gview_personas;
            this.grid_personas.MenuManager = this.barManager1;
            this.grid_personas.Name = "grid_personas";
            this.grid_personas.Size = new System.Drawing.Size(784, 243);
            this.grid_personas.TabIndex = 6;
            this.grid_personas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gview_personas,
            this.gview_detalles});
            // 
            // gview_personas
            // 
            this.gview_personas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_id_clientePersonas,
            this.col_nombreCliente,
            this.col_tipo_documento,
            this.col_debe,
            this.col_haber,
            this.col_saldo,
            this.col_saldo_vencido});
            this.gview_personas.GridControl = this.grid_personas;
            this.gview_personas.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "debe", this.col_debe, "n2"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "haber", this.col_haber, "n2"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "saldo", this.col_saldo, "n2"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "saldo_vencido", null, "n2")});
            this.gview_personas.Name = "gview_personas";
            this.gview_personas.OptionsMenu.EnableFooterMenu = false;
            this.gview_personas.OptionsMenu.ShowFooterItem = true;
            this.gview_personas.OptionsNavigation.AutoFocusNewRow = true;
            this.gview_personas.OptionsNavigation.EnterMoveNextColumn = true;
            this.gview_personas.OptionsView.ShowAutoFilterRow = true;
            this.gview_personas.OptionsView.ShowFooter = true;
            this.gview_personas.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gview_personas_RowStyle);
            this.gview_personas.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gview_personas_FocusedRowChanged);
            this.gview_personas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gview_personas_MouseUp);
            // 
            // col_id_clientePersonas
            // 
            this.col_id_clientePersonas.Caption = "idCliente";
            this.col_id_clientePersonas.FieldName = "id_cliente";
            this.col_id_clientePersonas.Name = "col_id_clientePersonas";
            this.col_id_clientePersonas.OptionsColumn.AllowEdit = false;
            this.col_id_clientePersonas.OptionsColumn.ShowInCustomizationForm = false;
            this.col_id_clientePersonas.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // col_nombreCliente
            // 
            this.col_nombreCliente.Caption = "NOMBRE CLIENTE";
            this.col_nombreCliente.FieldName = "nombre_cliente";
            this.col_nombreCliente.Name = "col_nombreCliente";
            this.col_nombreCliente.OptionsColumn.AllowEdit = false;
            this.col_nombreCliente.OptionsColumn.AllowShowHide = false;
            this.col_nombreCliente.OptionsColumn.FixedWidth = true;
            this.col_nombreCliente.Visible = true;
            this.col_nombreCliente.VisibleIndex = 0;
            this.col_nombreCliente.Width = 150;
            // 
            // col_tipo_documento
            // 
            this.col_tipo_documento.Caption = "DOCUMENTOS";
            this.col_tipo_documento.FieldName = "nombre_documento";
            this.col_tipo_documento.Name = "col_tipo_documento";
            this.col_tipo_documento.OptionsColumn.AllowEdit = false;
            this.col_tipo_documento.OptionsColumn.AllowShowHide = false;
            this.col_tipo_documento.OptionsColumn.FixedWidth = true;
            this.col_tipo_documento.Visible = true;
            this.col_tipo_documento.VisibleIndex = 1;
            this.col_tipo_documento.Width = 151;
            // 
            // col_debe
            // 
            this.col_debe.Caption = "DEBE";
            this.col_debe.FieldName = "debe";
            this.col_debe.Name = "col_debe";
            this.col_debe.OptionsColumn.AllowEdit = false;
            this.col_debe.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.col_debe.OptionsColumn.AllowShowHide = false;
            this.col_debe.OptionsColumn.FixedWidth = true;
            this.col_debe.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "debe", "{0:n2}")});
            this.col_debe.Visible = true;
            this.col_debe.VisibleIndex = 2;
            this.col_debe.Width = 118;
            // 
            // col_haber
            // 
            this.col_haber.Caption = "HABER";
            this.col_haber.FieldName = "haber";
            this.col_haber.Name = "col_haber";
            this.col_haber.OptionsColumn.AllowEdit = false;
            this.col_haber.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.col_haber.OptionsColumn.AllowShowHide = false;
            this.col_haber.OptionsColumn.FixedWidth = true;
            this.col_haber.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "haber", "{0:n2}")});
            this.col_haber.Visible = true;
            this.col_haber.VisibleIndex = 3;
            this.col_haber.Width = 87;
            // 
            // col_saldo
            // 
            this.col_saldo.Caption = "SALDO";
            this.col_saldo.FieldName = "saldo";
            this.col_saldo.Name = "col_saldo";
            this.col_saldo.OptionsColumn.AllowEdit = false;
            this.col_saldo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.col_saldo.OptionsColumn.AllowShowHide = false;
            this.col_saldo.OptionsColumn.FixedWidth = true;
            this.col_saldo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "saldo", "{0:n2}")});
            this.col_saldo.Visible = true;
            this.col_saldo.VisibleIndex = 4;
            this.col_saldo.Width = 76;
            // 
            // col_saldo_vencido
            // 
            this.col_saldo_vencido.Caption = "SALDO VENCIDO";
            this.col_saldo_vencido.FieldName = "saldo_vencido";
            this.col_saldo_vencido.Name = "col_saldo_vencido";
            this.col_saldo_vencido.OptionsColumn.AllowEdit = false;
            this.col_saldo_vencido.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.col_saldo_vencido.OptionsColumn.AllowShowHide = false;
            this.col_saldo_vencido.OptionsColumn.FixedWidth = true;
            this.col_saldo_vencido.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "saldo_vencido", "{0:n2}")});
            this.col_saldo_vencido.Visible = true;
            this.col_saldo_vencido.VisibleIndex = 5;
            // 
            // gview_detalles
            // 
            this.gview_detalles.GridControl = this.grid_personas;
            this.gview_detalles.Name = "gview_detalles";
            // 
            // xfrm_CuentasCobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.grid_personas);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("xfrm_CuentasCobrar.IconOptions.Icon")));
            this.Name = "xfrm_CuentasCobrar";
            this.Text = "CUENTAS POR COBRAR CORDOBAS";
            this.Activated += new System.EventHandler(this.xfrm_CuentasCobrar_Activated);
            this.Load += new System.EventHandler(this.xfrm_CuentasCobrar_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.xfrm_CuentasCobrar_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.radialMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_detalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding_Detalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview_detalles_cliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_personas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding_cuentasCobrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview_personas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview_detalles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RadialMenu radialMenu;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraGrid.GridControl grid_personas;
        private DevExpress.XtraGrid.Views.Grid.GridView gview_personas;
        private DevExpress.XtraGrid.Columns.GridColumn col_id_clientePersonas;
        private DevExpress.XtraGrid.Columns.GridColumn col_nombreCliente;
        private DevExpress.XtraGrid.Columns.GridColumn col_tipo_documento;
        private DevExpress.XtraGrid.Columns.GridColumn col_debe;
        private DevExpress.XtraGrid.Columns.GridColumn col_haber;
        private DevExpress.XtraGrid.Columns.GridColumn col_saldo;
        private DevExpress.XtraGrid.Columns.GridColumn col_saldo_vencido;
        private DevExpress.XtraGrid.Views.Grid.GridView gview_detalles;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.BarLargeButtonItem bbi_ver_detalles;
        private DevExpress.XtraBars.BarLargeButtonItem bbi_nuevo_documento;
        private DevExpress.XtraBars.BarLargeButtonItem bbi_aplicar_documento;
        private DevExpress.XtraGrid.GridControl grid_detalles;
        private DevExpress.XtraGrid.Views.Grid.GridView gview_detalles_cliente;
        private DevExpress.XtraGrid.Columns.GridColumn grid_idcliente_detalles;
        private DevExpress.XtraGrid.Columns.GridColumn col_tipo_doc_detalle;
        private DevExpress.XtraGrid.Columns.GridColumn col_dias_detalle;
        private DevExpress.XtraGrid.Columns.GridColumn col_estado_documento_detalles;
        private DevExpress.XtraGrid.Columns.GridColumn col_fecha_documento_detalles;
        private DevExpress.XtraGrid.Columns.GridColumn col_nombre_documento_detalles;
        private DevExpress.XtraGrid.Columns.GridColumn col_numero_doc;
        private DevExpress.XtraGrid.Columns.GridColumn col_concepto_doc;
        private DevExpress.XtraGrid.Columns.GridColumn col_nombre_cliente;
        private DevExpress.XtraGrid.Columns.GridColumn col_codigo_cliente;
        private DevExpress.XtraGrid.Columns.GridColumn col_debe_Detalles;
        private DevExpress.XtraGrid.Columns.GridColumn col_haber_detalles;
        private DevExpress.XtraGrid.Columns.GridColumn col_saldo_detalles;
        private DevExpress.XtraGrid.Columns.GridColumn col_fecha_vencimiento;
        private DevExpress.XtraGrid.Columns.GridColumn col_estatus_detalles;
        private DevExpress.XtraGrid.Columns.GridColumn col_usuario;
        private DevExpress.XtraGrid.Columns.GridColumn col_cobrador;
        private System.Windows.Forms.BindingSource binding_cuentasCobrar;
        private System.Windows.Forms.BindingSource binding_Detalles;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraBars.BarEditItem cbb_tipo_saldo;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
    }
}