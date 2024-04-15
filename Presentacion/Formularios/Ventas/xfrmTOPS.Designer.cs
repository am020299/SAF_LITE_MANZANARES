namespace Presentacion.Formularios.Ventas
{
    partial class xfrmTOPS
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.dateFin = new DevExpress.XtraEditors.DateEdit();
            this.cbAño = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dateInicio = new DevExpress.XtraEditors.DateEdit();
            this.cbMes = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutFechaInicio = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutFechaFin = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutAño = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutMes = new DevExpress.XtraLayout.LayoutControlItem();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gview = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAño.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateInicio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutFechaInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutFechaFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutAño)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lookUpEdit1);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.comboBoxEdit1);
            this.layoutControl1.Controls.Add(this.grid);
            this.layoutControl1.Controls.Add(this.dateInicio);
            this.layoutControl1.Controls.Add(this.dateFin);
            this.layoutControl1.Controls.Add(this.radioGroup1);
            this.layoutControl1.Controls.Add(this.cbAño);
            this.layoutControl1.Controls.Add(this.cbMes);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(790, 568);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutFechaInicio,
            this.layoutFechaFin,
            this.layoutControlItem5,
            this.layoutAño,
            this.layoutMes,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem4,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(790, 568);
            this.Root.TextVisible = false;
            // 
            // radioGroup1
            // 
            this.radioGroup1.EditValue = ((short)(1));
            this.radioGroup1.Location = new System.Drawing.Point(12, 88);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "DÍA"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("2", "MES"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("3", "AÑO"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("4", "RANGO FECHAS")});
            this.radioGroup1.Size = new System.Drawing.Size(766, 23);
            this.radioGroup1.StyleController = this.layoutControl1;
            this.radioGroup1.TabIndex = 6;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // dateFin
            // 
            this.dateFin.EditValue = null;
            this.dateFin.Location = new System.Drawing.Point(109, 62);
            this.dateFin.Name = "dateFin";
            this.dateFin.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFin.Properties.Appearance.Options.UseFont = true;
            this.dateFin.Properties.AppearanceFocused.BackColor = System.Drawing.SystemColors.Info;
            this.dateFin.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.dateFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFin.Size = new System.Drawing.Size(285, 22);
            this.dateFin.StyleController = this.layoutControl1;
            this.dateFin.TabIndex = 5;
            // 
            // cbAño
            // 
            this.cbAño.EnterMoveNextControl = true;
            this.cbAño.Location = new System.Drawing.Point(495, 36);
            this.cbAño.Name = "cbAño";
            this.cbAño.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAño.Properties.Appearance.Options.UseFont = true;
            this.cbAño.Properties.AppearanceFocused.BackColor = System.Drawing.SystemColors.Info;
            this.cbAño.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.cbAño.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbAño.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbAño.Size = new System.Drawing.Size(283, 22);
            this.cbAño.StyleController = this.layoutControl1;
            this.cbAño.TabIndex = 7;
            // 
            // dateInicio
            // 
            this.dateInicio.EditValue = null;
            this.dateInicio.Location = new System.Drawing.Point(109, 36);
            this.dateInicio.Name = "dateInicio";
            this.dateInicio.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateInicio.Properties.Appearance.Options.UseFont = true;
            this.dateInicio.Properties.AppearanceFocused.BackColor = System.Drawing.SystemColors.Info;
            this.dateInicio.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.dateInicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateInicio.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateInicio.Size = new System.Drawing.Size(285, 22);
            this.dateInicio.StyleController = this.layoutControl1;
            this.dateInicio.TabIndex = 4;
            // 
            // cbMes
            // 
            this.cbMes.EnterMoveNextControl = true;
            this.cbMes.Location = new System.Drawing.Point(495, 62);
            this.cbMes.Name = "cbMes";
            this.cbMes.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMes.Properties.Appearance.Options.UseFont = true;
            this.cbMes.Properties.AppearanceFocused.BackColor = System.Drawing.SystemColors.Info;
            this.cbMes.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.cbMes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbMes.Properties.Items.AddRange(new object[] {
            "ENERO",
            "FEBRERO",
            "MARZO",
            "ABRIL",
            "MAYO",
            "JUNIO",
            "JULIO",
            "AGOSTO",
            "SEPTIEMBRE",
            "OCTUBRE",
            "NOVIEMBRE",
            "DICIEMBRE"});
            this.cbMes.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbMes.Size = new System.Drawing.Size(283, 22);
            this.cbMes.StyleController = this.layoutControl1;
            this.cbMes.TabIndex = 8;
            // 
            // layoutFechaInicio
            // 
            this.layoutFechaInicio.Control = this.dateInicio;
            this.layoutFechaInicio.CustomizationFormText = "FECHA INICIO:";
            this.layoutFechaInicio.Location = new System.Drawing.Point(0, 24);
            this.layoutFechaInicio.Name = "layoutFechaInicio";
            this.layoutFechaInicio.Size = new System.Drawing.Size(386, 26);
            this.layoutFechaInicio.Text = "FECHA INICIO:";
            this.layoutFechaInicio.TextSize = new System.Drawing.Size(93, 13);
            // 
            // layoutFechaFin
            // 
            this.layoutFechaFin.Control = this.dateFin;
            this.layoutFechaFin.CustomizationFormText = "FECHA FIN:";
            this.layoutFechaFin.Location = new System.Drawing.Point(0, 50);
            this.layoutFechaFin.Name = "layoutFechaFin";
            this.layoutFechaFin.Size = new System.Drawing.Size(386, 26);
            this.layoutFechaFin.Text = "FECHA FIN:";
            this.layoutFechaFin.TextSize = new System.Drawing.Size(93, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.radioGroup1;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 76);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(770, 27);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutAño
            // 
            this.layoutAño.Control = this.cbAño;
            this.layoutAño.CustomizationFormText = "AÑO:";
            this.layoutAño.Location = new System.Drawing.Point(386, 24);
            this.layoutAño.Name = "layoutAño";
            this.layoutAño.Size = new System.Drawing.Size(384, 26);
            this.layoutAño.Text = "AÑO:";
            this.layoutAño.TextSize = new System.Drawing.Size(93, 13);
            // 
            // layoutMes
            // 
            this.layoutMes.Control = this.cbMes;
            this.layoutMes.CustomizationFormText = "MES:";
            this.layoutMes.Location = new System.Drawing.Point(386, 50);
            this.layoutMes.Name = "layoutMes";
            this.layoutMes.Size = new System.Drawing.Size(384, 26);
            this.layoutMes.Text = "MES:";
            this.layoutMes.TextSize = new System.Drawing.Size(93, 13);
            // 
            // grid
            // 
            this.grid.Location = new System.Drawing.Point(12, 165);
            this.grid.MainView = this.gview;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(766, 391);
            this.grid.TabIndex = 9;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gview});
            // 
            // gview
            // 
            this.gview.GridControl = this.grid;
            this.gview.Name = "gview";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grid;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 153);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(770, 395);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(109, 12);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Properties.Items.AddRange(new object[] {
            "TOP 10 CLIENTES",
            "TOP 10 PRODUCTOS MAS VENDIDOS",
            "TOP 10 PRODUCTOS POR CLIENTES"});
            this.comboBoxEdit1.Size = new System.Drawing.Size(669, 20);
            this.comboBoxEdit1.StyleController = this.layoutControl1;
            this.comboBoxEdit1.TabIndex = 10;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.comboBoxEdit1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(770, 24);
            this.layoutControlItem2.Text = "REPORTE";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(93, 13);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(12, 139);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(105, 22);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 11;
            this.simpleButton1.Text = "CARGAR";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.simpleButton1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 127);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(109, 26);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(109, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(109, 26);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(109, 127);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(661, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(109, 115);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Size = new System.Drawing.Size(669, 20);
            this.lookUpEdit1.StyleController = this.layoutControl1;
            this.lookUpEdit1.TabIndex = 12;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lookUpEdit1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 103);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(770, 24);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(93, 13);
            // 
            // xfrmTOPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 568);
            this.Controls.Add(this.layoutControl1);
            this.Name = "xfrmTOPS";
            this.Text = "TOPS 10\'S";
            this.Load += new System.EventHandler(this.xfrmTOPS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAño.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateInicio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutFechaInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutFechaFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutAño)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.DateEdit dateInicio;
        private DevExpress.XtraEditors.DateEdit dateFin;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.ComboBoxEdit cbAño;
        private DevExpress.XtraEditors.ComboBoxEdit cbMes;
        private DevExpress.XtraLayout.LayoutControlItem layoutFechaInicio;
        private DevExpress.XtraLayout.LayoutControlItem layoutFechaFin;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutAño;
        private DevExpress.XtraLayout.LayoutControlItem layoutMes;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gview;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}