namespace Presentacion.Formularios.Compras
{
    partial class xfrm_MostrarCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xfrm_MostrarCompra));
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions1 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions2 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            this.gridCompras = new DevExpress.XtraGrid.GridControl();
            this.bindingSourceCompras = new System.Windows.Forms.BindingSource(this.components);
            this.viewCompras = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_Estado = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.radialMenu1 = new DevExpress.XtraBars.Ribbon.RadialMenu(this.components);
            this.bbiVerOrden = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiImprimir = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiEliminarCompra = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiRecibirProducto = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiDuplicarCompra = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbiEditarCompra = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.lbl_fecha_inicio = new DevExpress.XtraBars.BarStaticItem();
            this.bbi_FechaInicio = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.bbi_FechaFin = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bbi_fecha_inicio = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.flyoutPanel1 = new DevExpress.Utils.FlyoutPanel();
            this.flyoutPanelControl1 = new DevExpress.Utils.FlyoutPanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.flyoutPanel2 = new DevExpress.Utils.FlyoutPanel();
            this.flyoutPanelControl2 = new DevExpress.Utils.FlyoutPanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridCompras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCompras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewCompras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Estado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radialMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel1)).BeginInit();
            this.flyoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl1)).BeginInit();
            this.flyoutPanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel2)).BeginInit();
            this.flyoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridCompras
            // 
            this.gridCompras.DataSource = this.bindingSourceCompras;
            this.gridCompras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCompras.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridCompras.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridCompras.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridCompras.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridCompras.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridCompras.Location = new System.Drawing.Point(0, 24);
            this.gridCompras.MainView = this.viewCompras;
            this.gridCompras.Name = "gridCompras";
            this.gridCompras.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit_Estado});
            this.gridCompras.Size = new System.Drawing.Size(784, 537);
            this.gridCompras.TabIndex = 0;
            this.gridCompras.UseEmbeddedNavigator = true;
            this.gridCompras.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewCompras});
            // 
            // viewCompras
            // 
            this.viewCompras.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.viewCompras.Appearance.FooterPanel.Options.UseFont = true;
            this.viewCompras.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewCompras.Appearance.GroupRow.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.viewCompras.Appearance.GroupRow.Options.UseFont = true;
            this.viewCompras.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.viewCompras.Appearance.Row.Options.UseFont = true;
            this.viewCompras.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.viewCompras.GridControl = this.gridCompras;
            this.viewCompras.GroupCount = 1;
            this.viewCompras.Name = "viewCompras";
            this.viewCompras.OptionsBehavior.AutoExpandAllGroups = true;
            this.viewCompras.OptionsBehavior.Editable = false;
            this.viewCompras.OptionsFind.AlwaysVisible = true;
            this.viewCompras.OptionsMenu.EnableColumnMenu = false;
            this.viewCompras.OptionsView.EnableAppearanceEvenRow = true;
            this.viewCompras.OptionsView.ShowAutoFilterRow = true;
            this.viewCompras.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn8, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.viewCompras.MouseUp += new System.Windows.Forms.MouseEventHandler(this.viewCompras_MouseUp);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "id";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Nº";
            this.gridColumn2.FieldName = "numero";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "FECHA";
            this.gridColumn3.FieldName = "fecha";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "PROVEEDOR";
            this.gridColumn4.FieldName = "nombre";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Nº FACTURA";
            this.gridColumn5.FieldName = "numero_factura";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "TOTAL";
            this.gridColumn6.DisplayFormat.FormatString = "n2";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "total";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "FECHA ESTIMADA";
            this.gridColumn7.FieldName = "fecha_estimada";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "ESTADO";
            this.gridColumn8.ColumnEdit = this.repositoryItemLookUpEdit_Estado;
            this.gridColumn8.FieldName = "estado";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            // 
            // repositoryItemLookUpEdit_Estado
            // 
            this.repositoryItemLookUpEdit_Estado.AutoHeight = false;
            this.repositoryItemLookUpEdit_Estado.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_Estado.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("estado", "ESTADO", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("descripcion", "ESTADO")});
            this.repositoryItemLookUpEdit_Estado.DisplayMember = "descripcion";
            this.repositoryItemLookUpEdit_Estado.Name = "repositoryItemLookUpEdit_Estado";
            this.repositoryItemLookUpEdit_Estado.ValueMember = "estado";
            // 
            // radialMenu1
            // 
            this.radialMenu1.AutoExpand = true;
            this.radialMenu1.Glyph = global::Presentacion.Properties.Resources.menu_16;
            this.radialMenu1.ItemAutoSize = DevExpress.XtraBars.Ribbon.RadialMenuItemAutoSize.Spring;
            this.radialMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiVerOrden),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiImprimir),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiEliminarCompra),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiRecibirProducto),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiDuplicarCompra),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiEditarCompra)});
            this.radialMenu1.Manager = this.barManager1;
            this.radialMenu1.Name = "radialMenu1";
            this.radialMenu1.Popup += new System.EventHandler(this.radialMenu1_Popup);
            // 
            // bbiVerOrden
            // 
            this.bbiVerOrden.Caption = "Ver Compra";
            this.bbiVerOrden.Id = 0;
            this.bbiVerOrden.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiVerOrden.ImageOptions.Image")));
            this.bbiVerOrden.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiVerOrden.ImageOptions.LargeImage")));
            this.bbiVerOrden.Name = "bbiVerOrden";
            this.bbiVerOrden.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiVerOrden_ItemClick);
            // 
            // bbiImprimir
            // 
            this.bbiImprimir.Caption = "Imprimir";
            this.bbiImprimir.Id = 1;
            this.bbiImprimir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiImprimir.ImageOptions.Image")));
            this.bbiImprimir.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiImprimir.ImageOptions.LargeImage")));
            this.bbiImprimir.Name = "bbiImprimir";
            this.bbiImprimir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiImprimir_ItemClick);
            // 
            // bbiEliminarCompra
            // 
            this.bbiEliminarCompra.Caption = "Eliminar Compra";
            this.bbiEliminarCompra.Id = 2;
            this.bbiEliminarCompra.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiEliminarCompra.ImageOptions.Image")));
            this.bbiEliminarCompra.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiEliminarCompra.ImageOptions.LargeImage")));
            this.bbiEliminarCompra.Name = "bbiEliminarCompra";
            this.bbiEliminarCompra.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEliminarCompra_ItemClick);
            // 
            // bbiRecibirProducto
            // 
            this.bbiRecibirProducto.Caption = "Recibir Producto";
            this.bbiRecibirProducto.Id = 3;
            this.bbiRecibirProducto.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiRecibirProducto.ImageOptions.Image")));
            this.bbiRecibirProducto.Name = "bbiRecibirProducto";
            this.bbiRecibirProducto.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRecibirProducto_ItemClick);
            // 
            // bbiDuplicarCompra
            // 
            this.bbiDuplicarCompra.Caption = "Duplicar Orden";
            this.bbiDuplicarCompra.Id = 4;
            this.bbiDuplicarCompra.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiDuplicarCompra.ImageOptions.Image")));
            this.bbiDuplicarCompra.Name = "bbiDuplicarCompra";
            this.bbiDuplicarCompra.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDuplicarCompra_ItemClick);
            // 
            // bbiEditarCompra
            // 
            this.bbiEditarCompra.Caption = "Editar Compra";
            this.bbiEditarCompra.Id = 5;
            this.bbiEditarCompra.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiEditarCompra.ImageOptions.Image")));
            this.bbiEditarCompra.Name = "bbiEditarCompra";
            this.bbiEditarCompra.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEditarCompra_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiVerOrden,
            this.bbiImprimir,
            this.bbiEliminarCompra,
            this.bbiRecibirProducto,
            this.bbiDuplicarCompra,
            this.bbiEditarCompra,
            this.bbi_fecha_inicio,
            this.lbl_fecha_inicio,
            this.bbi_FechaInicio,
            this.barStaticItem1,
            this.bbi_FechaFin,
            this.barButtonItem1});
            this.barManager1.MaxItemId = 12;
            this.barManager1.OptionsLayout.AllowAddNewItems = false;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemDateEdit2,
            this.repositoryItemDateEdit3});
            // 
            // bar1
            // 
            this.bar1.BarName = "Personalizada 2";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lbl_fecha_inicio),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.bbi_FechaInicio, "", false, true, true, 118),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.bbi_FechaFin, "", false, true, true, 131),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.Text = "Personalizada 2";
            // 
            // lbl_fecha_inicio
            // 
            this.lbl_fecha_inicio.Caption = "Fecha Inicio:";
            this.lbl_fecha_inicio.Id = 7;
            this.lbl_fecha_inicio.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_fecha_inicio.ItemAppearance.Normal.Options.UseFont = true;
            this.lbl_fecha_inicio.Name = "lbl_fecha_inicio";
            // 
            // bbi_FechaInicio
            // 
            this.bbi_FechaInicio.Edit = this.repositoryItemDateEdit2;
            this.bbi_FechaInicio.Id = 8;
            this.bbi_FechaInicio.Name = "bbi_FechaInicio";
            this.bbi_FechaInicio.Size = new System.Drawing.Size(125, 0);
            // 
            // repositoryItemDateEdit2
            // 
            this.repositoryItemDateEdit2.AutoHeight = false;
            this.repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "Fecha Fin:";
            this.barStaticItem1.Id = 9;
            this.barStaticItem1.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.barStaticItem1.ItemAppearance.Normal.Options.UseFont = true;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // bbi_FechaFin
            // 
            this.bbi_FechaFin.Edit = this.repositoryItemDateEdit3;
            this.bbi_FechaFin.Id = 10;
            this.bbi_FechaFin.Name = "bbi_FechaFin";
            this.bbi_FechaFin.Size = new System.Drawing.Size(125, 0);
            // 
            // repositoryItemDateEdit3
            // 
            this.repositoryItemDateEdit3.AutoHeight = false;
            this.repositoryItemDateEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit3.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit3.Name = "repositoryItemDateEdit3";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "CARGAR";
            this.barButtonItem1.Id = 11;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.barButtonItem1.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
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
            // bbi_fecha_inicio
            // 
            this.bbi_fecha_inicio.AutoFillWidth = true;
            this.bbi_fecha_inicio.Caption = "Fecha Inicio:";
            this.bbi_fecha_inicio.Edit = this.repositoryItemDateEdit1;
            this.bbi_fecha_inicio.Id = 6;
            this.bbi_fecha_inicio.Name = "bbi_fecha_inicio";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // flyoutPanel1
            // 
            this.flyoutPanel1.Controls.Add(this.flyoutPanelControl1);
            this.flyoutPanel1.Location = new System.Drawing.Point(29, 343);
            this.flyoutPanel1.Name = "flyoutPanel1";
            this.flyoutPanel1.Options.CloseOnOuterClick = true;
            this.flyoutPanel1.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Top;
            this.flyoutPanel1.OptionsButtonPanel.ButtonPanelContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.flyoutPanel1.OptionsButtonPanel.ButtonPanelHeight = 40;
            this.flyoutPanel1.OptionsButtonPanel.ButtonPanelLocation = DevExpress.Utils.FlyoutPanelButtonPanelLocation.Bottom;
            buttonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions1.Image")));
            buttonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions2.Image")));
            this.flyoutPanel1.OptionsButtonPanel.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.Utils.PeekFormButton("ACEPTAR", true, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, "aceptar", -1, false),
            new DevExpress.Utils.PeekFormButton("CANCELAR", true, buttonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, "cancelar", -1, false)});
            this.flyoutPanel1.OptionsButtonPanel.ShowButtonPanel = true;
            this.flyoutPanel1.OwnerControl = this.barDockControlTop;
            this.flyoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 40);
            this.flyoutPanel1.Size = new System.Drawing.Size(274, 74);
            this.flyoutPanel1.TabIndex = 6;
            this.flyoutPanel1.ButtonClick += new DevExpress.Utils.FlyoutPanelButtonClickEventHandler(this.flyoutPanel1_ButtonClick);
            // 
            // flyoutPanelControl1
            // 
            this.flyoutPanelControl1.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.flyoutPanelControl1.Controls.Add(this.labelControl1);
            this.flyoutPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flyoutPanelControl1.FlyoutPanel = this.flyoutPanel1;
            this.flyoutPanelControl1.Location = new System.Drawing.Point(0, 0);
            this.flyoutPanelControl1.Name = "flyoutPanelControl1";
            this.flyoutPanelControl1.Size = new System.Drawing.Size(274, 34);
            this.flyoutPanelControl1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(16, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(243, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "¿ Eliminar la Compra  [Nº 999] ?";
            // 
            // flyoutPanel2
            // 
            this.flyoutPanel2.Controls.Add(this.flyoutPanelControl2);
            this.flyoutPanel2.Location = new System.Drawing.Point(12, 506);
            this.flyoutPanel2.Name = "flyoutPanel2";
            this.flyoutPanel2.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Bottom;
            this.flyoutPanel2.Options.CloseOnOuterClick = true;
            this.flyoutPanel2.OwnerControl = this;
            this.flyoutPanel2.Size = new System.Drawing.Size(334, 43);
            this.flyoutPanel2.TabIndex = 7;
            // 
            // flyoutPanelControl2
            // 
            this.flyoutPanelControl2.ContentImage = ((System.Drawing.Image)(resources.GetObject("flyoutPanelControl2.ContentImage")));
            this.flyoutPanelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flyoutPanelControl2.FlyoutPanel = this.flyoutPanel2;
            this.flyoutPanelControl2.Location = new System.Drawing.Point(0, 0);
            this.flyoutPanelControl2.Name = "flyoutPanelControl2";
            this.flyoutPanelControl2.Size = new System.Drawing.Size(334, 43);
            this.flyoutPanelControl2.TabIndex = 0;
            // 
            // xfrm_MostrarCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.flyoutPanel2);
            this.Controls.Add(this.flyoutPanel1);
            this.Controls.Add(this.gridCompras);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "xfrm_MostrarCompra";
            this.Text = "ORDENES DE COMPRA";
            this.Activated += new System.EventHandler(this.xfrm_MostrarCompra_Activated);
            this.Load += new System.EventHandler(this.xfrm_MostrarCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridCompras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCompras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewCompras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Estado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radialMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel1)).EndInit();
            this.flyoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl1)).EndInit();
            this.flyoutPanelControl1.ResumeLayout(false);
            this.flyoutPanelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel2)).EndInit();
            this.flyoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridCompras;
        private DevExpress.XtraGrid.Views.Grid.GridView viewCompras;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_Estado;
        private System.Windows.Forms.BindingSource bindingSourceCompras;
        private DevExpress.XtraBars.Ribbon.RadialMenu radialMenu1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarLargeButtonItem bbiVerOrden;
        private DevExpress.XtraBars.BarLargeButtonItem bbiImprimir;
        private DevExpress.XtraBars.BarLargeButtonItem bbiEliminarCompra;
        private DevExpress.XtraBars.BarLargeButtonItem bbiRecibirProducto;
        private DevExpress.XtraBars.BarLargeButtonItem bbiDuplicarCompra;
        private DevExpress.XtraBars.BarLargeButtonItem bbiEditarCompra;
        private DevExpress.Utils.FlyoutPanel flyoutPanel1;
        private DevExpress.Utils.FlyoutPanelControl flyoutPanelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.Utils.FlyoutPanel flyoutPanel2;
        private DevExpress.Utils.FlyoutPanelControl flyoutPanelControl2;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarEditItem bbi_fecha_inicio;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarStaticItem lbl_fecha_inicio;
        private DevExpress.XtraBars.BarEditItem bbi_FechaInicio;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarEditItem bbi_FechaFin;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
    }
}