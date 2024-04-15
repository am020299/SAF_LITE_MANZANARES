namespace Presentacion.Formularios.Mantenimiento
{
    partial class xfrm_usuarios_logueados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xfrm_usuarios_logueados));
            this.gridControl_Usuarios_Logueados = new DevExpress.XtraGrid.GridControl();
            this.click_derecho_usuarios_logueados = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView_Usuarios_Logueados = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn74 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn75 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn76 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn77 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn78 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn79 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn80 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbi_actualizar = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Usuarios_Logueados)).BeginInit();
            this.click_derecho_usuarios_logueados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Usuarios_Logueados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_Usuarios_Logueados
            // 
            this.gridControl_Usuarios_Logueados.ContextMenuStrip = this.click_derecho_usuarios_logueados;
            this.gridControl_Usuarios_Logueados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Usuarios_Logueados.Location = new System.Drawing.Point(0, 40);
            this.gridControl_Usuarios_Logueados.MainView = this.gridView_Usuarios_Logueados;
            this.gridControl_Usuarios_Logueados.Name = "gridControl_Usuarios_Logueados";
            this.gridControl_Usuarios_Logueados.Size = new System.Drawing.Size(1077, 549);
            this.gridControl_Usuarios_Logueados.TabIndex = 1;
            this.gridControl_Usuarios_Logueados.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Usuarios_Logueados});
            // 
            // click_derecho_usuarios_logueados
            // 
            this.click_derecho_usuarios_logueados.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarSesiónToolStripMenuItem});
            this.click_derecho_usuarios_logueados.Name = "click_derecho_usuarios_logueados";
            this.click_derecho_usuarios_logueados.Size = new System.Drawing.Size(144, 26);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Image = global::Presentacion.Properties.Resources.logout;
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // gridView_Usuarios_Logueados
            // 
            this.gridView_Usuarios_Logueados.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_Usuarios_Logueados.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView_Usuarios_Logueados.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn74,
            this.gridColumn75,
            this.gridColumn76,
            this.gridColumn77,
            this.gridColumn78,
            this.gridColumn79,
            this.gridColumn80});
            this.gridView_Usuarios_Logueados.GridControl = this.gridControl_Usuarios_Logueados;
            this.gridView_Usuarios_Logueados.Name = "gridView_Usuarios_Logueados";
            this.gridView_Usuarios_Logueados.OptionsView.ShowAutoFilterRow = true;
            this.gridView_Usuarios_Logueados.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn74
            // 
            this.gridColumn74.Caption = "LOGIN";
            this.gridColumn74.FieldName = "id_login";
            this.gridColumn74.Name = "gridColumn74";
            // 
            // gridColumn75
            // 
            this.gridColumn75.Caption = "ID EMPLEADO";
            this.gridColumn75.FieldName = "id_empleado";
            this.gridColumn75.Name = "gridColumn75";
            // 
            // gridColumn76
            // 
            this.gridColumn76.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn76.AppearanceHeader.Options.UseFont = true;
            this.gridColumn76.Caption = "NOMBRE";
            this.gridColumn76.FieldName = "nombre";
            this.gridColumn76.Name = "gridColumn76";
            this.gridColumn76.OptionsColumn.AllowEdit = false;
            this.gridColumn76.Visible = true;
            this.gridColumn76.VisibleIndex = 0;
            // 
            // gridColumn77
            // 
            this.gridColumn77.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn77.AppearanceHeader.Options.UseFont = true;
            this.gridColumn77.Caption = "CARGO";
            this.gridColumn77.FieldName = "cargo";
            this.gridColumn77.Name = "gridColumn77";
            this.gridColumn77.OptionsColumn.AllowEdit = false;
            this.gridColumn77.Visible = true;
            this.gridColumn77.VisibleIndex = 1;
            // 
            // gridColumn78
            // 
            this.gridColumn78.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn78.AppearanceHeader.Options.UseFont = true;
            this.gridColumn78.Caption = "USUARIO";
            this.gridColumn78.FieldName = "usuario";
            this.gridColumn78.Name = "gridColumn78";
            this.gridColumn78.OptionsColumn.AllowEdit = false;
            this.gridColumn78.Visible = true;
            this.gridColumn78.VisibleIndex = 2;
            // 
            // gridColumn79
            // 
            this.gridColumn79.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn79.AppearanceHeader.Options.UseFont = true;
            this.gridColumn79.Caption = "FECHA";
            this.gridColumn79.FieldName = "fecha";
            this.gridColumn79.Name = "gridColumn79";
            this.gridColumn79.OptionsColumn.AllowEdit = false;
            this.gridColumn79.Visible = true;
            this.gridColumn79.VisibleIndex = 3;
            // 
            // gridColumn80
            // 
            this.gridColumn80.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn80.AppearanceHeader.Options.UseFont = true;
            this.gridColumn80.Caption = "HORA DE INICIO";
            this.gridColumn80.FieldName = "hora_inicio";
            this.gridColumn80.Name = "gridColumn80";
            this.gridColumn80.OptionsColumn.AllowEdit = false;
            this.gridColumn80.Visible = true;
            this.gridColumn80.VisibleIndex = 4;
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
            this.bbi_actualizar});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 1;
            // 
            // bar2
            // 
            this.bar2.BarName = "Menú principal";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbi_actualizar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menú principal";
            // 
            // bbi_actualizar
            // 
            this.bbi_actualizar.Caption = "Actualizar";
            this.bbi_actualizar.Id = 0;
            this.bbi_actualizar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbi_actualizar.ImageOptions.Image")));
            this.bbi_actualizar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbi_actualizar.ImageOptions.LargeImage")));
            this.bbi_actualizar.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbi_actualizar.ItemAppearance.Normal.Options.UseFont = true;
            this.bbi_actualizar.Name = "bbi_actualizar";
            this.bbi_actualizar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_actualizar_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1077, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 589);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1077, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 549);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1077, 40);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 549);
            // 
            // xfrm_usuarios_logueados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 589);
            this.Controls.Add(this.gridControl_Usuarios_Logueados);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "xfrm_usuarios_logueados";
            this.Text = "USUARIOS LOGUEADOS";
            this.Load += new System.EventHandler(this.xfrm_usuarios_logueados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Usuarios_Logueados)).EndInit();
            this.click_derecho_usuarios_logueados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Usuarios_Logueados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Usuarios_Logueados;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Usuarios_Logueados;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn74;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn75;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn76;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn77;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn78;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn79;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn80;
        private System.Windows.Forms.ContextMenuStrip click_derecho_usuarios_logueados;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem bbi_actualizar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}