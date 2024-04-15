namespace Presentacion.Formularios.Inventario
{
    partial class xfrm_movimiento_inventario_detallado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xfrm_movimiento_inventario_detallado));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grid_movimiento_detalle = new DevExpress.XtraGrid.GridControl();
            this.gview_detalle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_numero_doc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_fecha_documento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_numero_referencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_observaciones = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_referencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_id_producto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_nombre_bodega = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ubicacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_lote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_codigo_producto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_cantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_tipo_documento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_documento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_tipo_mov = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbi_cargar = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_reporte = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_excel = new DevExpress.XtraBars.BarButtonItem();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dtp_desde = new DevExpress.XtraEditors.DateEdit();
            this.dtp_hasta = new DevExpress.XtraEditors.DateEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.binding_detalles = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_movimiento_detalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview_detalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_desde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_desde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_hasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_hasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding_detalles)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grid_movimiento_detalle);
            this.layoutControl1.Controls.Add(this.standaloneBarDockControl1);
            this.layoutControl1.Controls.Add(this.dtp_desde);
            this.layoutControl1.Controls.Add(this.dtp_hasta);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(790, 568);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grid_movimiento_detalle
            // 
            this.grid_movimiento_detalle.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grid_movimiento_detalle.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grid_movimiento_detalle.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grid_movimiento_detalle.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grid_movimiento_detalle.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grid_movimiento_detalle.Location = new System.Drawing.Point(12, 92);
            this.grid_movimiento_detalle.MainView = this.gview_detalle;
            this.grid_movimiento_detalle.MenuManager = this.barManager1;
            this.grid_movimiento_detalle.Name = "grid_movimiento_detalle";
            this.grid_movimiento_detalle.Size = new System.Drawing.Size(766, 464);
            this.grid_movimiento_detalle.TabIndex = 7;
            this.grid_movimiento_detalle.UseEmbeddedNavigator = true;
            this.grid_movimiento_detalle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gview_detalle});
            // 
            // gview_detalle
            // 
            this.gview_detalle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_id,
            this.col_numero_doc,
            this.col_fecha_documento,
            this.col_numero_referencia,
            this.col_observaciones,
            this.col_referencia,
            this.col_id_producto,
            this.col_nombre_bodega,
            this.col_ubicacion,
            this.col_lote,
            this.col_codigo_producto,
            this.col_cantidad,
            this.col_tipo_documento,
            this.col_documento,
            this.col_tipo_mov});
            this.gview_detalle.GridControl = this.grid_movimiento_detalle;
            this.gview_detalle.Name = "gview_detalle";
            this.gview_detalle.OptionsBehavior.Editable = false;
            this.gview_detalle.OptionsView.ShowAutoFilterRow = true;
            this.gview_detalle.OptionsView.ShowGroupPanel = false;
            // 
            // col_id
            // 
            this.col_id.Caption = "id_movimiento";
            this.col_id.FieldName = "ID";
            this.col_id.Name = "col_id";
            // 
            // col_numero_doc
            // 
            this.col_numero_doc.Caption = "NUMERO";
            this.col_numero_doc.FieldName = "numero_documento";
            this.col_numero_doc.Name = "col_numero_doc";
            // 
            // col_fecha_documento
            // 
            this.col_fecha_documento.Caption = "FECHA";
            this.col_fecha_documento.FieldName = "fecha_documento";
            this.col_fecha_documento.Name = "col_fecha_documento";
            this.col_fecha_documento.Visible = true;
            this.col_fecha_documento.VisibleIndex = 0;
            // 
            // col_numero_referencia
            // 
            this.col_numero_referencia.Caption = "NUMERO REF";
            this.col_numero_referencia.FieldName = "numero_documento";
            this.col_numero_referencia.Name = "col_numero_referencia";
            this.col_numero_referencia.Visible = true;
            this.col_numero_referencia.VisibleIndex = 2;
            // 
            // col_observaciones
            // 
            this.col_observaciones.Caption = "OBSERVACION";
            this.col_observaciones.FieldName = "observacion";
            this.col_observaciones.Name = "col_observaciones";
            this.col_observaciones.Visible = true;
            this.col_observaciones.VisibleIndex = 9;
            // 
            // col_referencia
            // 
            this.col_referencia.Caption = "REFERENCIA";
            this.col_referencia.FieldName = "persona_referencia";
            this.col_referencia.Name = "col_referencia";
            this.col_referencia.Visible = true;
            this.col_referencia.VisibleIndex = 3;
            // 
            // col_id_producto
            // 
            this.col_id_producto.Caption = "id_producto";
            this.col_id_producto.FieldName = "id_producto";
            this.col_id_producto.Name = "col_id_producto";
            // 
            // col_nombre_bodega
            // 
            this.col_nombre_bodega.Caption = "BODEGA";
            this.col_nombre_bodega.FieldName = "nombre";
            this.col_nombre_bodega.Name = "col_nombre_bodega";
            this.col_nombre_bodega.Visible = true;
            this.col_nombre_bodega.VisibleIndex = 4;
            // 
            // col_ubicacion
            // 
            this.col_ubicacion.Caption = "UBICACION";
            this.col_ubicacion.FieldName = "ubicacion";
            this.col_ubicacion.Name = "col_ubicacion";
            this.col_ubicacion.Visible = true;
            this.col_ubicacion.VisibleIndex = 5;
            // 
            // col_lote
            // 
            this.col_lote.Caption = "LOTE";
            this.col_lote.FieldName = "lote";
            this.col_lote.Name = "col_lote";
            this.col_lote.Visible = true;
            this.col_lote.VisibleIndex = 6;
            // 
            // col_codigo_producto
            // 
            this.col_codigo_producto.Caption = "CODIGO PRODUCTO";
            this.col_codigo_producto.FieldName = "codigo";
            this.col_codigo_producto.Name = "col_codigo_producto";
            this.col_codigo_producto.Visible = true;
            this.col_codigo_producto.VisibleIndex = 7;
            // 
            // col_cantidad
            // 
            this.col_cantidad.Caption = "CANTIDAD";
            this.col_cantidad.FieldName = "cantidad";
            this.col_cantidad.Name = "col_cantidad";
            this.col_cantidad.Visible = true;
            this.col_cantidad.VisibleIndex = 8;
            // 
            // col_tipo_documento
            // 
            this.col_tipo_documento.Caption = "DOCUMENTO";
            this.col_tipo_documento.FieldName = "descripcion_doc";
            this.col_tipo_documento.Name = "col_tipo_documento";
            // 
            // col_documento
            // 
            this.col_documento.Caption = "DOCUMENTO";
            this.col_documento.FieldName = "descripcion_corta";
            this.col_documento.Name = "col_documento";
            this.col_documento.Visible = true;
            this.col_documento.VisibleIndex = 1;
            // 
            // col_tipo_mov
            // 
            this.col_tipo_mov.Caption = "TIPO MOV";
            this.col_tipo_mov.FieldName = "tipo_movimiento";
            this.col_tipo_mov.Name = "col_tipo_mov";
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
            this.bbi_cargar,
            this.bbi_reporte,
            this.bbi_excel});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Menú principal";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbi_cargar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbi_reporte, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbi_excel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.bar2.Text = "Menú principal";
            // 
            // bbi_cargar
            // 
            this.bbi_cargar.Caption = "CARGAR";
            this.bbi_cargar.Id = 0;
            this.bbi_cargar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbi_cargar.ImageOptions.Image")));
            this.bbi_cargar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbi_cargar.ImageOptions.LargeImage")));
            this.bbi_cargar.Name = "bbi_cargar";
            this.bbi_cargar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_cargar_ItemClick);
            // 
            // bbi_reporte
            // 
            this.bbi_reporte.Caption = "REPORTE";
            this.bbi_reporte.Id = 1;
            this.bbi_reporte.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbi_reporte.ImageOptions.Image")));
            this.bbi_reporte.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbi_reporte.ImageOptions.LargeImage")));
            this.bbi_reporte.Name = "bbi_reporte";
            this.bbi_reporte.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_reporte_ItemClick);
            // 
            // bbi_excel
            // 
            this.bbi_excel.Caption = "Excel";
            this.bbi_excel.Id = 2;
            this.bbi_excel.ImageOptions.Image = global::Presentacion.Properties.Resources.excel_16;
            this.bbi_excel.Name = "bbi_excel";
            this.bbi_excel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_excel_ItemClick);
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(12, 64);
            this.standaloneBarDockControl1.Manager = this.barManager1;
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(766, 24);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(790, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 568);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(790, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 568);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(790, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 568);
            // 
            // dtp_desde
            // 
            this.dtp_desde.EditValue = null;
            this.dtp_desde.Location = new System.Drawing.Point(52, 12);
            this.dtp_desde.Name = "dtp_desde";
            this.dtp_desde.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_desde.Properties.Appearance.Options.UseFont = true;
            this.dtp_desde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtp_desde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtp_desde.Size = new System.Drawing.Size(188, 22);
            this.dtp_desde.StyleController = this.layoutControl1;
            toolTipTitleItem1.ImageOptions.ImageUri.Uri = "MonthView";
            toolTipTitleItem1.Text = "Fecha de Inicio";
            toolTipItem1.ImageOptions.ImageUri.Uri = "SwitchTimeScalesTo";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Esta es la fecha del inicio de la busqueda de los Asientos en formato dia/mes/año" +
    "";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.dtp_desde.SuperTip = superToolTip1;
            this.dtp_desde.TabIndex = 4;
            // 
            // dtp_hasta
            // 
            this.dtp_hasta.EditValue = null;
            this.dtp_hasta.Location = new System.Drawing.Point(52, 38);
            this.dtp_hasta.Name = "dtp_hasta";
            this.dtp_hasta.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_hasta.Properties.Appearance.Options.UseFont = true;
            this.dtp_hasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtp_hasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtp_hasta.Size = new System.Drawing.Size(188, 22);
            this.dtp_hasta.StyleController = this.layoutControl1;
            toolTipTitleItem2.Text = "Fecha Final";
            toolTipItem2.ImageOptions.ImageUri.Uri = "SwitchTimeScalesTo";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "Esta es la fecha final de la busqueda de los Asientos en formato dia/mes/año";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.dtp_hasta.SuperTip = superToolTip2;
            this.dtp_hasta.TabIndex = 5;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem2,
            this.layoutControlItem4});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(790, 568);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dtp_desde;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(232, 26);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(232, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(232, 26);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "DESDE";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(37, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dtp_hasta;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(232, 26);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(232, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(232, 26);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "HASTA:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(37, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.standaloneBarDockControl1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(770, 28);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(232, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(538, 52);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.grid_movimiento_detalle;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 80);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(770, 468);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // binding_detalles
            // 
            this.binding_detalles.CurrentChanged += new System.EventHandler(this.binding_detalles_CurrentChanged);
            // 
            // xfrm_movimiento_inventario_detallado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 568);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "xfrm_movimiento_inventario_detallado";
            this.Text = "MOVIMIENTO INVENTARIO DETALLADO";
            this.Load += new System.EventHandler(this.xfrm_movimiento_inventario_detallado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_movimiento_detalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview_detalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_desde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_desde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_hasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_hasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding_detalles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.DateEdit dtp_desde;
        private DevExpress.XtraEditors.DateEdit dtp_hasta;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl grid_movimiento_detalle;
        private DevExpress.XtraGrid.Views.Grid.GridView gview_detalle;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem bbi_cargar;
        private DevExpress.XtraBars.BarButtonItem bbi_reporte;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn col_id;
        private DevExpress.XtraGrid.Columns.GridColumn col_numero_doc;
        private DevExpress.XtraGrid.Columns.GridColumn col_fecha_documento;
        private DevExpress.XtraGrid.Columns.GridColumn col_numero_referencia;
        private DevExpress.XtraGrid.Columns.GridColumn col_observaciones;
        private DevExpress.XtraGrid.Columns.GridColumn col_referencia;
        private DevExpress.XtraGrid.Columns.GridColumn col_id_producto;
        private DevExpress.XtraGrid.Columns.GridColumn col_nombre_bodega;
        private DevExpress.XtraGrid.Columns.GridColumn col_ubicacion;
        private DevExpress.XtraGrid.Columns.GridColumn col_lote;
        private DevExpress.XtraGrid.Columns.GridColumn col_codigo_producto;
        private DevExpress.XtraGrid.Columns.GridColumn col_cantidad;
        private DevExpress.XtraGrid.Columns.GridColumn col_tipo_documento;
        private DevExpress.XtraGrid.Columns.GridColumn col_documento;
        private DevExpress.XtraGrid.Columns.GridColumn col_tipo_mov;
        private DevExpress.XtraBars.BarButtonItem bbi_excel;
        private System.Windows.Forms.BindingSource binding_detalles;
    }
}