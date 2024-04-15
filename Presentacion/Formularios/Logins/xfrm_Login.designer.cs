namespace Presentacion.Formularios.Login
{
    partial class xfrm_Login
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
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Proyecto_Lite.Formularios.Splash.xfrm_SplashScreen_1), true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xfrm_Login));
            this.dxErrorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.timer_Mensaje_1 = new System.Windows.Forms.Timer(this.components);
            this.timer_Mensaje_2 = new System.Windows.Forms.Timer(this.components);
            this.timer_MensajeHuella = new System.Windows.Forms.Timer(this.components);
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.txt_Clave = new DevExpress.XtraEditors.TextEdit();
            this.txt_Usuario = new DevExpress.XtraEditors.TextEdit();
            this.lbl_MsgError = new DevExpress.XtraEditors.LabelControl();
            this.pic_Huella = new DevExpress.XtraEditors.PictureEdit();
            this.timer_validacion = new System.Windows.Forms.Timer(this.components);
            this.txt_info = new DevExpress.XtraEditors.TextEdit();
            this.picture_1 = new DevExpress.XtraEditors.PictureEdit();
            this.picture_2 = new DevExpress.XtraEditors.PictureEdit();
            this.lbl_MensajeHuella = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Clave.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Usuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Huella.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_info.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_MensajeHuella.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            splashScreenManager1.ClosingDelay = 50;
            // 
            // dxErrorProvider
            // 
            this.dxErrorProvider.ContainerControl = this;
            // 
            // timer_Mensaje_1
            // 
            this.timer_Mensaje_1.Tick += new System.EventHandler(this.timer_Mensaje_1_Tick);
            // 
            // timer_MensajeHuella
            // 
            this.timer_MensajeHuella.Tick += new System.EventHandler(this.timer_MensajeHuella_Tick);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEdit1.EditValue = global::Presentacion.Properties.Resources.LOGIN_SISTEMA_SAF;
            this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(438, 282);
            this.pictureEdit1.TabIndex = 0;
            // 
            // txt_Clave
            // 
            this.txt_Clave.Location = new System.Drawing.Point(109, 160);
            this.txt_Clave.Name = "txt_Clave";
            this.txt_Clave.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Clave.Properties.Appearance.Options.UseFont = true;
            this.txt_Clave.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_Clave.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txt_Clave.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Clave.Properties.AppearanceFocused.Options.UseFont = true;
            this.txt_Clave.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.txt_Clave.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txt_Clave.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            //this.txt_Clave.Properties.ContextImageOptions.Image = global::Presentacion.Properties.Resources.key32x32;
            this.txt_Clave.Properties.MaxLength = 16;
            this.txt_Clave.Properties.PasswordChar = '*';
            this.txt_Clave.Size = new System.Drawing.Size(264, 36);
            this.txt_Clave.TabIndex = 23;
            this.txt_Clave.TextChanged += new System.EventHandler(this.txt_Clave_TextChanged);
            this.txt_Clave.Enter += new System.EventHandler(this.txt_Clave_Enter);
            this.txt_Clave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Clave_KeyPress);
            this.txt_Clave.Leave += new System.EventHandler(this.txt_Clave_Leave);
            // 
            // txt_Usuario
            // 
            this.txt_Usuario.EnterMoveNextControl = true;
            this.txt_Usuario.Location = new System.Drawing.Point(109, 113);
            this.txt_Usuario.Name = "txt_Usuario";
            this.txt_Usuario.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txt_Usuario.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Usuario.Properties.Appearance.Options.UseBackColor = true;
            this.txt_Usuario.Properties.Appearance.Options.UseFont = true;
            this.txt_Usuario.Properties.Appearance.Options.UseImage = true;
            this.txt_Usuario.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_Usuario.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txt_Usuario.Properties.AppearanceFocused.BackColor = System.Drawing.Color.White;
            this.txt_Usuario.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.White;
            this.txt_Usuario.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Usuario.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txt_Usuario.Properties.AppearanceFocused.Options.UseFont = true;
            this.txt_Usuario.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.txt_Usuario.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txt_Usuario.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.txt_Usuario.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txt_Usuario.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            //this.txt_Usuario.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("txt_Usuario.Properties.ContextImageOptions.Image")));
            this.txt_Usuario.Size = new System.Drawing.Size(264, 36);
            this.txt_Usuario.TabIndex = 22;
            this.txt_Usuario.Enter += new System.EventHandler(this.txt_Usuario_Enter);
            this.txt_Usuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Usuario_KeyPress);
            this.txt_Usuario.Leave += new System.EventHandler(this.txt_Usuario_Leave);
            // 
            // lbl_MsgError
            // 
            this.lbl_MsgError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_MsgError.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MsgError.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lbl_MsgError.Appearance.Options.UseFont = true;
            this.lbl_MsgError.Appearance.Options.UseForeColor = true;
            this.lbl_MsgError.Location = new System.Drawing.Point(174, 241);
            this.lbl_MsgError.Name = "lbl_MsgError";
            this.lbl_MsgError.Size = new System.Drawing.Size(73, 19);
            this.lbl_MsgError.TabIndex = 21;
            this.lbl_MsgError.Text = "MsgError";
            this.lbl_MsgError.Visible = false;
            // 
            // pic_Huella
            // 
            this.pic_Huella.Cursor = System.Windows.Forms.Cursors.Default;
            this.pic_Huella.Location = new System.Drawing.Point(12, 110);
            this.pic_Huella.Name = "pic_Huella";
            this.pic_Huella.Properties.AllowFocused = false;
            this.pic_Huella.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.pic_Huella.Properties.Appearance.Options.UseBackColor = true;
            this.pic_Huella.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.pic_Huella.Properties.ShowMenu = false;
            this.pic_Huella.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pic_Huella.Size = new System.Drawing.Size(83, 86);
            this.pic_Huella.TabIndex = 24;
            // 
            // timer_validacion
            // 
            this.timer_validacion.Tick += new System.EventHandler(this.timer_validacion_Tick);
            // 
            // txt_info
            // 
            this.txt_info.EditValue = "F12 = Limpiar, Esc = Cerrar";
            this.txt_info.Enabled = false;
            this.txt_info.Location = new System.Drawing.Point(87, 58);
            this.txt_info.Name = "txt_info";
            this.txt_info.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_info.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(161)))), ((int)(((byte)(223)))));
            this.txt_info.Properties.Appearance.Options.UseFont = true;
            this.txt_info.Properties.Appearance.Options.UseForeColor = true;
            this.txt_info.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.txt_info.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_info.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(161)))), ((int)(((byte)(223)))));
            this.txt_info.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txt_info.Properties.AppearanceDisabled.Options.UseFont = true;
            this.txt_info.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txt_info.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txt_info.Size = new System.Drawing.Size(171, 18);
            this.txt_info.TabIndex = 25;
            // 
            // picture_1
            // 
            this.picture_1.Cursor = System.Windows.Forms.Cursors.Default;
            this.picture_1.EditValue = global::Presentacion.Properties.Resources.valido_jpg;
            this.picture_1.Location = new System.Drawing.Point(379, 118);
            this.picture_1.Name = "picture_1";
            this.picture_1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picture_1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picture_1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picture_1.Size = new System.Drawing.Size(35, 31);
            this.picture_1.TabIndex = 26;
            this.picture_1.Visible = false;
            // 
            // picture_2
            // 
            this.picture_2.Cursor = System.Windows.Forms.Cursors.Default;
            this.picture_2.EditValue = global::Presentacion.Properties.Resources.valido_jpg;
            this.picture_2.Location = new System.Drawing.Point(379, 165);
            this.picture_2.Name = "picture_2";
            this.picture_2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picture_2.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picture_2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picture_2.Size = new System.Drawing.Size(35, 31);
            this.picture_2.TabIndex = 27;
            this.picture_2.Visible = false;
            // 
            // lbl_MensajeHuella
            // 
            this.lbl_MensajeHuella.EditValue = "F12 = Limpiar, Esc = Cerrar";
            this.lbl_MensajeHuella.Enabled = false;
            this.lbl_MensajeHuella.Location = new System.Drawing.Point(122, 202);
            this.lbl_MensajeHuella.Name = "lbl_MensajeHuella";
            this.lbl_MensajeHuella.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MensajeHuella.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(161)))), ((int)(((byte)(223)))));
            this.lbl_MensajeHuella.Properties.Appearance.Options.UseFont = true;
            this.lbl_MensajeHuella.Properties.Appearance.Options.UseForeColor = true;
            this.lbl_MensajeHuella.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.lbl_MensajeHuella.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MensajeHuella.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(161)))), ((int)(((byte)(223)))));
            this.lbl_MensajeHuella.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.lbl_MensajeHuella.Properties.AppearanceDisabled.Options.UseFont = true;
            this.lbl_MensajeHuella.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.lbl_MensajeHuella.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lbl_MensajeHuella.Size = new System.Drawing.Size(251, 18);
            this.lbl_MensajeHuella.TabIndex = 28;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(281, 260);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(151, 14);
            this.labelControl1.TabIndex = 29;
            this.labelControl1.Text = "SAFNISA Copyright © 2018";
            // 
            // xfrm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 282);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lbl_MensajeHuella);
            this.Controls.Add(this.picture_2);
            this.Controls.Add(this.picture_1);
            this.Controls.Add(this.txt_info);
            this.Controls.Add(this.pic_Huella);
            this.Controls.Add(this.txt_Clave);
            this.Controls.Add(this.txt_Usuario);
            this.Controls.Add(this.lbl_MsgError);
            this.Controls.Add(this.pictureEdit1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "xfrm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGIN";
            this.Load += new System.EventHandler(this.xfrm_Login_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.xfrm_Login_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Clave.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Usuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Huella.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_info.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_MensajeHuella.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider;
        private System.Windows.Forms.Timer timer_Mensaje_1;
        private System.Windows.Forms.Timer timer_Mensaje_2;
        private System.Windows.Forms.Timer timer_MensajeHuella;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.TextEdit txt_Clave;
        private DevExpress.XtraEditors.TextEdit txt_Usuario;
        private DevExpress.XtraEditors.LabelControl lbl_MsgError;
        private DevExpress.XtraEditors.PictureEdit pic_Huella;
        private System.Windows.Forms.Timer timer_validacion;
        private DevExpress.XtraEditors.TextEdit txt_info;
        private DevExpress.XtraEditors.PictureEdit picture_2;
        private DevExpress.XtraEditors.PictureEdit picture_1;
        private DevExpress.XtraEditors.TextEdit lbl_MensajeHuella;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}