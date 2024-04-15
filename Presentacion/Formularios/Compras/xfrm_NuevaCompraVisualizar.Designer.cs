namespace Presentacion.Formularios.Compras
{
    partial class xfrm_NuevaCompraVisualizar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xfrm_NuevaCompraVisualizar));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnGuardar = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnGuardarImprimir = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnLimpiar = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barLargeButtonItem1 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridCompra = new DevExpress.XtraGrid.GridControl();
            this.bindingSourceDetalle = new System.Windows.Forms.BindingSource(this.components);
            this.viewDetalle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_Producto = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrecio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImpuesto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repository_Lote = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repositoryItemSearchLookUpEdit_Producto = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Producto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repository_Lote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit_Producto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnGuardar,
            this.btnGuardarImprimir,
            this.btnLimpiar,
            this.barLargeButtonItem1});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 4;
            // 
            // bar2
            // 
            this.bar2.BarName = "Menú principal";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Standalone;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGuardar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGuardarImprimir, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLimpiar),
            new DevExpress.XtraBars.LinkPersistInfo(this.barLargeButtonItem1)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menú principal";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Caption = "GUARDAR";
            this.btnGuardar.Id = 0;
            this.btnGuardar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.ImageOptions.Image")));
            this.btnGuardar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGuardar.ImageOptions.LargeImage")));
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGuardar_ItemClick);
            // 
            // btnGuardarImprimir
            // 
            this.btnGuardarImprimir.Caption = "GUARDAR E IMPRIMIR";
            this.btnGuardarImprimir.Id = 1;
            this.btnGuardarImprimir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarImprimir.ImageOptions.Image")));
            this.btnGuardarImprimir.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGuardarImprimir.ImageOptions.LargeImage")));
            this.btnGuardarImprimir.Name = "btnGuardarImprimir";
            this.btnGuardarImprimir.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnGuardarImprimir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGuardarImprimir_ItemClick);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Caption = "LIMPIAR (F12)";
            this.btnLimpiar.Id = 2;
            this.btnLimpiar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.ImageOptions.Image")));
            this.btnLimpiar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.ImageOptions.LargeImage")));
            this.btnLimpiar.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F12);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLimpiar_ItemClick);
            // 
            // barLargeButtonItem1
            // 
            this.barLargeButtonItem1.Caption = "ACTUALIZAR DATOS";
            this.barLargeButtonItem1.Id = 3;
            this.barLargeButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barLargeButtonItem1.ImageOptions.Image")));
            this.barLargeButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barLargeButtonItem1.ImageOptions.LargeImage")));
            this.barLargeButtonItem1.Name = "barLargeButtonItem1";
            this.barLargeButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barLargeButtonItem1_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(842, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 539);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(842, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 539);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(842, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 539);
            // 
            // gridCompra
            // 
            this.gridCompra.DataSource = this.bindingSourceDetalle;
            this.gridCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCompra.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridCompra.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridCompra.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridCompra.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridCompra.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridCompra.Location = new System.Drawing.Point(0, 0);
            this.gridCompra.MainView = this.viewDetalle;
            this.gridCompra.Name = "gridCompra";
            this.gridCompra.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit_Producto,
            this.repositoryItemSpinEdit1,
            this.repositoryItemSpinEdit2,
            this.repositoryItemSearchLookUpEdit_Producto,
            this.repository_Lote});
            this.gridCompra.Size = new System.Drawing.Size(842, 539);
            this.gridCompra.TabIndex = 1;
            this.gridCompra.UseEmbeddedNavigator = true;
            this.gridCompra.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewDetalle});
            // 
            // viewDetalle
            // 
            this.viewDetalle.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.viewDetalle.Appearance.FooterPanel.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.viewDetalle.Appearance.FooterPanel.Options.UseFont = true;
            this.viewDetalle.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewDetalle.Appearance.Row.Options.UseFont = true;
            this.viewDetalle.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.viewDetalle.Appearance.TopNewRow.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.viewDetalle.Appearance.TopNewRow.Options.UseFont = true;
            this.viewDetalle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.gridColumn2,
            this.colCantidad,
            this.gridColumn4,
            this.colPrecio,
            this.colImpuesto,
            this.gridColumn7,
            this.gridColumn3,
            this.gridColumn8,
            this.gridColumn10,
            this.gridColumn11});
            this.viewDetalle.GridControl = this.gridCompra;
            this.viewDetalle.Name = "viewDetalle";
            this.viewDetalle.OptionsCustomization.AllowColumnMoving = false;
            this.viewDetalle.OptionsCustomization.AllowFilter = false;
            this.viewDetalle.OptionsCustomization.AllowGroup = false;
            this.viewDetalle.OptionsMenu.EnableColumnMenu = false;
            this.viewDetalle.OptionsMenu.EnableFooterMenu = false;
            this.viewDetalle.OptionsMenu.EnableGroupPanelMenu = false;
            this.viewDetalle.OptionsView.ShowAutoFilterRow = true;
            this.viewDetalle.OptionsView.ShowFooter = true;
            this.viewDetalle.OptionsView.ShowGroupPanel = false;
            this.viewDetalle.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.viewDetalle_InvalidRowException);
            this.viewDetalle.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.viewDetalle_ValidateRow);
            this.viewDetalle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.viewDetalle_KeyDown);
            this.viewDetalle.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.viewDetalle_ValidatingEditor);
            this.viewDetalle.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.viewDetalle_InvalidValueException);
            // 
            // colID
            // 
            this.colID.Caption = "CÓDIGO";
            this.colID.ColumnEdit = this.repositoryItemLookUpEdit_Producto;
            this.colID.FieldName = "id";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            this.colID.Width = 95;
            // 
            // repositoryItemLookUpEdit_Producto
            // 
            this.repositoryItemLookUpEdit_Producto.AutoHeight = false;
            this.repositoryItemLookUpEdit_Producto.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.repositoryItemLookUpEdit_Producto.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_Producto.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("codigo", "CÓDIGO"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("descripcion", "DESCRIPCIÓN"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("stock", "EXISTENCIAS")});
            this.repositoryItemLookUpEdit_Producto.DisplayMember = "codigo";
            this.repositoryItemLookUpEdit_Producto.Name = "repositoryItemLookUpEdit_Producto";
            this.repositoryItemLookUpEdit_Producto.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.repositoryItemLookUpEdit_Producto.ValueMember = "id";
            this.repositoryItemLookUpEdit_Producto.EditValueChanged += new System.EventHandler(this.repositoryItemLookUpEdit_Producto_EditValueChanged);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "DESCRIPCIÓN";
            this.gridColumn2.FieldName = "descripcion";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 340;
            // 
            // colCantidad
            // 
            this.colCantidad.Caption = "CANTIDAD";
            this.colCantidad.ColumnEdit = this.repositoryItemSpinEdit2;
            this.colCantidad.FieldName = "cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cantidad", "{0:#.##}")});
            this.colCantidad.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colCantidad.Visible = true;
            this.colCantidad.VisibleIndex = 2;
            this.colCantidad.Width = 103;
            // 
            // repositoryItemSpinEdit2
            // 
            this.repositoryItemSpinEdit2.AutoHeight = false;
            this.repositoryItemSpinEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit2.Mask.EditMask = "n2";
            this.repositoryItemSpinEdit2.Name = "repositoryItemSpinEdit2";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "COSTO";
            this.gridColumn4.FieldName = "precio1";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.gridColumn4.Width = 81;
            // 
            // colPrecio
            // 
            this.colPrecio.Caption = "COSTO NUEVO";
            this.colPrecio.ColumnEdit = this.repositoryItemSpinEdit2;
            this.colPrecio.DisplayFormat.FormatString = "n2";
            this.colPrecio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrecio.FieldName = "precio_nuevo";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "subtotal", "SUB TOTAL: {0:n2}")});
            this.colPrecio.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colPrecio.Width = 95;
            // 
            // colImpuesto
            // 
            this.colImpuesto.Caption = "IMPUESTO %";
            this.colImpuesto.ColumnEdit = this.repositoryItemSpinEdit2;
            this.colImpuesto.DisplayFormat.FormatString = "n2";
            this.colImpuesto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImpuesto.FieldName = "impuesto";
            this.colImpuesto.Name = "colImpuesto";
            this.colImpuesto.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "impuesto_monto", "IMPUESTO: {0:n2}")});
            this.colImpuesto.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colImpuesto.Width = 85;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "TOTAL";
            this.gridColumn7.DisplayFormat.FormatString = "n2";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "total";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "TOTAL: {0:n2}")});
            this.gridColumn7.UnboundExpression = "[cantidad] * [precio_nuevo] * (1 + [impuesto] / 100)";
            this.gridColumn7.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.gridColumn7.Width = 100;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "SUB TOTAL";
            this.gridColumn3.FieldName = "subtotal";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.UnboundExpression = "[cantidad] * [precio_nuevo]";
            this.gridColumn3.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "IMPUESTO MONTO";
            this.gridColumn8.DisplayFormat.FormatString = "n2";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "impuesto_monto";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.UnboundExpression = "[cantidad] * [precio_nuevo] * ([impuesto] / 100)";
            this.gridColumn8.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "LOTE";
            this.gridColumn10.ColumnEdit = this.repository_Lote;
            this.gridColumn10.FieldName = "id_lote";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // repository_Lote
            // 
            this.repository_Lote.AutoHeight = false;
            this.repository_Lote.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repository_Lote.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_lote", "id_lote", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("lote", "LOTES")});
            this.repository_Lote.DisplayMember = "lote";
            this.repository_Lote.Name = "repository_Lote";
            this.repository_Lote.ValueMember = "id_lote";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "UBICACIÓN";
            this.gridColumn11.FieldName = "ubicacion";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit1.Mask.EditMask = "n0";
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // repositoryItemSearchLookUpEdit_Producto
            // 
            this.repositoryItemSearchLookUpEdit_Producto.AutoHeight = false;
            this.repositoryItemSearchLookUpEdit_Producto.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.repositoryItemSearchLookUpEdit_Producto.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSearchLookUpEdit_Producto.DisplayMember = "codigo";
            this.repositoryItemSearchLookUpEdit_Producto.Name = "repositoryItemSearchLookUpEdit_Producto";
            this.repositoryItemSearchLookUpEdit_Producto.PopupView = this.repositoryItemSearchLookUpEdit1View;
            this.repositoryItemSearchLookUpEdit_Producto.ValueMember = "id";
            this.repositoryItemSearchLookUpEdit_Producto.EditValueChanged += new System.EventHandler(this.repositoryItemSearchLookUpEdit_Producto_EditValueChanged);
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn9});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "id";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "CÓDIGO";
            this.gridColumn5.FieldName = "codigo";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "DESCRIPCIÓN";
            this.gridColumn6.FieldName = "descripcion";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "EXISTENCIA";
            this.gridColumn9.DisplayFormat.FormatString = "n2";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.FieldName = "stock";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 2;
            // 
            // xfrm_NuevaCompraVisualizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 539);
            this.Controls.Add(this.gridCompra);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("xfrm_NuevaCompraVisualizar.IconOptions.Icon")));
            this.Name = "xfrm_NuevaCompraVisualizar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NUEVA ORDEN DE COMPRA";
            this.Activated += new System.EventHandler(this.xfrm_NuevaCompra_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.xfrm_NuevaCompra_FormClosing);
            this.Load += new System.EventHandler(this.xfrm_NuevaCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Producto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repository_Lote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit_Producto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridCompra;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn colPrecio;
        private DevExpress.XtraGrid.Columns.GridColumn colImpuesto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private System.Windows.Forms.BindingSource bindingSourceDetalle;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_Producto;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarLargeButtonItem btnLimpiar;
        public DevExpress.XtraBars.BarLargeButtonItem btnGuardar;
        public DevExpress.XtraBars.BarLargeButtonItem btnGuardarImprimir;
        public DevExpress.XtraGrid.Views.Grid.GridView viewDetalle;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repositoryItemSearchLookUpEdit_Producto;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repository_Lote;
        private DevExpress.XtraBars.BarLargeButtonItem barLargeButtonItem1;
    }
}