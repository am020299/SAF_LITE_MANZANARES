namespace Presentacion.Formularios.Inventario
{
    partial class xfrm_consulta_Inventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xfrm_consulta_Inventario));
            this.grid_Consulta_Inventario = new DevExpress.XtraGrid.GridControl();
            this.gview_consulta = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbi_actualizar = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_exportar_excel = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Consulta_Inventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview_consulta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_Consulta_Inventario
            // 
            this.grid_Consulta_Inventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_Consulta_Inventario.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grid_Consulta_Inventario.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grid_Consulta_Inventario.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grid_Consulta_Inventario.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grid_Consulta_Inventario.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grid_Consulta_Inventario.Location = new System.Drawing.Point(0, 24);
            this.grid_Consulta_Inventario.MainView = this.gview_consulta;
            this.grid_Consulta_Inventario.Name = "grid_Consulta_Inventario";
            this.grid_Consulta_Inventario.Size = new System.Drawing.Size(790, 544);
            this.grid_Consulta_Inventario.TabIndex = 0;
            this.grid_Consulta_Inventario.UseEmbeddedNavigator = true;
            this.grid_Consulta_Inventario.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gview_consulta});
            // 
            // gview_consulta
            // 
            this.gview_consulta.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gview_consulta.Appearance.Row.Options.UseFont = true;
            this.gview_consulta.GridControl = this.grid_Consulta_Inventario;
            this.gview_consulta.Name = "gview_consulta";
            this.gview_consulta.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.gview_consulta.OptionsBehavior.AutoExpandAllGroups = true;
            this.gview_consulta.OptionsBehavior.Editable = false;
            this.gview_consulta.OptionsView.ShowAutoFilterRow = true;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbi_actualizar,
            this.bbi_exportar_excel});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 2;
            // 
            // bar2
            // 
            this.bar2.BarName = "Menú principal";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbi_actualizar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbi_exportar_excel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
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
            // bbi_exportar_excel
            // 
            this.bbi_exportar_excel.Caption = "EXPORTAR EXCEL";
            this.bbi_exportar_excel.Id = 1;
            this.bbi_exportar_excel.ImageOptions.Image = global::Presentacion.Properties.Resources.excel_16;
            this.bbi_exportar_excel.Name = "bbi_exportar_excel";
            this.bbi_exportar_excel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_exportar_excel_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(790, 24);
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
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 544);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(790, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 544);
            // 
            // xfrm_consulta_Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 568);
            this.Controls.Add(this.grid_Consulta_Inventario);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "xfrm_consulta_Inventario";
            this.Text = "CONSULTA DE INVENTARIO";
            this.Activated += new System.EventHandler(this.xfrm_consulta_Inventario_Activated);
            this.Load += new System.EventHandler(this.xfrm_consulta_Inventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Consulta_Inventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview_consulta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid_Consulta_Inventario;
        private DevExpress.XtraGrid.Views.Grid.GridView gview_consulta;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem bbi_actualizar;
        private DevExpress.XtraBars.BarButtonItem bbi_exportar_excel;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}