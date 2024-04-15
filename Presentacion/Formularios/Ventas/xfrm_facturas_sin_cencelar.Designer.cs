namespace Presentacion.Formularios.Ventas
{
    partial class xfrm_facturas_sin_cencelar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xfrm_facturas_sin_cencelar));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btn_Actualizar = new DevExpress.XtraEditors.SimpleButton();
            this.grid_facturas = new DevExpress.XtraGrid.GridControl();
            this.gview_Facturas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_n_factura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_fecha_ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_total = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_moneda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_id_factura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.source = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_facturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview_Facturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.source)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btn_Actualizar);
            this.layoutControl1.Controls.Add(this.grid_facturas);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(789, 580);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btn_Actualizar
            // 
            this.btn_Actualizar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Actualizar.ImageOptions.Image")));
            this.btn_Actualizar.Location = new System.Drawing.Point(548, 12);
            this.btn_Actualizar.Name = "btn_Actualizar";
            this.btn_Actualizar.Size = new System.Drawing.Size(229, 36);
            this.btn_Actualizar.StyleController = this.layoutControl1;
            this.btn_Actualizar.TabIndex = 5;
            this.btn_Actualizar.Text = "ACTUALIZAR";
            this.btn_Actualizar.Click += new System.EventHandler(this.btn_Actualizar_Click);
            // 
            // grid_facturas
            // 
            this.grid_facturas.Location = new System.Drawing.Point(12, 52);
            this.grid_facturas.MainView = this.gview_Facturas;
            this.grid_facturas.Name = "grid_facturas";
            this.grid_facturas.Size = new System.Drawing.Size(765, 516);
            this.grid_facturas.TabIndex = 4;
            this.grid_facturas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gview_Facturas});
            // 
            // gview_Facturas
            // 
            this.gview_Facturas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_n_factura,
            this.col_cliente,
            this.col_fecha_,
            this.col_total,
            this.col_moneda,
            this.col_id_factura,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gview_Facturas.GridControl = this.grid_facturas;
            this.gview_Facturas.Name = "gview_Facturas";
            this.gview_Facturas.OptionsBehavior.Editable = false;
            this.gview_Facturas.OptionsCustomization.AllowColumnMoving = false;
            this.gview_Facturas.OptionsCustomization.AllowGroup = false;
            this.gview_Facturas.OptionsView.ShowGroupPanel = false;
            this.gview_Facturas.DoubleClick += new System.EventHandler(this.gview_Facturas_DoubleClick);
            // 
            // col_n_factura
            // 
            this.col_n_factura.Caption = "N° FACTURA";
            this.col_n_factura.FieldName = "numero";
            this.col_n_factura.Name = "col_n_factura";
            this.col_n_factura.Visible = true;
            this.col_n_factura.VisibleIndex = 0;
            // 
            // col_cliente
            // 
            this.col_cliente.Caption = "CLIENTE";
            this.col_cliente.FieldName = "cliente";
            this.col_cliente.Name = "col_cliente";
            this.col_cliente.Visible = true;
            this.col_cliente.VisibleIndex = 1;
            // 
            // col_fecha_
            // 
            this.col_fecha_.Caption = "FECHA";
            this.col_fecha_.FieldName = "fecha";
            this.col_fecha_.Name = "col_fecha_";
            this.col_fecha_.Visible = true;
            this.col_fecha_.VisibleIndex = 2;
            // 
            // col_total
            // 
            this.col_total.Caption = "TOTAL FACTURA";
            this.col_total.FieldName = "total";
            this.col_total.Name = "col_total";
            this.col_total.Visible = true;
            this.col_total.VisibleIndex = 3;
            // 
            // col_moneda
            // 
            this.col_moneda.Caption = "MONEDA";
            this.col_moneda.FieldName = "moneda_factura";
            this.col_moneda.Name = "col_moneda";
            this.col_moneda.Visible = true;
            this.col_moneda.VisibleIndex = 4;
            // 
            // col_id_factura
            // 
            this.col_id_factura.Caption = "id_factura";
            this.col_id_factura.FieldName = "id";
            this.col_id_factura.Name = "col_id_factura";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.FieldName = "tipo_documento";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.FieldName = "moneda";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "ID_DOCUMENTO_CXC";
            this.gridColumn3.FieldName = "id_documento_cxc";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Es Cambio";
            this.gridColumn4.FieldName = "esCambio";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(789, 580);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grid_facturas;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(769, 520);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btn_Actualizar;
            this.layoutControlItem2.Location = new System.Drawing.Point(536, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(233, 40);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(536, 40);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // timer
            // 
            this.timer.Interval = 10000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // xfrm_facturas_sin_cencelar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 580);
            this.Controls.Add(this.layoutControl1);
            this.Name = "xfrm_facturas_sin_cencelar";
            this.Text = "PAGAR FACTURAS";
            this.Activated += new System.EventHandler(this.xfrm_facturas_sin_cencelar_Activated);
            this.Load += new System.EventHandler(this.xfrm_facturas_sin_cencelar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_facturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview_Facturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.source)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl grid_facturas;
        private DevExpress.XtraGrid.Views.Grid.GridView gview_Facturas;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn col_n_factura;
        private DevExpress.XtraGrid.Columns.GridColumn col_cliente;
        private DevExpress.XtraGrid.Columns.GridColumn col_fecha_;
        private DevExpress.XtraGrid.Columns.GridColumn col_total;
        private DevExpress.XtraGrid.Columns.GridColumn col_moneda;
        private DevExpress.XtraEditors.SimpleButton btn_Actualizar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.Timer timer;
        private DevExpress.XtraGrid.Columns.GridColumn col_id_factura;
        private System.Windows.Forms.BindingSource source;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}