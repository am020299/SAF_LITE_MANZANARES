namespace Presentacion.Formularios.Moneda
{
    partial class frmTipoCambio
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
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTipoCambio));
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            this.gridDetalle = new DevExpress.XtraGrid.GridControl();
            this.gvDetalle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtMsg = new DevExpress.XtraEditors.TextEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.btnGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btn_tc_internet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMsg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridDetalle
            // 
            this.gridDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gridDetalle.Location = new System.Drawing.Point(12, 154);
            this.gridDetalle.MainView = this.gvDetalle;
            this.gridDetalle.Name = "gridDetalle";
            this.gridDetalle.Size = new System.Drawing.Size(429, 427);
            this.gridDetalle.TabIndex = 5;
            this.gridDetalle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetalle});
            // 
            // gvDetalle
            // 
            this.gvDetalle.GridControl = this.gridDetalle;
            this.gvDetalle.Name = "gvDetalle";
            this.gvDetalle.OptionsBehavior.Editable = false;
            this.gvDetalle.OptionsCustomization.AllowColumnMoving = false;
            this.gvDetalle.OptionsCustomization.AllowColumnResizing = false;
            this.gvDetalle.OptionsCustomization.AllowFilter = false;
            this.gvDetalle.OptionsMenu.EnableColumnMenu = false;
            this.gvDetalle.OptionsView.ColumnAutoWidth = false;
            this.gvDetalle.OptionsView.ShowGroupPanel = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = global::Presentacion.Properties.Resources.sobresalir1;
            this.simpleButton1.Location = new System.Drawing.Point(12, 103);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(94, 45);
            superToolTip3.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            superToolTip3.DistanceBetweenItems = 10;
            toolTipTitleItem3.Text = "Tipo de Archivo de Excel";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "Hoja de cálculo de Microsoft Excel 97-2003 (.xls)";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            this.simpleButton1.SuperTip = superToolTip3;
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "Importar";
            this.simpleButton1.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(212, 128);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Properties.ReadOnly = true;
            this.txtMsg.Size = new System.Drawing.Size(229, 20);
            this.txtMsg.TabIndex = 7;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.EditValue = global::Presentacion.Properties.Resources.banco_nicaragua;
            this.pictureEdit1.Location = new System.Drawing.Point(12, 12);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.AllowFocused = false;
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.ShowMenu = false;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(429, 85);
            this.pictureEdit1.TabIndex = 8;
            // 
            // groupControl3
            // 
            this.groupControl3.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl3.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl3.CaptionLocation = DevExpress.Utils.Locations.Top;
            this.groupControl3.Controls.Add(this.btnGuardar);
            this.groupControl3.Controls.Add(this.btnCancelar);
            this.groupControl3.Location = new System.Drawing.Point(447, 12);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(141, 185);
            this.groupControl3.TabIndex = 44;
            this.groupControl3.Text = "Operaciones";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Appearance.Options.UseFont = true;
            this.btnGuardar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnGuardar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.ImageOptions.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(10, 34);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 60);
            this.btnGuardar.TabIndex = 27;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Appearance.Options.UseFont = true;
            this.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(10, 100);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 60);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btn_tc_internet
            // 
            this.btn_tc_internet.Appearance.Options.UseTextOptions = true;
            this.btn_tc_internet.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btn_tc_internet.ImageOptions.Image = global::Presentacion.Properties.Resources.sobresalir1;
            this.btn_tc_internet.Location = new System.Drawing.Point(112, 103);
            this.btn_tc_internet.Name = "btn_tc_internet";
            this.btn_tc_internet.Size = new System.Drawing.Size(94, 45);
            superToolTip4.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            superToolTip4.DistanceBetweenItems = 10;
            toolTipTitleItem4.Text = "Tipo de Archivo de Excel";
            toolTipItem4.LeftIndent = 6;
            toolTipItem4.Text = "Hoja de cálculo de Microsoft Excel 97-2003 (.xls)";
            superToolTip4.Items.Add(toolTipTitleItem4);
            superToolTip4.Items.Add(toolTipItem4);
            this.btn_tc_internet.SuperTip = superToolTip4;
            this.btn_tc_internet.TabIndex = 45;
            this.btn_tc_internet.Text = "Importar de la web";
            this.btn_tc_internet.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btn_tc_internet.Click += new System.EventHandler(this.btn_tc_internet_Click);
            // 
            // frmTipoCambio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 593);
            this.Controls.Add(this.btn_tc_internet);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.gridDetalle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTipoCambio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipo de Cambio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTipoCambio_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMsg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridDetalle;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetalle;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit txtMsg;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SimpleButton btnGuardar;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btn_tc_internet;
        //    private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}