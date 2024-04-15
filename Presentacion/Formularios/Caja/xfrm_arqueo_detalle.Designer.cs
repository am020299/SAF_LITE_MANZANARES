namespace Presentacion.Formularios.Caja
{
    partial class xfrm_arqueo_detalle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xfrm_arqueo_detalle));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txt_cheques_finales_suma = new DevExpress.XtraEditors.TextEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbi_reabrir = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_guardar = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_cerrar = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_imprimir = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_imprimir_arqueo_consolidado = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_imprimir_empleado = new DevExpress.XtraBars.BarButtonItem();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.txt_venta_esperada = new DevExpress.XtraEditors.TextEdit();
            this.txt_diferencia_en_caja = new DevExpress.XtraEditors.TextEdit();
            this.txt_venta_total = new DevExpress.XtraEditors.TextEdit();
            this.txt_venta_cordobizada = new DevExpress.XtraEditors.TextEdit();
            this.txt_venta_cordobas = new DevExpress.XtraEditors.TextEdit();
            this.txt_venta_dolares = new DevExpress.XtraEditors.TextEdit();
            this.txt_total_caja_final = new DevExpress.XtraEditors.TextEdit();
            this.txt_dolares_final = new DevExpress.XtraEditors.TextEdit();
            this.txt_cordobas_finales = new DevExpress.XtraEditors.TextEdit();
            this.txt_dolares_cordobizados_inicial = new DevExpress.XtraEditors.TextEdit();
            this.txt_total_caja_inicial = new DevExpress.XtraEditors.TextEdit();
            this.txt_total_dolares_inicial = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.grid_caja_final_dolares = new DevExpress.XtraGrid.GridControl();
            this.binding_final_dolares = new System.Windows.Forms.BindingSource(this.components);
            this.gview_caja_final_dolares = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_id_dolares_final = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_denominacion_dolares_final = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_cantidad_final_dolares = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_total_final_dolares = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_descripcion_final_dolares = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_tipo_denominacion_dolares = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.grid_caja_final_cordobas = new DevExpress.XtraGrid.GridControl();
            this.binding_final_cordobas = new System.Windows.Forms.BindingSource(this.components);
            this.gview_caja_final_cordobas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_caja_final_cordobas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_denominacion_fnal_cordobas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_cantidad_final_cordobas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_total_cordobas_final = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_final_cordobas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_id_tipo_deno_cordobas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_total_cordobas_iniciales = new DevExpress.XtraEditors.TextEdit();
            this.grid_inicial_dolares = new DevExpress.XtraGrid.GridControl();
            this.binding_inicial_dolares = new System.Windows.Forms.BindingSource(this.components);
            this.gview_caja_inicial_dolares = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_descripcion_dolares_inicial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_id_cantidad_dolares_inicial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_denominacion_inicial_dolar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_cantidad_dolares_inicial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_total_dolares_inicial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grid_caja_inicial_cordobas = new DevExpress.XtraGrid.GridControl();
            this.binding_inicial_cordobas = new System.Windows.Forms.BindingSource(this.components);
            this.gview_caja_inicial_cordobas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_id_inicial_cordobas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_descripcion_inicial_cordobas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_denominacion_inicial_cordobas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_cantidad_inicial_cordobas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_total_inicial_cordobas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.txt_tc = new DevExpress.XtraEditors.TextEdit();
            this.look_empleados = new DevExpress.XtraEditors.LookUpEdit();
            this.dt_fecha_arqueo = new DevExpress.XtraEditors.DateEdit();
            this.txt_dolares_cordobizados_final = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.panel_detalles_generales = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_cheques_finales_suma.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_venta_esperada.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_diferencia_en_caja.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_venta_total.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_venta_cordobizada.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_venta_cordobas.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_venta_dolares.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_total_caja_final.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_dolares_final.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_cordobas_finales.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_dolares_cordobizados_inicial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_total_caja_inicial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_total_dolares_inicial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_caja_final_dolares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding_final_dolares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview_caja_final_dolares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_caja_final_cordobas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding_final_cordobas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview_caja_final_cordobas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_total_cordobas_iniciales.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_inicial_dolares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding_inicial_dolares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview_caja_inicial_dolares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_caja_inicial_cordobas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding_inicial_cordobas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview_caja_inicial_cordobas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.look_empleados.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_fecha_arqueo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_fecha_arqueo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_dolares_cordobizados_final.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel_detalles_generales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_cheques_finales_suma);
            this.layoutControl1.Controls.Add(this.txt_venta_esperada);
            this.layoutControl1.Controls.Add(this.txt_diferencia_en_caja);
            this.layoutControl1.Controls.Add(this.txt_venta_total);
            this.layoutControl1.Controls.Add(this.txt_venta_cordobizada);
            this.layoutControl1.Controls.Add(this.txt_venta_cordobas);
            this.layoutControl1.Controls.Add(this.txt_venta_dolares);
            this.layoutControl1.Controls.Add(this.txt_total_caja_final);
            this.layoutControl1.Controls.Add(this.txt_dolares_final);
            this.layoutControl1.Controls.Add(this.txt_cordobas_finales);
            this.layoutControl1.Controls.Add(this.txt_dolares_cordobizados_inicial);
            this.layoutControl1.Controls.Add(this.txt_total_caja_inicial);
            this.layoutControl1.Controls.Add(this.txt_total_dolares_inicial);
            this.layoutControl1.Controls.Add(this.labelControl4);
            this.layoutControl1.Controls.Add(this.grid_caja_final_dolares);
            this.layoutControl1.Controls.Add(this.labelControl3);
            this.layoutControl1.Controls.Add(this.grid_caja_final_cordobas);
            this.layoutControl1.Controls.Add(this.labelControl2);
            this.layoutControl1.Controls.Add(this.labelControl1);
            this.layoutControl1.Controls.Add(this.standaloneBarDockControl1);
            this.layoutControl1.Controls.Add(this.txt_total_cordobas_iniciales);
            this.layoutControl1.Controls.Add(this.grid_inicial_dolares);
            this.layoutControl1.Controls.Add(this.grid_caja_inicial_cordobas);
            this.layoutControl1.Controls.Add(this.textEdit2);
            this.layoutControl1.Controls.Add(this.txt_tc);
            this.layoutControl1.Controls.Add(this.look_empleados);
            this.layoutControl1.Controls.Add(this.dt_fecha_arqueo);
            this.layoutControl1.Controls.Add(this.txt_dolares_cordobizados_final);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1044, 689);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt_cheques_finales_suma
            // 
            this.txt_cheques_finales_suma.Location = new System.Drawing.Point(639, 540);
            this.txt_cheques_finales_suma.MenuManager = this.barManager1;
            this.txt_cheques_finales_suma.Name = "txt_cheques_finales_suma";
            this.txt_cheques_finales_suma.Size = new System.Drawing.Size(115, 20);
            this.txt_cheques_finales_suma.StyleController = this.layoutControl1;
            this.txt_cheques_finales_suma.TabIndex = 35;
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
            this.bbi_guardar,
            this.bbi_cerrar,
            this.bbi_imprimir,
            this.bbi_reabrir,
            this.bbi_imprimir_arqueo_consolidado,
            this.bbi_imprimir_empleado});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 7;
            // 
            // bar2
            // 
            this.bar2.BarName = "Menú principal";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbi_reabrir),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbi_guardar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbi_cerrar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbi_imprimir, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbi_imprimir_arqueo_consolidado),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbi_imprimir_empleado)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.bar2.Text = "Menú principal";
            // 
            // bbi_reabrir
            // 
            this.bbi_reabrir.Caption = "REABRIR ARQUEO DE CAJA";
            this.bbi_reabrir.Id = 4;
            this.bbi_reabrir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbi_reabrir.ImageOptions.Image")));
            this.bbi_reabrir.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbi_reabrir.ImageOptions.LargeImage")));
            this.bbi_reabrir.Name = "bbi_reabrir";
            this.bbi_reabrir.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbi_reabrir.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbi_reabrir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_actualizar_ItemClick);
            // 
            // bbi_guardar
            // 
            this.bbi_guardar.Caption = "GUARDAR ARQUEO";
            this.bbi_guardar.Id = 0;
            this.bbi_guardar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbi_guardar.ImageOptions.Image")));
            this.bbi_guardar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbi_guardar.ImageOptions.LargeImage")));
            this.bbi_guardar.Name = "bbi_guardar";
            this.bbi_guardar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // bbi_cerrar
            // 
            this.bbi_cerrar.Caption = "CERRAR ARQUEO";
            this.bbi_cerrar.Id = 1;
            this.bbi_cerrar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbi_cerrar.ImageOptions.Image")));
            this.bbi_cerrar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbi_cerrar.ImageOptions.LargeImage")));
            this.bbi_cerrar.Name = "bbi_cerrar";
            this.bbi_cerrar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // bbi_imprimir
            // 
            this.bbi_imprimir.Caption = "IMPRIMIR";
            this.bbi_imprimir.Id = 3;
            this.bbi_imprimir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbi_imprimir.ImageOptions.Image")));
            this.bbi_imprimir.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbi_imprimir.ImageOptions.LargeImage")));
            this.bbi_imprimir.Name = "bbi_imprimir";
            this.bbi_imprimir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // bbi_imprimir_arqueo_consolidado
            // 
            this.bbi_imprimir_arqueo_consolidado.Caption = "IMPRIMIR CONSOLIDADO";
            this.bbi_imprimir_arqueo_consolidado.Id = 5;
            this.bbi_imprimir_arqueo_consolidado.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbi_imprimir_arqueo_consolidado.ImageOptions.Image")));
            this.bbi_imprimir_arqueo_consolidado.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbi_imprimir_arqueo_consolidado.ImageOptions.LargeImage")));
            this.bbi_imprimir_arqueo_consolidado.Name = "bbi_imprimir_arqueo_consolidado";
            this.bbi_imprimir_arqueo_consolidado.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbi_imprimir_arqueo_consolidado.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbi_imprimir_arqueo_consolidado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_imprimir_arqueo_consolidado_ItemClick);
            // 
            // bbi_imprimir_empleado
            // 
            this.bbi_imprimir_empleado.Caption = "IMPRIMIR ARQUEO POR EMPLEADO";
            this.bbi_imprimir_empleado.Id = 6;
            this.bbi_imprimir_empleado.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbi_imprimir_empleado.ImageOptions.Image")));
            this.bbi_imprimir_empleado.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbi_imprimir_empleado.ImageOptions.LargeImage")));
            this.bbi_imprimir_empleado.Name = "bbi_imprimir_empleado";
            this.bbi_imprimir_empleado.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbi_imprimir_empleado.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbi_imprimir_empleado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_imprimir_empleado_ItemClick);
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(12, 12);
            this.standaloneBarDockControl1.Manager = this.barManager1;
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(1020, 24);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1044, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 689);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1044, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 689);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1044, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 689);
            // 
            // txt_venta_esperada
            // 
            this.txt_venta_esperada.Location = new System.Drawing.Point(862, 621);
            this.txt_venta_esperada.MenuManager = this.barManager1;
            this.txt_venta_esperada.Name = "txt_venta_esperada";
            this.txt_venta_esperada.Properties.Mask.EditMask = "n2";
            this.txt_venta_esperada.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt_venta_esperada.Properties.UseReadOnlyAppearance = false;
            this.txt_venta_esperada.Size = new System.Drawing.Size(158, 20);
            this.txt_venta_esperada.StyleController = this.layoutControl1;
            this.txt_venta_esperada.TabIndex = 33;
            this.txt_venta_esperada.EditValueChanged += new System.EventHandler(this.txt_venta_esperada_EditValueChanged);
            // 
            // txt_diferencia_en_caja
            // 
            this.txt_diferencia_en_caja.Location = new System.Drawing.Point(862, 645);
            this.txt_diferencia_en_caja.MenuManager = this.barManager1;
            this.txt_diferencia_en_caja.Name = "txt_diferencia_en_caja";
            this.txt_diferencia_en_caja.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt_diferencia_en_caja.Properties.UseReadOnlyAppearance = false;
            this.txt_diferencia_en_caja.Size = new System.Drawing.Size(158, 20);
            this.txt_diferencia_en_caja.StyleController = this.layoutControl1;
            this.txt_diferencia_en_caja.TabIndex = 32;
            // 
            // txt_venta_total
            // 
            this.txt_venta_total.Location = new System.Drawing.Point(484, 645);
            this.txt_venta_total.MenuManager = this.barManager1;
            this.txt_venta_total.Name = "txt_venta_total";
            this.txt_venta_total.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt_venta_total.Properties.UseReadOnlyAppearance = false;
            this.txt_venta_total.Size = new System.Drawing.Size(227, 20);
            this.txt_venta_total.StyleController = this.layoutControl1;
            this.txt_venta_total.TabIndex = 31;
            this.txt_venta_total.EditValueChanged += new System.EventHandler(this.txt_venta_total_EditValueChanged);
            // 
            // txt_venta_cordobizada
            // 
            this.txt_venta_cordobizada.Location = new System.Drawing.Point(484, 621);
            this.txt_venta_cordobizada.MenuManager = this.barManager1;
            this.txt_venta_cordobizada.Name = "txt_venta_cordobizada";
            this.txt_venta_cordobizada.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt_venta_cordobizada.Properties.UseReadOnlyAppearance = false;
            this.txt_venta_cordobizada.Size = new System.Drawing.Size(227, 20);
            this.txt_venta_cordobizada.StyleController = this.layoutControl1;
            this.txt_venta_cordobizada.TabIndex = 30;
            // 
            // txt_venta_cordobas
            // 
            this.txt_venta_cordobas.Location = new System.Drawing.Point(171, 645);
            this.txt_venta_cordobas.MenuManager = this.barManager1;
            this.txt_venta_cordobas.Name = "txt_venta_cordobas";
            this.txt_venta_cordobas.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt_venta_cordobas.Properties.UseReadOnlyAppearance = false;
            this.txt_venta_cordobas.Size = new System.Drawing.Size(162, 20);
            this.txt_venta_cordobas.StyleController = this.layoutControl1;
            this.txt_venta_cordobas.TabIndex = 29;
            // 
            // txt_venta_dolares
            // 
            this.txt_venta_dolares.Location = new System.Drawing.Point(171, 621);
            this.txt_venta_dolares.MenuManager = this.barManager1;
            this.txt_venta_dolares.Name = "txt_venta_dolares";
            this.txt_venta_dolares.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt_venta_dolares.Properties.UseReadOnlyAppearance = false;
            this.txt_venta_dolares.Size = new System.Drawing.Size(162, 20);
            this.txt_venta_dolares.StyleController = this.layoutControl1;
            this.txt_venta_dolares.TabIndex = 28;
            // 
            // txt_total_caja_final
            // 
            this.txt_total_caja_final.Location = new System.Drawing.Point(639, 564);
            this.txt_total_caja_final.Name = "txt_total_caja_final";
            this.txt_total_caja_final.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt_total_caja_final.Properties.UseReadOnlyAppearance = false;
            this.txt_total_caja_final.Size = new System.Drawing.Size(115, 20);
            this.txt_total_caja_final.StyleController = this.layoutControl1;
            this.txt_total_caja_final.TabIndex = 26;
            this.txt_total_caja_final.EditValueChanged += new System.EventHandler(this.txt_total_caja_final_EditValueChanged);
            // 
            // txt_dolares_final
            // 
            this.txt_dolares_final.Location = new System.Drawing.Point(639, 516);
            this.txt_dolares_final.Name = "txt_dolares_final";
            this.txt_dolares_final.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt_dolares_final.Properties.UseReadOnlyAppearance = false;
            this.txt_dolares_final.Size = new System.Drawing.Size(115, 20);
            this.txt_dolares_final.StyleController = this.layoutControl1;
            this.txt_dolares_final.TabIndex = 25;
            // 
            // txt_cordobas_finales
            // 
            this.txt_cordobas_finales.Location = new System.Drawing.Point(905, 516);
            this.txt_cordobas_finales.Name = "txt_cordobas_finales";
            this.txt_cordobas_finales.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt_cordobas_finales.Properties.UseReadOnlyAppearance = false;
            this.txt_cordobas_finales.Size = new System.Drawing.Size(127, 20);
            this.txt_cordobas_finales.StyleController = this.layoutControl1;
            this.txt_cordobas_finales.TabIndex = 24;
            this.txt_cordobas_finales.EditValueChanged += new System.EventHandler(this.txt_cordobas_finales_EditValueChanged);
            // 
            // txt_dolares_cordobizados_inicial
            // 
            this.txt_dolares_cordobizados_inicial.Location = new System.Drawing.Point(401, 540);
            this.txt_dolares_cordobizados_inicial.MenuManager = this.barManager1;
            this.txt_dolares_cordobizados_inicial.Name = "txt_dolares_cordobizados_inicial";
            this.txt_dolares_cordobizados_inicial.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt_dolares_cordobizados_inicial.Properties.UseReadOnlyAppearance = false;
            this.txt_dolares_cordobizados_inicial.Size = new System.Drawing.Size(87, 20);
            this.txt_dolares_cordobizados_inicial.StyleController = this.layoutControl1;
            this.txt_dolares_cordobizados_inicial.TabIndex = 22;
            // 
            // txt_total_caja_inicial
            // 
            this.txt_total_caja_inicial.Location = new System.Drawing.Point(159, 540);
            this.txt_total_caja_inicial.MenuManager = this.barManager1;
            this.txt_total_caja_inicial.Name = "txt_total_caja_inicial";
            this.txt_total_caja_inicial.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt_total_caja_inicial.Properties.UseReadOnlyAppearance = false;
            this.txt_total_caja_inicial.Size = new System.Drawing.Size(91, 20);
            this.txt_total_caja_inicial.StyleController = this.layoutControl1;
            this.txt_total_caja_inicial.TabIndex = 21;
            this.txt_total_caja_inicial.EditValueChanged += new System.EventHandler(this.txt_total_caja_inicial_EditValueChanged);
            // 
            // txt_total_dolares_inicial
            // 
            this.txt_total_dolares_inicial.Location = new System.Drawing.Point(401, 516);
            this.txt_total_dolares_inicial.MenuManager = this.barManager1;
            this.txt_total_dolares_inicial.Name = "txt_total_dolares_inicial";
            this.txt_total_dolares_inicial.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt_total_dolares_inicial.Properties.UseReadOnlyAppearance = false;
            this.txt_total_dolares_inicial.Size = new System.Drawing.Size(87, 20);
            this.txt_total_dolares_inicial.StyleController = this.layoutControl1;
            this.txt_total_dolares_inicial.TabIndex = 20;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(758, 133);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(134, 24);
            this.labelControl4.StyleController = this.layoutControl1;
            this.labelControl4.TabIndex = 18;
            this.labelControl4.Text = "FINAL DOLARES";
            // 
            // grid_caja_final_dolares
            // 
            this.grid_caja_final_dolares.DataSource = this.binding_final_dolares;
            this.grid_caja_final_dolares.Location = new System.Drawing.Point(758, 161);
            this.grid_caja_final_dolares.MainView = this.gview_caja_final_dolares;
            this.grid_caja_final_dolares.MenuManager = this.barManager1;
            this.grid_caja_final_dolares.Name = "grid_caja_final_dolares";
            this.grid_caja_final_dolares.Size = new System.Drawing.Size(274, 351);
            this.grid_caja_final_dolares.TabIndex = 17;
            this.grid_caja_final_dolares.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gview_caja_final_dolares});
            // 
            // gview_caja_final_dolares
            // 
            this.gview_caja_final_dolares.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_id_dolares_final,
            this.col_denominacion_dolares_final,
            this.col_cantidad_final_dolares,
            this.col_total_final_dolares,
            this.col_descripcion_final_dolares,
            this.col_tipo_denominacion_dolares,
            this.gridColumn1});
            this.gview_caja_final_dolares.GridControl = this.grid_caja_final_dolares;
            this.gview_caja_final_dolares.Name = "gview_caja_final_dolares";
            this.gview_caja_final_dolares.OptionsCustomization.AllowColumnMoving = false;
            this.gview_caja_final_dolares.OptionsNavigation.EnterMoveNextColumn = true;
            this.gview_caja_final_dolares.OptionsView.ShowFooter = true;
            this.gview_caja_final_dolares.OptionsView.ShowGroupPanel = false;
            this.gview_caja_final_dolares.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.gview_caja_final_dolares_CustomSummaryCalculate);
            this.gview_caja_final_dolares.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gview_caja_final_dolares_ShowingEditor);
            this.gview_caja_final_dolares.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gview_caja_final_dolares_ValidateRow);
            // 
            // col_id_dolares_final
            // 
            this.col_id_dolares_final.Caption = "id";
            this.col_id_dolares_final.FieldName = "id";
            this.col_id_dolares_final.Name = "col_id_dolares_final";
            this.col_id_dolares_final.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_id_dolares_final.OptionsFilter.AllowFilter = false;
            // 
            // col_denominacion_dolares_final
            // 
            this.col_denominacion_dolares_final.Caption = "DENOMINACION2";
            this.col_denominacion_dolares_final.DisplayFormat.FormatString = "n2";
            this.col_denominacion_dolares_final.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_denominacion_dolares_final.FieldName = "denominaciones";
            this.col_denominacion_dolares_final.Name = "col_denominacion_dolares_final";
            this.col_denominacion_dolares_final.OptionsColumn.AllowEdit = false;
            this.col_denominacion_dolares_final.OptionsColumn.AllowFocus = false;
            this.col_denominacion_dolares_final.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_denominacion_dolares_final.OptionsFilter.AllowFilter = false;
            this.col_denominacion_dolares_final.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            // 
            // col_cantidad_final_dolares
            // 
            this.col_cantidad_final_dolares.Caption = "CANTIDAD";
            this.col_cantidad_final_dolares.DisplayFormat.FormatString = "n2";
            this.col_cantidad_final_dolares.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_cantidad_final_dolares.FieldName = "cantidad";
            this.col_cantidad_final_dolares.Name = "col_cantidad_final_dolares";
            this.col_cantidad_final_dolares.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_cantidad_final_dolares.OptionsFilter.AllowFilter = false;
            this.col_cantidad_final_dolares.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "total", "{0:n2}", "1"),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "cantidad", "{0:n2}", "3"),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "cantidad", "{0:n2}", "4"),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "cantidad", "{0:n2}", "5"),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "cantidad", "{0:n2}", "6"),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "cantidad", "{0:n2}", "7")});
            this.col_cantidad_final_dolares.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.col_cantidad_final_dolares.Visible = true;
            this.col_cantidad_final_dolares.VisibleIndex = 1;
            // 
            // col_total_final_dolares
            // 
            this.col_total_final_dolares.Caption = "TOTAL";
            this.col_total_final_dolares.DisplayFormat.FormatString = "n2";
            this.col_total_final_dolares.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_total_final_dolares.FieldName = "total";
            this.col_total_final_dolares.Name = "col_total_final_dolares";
            this.col_total_final_dolares.OptionsColumn.AllowEdit = false;
            this.col_total_final_dolares.OptionsColumn.AllowFocus = false;
            this.col_total_final_dolares.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_total_final_dolares.OptionsFilter.AllowFilter = false;
            this.col_total_final_dolares.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "total", "{0:n2}", ((short)(2)))});
            this.col_total_final_dolares.UnboundExpression = "ToDecimal([cantidad]) * ToDecimal([denominaciones])";
            this.col_total_final_dolares.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            // 
            // col_descripcion_final_dolares
            // 
            this.col_descripcion_final_dolares.Caption = "DENOMINACION";
            this.col_descripcion_final_dolares.FieldName = "descripcion";
            this.col_descripcion_final_dolares.Name = "col_descripcion_final_dolares";
            this.col_descripcion_final_dolares.OptionsColumn.AllowEdit = false;
            this.col_descripcion_final_dolares.OptionsColumn.AllowFocus = false;
            this.col_descripcion_final_dolares.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_descripcion_final_dolares.OptionsFilter.AllowFilter = false;
            this.col_descripcion_final_dolares.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "descripcion", "$ CHEQUES "),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "descripcion", "$VALES"),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "descripcion", "$ VOUCHERS"),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "descripcion", "$ TRANSFERENCIA"),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "descripcion", "$ SALDOS APLICADOS")});
            this.col_descripcion_final_dolares.Visible = true;
            this.col_descripcion_final_dolares.VisibleIndex = 0;
            // 
            // col_tipo_denominacion_dolares
            // 
            this.col_tipo_denominacion_dolares.Caption = "tipo_denominacion";
            this.col_tipo_denominacion_dolares.FieldName = "tipo_denominacion";
            this.col_tipo_denominacion_dolares.Name = "col_tipo_denominacion_dolares";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "TOTAL";
            this.gridColumn1.DisplayFormat.FormatString = "{0:n2}";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "total1";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "total1", "{0:n2}", 2)});
            this.gridColumn1.UnboundExpression = "ToDecimal([cantidad]) * ToDecimal([denominaciones])";
            this.gridColumn1.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(492, 133);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(115, 24);
            this.labelControl3.StyleController = this.layoutControl1;
            this.labelControl3.TabIndex = 16;
            this.labelControl3.Text = "FINAL CORDOBAS";
            // 
            // grid_caja_final_cordobas
            // 
            this.grid_caja_final_cordobas.DataSource = this.binding_final_cordobas;
            this.grid_caja_final_cordobas.Location = new System.Drawing.Point(492, 161);
            this.grid_caja_final_cordobas.MainView = this.gview_caja_final_cordobas;
            this.grid_caja_final_cordobas.MenuManager = this.barManager1;
            this.grid_caja_final_cordobas.Name = "grid_caja_final_cordobas";
            this.grid_caja_final_cordobas.Size = new System.Drawing.Size(262, 351);
            this.grid_caja_final_cordobas.TabIndex = 15;
            this.grid_caja_final_cordobas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gview_caja_final_cordobas});
            // 
            // gview_caja_final_cordobas
            // 
            this.gview_caja_final_cordobas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_caja_final_cordobas,
            this.col_denominacion_fnal_cordobas,
            this.col_cantidad_final_cordobas,
            this.col_total_cordobas_final,
            this.col_final_cordobas,
            this.col_id_tipo_deno_cordobas,
            this.gridColumn2});
            this.gview_caja_final_cordobas.GridControl = this.grid_caja_final_cordobas;
            this.gview_caja_final_cordobas.Name = "gview_caja_final_cordobas";
            this.gview_caja_final_cordobas.OptionsCustomization.AllowColumnMoving = false;
            this.gview_caja_final_cordobas.OptionsNavigation.EnterMoveNextColumn = true;
            this.gview_caja_final_cordobas.OptionsView.ShowFooter = true;
            this.gview_caja_final_cordobas.OptionsView.ShowGroupPanel = false;
            this.gview_caja_final_cordobas.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.gview_caja_final_cordobas_CustomSummaryCalculate);
            this.gview_caja_final_cordobas.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gview_caja_final_cordobas_ShowingEditor);
            this.gview_caja_final_cordobas.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gview_caja_final_cordobas_ValidateRow);
            // 
            // col_caja_final_cordobas
            // 
            this.col_caja_final_cordobas.Caption = "id";
            this.col_caja_final_cordobas.Name = "col_caja_final_cordobas";
            this.col_caja_final_cordobas.OptionsColumn.AllowEdit = false;
            this.col_caja_final_cordobas.OptionsColumn.AllowFocus = false;
            this.col_caja_final_cordobas.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_caja_final_cordobas.OptionsFilter.AllowFilter = false;
            this.col_caja_final_cordobas.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            // 
            // col_denominacion_fnal_cordobas
            // 
            this.col_denominacion_fnal_cordobas.Caption = "DENOMINACION2";
            this.col_denominacion_fnal_cordobas.FieldName = "denominaciones";
            this.col_denominacion_fnal_cordobas.Name = "col_denominacion_fnal_cordobas";
            this.col_denominacion_fnal_cordobas.OptionsColumn.AllowEdit = false;
            this.col_denominacion_fnal_cordobas.OptionsColumn.AllowFocus = false;
            this.col_denominacion_fnal_cordobas.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_denominacion_fnal_cordobas.OptionsFilter.AllowFilter = false;
            this.col_denominacion_fnal_cordobas.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.col_denominacion_fnal_cordobas.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.col_denominacion_fnal_cordobas.Width = 92;
            // 
            // col_cantidad_final_cordobas
            // 
            this.col_cantidad_final_cordobas.Caption = "CANTIDAD";
            this.col_cantidad_final_cordobas.FieldName = "cantidad";
            this.col_cantidad_final_cordobas.Name = "col_cantidad_final_cordobas";
            this.col_cantidad_final_cordobas.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_cantidad_final_cordobas.OptionsFilter.AllowFilter = false;
            this.col_cantidad_final_cordobas.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.col_cantidad_final_cordobas.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "total", "{0:n2}", ((short)(1))),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "cantidad", "{0:n2}", "3"),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "cantidad", "{0:n2}", ((short)(4))),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "cantidad", "{0:n2}", "5"),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "cantidad", "{0:n2}", "6"),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "cantidad", "{0:n2}", "7")});
            this.col_cantidad_final_cordobas.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.col_cantidad_final_cordobas.Visible = true;
            this.col_cantidad_final_cordobas.VisibleIndex = 1;
            this.col_cantidad_final_cordobas.Width = 64;
            // 
            // col_total_cordobas_final
            // 
            this.col_total_cordobas_final.Caption = "TOTAL";
            this.col_total_cordobas_final.DisplayFormat.FormatString = "n2";
            this.col_total_cordobas_final.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_total_cordobas_final.FieldName = "total";
            this.col_total_cordobas_final.Name = "col_total_cordobas_final";
            this.col_total_cordobas_final.OptionsColumn.AllowEdit = false;
            this.col_total_cordobas_final.OptionsColumn.AllowFocus = false;
            this.col_total_cordobas_final.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_total_cordobas_final.OptionsFilter.AllowFilter = false;
            this.col_total_cordobas_final.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.col_total_cordobas_final.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "total", "{0:n2}", ((short)(2)))});
            this.col_total_cordobas_final.Width = 70;
            // 
            // col_final_cordobas
            // 
            this.col_final_cordobas.Caption = "DENOMINACION";
            this.col_final_cordobas.FieldName = "descripcion";
            this.col_final_cordobas.Name = "col_final_cordobas";
            this.col_final_cordobas.OptionsColumn.AllowEdit = false;
            this.col_final_cordobas.OptionsColumn.AllowFocus = false;
            this.col_final_cordobas.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_final_cordobas.OptionsFilter.AllowFilter = false;
            this.col_final_cordobas.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.col_final_cordobas.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "descripcion", "C$ CHEQUES"),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "descripcion", "C$ VALES"),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "descripcion", "C$ VOUCHERS"),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "descripcion", "C$ TRANSFERENCIA"),
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "descripcion", "C$ SALDOS APLICADOS")});
            this.col_final_cordobas.Visible = true;
            this.col_final_cordobas.VisibleIndex = 0;
            // 
            // col_id_tipo_deno_cordobas
            // 
            this.col_id_tipo_deno_cordobas.Caption = "col_id_tipo_deno";
            this.col_id_tipo_deno_cordobas.FieldName = "tipo_denominacion";
            this.col_id_tipo_deno_cordobas.Name = "col_id_tipo_deno_cordobas";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "TOTAL";
            this.gridColumn2.DisplayFormat.FormatString = "n2";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "total1";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "total1", "{0:n2}", 2)});
            this.gridColumn2.UnboundExpression = "ToDecimal([cantidad]) * ToDecimal([denominaciones])";
            this.gridColumn2.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(254, 133);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(116, 24);
            this.labelControl2.StyleController = this.layoutControl1;
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "INICIAL DOLARES";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 133);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(128, 24);
            this.labelControl1.StyleController = this.layoutControl1;
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "INICIAL CORDOBAS";
            // 
            // txt_total_cordobas_iniciales
            // 
            this.txt_total_cordobas_iniciales.Location = new System.Drawing.Point(159, 516);
            this.txt_total_cordobas_iniciales.Name = "txt_total_cordobas_iniciales";
            this.txt_total_cordobas_iniciales.Properties.Mask.EditMask = "n2";
            this.txt_total_cordobas_iniciales.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt_total_cordobas_iniciales.Properties.UseReadOnlyAppearance = false;
            this.txt_total_cordobas_iniciales.Size = new System.Drawing.Size(91, 20);
            this.txt_total_cordobas_iniciales.StyleController = this.layoutControl1;
            this.txt_total_cordobas_iniciales.TabIndex = 11;
            // 
            // grid_inicial_dolares
            // 
            this.grid_inicial_dolares.DataSource = this.binding_inicial_dolares;
            this.grid_inicial_dolares.Location = new System.Drawing.Point(254, 161);
            this.grid_inicial_dolares.MainView = this.gview_caja_inicial_dolares;
            this.grid_inicial_dolares.Name = "grid_inicial_dolares";
            this.grid_inicial_dolares.Size = new System.Drawing.Size(234, 351);
            this.grid_inicial_dolares.TabIndex = 10;
            this.grid_inicial_dolares.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gview_caja_inicial_dolares});
            this.grid_inicial_dolares.Click += new System.EventHandler(this.grid_inicial_dolares_Click);
            // 
            // gview_caja_inicial_dolares
            // 
            this.gview_caja_inicial_dolares.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_descripcion_dolares_inicial,
            this.col_id_cantidad_dolares_inicial,
            this.col_denominacion_inicial_dolar,
            this.col_cantidad_dolares_inicial,
            this.col_total_dolares_inicial});
            this.gview_caja_inicial_dolares.GridControl = this.grid_inicial_dolares;
            this.gview_caja_inicial_dolares.Name = "gview_caja_inicial_dolares";
            this.gview_caja_inicial_dolares.OptionsCustomization.AllowColumnMoving = false;
            this.gview_caja_inicial_dolares.OptionsNavigation.EnterMoveNextColumn = true;
            this.gview_caja_inicial_dolares.OptionsView.ShowFooter = true;
            this.gview_caja_inicial_dolares.OptionsView.ShowGroupPanel = false;
            this.gview_caja_inicial_dolares.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gview_caja_inicial_dolares_ValidateRow);
            // 
            // col_descripcion_dolares_inicial
            // 
            this.col_descripcion_dolares_inicial.Caption = "DENOMINACION";
            this.col_descripcion_dolares_inicial.FieldName = "descripcion";
            this.col_descripcion_dolares_inicial.Name = "col_descripcion_dolares_inicial";
            this.col_descripcion_dolares_inicial.OptionsColumn.AllowEdit = false;
            this.col_descripcion_dolares_inicial.OptionsColumn.AllowFocus = false;
            this.col_descripcion_dolares_inicial.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_descripcion_dolares_inicial.OptionsFilter.AllowFilter = false;
            this.col_descripcion_dolares_inicial.Visible = true;
            this.col_descripcion_dolares_inicial.VisibleIndex = 0;
            // 
            // col_id_cantidad_dolares_inicial
            // 
            this.col_id_cantidad_dolares_inicial.Caption = "id";
            this.col_id_cantidad_dolares_inicial.FieldName = "id";
            this.col_id_cantidad_dolares_inicial.Name = "col_id_cantidad_dolares_inicial";
            this.col_id_cantidad_dolares_inicial.OptionsColumn.AllowEdit = false;
            this.col_id_cantidad_dolares_inicial.OptionsColumn.AllowFocus = false;
            this.col_id_cantidad_dolares_inicial.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_id_cantidad_dolares_inicial.OptionsFilter.AllowFilter = false;
            // 
            // col_denominacion_inicial_dolar
            // 
            this.col_denominacion_inicial_dolar.Caption = "DENOMINACION";
            this.col_denominacion_inicial_dolar.FieldName = "denominaciones";
            this.col_denominacion_inicial_dolar.Name = "col_denominacion_inicial_dolar";
            this.col_denominacion_inicial_dolar.OptionsColumn.AllowEdit = false;
            this.col_denominacion_inicial_dolar.OptionsColumn.AllowFocus = false;
            this.col_denominacion_inicial_dolar.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_denominacion_inicial_dolar.OptionsFilter.AllowFilter = false;
            this.col_denominacion_inicial_dolar.Width = 100;
            // 
            // col_cantidad_dolares_inicial
            // 
            this.col_cantidad_dolares_inicial.Caption = "CANTIDAD";
            this.col_cantidad_dolares_inicial.FieldName = "cantidad";
            this.col_cantidad_dolares_inicial.Name = "col_cantidad_dolares_inicial";
            this.col_cantidad_dolares_inicial.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_cantidad_dolares_inicial.OptionsFilter.AllowFilter = false;
            this.col_cantidad_dolares_inicial.Visible = true;
            this.col_cantidad_dolares_inicial.VisibleIndex = 1;
            this.col_cantidad_dolares_inicial.Width = 74;
            // 
            // col_total_dolares_inicial
            // 
            this.col_total_dolares_inicial.Caption = "TOTAL";
            this.col_total_dolares_inicial.DisplayFormat.FormatString = "n2";
            this.col_total_dolares_inicial.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_total_dolares_inicial.FieldName = "total";
            this.col_total_dolares_inicial.Name = "col_total_dolares_inicial";
            this.col_total_dolares_inicial.OptionsColumn.AllowEdit = false;
            this.col_total_dolares_inicial.OptionsColumn.AllowFocus = false;
            this.col_total_dolares_inicial.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_total_dolares_inicial.OptionsFilter.AllowFilter = false;
            this.col_total_dolares_inicial.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:n2}")});
            this.col_total_dolares_inicial.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.col_total_dolares_inicial.Visible = true;
            this.col_total_dolares_inicial.VisibleIndex = 2;
            this.col_total_dolares_inicial.Width = 51;
            // 
            // grid_caja_inicial_cordobas
            // 
            this.grid_caja_inicial_cordobas.DataSource = this.binding_inicial_cordobas;
            this.grid_caja_inicial_cordobas.Location = new System.Drawing.Point(12, 161);
            this.grid_caja_inicial_cordobas.MainView = this.gview_caja_inicial_cordobas;
            this.grid_caja_inicial_cordobas.Name = "grid_caja_inicial_cordobas";
            this.grid_caja_inicial_cordobas.Size = new System.Drawing.Size(238, 351);
            this.grid_caja_inicial_cordobas.TabIndex = 9;
            this.grid_caja_inicial_cordobas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gview_caja_inicial_cordobas});
            // 
            // binding_inicial_cordobas
            // 
            this.binding_inicial_cordobas.AllowNew = false;
            // 
            // gview_caja_inicial_cordobas
            // 
            this.gview_caja_inicial_cordobas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_id_inicial_cordobas,
            this.col_descripcion_inicial_cordobas,
            this.col_denominacion_inicial_cordobas,
            this.col_cantidad_inicial_cordobas,
            this.col_total_inicial_cordobas});
            this.gview_caja_inicial_cordobas.GridControl = this.grid_caja_inicial_cordobas;
            this.gview_caja_inicial_cordobas.Name = "gview_caja_inicial_cordobas";
            this.gview_caja_inicial_cordobas.OptionsCustomization.AllowColumnMoving = false;
            this.gview_caja_inicial_cordobas.OptionsCustomization.AllowFilter = false;
            this.gview_caja_inicial_cordobas.OptionsCustomization.AllowGroup = false;
            this.gview_caja_inicial_cordobas.OptionsCustomization.AllowSort = false;
            this.gview_caja_inicial_cordobas.OptionsMenu.EnableColumnMenu = false;
            this.gview_caja_inicial_cordobas.OptionsNavigation.EnterMoveNextColumn = true;
            this.gview_caja_inicial_cordobas.OptionsView.ShowFooter = true;
            this.gview_caja_inicial_cordobas.OptionsView.ShowGroupPanel = false;
            this.gview_caja_inicial_cordobas.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gview_caja_inicial_cordobas_ValidateRow);
            this.gview_caja_inicial_cordobas.CustomRowFilter += new DevExpress.XtraGrid.Views.Base.RowFilterEventHandler(this.gview_caja_inicial_cordobas_CustomRowFilter);
            this.gview_caja_inicial_cordobas.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.gview_caja_inicial_cordobas_InvalidValueException);
            // 
            // col_id_inicial_cordobas
            // 
            this.col_id_inicial_cordobas.Caption = "id";
            this.col_id_inicial_cordobas.FieldName = "id_denominacion";
            this.col_id_inicial_cordobas.Name = "col_id_inicial_cordobas";
            this.col_id_inicial_cordobas.OptionsColumn.AllowEdit = false;
            this.col_id_inicial_cordobas.OptionsColumn.AllowFocus = false;
            // 
            // col_descripcion_inicial_cordobas
            // 
            this.col_descripcion_inicial_cordobas.Caption = "DENOMINACION";
            this.col_descripcion_inicial_cordobas.FieldName = "descripcion";
            this.col_descripcion_inicial_cordobas.Name = "col_descripcion_inicial_cordobas";
            this.col_descripcion_inicial_cordobas.OptionsColumn.AllowEdit = false;
            this.col_descripcion_inicial_cordobas.OptionsColumn.AllowFocus = false;
            this.col_descripcion_inicial_cordobas.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_descripcion_inicial_cordobas.OptionsFilter.AllowFilter = false;
            this.col_descripcion_inicial_cordobas.Visible = true;
            this.col_descripcion_inicial_cordobas.VisibleIndex = 0;
            // 
            // col_denominacion_inicial_cordobas
            // 
            this.col_denominacion_inicial_cordobas.Caption = "DENOMINACION";
            this.col_denominacion_inicial_cordobas.FieldName = "denominaciones";
            this.col_denominacion_inicial_cordobas.Name = "col_denominacion_inicial_cordobas";
            this.col_denominacion_inicial_cordobas.OptionsColumn.AllowEdit = false;
            this.col_denominacion_inicial_cordobas.OptionsColumn.AllowFocus = false;
            this.col_denominacion_inicial_cordobas.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_denominacion_inicial_cordobas.OptionsFilter.AllowFilter = false;
            this.col_denominacion_inicial_cordobas.Width = 94;
            // 
            // col_cantidad_inicial_cordobas
            // 
            this.col_cantidad_inicial_cordobas.Caption = "CANTIDAD";
            this.col_cantidad_inicial_cordobas.FieldName = "cantidad";
            this.col_cantidad_inicial_cordobas.Name = "col_cantidad_inicial_cordobas";
            this.col_cantidad_inicial_cordobas.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_cantidad_inicial_cordobas.OptionsFilter.AllowFilter = false;
            this.col_cantidad_inicial_cordobas.Visible = true;
            this.col_cantidad_inicial_cordobas.VisibleIndex = 1;
            this.col_cantidad_inicial_cordobas.Width = 70;
            // 
            // col_total_inicial_cordobas
            // 
            this.col_total_inicial_cordobas.Caption = "TOTAL";
            this.col_total_inicial_cordobas.DisplayFormat.FormatString = "n2";
            this.col_total_inicial_cordobas.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.col_total_inicial_cordobas.FieldName = "total";
            this.col_total_inicial_cordobas.Name = "col_total_inicial_cordobas";
            this.col_total_inicial_cordobas.OptionsColumn.AllowEdit = false;
            this.col_total_inicial_cordobas.OptionsColumn.AllowFocus = false;
            this.col_total_inicial_cordobas.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.col_total_inicial_cordobas.OptionsFilter.AllowFilter = false;
            this.col_total_inicial_cordobas.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:n2}")});
            this.col_total_inicial_cordobas.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.col_total_inicial_cordobas.Visible = true;
            this.col_total_inicial_cordobas.VisibleIndex = 2;
            this.col_total_inicial_cordobas.Width = 51;
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(171, 97);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.ReadOnly = true;
            this.textEdit2.Size = new System.Drawing.Size(288, 20);
            this.textEdit2.StyleController = this.layoutControl1;
            this.textEdit2.TabIndex = 7;
            // 
            // txt_tc
            // 
            this.txt_tc.Location = new System.Drawing.Point(610, 97);
            this.txt_tc.Name = "txt_tc";
            this.txt_tc.Properties.ReadOnly = true;
            this.txt_tc.Size = new System.Drawing.Size(410, 20);
            this.txt_tc.StyleController = this.layoutControl1;
            this.txt_tc.TabIndex = 6;
            // 
            // look_empleados
            // 
            this.look_empleados.Location = new System.Drawing.Point(610, 73);
            this.look_empleados.Name = "look_empleados";
            this.look_empleados.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.look_empleados.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_empleado", "id_empleado", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nombre", "NOMBRE")});
            this.look_empleados.Properties.DisplayMember = "nombre";
            this.look_empleados.Properties.DropDownRows = 5;
            this.look_empleados.Properties.ValueMember = "id";
            this.look_empleados.Size = new System.Drawing.Size(410, 20);
            this.look_empleados.StyleController = this.layoutControl1;
            this.look_empleados.TabIndex = 5;
            // 
            // dt_fecha_arqueo
            // 
            this.dt_fecha_arqueo.EditValue = null;
            this.dt_fecha_arqueo.Location = new System.Drawing.Point(171, 73);
            this.dt_fecha_arqueo.Name = "dt_fecha_arqueo";
            this.dt_fecha_arqueo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dt_fecha_arqueo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dt_fecha_arqueo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dt_fecha_arqueo.Properties.CalendarTimeProperties.Mask.EditMask = "d";
            this.dt_fecha_arqueo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dt_fecha_arqueo.Size = new System.Drawing.Size(288, 20);
            this.dt_fecha_arqueo.StyleController = this.layoutControl1;
            this.dt_fecha_arqueo.TabIndex = 4;
            this.dt_fecha_arqueo.EditValueChanged += new System.EventHandler(this.dt_fecha_arqueo_EditValueChanged);
            // 
            // txt_dolares_cordobizados_final
            // 
            this.txt_dolares_cordobizados_final.Location = new System.Drawing.Point(905, 540);
            this.txt_dolares_cordobizados_final.Name = "txt_dolares_cordobizados_final";
            this.txt_dolares_cordobizados_final.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt_dolares_cordobizados_final.Properties.UseReadOnlyAppearance = false;
            this.txt_dolares_cordobizados_final.Size = new System.Drawing.Size(127, 20);
            this.txt_dolares_cordobizados_final.StyleController = this.layoutControl1;
            this.txt_dolares_cordobizados_final.TabIndex = 26;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1,
            this.layoutControlItem5,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem12,
            this.layoutControlItem14,
            this.layoutControlItem11,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.layoutControlItem13,
            this.emptySpaceItem4,
            this.layoutControlItem15,
            this.layoutControlItem16,
            this.layoutControlItem17,
            this.layoutControlItem8,
            this.panel_detalles_generales,
            this.layoutControlItem19,
            this.layoutControlItem20,
            this.layoutControlItem21,
            this.layoutControlItem18,
            this.layoutControlItem28,
            this.emptySpaceItem5,
            this.emptySpaceItem6,
            this.emptySpaceItem7});
            this.Root.Name = "Root";
            this.Root.ShowInCustomizationForm = false;
            this.Root.Size = new System.Drawing.Size(1044, 689);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.ExpandButtonVisible = true;
            this.layoutControlGroup1.ExpandOnDoubleClick = true;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 28);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1024, 93);
            this.layoutControlGroup1.Text = "DATOS ARQUEO";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dt_fecha_arqueo;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(439, 24);
            this.layoutControlItem1.Text = "FECHA:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(135, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txt_tc;
            this.layoutControlItem3.Location = new System.Drawing.Point(439, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(561, 24);
            this.layoutControlItem3.Text = "T/C";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(135, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.look_empleados;
            this.layoutControlItem2.Location = new System.Drawing.Point(439, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(561, 24);
            this.layoutControlItem2.Text = "EMPLEADO";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(135, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.textEdit2;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(439, 24);
            this.layoutControlItem4.Text = "NUMERO:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(135, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.standaloneBarDockControl1;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(1024, 28);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.labelControl1;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 121);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(124, 18);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(132, 28);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.labelControl2;
            this.layoutControlItem10.Location = new System.Drawing.Point(242, 121);
            this.layoutControlItem10.MinSize = new System.Drawing.Size(113, 18);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(120, 28);
            this.layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.grid_caja_inicial_cordobas;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 149);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(104, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(242, 355);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.grid_inicial_dolares;
            this.layoutControlItem7.Location = new System.Drawing.Point(242, 149);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(104, 24);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(238, 355);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.labelControl3;
            this.layoutControlItem12.Location = new System.Drawing.Point(480, 121);
            this.layoutControlItem12.MinSize = new System.Drawing.Size(112, 18);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(119, 28);
            this.layoutControlItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.labelControl4;
            this.layoutControlItem14.Location = new System.Drawing.Point(746, 121);
            this.layoutControlItem14.MinSize = new System.Drawing.Size(111, 17);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(138, 28);
            this.layoutControlItem14.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem14.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem14.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.grid_caja_final_cordobas;
            this.layoutControlItem11.Location = new System.Drawing.Point(480, 149);
            this.layoutControlItem11.MinSize = new System.Drawing.Size(104, 24);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(266, 355);
            this.layoutControlItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(132, 121);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(110, 28);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(362, 121);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(118, 28);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(599, 121);
            this.emptySpaceItem3.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(147, 28);
            this.emptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.grid_caja_final_dolares;
            this.layoutControlItem13.Location = new System.Drawing.Point(746, 149);
            this.layoutControlItem13.MinSize = new System.Drawing.Size(104, 24);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(278, 355);
            this.layoutControlItem13.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextVisible = false;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(884, 121);
            this.emptySpaceItem4.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(140, 28);
            this.emptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.txt_total_dolares_inicial;
            this.layoutControlItem15.Location = new System.Drawing.Point(242, 504);
            this.layoutControlItem15.MinSize = new System.Drawing.Size(187, 24);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(238, 24);
            this.layoutControlItem15.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem15.Text = "TOTAL DOLARES";
            this.layoutControlItem15.TextSize = new System.Drawing.Size(135, 13);
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.txt_total_caja_inicial;
            this.layoutControlItem16.Location = new System.Drawing.Point(0, 528);
            this.layoutControlItem16.MinSize = new System.Drawing.Size(216, 24);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(242, 24);
            this.layoutControlItem16.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem16.Text = "TOTAL CAJA INICIAL";
            this.layoutControlItem16.TextSize = new System.Drawing.Size(135, 13);
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.txt_dolares_cordobizados_inicial;
            this.layoutControlItem17.Location = new System.Drawing.Point(242, 528);
            this.layoutControlItem17.MinSize = new System.Drawing.Size(187, 24);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(238, 24);
            this.layoutControlItem17.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem17.Text = "DOLARES CORDOBIZADOS";
            this.layoutControlItem17.TextSize = new System.Drawing.Size(135, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txt_total_cordobas_iniciales;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 504);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(216, 24);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(242, 24);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.Text = "TOTAL CORDOBAS";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(135, 13);
            // 
            // panel_detalles_generales
            // 
            this.panel_detalles_generales.ExpandButtonVisible = true;
            this.panel_detalles_generales.ExpandOnDoubleClick = true;
            this.panel_detalles_generales.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem22,
            this.layoutControlItem23,
            this.layoutControlItem25,
            this.layoutControlItem24,
            this.layoutControlItem27,
            this.layoutControlItem26});
            this.panel_detalles_generales.Location = new System.Drawing.Point(0, 576);
            this.panel_detalles_generales.Name = "panel_detalles_generales";
            this.panel_detalles_generales.Size = new System.Drawing.Size(1024, 93);
            this.panel_detalles_generales.Tag = "100";
            this.panel_detalles_generales.Text = "DETALLES GENERALES";
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.txt_venta_dolares;
            this.layoutControlItem22.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(313, 24);
            this.layoutControlItem22.Text = "Venta Unicrese dolares";
            this.layoutControlItem22.TextSize = new System.Drawing.Size(135, 13);
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.Control = this.txt_venta_cordobas;
            this.layoutControlItem23.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(313, 24);
            this.layoutControlItem23.Text = "Venta Mochila Cordobas";
            this.layoutControlItem23.TextSize = new System.Drawing.Size(135, 13);
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.Control = this.txt_venta_total;
            this.layoutControlItem25.Location = new System.Drawing.Point(313, 24);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new System.Drawing.Size(378, 24);
            this.layoutControlItem25.Text = "Venta Total Segun Sistema";
            this.layoutControlItem25.TextSize = new System.Drawing.Size(135, 13);
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.Control = this.txt_venta_cordobizada;
            this.layoutControlItem24.Location = new System.Drawing.Point(313, 0);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new System.Drawing.Size(378, 24);
            this.layoutControlItem24.Text = "Venta Unicrese Cordobizado";
            this.layoutControlItem24.TextSize = new System.Drawing.Size(135, 13);
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.Control = this.txt_venta_esperada;
            this.layoutControlItem27.Location = new System.Drawing.Point(691, 0);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(309, 24);
            this.layoutControlItem27.Text = "Venta Sugerida";
            this.layoutControlItem27.TextSize = new System.Drawing.Size(135, 13);
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.Control = this.txt_diferencia_en_caja;
            this.layoutControlItem26.Location = new System.Drawing.Point(691, 24);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Size = new System.Drawing.Size(309, 24);
            this.layoutControlItem26.Text = "Diferencia en caja";
            this.layoutControlItem26.TextSize = new System.Drawing.Size(135, 13);
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.txt_dolares_final;
            this.layoutControlItem19.Location = new System.Drawing.Point(480, 504);
            this.layoutControlItem19.MinSize = new System.Drawing.Size(187, 24);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(266, 24);
            this.layoutControlItem19.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem19.Text = "TOTAL DOLARES";
            this.layoutControlItem19.TextSize = new System.Drawing.Size(135, 13);
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.txt_total_caja_final;
            this.layoutControlItem20.Location = new System.Drawing.Point(480, 552);
            this.layoutControlItem20.MinSize = new System.Drawing.Size(187, 24);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(266, 24);
            this.layoutControlItem20.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem20.Text = "TOTAL CAJA FINAL";
            this.layoutControlItem20.TextSize = new System.Drawing.Size(135, 13);
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.txt_dolares_cordobizados_final;
            this.layoutControlItem21.CustomizationFormText = "layoutControlItem20";
            this.layoutControlItem21.Location = new System.Drawing.Point(746, 528);
            this.layoutControlItem21.MinSize = new System.Drawing.Size(187, 24);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(278, 24);
            this.layoutControlItem21.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem21.Text = "DOLARES CORDOBIZADOS";
            this.layoutControlItem21.TextSize = new System.Drawing.Size(135, 13);
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.txt_cordobas_finales;
            this.layoutControlItem18.Location = new System.Drawing.Point(746, 504);
            this.layoutControlItem18.MinSize = new System.Drawing.Size(187, 24);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(278, 24);
            this.layoutControlItem18.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem18.Text = "TOTAL CORDOBAS";
            this.layoutControlItem18.TextSize = new System.Drawing.Size(135, 13);
            // 
            // layoutControlItem28
            // 
            this.layoutControlItem28.Control = this.txt_cheques_finales_suma;
            this.layoutControlItem28.Location = new System.Drawing.Point(480, 528);
            this.layoutControlItem28.MinSize = new System.Drawing.Size(187, 24);
            this.layoutControlItem28.Name = "layoutControlItem28";
            this.layoutControlItem28.Size = new System.Drawing.Size(266, 24);
            this.layoutControlItem28.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem28.Text = "CHEQUES";
            this.layoutControlItem28.TextSize = new System.Drawing.Size(135, 13);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(746, 552);
            this.emptySpaceItem5.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(278, 24);
            this.emptySpaceItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.Location = new System.Drawing.Point(242, 552);
            this.emptySpaceItem6.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(238, 24);
            this.emptySpaceItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem7
            // 
            this.emptySpaceItem7.AllowHotTrack = false;
            this.emptySpaceItem7.Location = new System.Drawing.Point(0, 552);
            this.emptySpaceItem7.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem7.Name = "emptySpaceItem7";
            this.emptySpaceItem7.Size = new System.Drawing.Size(242, 24);
            this.emptySpaceItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
            // 
            // xfrm_arqueo_detalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 689);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "xfrm_arqueo_detalle";
            this.Text = "ARQUEO";
            this.Activated += new System.EventHandler(this.xfrm_arqueo_detalle_Activated);
            this.Load += new System.EventHandler(this.xfrm_arqueo_detalle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_cheques_finales_suma.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_venta_esperada.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_diferencia_en_caja.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_venta_total.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_venta_cordobizada.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_venta_cordobas.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_venta_dolares.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_total_caja_final.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_dolares_final.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_cordobas_finales.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_dolares_cordobizados_inicial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_total_caja_inicial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_total_dolares_inicial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_caja_final_dolares)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding_final_dolares)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview_caja_final_dolares)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_caja_final_cordobas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding_final_cordobas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview_caja_final_cordobas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_total_cordobas_iniciales.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_inicial_dolares)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding_inicial_dolares)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview_caja_inicial_dolares)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_caja_inicial_cordobas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding_inicial_cordobas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview_caja_inicial_cordobas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.look_empleados.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_fecha_arqueo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_fecha_arqueo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_dolares_cordobizados_final.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel_detalles_generales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit txt_tc;
        private DevExpress.XtraEditors.LookUpEdit look_empleados;
        private DevExpress.XtraEditors.DateEdit dt_fecha_arqueo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.TextEdit txt_total_cordobas_iniciales;
        private DevExpress.XtraGrid.GridControl grid_inicial_dolares;
        private DevExpress.XtraGrid.Views.Grid.GridView gview_caja_inicial_dolares;
        private DevExpress.XtraGrid.GridControl grid_caja_inicial_cordobas;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.Views.Grid.GridView gview_caja_inicial_cordobas;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem bbi_guardar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraBars.BarButtonItem bbi_cerrar;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraGrid.GridControl grid_caja_final_dolares;
        private DevExpress.XtraGrid.Views.Grid.GridView gview_caja_final_dolares;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.GridControl grid_caja_final_cordobas;
        private DevExpress.XtraGrid.Views.Grid.GridView gview_caja_final_cordobas;
        private DevExpress.XtraGrid.Columns.GridColumn col_id_inicial_cordobas;
        private DevExpress.XtraGrid.Columns.GridColumn col_denominacion_inicial_cordobas;
        private DevExpress.XtraGrid.Columns.GridColumn col_cantidad_inicial_cordobas;
        private DevExpress.XtraGrid.Columns.GridColumn col_total_inicial_cordobas;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private System.Windows.Forms.BindingSource binding_inicial_cordobas;
        private DevExpress.XtraGrid.Columns.GridColumn col_id_cantidad_dolares_inicial;
        private DevExpress.XtraGrid.Columns.GridColumn col_denominacion_inicial_dolar;
        private DevExpress.XtraGrid.Columns.GridColumn col_cantidad_dolares_inicial;
        private DevExpress.XtraGrid.Columns.GridColumn col_total_dolares_inicial;
        private System.Windows.Forms.BindingSource binding_inicial_dolares;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraGrid.Columns.GridColumn col_caja_final_cordobas;
        private DevExpress.XtraGrid.Columns.GridColumn col_denominacion_fnal_cordobas;
        private DevExpress.XtraGrid.Columns.GridColumn col_cantidad_final_cordobas;
        private DevExpress.XtraGrid.Columns.GridColumn col_total_cordobas_final;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraGrid.Columns.GridColumn col_id_dolares_final;
        private DevExpress.XtraGrid.Columns.GridColumn col_denominacion_dolares_final;
        private DevExpress.XtraGrid.Columns.GridColumn col_cantidad_final_dolares;
        private DevExpress.XtraGrid.Columns.GridColumn col_total_final_dolares;
        private System.Windows.Forms.BindingSource binding_final_cordobas;
        private System.Windows.Forms.BindingSource binding_final_dolares;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.TextEdit txt_dolares_cordobizados_inicial;
        private DevExpress.XtraEditors.TextEdit txt_total_caja_inicial;
        private DevExpress.XtraEditors.TextEdit txt_total_dolares_inicial;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraGrid.Columns.GridColumn col_descripcion_inicial_cordobas;
        private DevExpress.XtraGrid.Columns.GridColumn col_descripcion_dolares_inicial;
        private DevExpress.XtraGrid.Columns.GridColumn col_descripcion_final_dolares;
        private DevExpress.XtraGrid.Columns.GridColumn col_final_cordobas;
        private DevExpress.XtraEditors.TextEdit txt_total_caja_final;
        private DevExpress.XtraEditors.TextEdit txt_dolares_final;
        private DevExpress.XtraEditors.TextEdit txt_cordobas_finales;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraEditors.TextEdit txt_dolares_cordobizados_final;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraEditors.TextEdit txt_venta_esperada;
        private DevExpress.XtraEditors.TextEdit txt_diferencia_en_caja;
        private DevExpress.XtraEditors.TextEdit txt_venta_total;
        private DevExpress.XtraEditors.TextEdit txt_venta_cordobizada;
        private DevExpress.XtraEditors.TextEdit txt_venta_cordobas;
        private DevExpress.XtraEditors.TextEdit txt_venta_dolares;
        private DevExpress.XtraLayout.LayoutControlGroup panel_detalles_generales;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private DevExpress.XtraBars.BarButtonItem bbi_imprimir;
        private DevExpress.XtraEditors.TextEdit txt_cheques_finales_suma;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem28;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraGrid.Columns.GridColumn col_tipo_denominacion_dolares;
        private DevExpress.XtraGrid.Columns.GridColumn col_id_tipo_deno_cordobas;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraBars.BarButtonItem bbi_reabrir;
        private DevExpress.XtraBars.BarButtonItem bbi_imprimir_arqueo_consolidado;
        private DevExpress.XtraBars.BarButtonItem bbi_imprimir_empleado;
    }
}