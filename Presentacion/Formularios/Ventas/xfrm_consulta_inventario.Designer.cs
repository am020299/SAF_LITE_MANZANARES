namespace Presentacion.Formularios.Ventas
{
    partial class xfrm_consulta_inventario
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
            DevExpress.XtraPivotGrid.PivotGridGroup pivotGridGroup1 = new DevExpress.XtraPivotGrid.PivotGridGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.pivot_Kardex_consulta = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.binding_Kardex = new System.Windows.Forms.BindingSource(this.components);
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.campo_id_producto = new DevExpress.XtraPivotGrid.PivotGridField();
            this.campo_id_lote = new DevExpress.XtraPivotGrid.PivotGridField();
            this.campo_lote = new DevExpress.XtraPivotGrid.PivotGridField();
            this.campo_codigo = new DevExpress.XtraPivotGrid.PivotGridField();
            this.campo_nombre_producto = new DevExpress.XtraPivotGrid.PivotGridField();
            this.campo_categoria = new DevExpress.XtraPivotGrid.PivotGridField();
            this.campo_marca = new DevExpress.XtraPivotGrid.PivotGridField();
            this.campo_id_bodega = new DevExpress.XtraPivotGrid.PivotGridField();
            this.campo_bodega = new DevExpress.XtraPivotGrid.PivotGridField();
            this.campo_ubicacion = new DevExpress.XtraPivotGrid.PivotGridField();
            this.campo_entradas = new DevExpress.XtraPivotGrid.PivotGridField();
            this.campo_salidas = new DevExpress.XtraPivotGrid.PivotGridField();
            this.campo_ajustes = new DevExpress.XtraPivotGrid.PivotGridField();
            this.campo_saldo_actual = new DevExpress.XtraPivotGrid.PivotGridField();
            this.campo_disponibilidad = new DevExpress.XtraPivotGrid.PivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivot_Kardex_consulta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding_Kardex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.pivot_Kardex_consulta);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1064, 575);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // pivot_Kardex_consulta
            // 
            this.pivot_Kardex_consulta.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.campo_id_producto,
            this.campo_id_lote,
            this.campo_lote,
            this.campo_codigo,
            this.campo_nombre_producto,
            this.campo_categoria,
            this.campo_marca,
            this.campo_id_bodega,
            this.campo_bodega,
            this.campo_ubicacion,
            this.campo_entradas,
            this.campo_salidas,
            this.campo_ajustes,
            this.campo_saldo_actual,
            this.campo_disponibilidad});
            pivotGridGroup1.Fields.Add(this.campo_categoria);
            this.pivot_Kardex_consulta.Groups.AddRange(new DevExpress.XtraPivotGrid.PivotGridGroup[] {
            pivotGridGroup1});
            this.pivot_Kardex_consulta.Location = new System.Drawing.Point(12, 12);
            this.pivot_Kardex_consulta.Name = "pivot_Kardex_consulta";
            this.pivot_Kardex_consulta.Size = new System.Drawing.Size(1040, 551);
            this.pivot_Kardex_consulta.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1064, 575);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.pivot_Kardex_consulta;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1044, 555);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // campo_id_producto
            // 
            this.campo_id_producto.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.campo_id_producto.AreaIndex = 0;
            this.campo_id_producto.FieldName = "id_producto";
            this.campo_id_producto.Name = "campo_id_producto";
            this.campo_id_producto.Visible = false;
            // 
            // campo_id_lote
            // 
            this.campo_id_lote.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.campo_id_lote.AreaIndex = 1;
            this.campo_id_lote.FieldName = "id_lote";
            this.campo_id_lote.Name = "campo_id_lote";
            this.campo_id_lote.Visible = false;
            // 
            // campo_lote
            // 
            this.campo_lote.AreaIndex = 2;
            this.campo_lote.Caption = "LOTE";
            this.campo_lote.FieldName = "lote";
            this.campo_lote.Name = "campo_lote";
            // 
            // campo_codigo
            // 
            this.campo_codigo.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.campo_codigo.AreaIndex = 0;
            this.campo_codigo.Caption = "CODIGO";
            this.campo_codigo.FieldName = "codigo";
            this.campo_codigo.Name = "campo_codigo";
            // 
            // campo_nombre_producto
            // 
            this.campo_nombre_producto.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.campo_nombre_producto.AreaIndex = 1;
            this.campo_nombre_producto.Caption = "DESCRIPCION";
            this.campo_nombre_producto.FieldName = "producto";
            this.campo_nombre_producto.Name = "campo_nombre_producto";
            // 
            // campo_categoria
            // 
            this.campo_categoria.AreaIndex = 0;
            this.campo_categoria.Caption = "GRUPO";
            this.campo_categoria.FieldName = "categoria";
            this.campo_categoria.Name = "campo_categoria";
            // 
            // campo_marca
            // 
            this.campo_marca.AreaIndex = 1;
            this.campo_marca.Caption = "MARCA";
            this.campo_marca.FieldName = "marca";
            this.campo_marca.Name = "campo_marca";
            // 
            // campo_id_bodega
            // 
            this.campo_id_bodega.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.campo_id_bodega.AreaIndex = 6;
            this.campo_id_bodega.Caption = "id_bodega";
            this.campo_id_bodega.FieldName = "id_bodega";
            this.campo_id_bodega.Name = "campo_id_bodega";
            this.campo_id_bodega.Visible = false;
            // 
            // campo_bodega
            // 
            this.campo_bodega.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.campo_bodega.AreaIndex = 0;
            this.campo_bodega.Caption = "BODEGA";
            this.campo_bodega.FieldName = "bodega";
            this.campo_bodega.Name = "campo_bodega";
            // 
            // campo_ubicacion
            // 
            this.campo_ubicacion.AreaIndex = 3;
            this.campo_ubicacion.Caption = "MODULO";
            this.campo_ubicacion.FieldName = "ubicacion";
            this.campo_ubicacion.Name = "campo_ubicacion";
            // 
            // campo_entradas
            // 
            this.campo_entradas.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.campo_entradas.AreaIndex = 8;
            this.campo_entradas.Caption = "ENTRADAS";
            this.campo_entradas.FieldName = "entradas";
            this.campo_entradas.Name = "campo_entradas";
            this.campo_entradas.Visible = false;
            // 
            // campo_salidas
            // 
            this.campo_salidas.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.campo_salidas.AreaIndex = 8;
            this.campo_salidas.Caption = "SALIDAS";
            this.campo_salidas.FieldName = "salidas";
            this.campo_salidas.Name = "campo_salidas";
            this.campo_salidas.Visible = false;
            // 
            // campo_ajustes
            // 
            this.campo_ajustes.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.campo_ajustes.AreaIndex = 8;
            this.campo_ajustes.Caption = "AJUSTES";
            this.campo_ajustes.FieldName = "ajuste";
            this.campo_ajustes.Name = "campo_ajustes";
            this.campo_ajustes.Visible = false;
            // 
            // campo_saldo_actual
            // 
            this.campo_saldo_actual.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.campo_saldo_actual.AreaIndex = 0;
            this.campo_saldo_actual.Caption = "SALDO ACTUAL";
            this.campo_saldo_actual.FieldName = "saldo_actual";
            this.campo_saldo_actual.Name = "campo_saldo_actual";
            // 
            // campo_disponibilidad
            // 
            this.campo_disponibilidad.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.campo_disponibilidad.AreaIndex = 9;
            this.campo_disponibilidad.Caption = "DISPONIBILIDAD";
            this.campo_disponibilidad.FieldName = "disponible";
            this.campo_disponibilidad.Name = "campo_disponibilidad";
            this.campo_disponibilidad.Visible = false;
            // 
            // xfrm_consulta_inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 575);
            this.Controls.Add(this.layoutControl1);
            this.Name = "xfrm_consulta_inventario";
            this.Text = "CONSULTA DE INVENTARIO ";
            this.Load += new System.EventHandler(this.xfrm_consulta_inventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pivot_Kardex_consulta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding_Kardex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraPivotGrid.PivotGridControl pivot_Kardex_consulta;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource binding_Kardex;
        private DevExpress.XtraPivotGrid.PivotGridField campo_id_producto;
        private DevExpress.XtraPivotGrid.PivotGridField campo_id_lote;
        private DevExpress.XtraPivotGrid.PivotGridField campo_lote;
        private DevExpress.XtraPivotGrid.PivotGridField campo_codigo;
        private DevExpress.XtraPivotGrid.PivotGridField campo_nombre_producto;
        private DevExpress.XtraPivotGrid.PivotGridField campo_categoria;
        private DevExpress.XtraPivotGrid.PivotGridField campo_marca;
        private DevExpress.XtraPivotGrid.PivotGridField campo_id_bodega;
        private DevExpress.XtraPivotGrid.PivotGridField campo_bodega;
        private DevExpress.XtraPivotGrid.PivotGridField campo_ubicacion;
        private DevExpress.XtraPivotGrid.PivotGridField campo_entradas;
        private DevExpress.XtraPivotGrid.PivotGridField campo_salidas;
        private DevExpress.XtraPivotGrid.PivotGridField campo_ajustes;
        private DevExpress.XtraPivotGrid.PivotGridField campo_saldo_actual;
        private DevExpress.XtraPivotGrid.PivotGridField campo_disponibilidad;
    }
}