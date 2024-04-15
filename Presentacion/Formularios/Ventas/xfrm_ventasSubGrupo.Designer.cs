
namespace Presentacion.Formularios.Ventas
{
    partial class xfrm_ventasSubGrupo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xfrm_ventasSubGrupo));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.dateFecha_Inicio = new DevExpress.XtraBars.BarEditItem();
            this.repositoryDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.dateFecha_Fin = new DevExpress.XtraBars.BarEditItem();
            this.repositoryDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barLargeButtonItem1 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.gridControlVentasSubGrupo = new DevExpress.XtraGrid.GridControl();
            this.bindingSource_VentasSubGrupo = new System.Windows.Forms.BindingSource(this.components);
            this.viewDetalleVentasSubgrupo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryDateEdit2.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlVentasSubGrupo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_VentasSubGrupo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDetalleVentasSubgrupo)).BeginInit();
            this.SuspendLayout();
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
            this.dateFecha_Inicio,
            this.barStaticItem1,
            this.barStaticItem2,
            this.barEditItem2,
            this.dateFecha_Fin,
            this.barLargeButtonItem1,
            this.barButtonItem1,
            this.barButtonItem2});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 8;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryDateEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryDateEdit2});
            // 
            // bar2
            // 
            this.bar2.BarName = "Menú principal";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.dateFecha_Inicio),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.dateFecha_Fin),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menú principal";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "FECHA INICIO:";
            this.barStaticItem1.Id = 1;
            this.barStaticItem1.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.barStaticItem1.ItemAppearance.Normal.Options.UseFont = true;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // dateFecha_Inicio
            // 
            this.dateFecha_Inicio.Edit = this.repositoryDateEdit1;
            this.dateFecha_Inicio.Id = 0;
            this.dateFecha_Inicio.Name = "dateFecha_Inicio";
            this.dateFecha_Inicio.Size = new System.Drawing.Size(125, 0);
            // 
            // repositoryDateEdit1
            // 
            this.repositoryDateEdit1.AutoHeight = false;
            this.repositoryDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryDateEdit1.Name = "repositoryDateEdit1";
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Caption = "FECHA FIN:";
            this.barStaticItem2.Id = 2;
            this.barStaticItem2.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.barStaticItem2.ItemAppearance.Normal.Options.UseFont = true;
            this.barStaticItem2.Name = "barStaticItem2";
            // 
            // dateFecha_Fin
            // 
            this.dateFecha_Fin.Edit = this.repositoryDateEdit2;
            this.dateFecha_Fin.Id = 4;
            this.dateFecha_Fin.Name = "dateFecha_Fin";
            this.dateFecha_Fin.Size = new System.Drawing.Size(125, 0);
            // 
            // repositoryDateEdit2
            // 
            this.repositoryDateEdit2.AutoHeight = false;
            this.repositoryDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryDateEdit2.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryDateEdit2.Name = "repositoryDateEdit2";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "CARGAR";
            this.barButtonItem1.Id = 6;
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
            this.barDockControlTop.Size = new System.Drawing.Size(1023, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 523);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1023, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 499);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1023, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 499);
            // 
            // barEditItem2
            // 
            this.barEditItem2.Caption = "barEditItem2";
            this.barEditItem2.Edit = this.repositoryItemTextEdit1;
            this.barEditItem2.Id = 3;
            this.barEditItem2.Name = "barEditItem2";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // barLargeButtonItem1
            // 
            this.barLargeButtonItem1.Caption = "CARGAR";
            this.barLargeButtonItem1.Id = 5;
            this.barLargeButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barLargeButtonItem1.ImageOptions.Image")));
            this.barLargeButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barLargeButtonItem1.ImageOptions.LargeImage")));
            this.barLargeButtonItem1.Name = "barLargeButtonItem1";
            this.barLargeButtonItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            // 
            // gridControlVentasSubGrupo
            // 
            this.gridControlVentasSubGrupo.DataSource = this.bindingSource_VentasSubGrupo;
            this.gridControlVentasSubGrupo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlVentasSubGrupo.Location = new System.Drawing.Point(0, 24);
            this.gridControlVentasSubGrupo.MainView = this.viewDetalleVentasSubgrupo;
            this.gridControlVentasSubGrupo.MenuManager = this.barManager1;
            this.gridControlVentasSubGrupo.Name = "gridControlVentasSubGrupo";
            this.gridControlVentasSubGrupo.Size = new System.Drawing.Size(1023, 499);
            this.gridControlVentasSubGrupo.TabIndex = 4;
            this.gridControlVentasSubGrupo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewDetalleVentasSubgrupo});
            // 
            // viewDetalleVentasSubgrupo
            // 
            this.viewDetalleVentasSubgrupo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn6});
            this.viewDetalleVentasSubgrupo.GridControl = this.gridControlVentasSubGrupo;
            this.viewDetalleVentasSubgrupo.GroupCount = 1;
            this.viewDetalleVentasSubgrupo.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", this.gridColumn4, "{0:n2}")});
            this.viewDetalleVentasSubgrupo.Name = "viewDetalleVentasSubgrupo";
            this.viewDetalleVentasSubgrupo.OptionsBehavior.ReadOnly = true;
            this.viewDetalleVentasSubgrupo.OptionsView.ShowAutoFilterRow = true;
            this.viewDetalleVentasSubgrupo.OptionsView.ShowFooter = true;
            this.viewDetalleVentasSubgrupo.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn5, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.Caption = "SUBGRUPO";
            this.gridColumn5.FieldName = "sub_grupo";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.Caption = "CODIGO";
            this.gridColumn1.FieldName = "codigo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "CANTIDAD";
            this.gridColumn2.FieldName = "cant_vendida";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.UnboundDataType = typeof(decimal);
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "PRECIO";
            this.gridColumn3.FieldName = "precio";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.UnboundDataType = typeof(decimal);
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "TOTAL";
            this.gridColumn4.DisplayFormat.FormatString = "n2";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "total";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:n2}")});
            this.gridColumn4.UnboundDataType = typeof(decimal);
            this.gridColumn4.UnboundExpression = "[cant_vendida] * [precio]";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "FECHA";
            this.gridColumn6.FieldName = "fecha";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "EXPORTAR EXCEL";
            this.barButtonItem2.Id = 7;
            this.barButtonItem2.ImageOptions.Image = global::Presentacion.Properties.Resources.excel_16;
            this.barButtonItem2.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.barButtonItem2.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // xfrm_ventasSubGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 523);
            this.Controls.Add(this.gridControlVentasSubGrupo);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("xfrm_ventasSubGrupo.IconOptions.Image")));
            this.Name = "xfrm_ventasSubGrupo";
            this.Text = "VENTAS POR SUBGRUPO";
            this.Load += new System.EventHandler(this.xfrm_ventasSubGrupo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryDateEdit2.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlVentasSubGrupo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_VentasSubGrupo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDetalleVentasSubgrupo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarEditItem dateFecha_Inicio;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryDateEdit1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarEditItem dateFecha_Fin;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryDateEdit2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarLargeButtonItem barLargeButtonItem1;
        private DevExpress.XtraGrid.GridControl gridControlVentasSubGrupo;
        private DevExpress.XtraGrid.Views.Grid.GridView viewDetalleVentasSubgrupo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private System.Windows.Forms.BindingSource bindingSource_VentasSubGrupo;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
    }
}