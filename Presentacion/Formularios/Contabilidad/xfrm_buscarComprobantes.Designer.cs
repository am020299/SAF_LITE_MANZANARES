namespace Presentacion.Formularios.Contabilidad
{
    partial class xfrm_buscarComprobantes
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xfrm_buscarComprobantes));
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.gview_detalle_comprobantes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_id_comprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_n_cuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_nombre_cuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_debe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_haber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grid_control_comprobantes = new DevExpress.XtraGrid.GridControl();
            this.gview_comprobantes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id_comprobante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnumero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_fecha_asiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colconcepto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_tipo_letras = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltipo_numero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDebe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHaber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Estado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_sucursal_numero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_conciliado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbi_buscar = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_expoortar_listado = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.blb_editar_asiento = new DevExpress.XtraBars.BarLargeButtonItem();
            this.blb_Nuevo_Asiento = new DevExpress.XtraBars.BarLargeButtonItem();
            this.blb_AnularAsiento = new DevExpress.XtraBars.BarLargeButtonItem();
            this.blb_duplicarAsiento = new DevExpress.XtraBars.BarLargeButtonItem();
            this.blb_ImprimrAsiento = new DevExpress.XtraBars.BarLargeButtonItem();
            this.dtp_desde = new DevExpress.XtraEditors.DateEdit();
            this.dtp_hasta = new DevExpress.XtraEditors.DateEdit();
            this.radio_tipo_busqueda = new DevExpress.XtraEditors.RadioGroup();
            this.Look_tipo_comprobante = new DevExpress.XtraEditors.LookUpEdit();
            this.radio_tipo_cuadratura = new DevExpress.XtraEditors.RadioGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.menu = new DevExpress.XtraBars.Ribbon.RadialMenu(this.components);
            this.binding_Reporte = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gview_detalle_comprobantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_control_comprobantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview_comprobantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_desde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_desde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_hasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_hasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radio_tipo_busqueda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Look_tipo_comprobante.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radio_tipo_cuadratura.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding_Reporte)).BeginInit();
            this.SuspendLayout();
            // 
            // gview_detalle_comprobantes
            // 
            this.gview_detalle_comprobantes.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_id,
            this.col_id_comprobante,
            this.col_n_cuenta,
            this.col_nombre_cuenta,
            this.col_debe,
            this.col_haber});
            this.gview_detalle_comprobantes.GridControl = this.grid_control_comprobantes;
            this.gview_detalle_comprobantes.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "debe", this.col_debe, "{0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "haber", this.col_haber, "{0:c2}")});
            this.gview_detalle_comprobantes.Name = "gview_detalle_comprobantes";
            this.gview_detalle_comprobantes.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gview_detalle_comprobantes.OptionsBehavior.Editable = false;
            this.gview_detalle_comprobantes.OptionsCustomization.AllowColumnMoving = false;
            this.gview_detalle_comprobantes.OptionsCustomization.AllowColumnResizing = false;
            this.gview_detalle_comprobantes.OptionsCustomization.AllowFilter = false;
            this.gview_detalle_comprobantes.OptionsCustomization.AllowGroup = false;
            this.gview_detalle_comprobantes.OptionsCustomization.AllowSort = false;
            this.gview_detalle_comprobantes.OptionsMenu.EnableColumnMenu = false;
            this.gview_detalle_comprobantes.OptionsView.EnableAppearanceOddRow = true;
            this.gview_detalle_comprobantes.OptionsView.ShowFooter = true;
            this.gview_detalle_comprobantes.OptionsView.ShowGroupPanel = false;
            // 
            // col_id
            // 
            this.col_id.Caption = "id";
            this.col_id.FieldName = "id";
            this.col_id.Name = "col_id";
            // 
            // col_id_comprobante
            // 
            this.col_id_comprobante.Caption = "ID_COMPROBANTE";
            this.col_id_comprobante.FieldName = "id_comprobante";
            this.col_id_comprobante.Name = "col_id_comprobante";
            // 
            // col_n_cuenta
            // 
            this.col_n_cuenta.Caption = "NUMERO CUENTA";
            this.col_n_cuenta.FieldName = "cta";
            this.col_n_cuenta.Name = "col_n_cuenta";
            this.col_n_cuenta.Visible = true;
            this.col_n_cuenta.VisibleIndex = 0;
            this.col_n_cuenta.Width = 177;
            // 
            // col_nombre_cuenta
            // 
            this.col_nombre_cuenta.Caption = "DESCRIPCIÓN CUENTA";
            this.col_nombre_cuenta.FieldName = "nombre_cuenta";
            this.col_nombre_cuenta.Name = "col_nombre_cuenta";
            this.col_nombre_cuenta.Visible = true;
            this.col_nombre_cuenta.VisibleIndex = 1;
            this.col_nombre_cuenta.Width = 289;
            // 
            // col_debe
            // 
            this.col_debe.Caption = "DEBE";
            this.col_debe.DisplayFormat.FormatString = "{0:c2}";
            this.col_debe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_debe.FieldName = "debe";
            this.col_debe.Name = "col_debe";
            this.col_debe.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "debe", "{0:c2}")});
            this.col_debe.Visible = true;
            this.col_debe.VisibleIndex = 2;
            this.col_debe.Width = 135;
            // 
            // col_haber
            // 
            this.col_haber.Caption = "HABER";
            this.col_haber.DisplayFormat.FormatString = "{0:c2}";
            this.col_haber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_haber.FieldName = "haber";
            this.col_haber.Name = "col_haber";
            this.col_haber.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "haber", "{0:c2}")});
            this.col_haber.Visible = true;
            this.col_haber.VisibleIndex = 3;
            this.col_haber.Width = 141;
            // 
            // grid_control_comprobantes
            // 
            this.grid_control_comprobantes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_control_comprobantes.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grid_control_comprobantes.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grid_control_comprobantes.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grid_control_comprobantes.EmbeddedNavigator.Buttons.EnabledAutoRepeat = false;
            this.grid_control_comprobantes.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grid_control_comprobantes.EmbeddedNavigator.Buttons.Remove.Visible = false;
            gridLevelNode2.LevelTemplate = this.gview_detalle_comprobantes;
            gridLevelNode2.RelationName = "Detalle Comprobante";
            this.grid_control_comprobantes.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.grid_control_comprobantes.Location = new System.Drawing.Point(12, 124);
            this.grid_control_comprobantes.MainView = this.gview_comprobantes;
            this.grid_control_comprobantes.Name = "grid_control_comprobantes";
            this.grid_control_comprobantes.Size = new System.Drawing.Size(760, 425);
            this.grid_control_comprobantes.TabIndex = 16;
            this.grid_control_comprobantes.UseEmbeddedNavigator = true;
            this.grid_control_comprobantes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gview_comprobantes,
            this.gview_detalle_comprobantes});
            this.grid_control_comprobantes.Click += new System.EventHandler(this.grid_control_comprobantes_Click);
            // 
            // gview_comprobantes
            // 
            this.gview_comprobantes.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gview_comprobantes.Appearance.FocusedCell.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            this.gview_comprobantes.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gview_comprobantes.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gview_comprobantes.Appearance.FocusedRow.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            this.gview_comprobantes.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gview_comprobantes.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gview_comprobantes.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Blue;
            this.gview_comprobantes.Appearance.FooterPanel.Options.UseFont = true;
            this.gview_comprobantes.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gview_comprobantes.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gview_comprobantes.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gview_comprobantes.Appearance.FooterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gview_comprobantes.Appearance.HeaderPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gview_comprobantes.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gview_comprobantes.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gview_comprobantes.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gview_comprobantes.Appearance.HeaderPanel.Options.UseFont = true;
            this.gview_comprobantes.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gview_comprobantes.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gview_comprobantes.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gview_comprobantes.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gview_comprobantes.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id_comprobante,
            this.colnumero,
            this.colfecha,
            this.col_fecha_asiento,
            this.colconcepto,
            this.col_tipo_letras,
            this.coltipo_numero,
            this.colDebe,
            this.colHaber,
            this.col_Estado,
            this.col_sucursal_numero,
            this.col_conciliado});
            this.gview_comprobantes.GridControl = this.grid_control_comprobantes;
            this.gview_comprobantes.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "debe", this.colDebe, "(Total: {0:#.##})"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "haber", this.colHaber, "(Total: {0:#.##})")});
            this.gview_comprobantes.Name = "gview_comprobantes";
            this.gview_comprobantes.OptionsBehavior.Editable = false;
            this.gview_comprobantes.OptionsMenu.EnableColumnMenu = false;
            this.gview_comprobantes.OptionsView.EnableAppearanceOddRow = true;
            this.gview_comprobantes.OptionsView.ShowAutoFilterRow = true;
            this.gview_comprobantes.OptionsView.ShowFooter = true;
            this.gview_comprobantes.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gview_comprobantes_RowStyle);
            this.gview_comprobantes.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.gview_comprobantes_CustomSummaryCalculate);
            this.gview_comprobantes.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gview_comprobantes_FocusedRowChanged);
            this.gview_comprobantes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gview_comprobantes_MouseUp);
            // 
            // id_comprobante
            // 
            this.id_comprobante.Caption = "id_comprobante";
            this.id_comprobante.FieldName = "id_comprobante";
            this.id_comprobante.Name = "id_comprobante";
            this.id_comprobante.OptionsColumn.AllowMove = false;
            this.id_comprobante.OptionsFilter.AllowAutoFilter = false;
            this.id_comprobante.OptionsFilter.AllowFilter = false;
            // 
            // colnumero
            // 
            this.colnumero.AppearanceCell.Options.UseTextOptions = true;
            this.colnumero.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colnumero.Caption = "N° DE ASIENTO";
            this.colnumero.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colnumero.FieldName = "num_comprobante";
            this.colnumero.Name = "colnumero";
            this.colnumero.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colnumero.OptionsColumn.AllowMove = false;
            this.colnumero.OptionsColumn.AllowSize = false;
            this.colnumero.Visible = true;
            this.colnumero.VisibleIndex = 1;
            this.colnumero.Width = 111;
            // 
            // colfecha
            // 
            this.colfecha.Caption = "FECHA DE REGISTRO";
            this.colfecha.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.colfecha.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colfecha.FieldName = "fecha_registro";
            this.colfecha.Name = "colfecha";
            this.colfecha.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.colfecha.OptionsColumn.AllowSize = false;
            this.colfecha.Width = 187;
            // 
            // col_fecha_asiento
            // 
            this.col_fecha_asiento.Caption = "FECHA DE ASIENTO";
            this.col_fecha_asiento.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.col_fecha_asiento.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.col_fecha_asiento.FieldName = "fecha_asiento";
            this.col_fecha_asiento.Name = "col_fecha_asiento";
            this.col_fecha_asiento.Visible = true;
            this.col_fecha_asiento.VisibleIndex = 0;
            this.col_fecha_asiento.Width = 121;
            // 
            // colconcepto
            // 
            this.colconcepto.Caption = "CONCEPTO";
            this.colconcepto.FieldName = "concepto";
            this.colconcepto.Name = "colconcepto";
            this.colconcepto.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colconcepto.OptionsColumn.AllowMove = false;
            this.colconcepto.Visible = true;
            this.colconcepto.VisibleIndex = 2;
            this.colconcepto.Width = 190;
            // 
            // col_tipo_letras
            // 
            this.col_tipo_letras.Caption = "TIPO DE ASIENTO";
            this.col_tipo_letras.FieldName = "Tipo";
            this.col_tipo_letras.Name = "col_tipo_letras";
            this.col_tipo_letras.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Tipo", "DIFERENCIA:{0:c2}")});
            this.col_tipo_letras.Visible = true;
            this.col_tipo_letras.VisibleIndex = 3;
            this.col_tipo_letras.Width = 135;
            // 
            // coltipo_numero
            // 
            this.coltipo_numero.Caption = "tipo_numero";
            this.coltipo_numero.FieldName = "tipo_numero";
            this.coltipo_numero.Name = "coltipo_numero";
            // 
            // colDebe
            // 
            this.colDebe.Caption = "DEBE";
            this.colDebe.DisplayFormat.FormatString = "{0:c2}";
            this.colDebe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDebe.FieldName = "debe";
            this.colDebe.GroupFormat.FormatString = "c2";
            this.colDebe.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDebe.Name = "colDebe";
            this.colDebe.OptionsColumn.AllowMove = false;
            this.colDebe.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "debe", "{0:c2}")});
            this.colDebe.Visible = true;
            this.colDebe.VisibleIndex = 4;
            this.colDebe.Width = 102;
            // 
            // colHaber
            // 
            this.colHaber.Caption = "HABER";
            this.colHaber.DisplayFormat.FormatString = "c2";
            this.colHaber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colHaber.FieldName = "haber";
            this.colHaber.GroupFormat.FormatString = "c2";
            this.colHaber.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colHaber.Name = "colHaber";
            this.colHaber.OptionsColumn.AllowMove = false;
            this.colHaber.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "haber", "{0:c2}")});
            this.colHaber.Visible = true;
            this.colHaber.VisibleIndex = 5;
            this.colHaber.Width = 83;
            // 
            // col_Estado
            // 
            this.col_Estado.Caption = "estado";
            this.col_Estado.FieldName = "Estado";
            this.col_Estado.Name = "col_Estado";
            // 
            // col_sucursal_numero
            // 
            this.col_sucursal_numero.Caption = "sucursal";
            this.col_sucursal_numero.FieldName = "sucursal";
            this.col_sucursal_numero.Name = "col_sucursal_numero";
            // 
            // col_conciliado
            // 
            this.col_conciliado.Caption = "Conciliado";
            this.col_conciliado.FieldName = "conciliado";
            this.col_conciliado.Name = "col_conciliado";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.standaloneBarDockControl1);
            this.layoutControl1.Controls.Add(this.grid_control_comprobantes);
            this.layoutControl1.Controls.Add(this.dtp_desde);
            this.layoutControl1.Controls.Add(this.dtp_hasta);
            this.layoutControl1.Controls.Add(this.radio_tipo_busqueda);
            this.layoutControl1.Controls.Add(this.Look_tipo_comprobante);
            this.layoutControl1.Controls.Add(this.radio_tipo_cuadratura);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(784, 561);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(12, 96);
            this.standaloneBarDockControl1.Manager = this.barManager1;
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(760, 24);
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
            this.bbi_buscar,
            this.blb_editar_asiento,
            this.blb_Nuevo_Asiento,
            this.blb_AnularAsiento,
            this.blb_duplicarAsiento,
            this.blb_ImprimrAsiento,
            this.bbi_expoortar_listado});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 8;
            // 
            // bar2
            // 
            this.bar2.BarName = "Menú principal";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbi_buscar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbi_expoortar_listado, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.bar2.Text = "Menú principal";
            // 
            // bbi_buscar
            // 
            this.bbi_buscar.Caption = "BUSCAR";
            this.bbi_buscar.Id = 0;
            this.bbi_buscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbi_buscar.ImageOptions.Image")));
            this.bbi_buscar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbi_buscar.ImageOptions.LargeImage")));
            this.bbi_buscar.Name = "bbi_buscar";
            this.bbi_buscar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_buscar_ItemClick);
            // 
            // bbi_expoortar_listado
            // 
            this.bbi_expoortar_listado.Caption = "EXPORTAR LISTADO";
            this.bbi_expoortar_listado.Id = 7;
            this.bbi_expoortar_listado.ImageOptions.Image = global::Presentacion.Properties.Resources.excel_16;
            this.bbi_expoortar_listado.ImageOptions.LargeImage = global::Presentacion.Properties.Resources.excel_16;
            this.bbi_expoortar_listado.Name = "bbi_expoortar_listado";
            this.bbi_expoortar_listado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_expoortar_listado_ItemClick);
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
            // blb_editar_asiento
            // 
            this.blb_editar_asiento.Caption = "Editar Asiento";
            this.blb_editar_asiento.Id = 2;
            this.blb_editar_asiento.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("blb_editar_asiento.ImageOptions.Image")));
            this.blb_editar_asiento.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("blb_editar_asiento.ImageOptions.LargeImage")));
            this.blb_editar_asiento.Name = "blb_editar_asiento";
            this.blb_editar_asiento.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.blb_editar_asiento_ItemClick);
            // 
            // blb_Nuevo_Asiento
            // 
            this.blb_Nuevo_Asiento.Caption = "Nuevo Asiento";
            this.blb_Nuevo_Asiento.Id = 3;
            this.blb_Nuevo_Asiento.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("blb_Nuevo_Asiento.ImageOptions.Image")));
            this.blb_Nuevo_Asiento.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("blb_Nuevo_Asiento.ImageOptions.LargeImage")));
            this.blb_Nuevo_Asiento.Name = "blb_Nuevo_Asiento";
            this.blb_Nuevo_Asiento.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.blb_Nuevo_Asiento_ItemClick);
            // 
            // blb_AnularAsiento
            // 
            this.blb_AnularAsiento.Caption = "Anular Asiento";
            this.blb_AnularAsiento.Id = 4;
            this.blb_AnularAsiento.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("blb_AnularAsiento.ImageOptions.Image")));
            this.blb_AnularAsiento.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("blb_AnularAsiento.ImageOptions.LargeImage")));
            this.blb_AnularAsiento.Name = "blb_AnularAsiento";
            this.blb_AnularAsiento.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.blb_AnularAsiento_ItemClick);
            // 
            // blb_duplicarAsiento
            // 
            this.blb_duplicarAsiento.Caption = "Duplicar Asiento";
            this.blb_duplicarAsiento.Id = 5;
            this.blb_duplicarAsiento.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("blb_duplicarAsiento.ImageOptions.Image")));
            this.blb_duplicarAsiento.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("blb_duplicarAsiento.ImageOptions.LargeImage")));
            this.blb_duplicarAsiento.Name = "blb_duplicarAsiento";
            // 
            // blb_ImprimrAsiento
            // 
            this.blb_ImprimrAsiento.Caption = "Imprimir Asiento";
            this.blb_ImprimrAsiento.Id = 6;
            this.blb_ImprimrAsiento.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("blb_ImprimrAsiento.ImageOptions.Image")));
            this.blb_ImprimrAsiento.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("blb_ImprimrAsiento.ImageOptions.LargeImage")));
            this.blb_ImprimrAsiento.Name = "blb_ImprimrAsiento";
            this.blb_ImprimrAsiento.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.blb_ImprimrAsiento_ItemClick);
            // 
            // dtp_desde
            // 
            this.dtp_desde.EditValue = null;
            this.dtp_desde.Location = new System.Drawing.Point(84, 12);
            this.dtp_desde.Name = "dtp_desde";
            this.dtp_desde.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_desde.Properties.Appearance.Options.UseFont = true;
            this.dtp_desde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtp_desde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtp_desde.Size = new System.Drawing.Size(239, 22);
            this.dtp_desde.StyleController = this.layoutControl1;
            toolTipTitleItem4.ImageOptions.ImageUri.Uri = "MonthView";
            toolTipTitleItem4.Text = "Fecha de Inicio";
            toolTipItem4.ImageOptions.ImageUri.Uri = "SwitchTimeScalesTo";
            toolTipItem4.LeftIndent = 6;
            toolTipItem4.Text = "Esta es la fecha del inicio de la busqueda de los Asientos en formato dia/mes/año" +
    "";
            superToolTip4.Items.Add(toolTipTitleItem4);
            superToolTip4.Items.Add(toolTipItem4);
            this.dtp_desde.SuperTip = superToolTip4;
            this.dtp_desde.TabIndex = 1;
            this.dtp_desde.EditValueChanged += new System.EventHandler(this.dtp_desde_EditValueChanged);
            // 
            // dtp_hasta
            // 
            this.dtp_hasta.EditValue = null;
            this.dtp_hasta.Location = new System.Drawing.Point(84, 38);
            this.dtp_hasta.Name = "dtp_hasta";
            this.dtp_hasta.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_hasta.Properties.Appearance.Options.UseFont = true;
            this.dtp_hasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtp_hasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtp_hasta.Size = new System.Drawing.Size(239, 22);
            this.dtp_hasta.StyleController = this.layoutControl1;
            toolTipTitleItem1.Text = "Fecha Final";
            toolTipItem1.ImageOptions.ImageUri.Uri = "SwitchTimeScalesTo";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Esta es la fecha final de la busqueda de los Asientos en formato dia/mes/año";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.dtp_hasta.SuperTip = superToolTip1;
            this.dtp_hasta.TabIndex = 2;
            this.dtp_hasta.EditValueChanged += new System.EventHandler(this.dtp_hasta_EditValueChanged);
            // 
            // radio_tipo_busqueda
            // 
            this.radio_tipo_busqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radio_tipo_busqueda.Location = new System.Drawing.Point(84, 67);
            this.radio_tipo_busqueda.Name = "radio_tipo_busqueda";
            this.radio_tipo_busqueda.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Rango de Fechas"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Por Dia")});
            this.radio_tipo_busqueda.Size = new System.Drawing.Size(239, 25);
            this.radio_tipo_busqueda.StyleController = this.layoutControl1;
            this.radio_tipo_busqueda.TabIndex = 0;
            this.radio_tipo_busqueda.SelectedIndexChanged += new System.EventHandler(this.radio_tipo_busqueda_SelectedIndexChanged);
            // 
            // Look_tipo_comprobante
            // 
            this.Look_tipo_comprobante.Location = new System.Drawing.Point(399, 12);
            this.Look_tipo_comprobante.Name = "Look_tipo_comprobante";
            this.Look_tipo_comprobante.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Look_tipo_comprobante.Properties.Appearance.Options.UseFont = true;
            this.Look_tipo_comprobante.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Look_tipo_comprobante.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tipo_comprobante", "Tipo Asiento", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("descripcion", "Tipo Asiento")});
            this.Look_tipo_comprobante.Properties.DisplayMember = "descripcion";
            this.Look_tipo_comprobante.Properties.DropDownRows = 10;
            this.Look_tipo_comprobante.Properties.ValueMember = "tipo_comprobante";
            this.Look_tipo_comprobante.Size = new System.Drawing.Size(373, 22);
            this.Look_tipo_comprobante.StyleController = this.layoutControl1;
            toolTipTitleItem2.Text = "Tipo de Asiento";
            toolTipItem2.ImageOptions.ImageUri.Uri = "ListBullets";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "Aqui debe de Seleccionar el tipo de Asiento a buscar.\r\n";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.Look_tipo_comprobante.SuperTip = superToolTip2;
            this.Look_tipo_comprobante.TabIndex = 3;
            this.Look_tipo_comprobante.EditValueChanged += new System.EventHandler(this.Look_tipo_comprobante_EditValueChanged);
            // 
            // radio_tipo_cuadratura
            // 
            this.radio_tipo_cuadratura.Location = new System.Drawing.Point(399, 38);
            this.radio_tipo_cuadratura.Name = "radio_tipo_cuadratura";
            this.radio_tipo_cuadratura.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Todos"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Cuadrados"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Descuadrados")});
            this.radio_tipo_cuadratura.Size = new System.Drawing.Size(373, 25);
            this.radio_tipo_cuadratura.StyleController = this.layoutControl1;
            this.radio_tipo_cuadratura.TabIndex = 4;
            this.radio_tipo_cuadratura.SelectedIndexChanged += new System.EventHandler(this.radio_tipo_cuadratura_SelectedIndexChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem2,
            this.layoutControlItem9,
            this.layoutControlItem3,
            this.emptySpaceItem2,
            this.layoutControlItem1,
            this.layoutControlItem4});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(784, 561);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.dtp_desde;
            this.layoutControlItem6.CustomizationFormText = "DESDE:";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(315, 26);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(315, 26);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(315, 26);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "DESDE:";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(69, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.dtp_hasta;
            this.layoutControlItem7.CustomizationFormText = "HASTA";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(315, 29);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(315, 29);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(315, 29);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "HASTA";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(69, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.radio_tipo_busqueda;
            this.layoutControlItem2.CustomizationFormText = "BUSCAR POR";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 55);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(315, 29);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(315, 29);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(315, 29);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "BUSCAR POR";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(69, 13);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.Look_tipo_comprobante;
            this.layoutControlItem9.CustomizationFormText = "TIPO";
            this.layoutControlItem9.Location = new System.Drawing.Point(315, 0);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(449, 26);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(449, 26);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(449, 26);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.Text = "TIPO";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(69, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.radio_tipo_cuadratura;
            this.layoutControlItem3.CustomizationFormText = "CUADRATURA";
            this.layoutControlItem3.Location = new System.Drawing.Point(315, 26);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(449, 29);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(449, 29);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(449, 29);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "CUADRATURA";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(69, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(315, 55);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(449, 29);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(449, 29);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(449, 29);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grid_control_comprobantes;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 112);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(764, 429);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.standaloneBarDockControl1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 84);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(764, 28);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // menu
            // 
            this.menu.AutoExpand = true;
            this.menu.Glyph = global::Presentacion.Properties.Resources.menu_16;
            this.menu.ItemAutoSize = DevExpress.XtraBars.Ribbon.RadialMenuItemAutoSize.Spring;
            this.menu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.blb_editar_asiento),
            new DevExpress.XtraBars.LinkPersistInfo(this.blb_Nuevo_Asiento),
            new DevExpress.XtraBars.LinkPersistInfo(this.blb_AnularAsiento),
            new DevExpress.XtraBars.LinkPersistInfo(this.blb_ImprimrAsiento)});
            this.menu.Manager = this.barManager1;
            this.menu.Name = "menu";
            // 
            // xfrm_buscarComprobantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "xfrm_buscarComprobantes";
            this.Text = "BUSCAR ASIENTOS";
            this.Activated += new System.EventHandler(this.xfrm_buscarComprobantes_Activated);
            this.Load += new System.EventHandler(this.xfrm_buscarComprobantes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gview_detalle_comprobantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_control_comprobantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview_comprobantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_desde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_desde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_hasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_hasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radio_tipo_busqueda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Look_tipo_comprobante.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radio_tipo_cuadratura.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding_Reporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.DateEdit dtp_desde;
        private DevExpress.XtraEditors.DateEdit dtp_hasta;
        private DevExpress.XtraEditors.RadioGroup radio_tipo_busqueda;
        private DevExpress.XtraEditors.LookUpEdit Look_tipo_comprobante;
        private DevExpress.XtraEditors.RadioGroup radio_tipo_cuadratura;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.GridControl grid_control_comprobantes;
        private DevExpress.XtraGrid.Views.Grid.GridView gview_detalle_comprobantes;
        private DevExpress.XtraGrid.Columns.GridColumn col_id;
        private DevExpress.XtraGrid.Columns.GridColumn col_id_comprobante;
        private DevExpress.XtraGrid.Columns.GridColumn col_nombre_cuenta;
        private DevExpress.XtraGrid.Columns.GridColumn col_debe;
        private DevExpress.XtraGrid.Columns.GridColumn col_haber;
        private DevExpress.XtraGrid.Views.Grid.GridView gview_comprobantes;
        private DevExpress.XtraGrid.Columns.GridColumn id_comprobante;
        private DevExpress.XtraGrid.Columns.GridColumn colnumero;
        private DevExpress.XtraGrid.Columns.GridColumn colfecha;
        private DevExpress.XtraGrid.Columns.GridColumn col_fecha_asiento;
        private DevExpress.XtraGrid.Columns.GridColumn colconcepto;
        private DevExpress.XtraGrid.Columns.GridColumn col_tipo_letras;
        private DevExpress.XtraGrid.Columns.GridColumn coltipo_numero;
        private DevExpress.XtraGrid.Columns.GridColumn colDebe;
        private DevExpress.XtraGrid.Columns.GridColumn colHaber;
        private DevExpress.XtraGrid.Columns.GridColumn col_Estado;
        private DevExpress.XtraGrid.Columns.GridColumn col_sucursal_numero;
        private DevExpress.XtraGrid.Columns.GridColumn col_conciliado;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraBars.BarButtonItem bbi_buscar;
        private DevExpress.XtraBars.Ribbon.RadialMenu menu;
        private DevExpress.XtraBars.BarLargeButtonItem blb_editar_asiento;
        private DevExpress.XtraBars.BarLargeButtonItem blb_Nuevo_Asiento;
        private DevExpress.XtraBars.BarLargeButtonItem blb_AnularAsiento;
        private DevExpress.XtraBars.BarLargeButtonItem blb_duplicarAsiento;
        private DevExpress.XtraBars.BarLargeButtonItem blb_ImprimrAsiento;
        private DevExpress.XtraGrid.Columns.GridColumn col_n_cuenta;
        private DevExpress.XtraBars.BarButtonItem bbi_expoortar_listado;
        private System.Windows.Forms.BindingSource binding_Reporte;
    }
}