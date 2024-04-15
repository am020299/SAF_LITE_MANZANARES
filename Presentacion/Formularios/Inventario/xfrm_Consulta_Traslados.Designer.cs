namespace Presentacion.Formularios.Inventario
{
    partial class xfrm_Consulta_Traslados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xfrm_Consulta_Traslados));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btn_vaciar = new DevExpress.XtraEditors.SimpleButton();
            this.grid_control_traslados = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.iMPRIMIRTRASLADOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rEVERTIRTRASLADOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditarObservacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gview_traslados = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_numero_documento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_id_tipo_ajuste = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_tipo_ajuste = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_tipo_documento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_fecha_movimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_observaciom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_persona_referencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_empleado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_tipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_bodega = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_id_movimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.look_bodega = new DevExpress.XtraEditors.LookUpEdit();
            this.date_desde = new DevExpress.XtraEditors.DateEdit();
            this.date_hasta = new DevExpress.XtraEditors.DateEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.iMPRIMIRTRASLADOMCARTAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_control_traslados)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gview_traslados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.look_bodega.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_desde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_desde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_hasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_hasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.standaloneBarDockControl1);
            this.layoutControl1.Controls.Add(this.btn_vaciar);
            this.layoutControl1.Controls.Add(this.grid_control_traslados);
            this.layoutControl1.Controls.Add(this.look_bodega);
            this.layoutControl1.Controls.Add(this.date_desde);
            this.layoutControl1.Controls.Add(this.date_hasta);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(790, 568);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(12, 86);
            this.standaloneBarDockControl1.Manager = this.barManager1;
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(766, 20);
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
            this.barButtonItem1,
            this.barButtonItem2});
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.bar2.Text = "Menú principal";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "CARGAR";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "EXPORTAR";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
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
            // btn_vaciar
            // 
            this.btn_vaciar.Location = new System.Drawing.Point(310, 60);
            this.btn_vaciar.Name = "btn_vaciar";
            this.btn_vaciar.Size = new System.Drawing.Size(47, 22);
            this.btn_vaciar.StyleController = this.layoutControl1;
            this.btn_vaciar.TabIndex = 13;
            this.btn_vaciar.Text = "VACIAR";
            this.btn_vaciar.Click += new System.EventHandler(this.btn_vaciar_Click);
            // 
            // grid_control_traslados
            // 
            this.grid_control_traslados.ContextMenuStrip = this.contextMenuStrip1;
            this.grid_control_traslados.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grid_control_traslados.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grid_control_traslados.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grid_control_traslados.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grid_control_traslados.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grid_control_traslados.Location = new System.Drawing.Point(12, 110);
            this.grid_control_traslados.MainView = this.gview_traslados;
            this.grid_control_traslados.Name = "grid_control_traslados";
            this.grid_control_traslados.Size = new System.Drawing.Size(766, 446);
            this.grid_control_traslados.TabIndex = 10;
            this.grid_control_traslados.UseEmbeddedNavigator = true;
            this.grid_control_traslados.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gview_traslados});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iMPRIMIRTRASLADOToolStripMenuItem,
            this.iMPRIMIRTRASLADOMCARTAToolStripMenuItem,
            this.rEVERTIRTRASLADOToolStripMenuItem,
            this.EditarObservacionToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(253, 114);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // iMPRIMIRTRASLADOToolStripMenuItem
            // 
            this.iMPRIMIRTRASLADOToolStripMenuItem.Image = global::Presentacion.Properties.Resources.menu_16;
            this.iMPRIMIRTRASLADOToolStripMenuItem.Name = "iMPRIMIRTRASLADOToolStripMenuItem";
            this.iMPRIMIRTRASLADOToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.iMPRIMIRTRASLADOToolStripMenuItem.Text = "IMPRIMIR TRASLADO - CARTA";
            this.iMPRIMIRTRASLADOToolStripMenuItem.Click += new System.EventHandler(this.iMPRIMIRTRASLADOToolStripMenuItem_Click);
            // 
            // rEVERTIRTRASLADOToolStripMenuItem
            // 
            this.rEVERTIRTRASLADOToolStripMenuItem.Image = global::Presentacion.Properties.Resources.cambio_de_dinero_16;
            this.rEVERTIRTRASLADOToolStripMenuItem.Name = "rEVERTIRTRASLADOToolStripMenuItem";
            this.rEVERTIRTRASLADOToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.rEVERTIRTRASLADOToolStripMenuItem.Text = "REVERTIR TRASLADO";
            this.rEVERTIRTRASLADOToolStripMenuItem.Click += new System.EventHandler(this.rEVERTIRTRASLADOToolStripMenuItem_Click);
            // 
            // EditarObservacionToolStripMenuItem
            // 
            this.EditarObservacionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("EditarObservacionToolStripMenuItem.Image")));
            this.EditarObservacionToolStripMenuItem.Name = "EditarObservacionToolStripMenuItem";
            this.EditarObservacionToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.EditarObservacionToolStripMenuItem.Text = "EDITAR OBSERVACION";
            this.EditarObservacionToolStripMenuItem.Click += new System.EventHandler(this.EditarObservacionToolStripMenuItem_Click);
            // 
            // gview_traslados
            // 
            this.gview_traslados.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_numero_documento,
            this.col_id_tipo_ajuste,
            this.col_tipo_ajuste,
            this.col_tipo_documento,
            this.col_fecha_movimiento,
            this.col_observaciom,
            this.col_persona_referencia,
            this.col_empleado,
            this.col_tipo,
            this.col_bodega,
            this.col_id_movimiento});
            this.gview_traslados.GridControl = this.grid_control_traslados;
            this.gview_traslados.Name = "gview_traslados";
            this.gview_traslados.OptionsBehavior.Editable = false;
            this.gview_traslados.OptionsMenu.EnableColumnMenu = false;
            this.gview_traslados.OptionsView.ShowAutoFilterRow = true;
            this.gview_traslados.OptionsView.ShowGroupPanel = false;
            // 
            // col_numero_documento
            // 
            this.col_numero_documento.Caption = "NUMERO";
            this.col_numero_documento.FieldName = "numero_documento";
            this.col_numero_documento.Name = "col_numero_documento";
            this.col_numero_documento.Visible = true;
            this.col_numero_documento.VisibleIndex = 0;
            // 
            // col_id_tipo_ajuste
            // 
            this.col_id_tipo_ajuste.Caption = "id_tipo_ajuste";
            this.col_id_tipo_ajuste.FieldName = "id_tipo_ajuste";
            this.col_id_tipo_ajuste.Name = "col_id_tipo_ajuste";
            // 
            // col_tipo_ajuste
            // 
            this.col_tipo_ajuste.Caption = "TIPO AJUSTE";
            this.col_tipo_ajuste.FieldName = "tipo_ajuste";
            this.col_tipo_ajuste.Name = "col_tipo_ajuste";
            this.col_tipo_ajuste.Visible = true;
            this.col_tipo_ajuste.VisibleIndex = 3;
            // 
            // col_tipo_documento
            // 
            this.col_tipo_documento.Caption = "TIPO DOCUMENTO";
            this.col_tipo_documento.FieldName = "tipo_documento";
            this.col_tipo_documento.Name = "col_tipo_documento";
            // 
            // col_fecha_movimiento
            // 
            this.col_fecha_movimiento.Caption = "FECHA";
            this.col_fecha_movimiento.FieldName = "fecha_documento";
            this.col_fecha_movimiento.Name = "col_fecha_movimiento";
            this.col_fecha_movimiento.Visible = true;
            this.col_fecha_movimiento.VisibleIndex = 1;
            // 
            // col_observaciom
            // 
            this.col_observaciom.Caption = "OBSERVACION";
            this.col_observaciom.FieldName = "observacion";
            this.col_observaciom.Name = "col_observaciom";
            this.col_observaciom.Visible = true;
            this.col_observaciom.VisibleIndex = 5;
            // 
            // col_persona_referencia
            // 
            this.col_persona_referencia.Caption = "PERSONA REFERENCIA";
            this.col_persona_referencia.FieldName = "persona_referencia";
            this.col_persona_referencia.Name = "col_persona_referencia";
            // 
            // col_empleado
            // 
            this.col_empleado.Caption = "EMPLEADO";
            this.col_empleado.FieldName = "empleado";
            this.col_empleado.Name = "col_empleado";
            this.col_empleado.Visible = true;
            this.col_empleado.VisibleIndex = 4;
            // 
            // col_tipo
            // 
            this.col_tipo.Caption = "TIPO";
            this.col_tipo.FieldName = "tipo";
            this.col_tipo.Name = "col_tipo";
            // 
            // col_bodega
            // 
            this.col_bodega.Caption = "BODEGA";
            this.col_bodega.FieldName = "nombre";
            this.col_bodega.Name = "col_bodega";
            this.col_bodega.Visible = true;
            this.col_bodega.VisibleIndex = 2;
            // 
            // col_id_movimiento
            // 
            this.col_id_movimiento.Caption = "id_movimiento";
            this.col_id_movimiento.FieldName = "id";
            this.col_id_movimiento.Name = "col_id_movimiento";
            // 
            // look_bodega
            // 
            this.look_bodega.Location = new System.Drawing.Point(65, 60);
            this.look_bodega.Name = "look_bodega";
            this.look_bodega.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.look_bodega.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nombre", "NOMBRE")});
            this.look_bodega.Properties.DisplayMember = "nombre";
            this.look_bodega.Properties.ValueMember = "nombre";
            this.look_bodega.Size = new System.Drawing.Size(241, 20);
            this.look_bodega.StyleController = this.layoutControl1;
            this.look_bodega.TabIndex = 7;
            // 
            // date_desde
            // 
            this.date_desde.EditValue = null;
            this.date_desde.Location = new System.Drawing.Point(65, 12);
            this.date_desde.Name = "date_desde";
            this.date_desde.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.date_desde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_desde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_desde.Size = new System.Drawing.Size(292, 20);
            this.date_desde.StyleController = this.layoutControl1;
            this.date_desde.TabIndex = 8;
            // 
            // date_hasta
            // 
            this.date_hasta.EditValue = null;
            this.date_hasta.Location = new System.Drawing.Point(65, 36);
            this.date_hasta.Name = "date_hasta";
            this.date_hasta.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.date_hasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_hasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_hasta.Size = new System.Drawing.Size(292, 20);
            this.date_hasta.StyleController = this.layoutControl1;
            this.date_hasta.TabIndex = 9;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(790, 568);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.look_bodega;
            this.layoutControlItem4.CustomizationFormText = "BODEGA";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(298, 26);
            this.layoutControlItem4.Text = "BODEGA";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(41, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.date_desde;
            this.layoutControlItem5.CustomizationFormText = "DESDE";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(349, 24);
            this.layoutControlItem5.Text = "DESDE";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(41, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.date_hasta;
            this.layoutControlItem6.CustomizationFormText = "HASTA";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(349, 24);
            this.layoutControlItem6.Text = "HASTA";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(41, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grid_control_traslados;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 98);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(770, 450);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btn_vaciar;
            this.layoutControlItem2.Location = new System.Drawing.Point(298, 48);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(51, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(349, 0);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(421, 74);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(421, 74);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(421, 74);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.standaloneBarDockControl1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 74);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(770, 24);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(408, 86);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(76, 22);
            this.simpleButton2.TabIndex = 12;
            this.simpleButton2.Text = "VACIAR";
            // 
            // iMPRIMIRTRASLADOMCARTAToolStripMenuItem
            // 
            this.iMPRIMIRTRASLADOMCARTAToolStripMenuItem.Image = global::Presentacion.Properties.Resources.menu_16;
            this.iMPRIMIRTRASLADOMCARTAToolStripMenuItem.Name = "iMPRIMIRTRASLADOMCARTAToolStripMenuItem";
            this.iMPRIMIRTRASLADOMCARTAToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.iMPRIMIRTRASLADOMCARTAToolStripMenuItem.Text = "IMPRIMIR TRASLADO - M. CARTA";
            this.iMPRIMIRTRASLADOMCARTAToolStripMenuItem.Click += new System.EventHandler(this.iMPRIMIRTRASLADOMCARTAToolStripMenuItem_Click);
            // 
            // xfrm_Consulta_Traslados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 568);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "xfrm_Consulta_Traslados";
            this.Text = "CONSULTA DE TRASLADOS";
            this.Load += new System.EventHandler(this.xfrm_Consulta_Traslados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_control_traslados)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gview_traslados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.look_bodega.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_desde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_desde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_hasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_hasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.LookUpEdit look_bodega;
        private DevExpress.XtraEditors.DateEdit date_desde;
        private DevExpress.XtraEditors.DateEdit date_hasta;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraGrid.GridControl grid_control_traslados;
        private DevExpress.XtraGrid.Views.Grid.GridView gview_traslados;
        private DevExpress.XtraGrid.Columns.GridColumn col_numero_documento;
        private DevExpress.XtraGrid.Columns.GridColumn col_id_tipo_ajuste;
        private DevExpress.XtraGrid.Columns.GridColumn col_tipo_ajuste;
        private DevExpress.XtraGrid.Columns.GridColumn col_tipo_documento;
        private DevExpress.XtraGrid.Columns.GridColumn col_fecha_movimiento;
        private DevExpress.XtraGrid.Columns.GridColumn col_observaciom;
        private DevExpress.XtraGrid.Columns.GridColumn col_persona_referencia;
        private DevExpress.XtraGrid.Columns.GridColumn col_empleado;
        private DevExpress.XtraGrid.Columns.GridColumn col_tipo;
        private DevExpress.XtraGrid.Columns.GridColumn col_bodega;
        private DevExpress.XtraGrid.Columns.GridColumn col_id_movimiento;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SimpleButton btn_vaciar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem iMPRIMIRTRASLADOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rEVERTIRTRASLADOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditarObservacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iMPRIMIRTRASLADOMCARTAToolStripMenuItem;
    }
}