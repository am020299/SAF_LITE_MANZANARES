namespace Presentacion.Formularios.CuentasCobrar
{
    partial class xfrm_ParametrosCXC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xfrm_ParametrosCXC));
            this.NavControl = new DevExpress.XtraNavBar.NavBarControl();
            this.navGroupParametros = new DevExpress.XtraNavBar.NavBarGroup();
            this.navCuentas = new DevExpress.XtraNavBar.NavBarItem();
            this.binding_CuentasContables = new System.Windows.Forms.BindingSource(this.components);
            this.binding_CuentasContabilidad = new System.Windows.Forms.BindingSource(this.components);
            this.pagina_cuentas = new DevExpress.XtraTab.XtraTabPage();
            this.grid_cuentas_Contables = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositorio_search_cuentas = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gview_cuentas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_id_cuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_numero_cuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPaginas = new DevExpress.XtraTab.XtraTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.NavControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding_CuentasContables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding_CuentasContabilidad)).BeginInit();
            this.pagina_cuentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_cuentas_Contables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositorio_search_cuentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview_cuentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPaginas)).BeginInit();
            this.tabPaginas.SuspendLayout();
            this.SuspendLayout();
            // 
            // NavControl
            // 
            this.NavControl.ActiveGroup = this.navGroupParametros;
            this.NavControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.NavControl.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navGroupParametros});
            this.NavControl.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navCuentas});
            this.NavControl.Location = new System.Drawing.Point(0, 0);
            this.NavControl.Name = "NavControl";
            this.NavControl.OptionsNavPane.ExpandedWidth = 167;
            this.NavControl.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.NavControl.Size = new System.Drawing.Size(167, 561);
            this.NavControl.TabIndex = 0;
            this.NavControl.Text = "navBarControl1";
            // 
            // navGroupParametros
            // 
            this.navGroupParametros.Caption = "PARAMETROS";
            this.navGroupParametros.Expanded = true;
            this.navGroupParametros.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsList;
            this.navGroupParametros.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navCuentas)});
            this.navGroupParametros.Name = "navGroupParametros";
            // 
            // navCuentas
            // 
            this.navCuentas.Caption = "Cuentas";
            this.navCuentas.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navCuentas.ImageOptions.SmallImage")));
            this.navCuentas.Name = "navCuentas";
            // 
            // pagina_cuentas
            // 
            this.pagina_cuentas.Controls.Add(this.grid_cuentas_Contables);
            this.pagina_cuentas.Name = "pagina_cuentas";
            this.pagina_cuentas.Size = new System.Drawing.Size(611, 533);
            this.pagina_cuentas.Text = "CUENTAS CONTABLES";
            // 
            // grid_cuentas_Contables
            // 
            this.grid_cuentas_Contables.DataSource = this.binding_CuentasContables;
            this.grid_cuentas_Contables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_cuentas_Contables.Location = new System.Drawing.Point(0, 0);
            this.grid_cuentas_Contables.MainView = this.gview_cuentas;
            this.grid_cuentas_Contables.Name = "grid_cuentas_Contables";
            this.grid_cuentas_Contables.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositorio_search_cuentas});
            this.grid_cuentas_Contables.Size = new System.Drawing.Size(611, 533);
            this.grid_cuentas_Contables.TabIndex = 0;
            this.grid_cuentas_Contables.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gview_cuentas});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grid_cuentas_Contables;
            this.gridView1.Name = "gridView1";
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // repositorio_search_cuentas
            // 
            this.repositorio_search_cuentas.AutoHeight = false;
            this.repositorio_search_cuentas.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositorio_search_cuentas.DisplayMember = "CUENTA";
            this.repositorio_search_cuentas.Name = "repositorio_search_cuentas";
            this.repositorio_search_cuentas.PopupView = this.repositoryItemSearchLookUpEdit1View;
            this.repositorio_search_cuentas.ValueMember = "CUENTA";
            // 
            // gview_cuentas
            // 
            this.gview_cuentas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_id_cuenta,
            this.col_Descripcion,
            this.col_numero_cuenta});
            this.gview_cuentas.GridControl = this.grid_cuentas_Contables;
            this.gview_cuentas.Name = "gview_cuentas";
            this.gview_cuentas.OptionsCustomization.AllowGroup = false;
            this.gview_cuentas.OptionsCustomization.AllowSort = false;
            this.gview_cuentas.OptionsMenu.EnableColumnMenu = false;
            this.gview_cuentas.OptionsView.ShowAutoFilterRow = true;
            this.gview_cuentas.OptionsView.ShowGroupPanel = false;
            this.gview_cuentas.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gview_cuentas_RowUpdated);
            // 
            // col_id_cuenta
            // 
            this.col_id_cuenta.Caption = "id_cuentas";
            this.col_id_cuenta.FieldName = "id_Cuenta_contable";
            this.col_id_cuenta.Name = "col_id_cuenta";
            this.col_id_cuenta.OptionsColumn.AllowEdit = false;
            // 
            // col_Descripcion
            // 
            this.col_Descripcion.Caption = "DESCRIPCION CUENTA";
            this.col_Descripcion.FieldName = "descripcion_cuenta";
            this.col_Descripcion.Name = "col_Descripcion";
            this.col_Descripcion.OptionsColumn.AllowEdit = false;
            this.col_Descripcion.Visible = true;
            this.col_Descripcion.VisibleIndex = 0;
            this.col_Descripcion.Width = 376;
            // 
            // col_numero_cuenta
            // 
            this.col_numero_cuenta.Caption = "NUMERO DE CUENTA";
            this.col_numero_cuenta.ColumnEdit = this.repositorio_search_cuentas;
            this.col_numero_cuenta.FieldName = "numero_cuenta";
            this.col_numero_cuenta.Name = "col_numero_cuenta";
            this.col_numero_cuenta.Visible = true;
            this.col_numero_cuenta.VisibleIndex = 1;
            this.col_numero_cuenta.Width = 217;
            // 
            // tabPaginas
            // 
            this.tabPaginas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPaginas.Location = new System.Drawing.Point(167, 0);
            this.tabPaginas.Name = "tabPaginas";
            this.tabPaginas.SelectedTabPage = this.pagina_cuentas;
            this.tabPaginas.Size = new System.Drawing.Size(617, 561);
            this.tabPaginas.TabIndex = 1;
            this.tabPaginas.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pagina_cuentas});
            // 
            // xfrm_ParametrosCXC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabPaginas);
            this.Controls.Add(this.NavControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "xfrm_ParametrosCXC";
            this.Text = "PARAMETROS CUENTAS POR COBRAR";
            this.Load += new System.EventHandler(this.xfrm_ParametrosCXC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NavControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding_CuentasContables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binding_CuentasContabilidad)).EndInit();
            this.pagina_cuentas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_cuentas_Contables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositorio_search_cuentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview_cuentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPaginas)).EndInit();
            this.tabPaginas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl NavControl;
        private DevExpress.XtraNavBar.NavBarGroup navGroupParametros;
        private DevExpress.XtraNavBar.NavBarItem navCuentas;
        private System.Windows.Forms.BindingSource binding_CuentasContables;
        private System.Windows.Forms.BindingSource binding_CuentasContabilidad;
        private DevExpress.XtraTab.XtraTabPage pagina_cuentas;
        private DevExpress.XtraGrid.GridControl grid_cuentas_Contables;
        private DevExpress.XtraGrid.Views.Grid.GridView gview_cuentas;
        private DevExpress.XtraGrid.Columns.GridColumn col_id_cuenta;
        private DevExpress.XtraGrid.Columns.GridColumn col_Descripcion;
        private DevExpress.XtraGrid.Columns.GridColumn col_numero_cuenta;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repositorio_search_cuentas;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraTab.XtraTabControl tabPaginas;
    }
}