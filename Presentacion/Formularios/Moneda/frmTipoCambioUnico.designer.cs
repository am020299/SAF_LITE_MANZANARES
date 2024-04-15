namespace Presentacion.Formularios.Moneda
{
    partial class frmTipoCambioUnico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTipoCambioUnico));
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.bbi_editar = new DevExpress.XtraEditors.CheckButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_compra = new DevExpress.XtraEditors.TextEdit();
            this.lblMes = new DevExpress.XtraEditors.LabelControl();
            this.txtTipoCambio_venta = new DevExpress.XtraEditors.TextEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bbi_guardar = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_compra.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio_venta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl3
            // 
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl3.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.groupControl3.CaptionLocation = DevExpress.Utils.Locations.Bottom;
            this.groupControl3.Controls.Add(this.bbi_editar);
            this.groupControl3.Controls.Add(this.simpleButton1);
            this.groupControl3.Controls.Add(this.labelControl1);
            this.groupControl3.Controls.Add(this.txt_compra);
            this.groupControl3.Controls.Add(this.lblMes);
            this.groupControl3.Controls.Add(this.txtTipoCambio_venta);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(0, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(395, 156);
            this.groupControl3.TabIndex = 0;
            // 
            // bbi_editar
            // 
            this.bbi_editar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbi_editar.ImageOptions.Image")));
            this.bbi_editar.Location = new System.Drawing.Point(145, 5);
            this.bbi_editar.Name = "bbi_editar";
            this.bbi_editar.Size = new System.Drawing.Size(105, 23);
            this.bbi_editar.TabIndex = 51;
            this.bbi_editar.Text = "EDITAR";
            this.bbi_editar.CheckedChanged += new System.EventHandler(this.bbi_editar_CheckedChanged);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(12, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(127, 23);
            this.simpleButton1.TabIndex = 50;
            this.simpleButton1.Text = "GUARDAR";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl1.Location = new System.Drawing.Point(12, 88);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(110, 19);
            this.labelControl1.TabIndex = 49;
            this.labelControl1.Text = "TASA COMPRA";
            // 
            // txt_compra
            // 
            this.txt_compra.EditValue = "";
            this.txt_compra.Location = new System.Drawing.Point(137, 85);
            this.txt_compra.Name = "txt_compra";
            this.txt_compra.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_compra.Properties.Appearance.Options.UseFont = true;
            this.txt_compra.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_compra.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txt_compra.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(180)))));
            this.txt_compra.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txt_compra.Properties.Mask.BeepOnError = true;
            this.txt_compra.Properties.Mask.EditMask = "c2";
            this.txt_compra.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txt_compra.Properties.MaxLength = 7;
            this.txt_compra.Properties.NullText = "Ingrese el tipo de cambio";
            this.txt_compra.Properties.NullValuePrompt = "Ingrese el tipo de cambio";
            this.txt_compra.Properties.NullValuePromptShowForEmptyValue = true;
            this.txt_compra.Properties.ShowNullValuePromptWhenFocused = true;
            this.txt_compra.Size = new System.Drawing.Size(205, 30);
            this.txt_compra.TabIndex = 48;
            // 
            // lblMes
            // 
            this.lblMes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMes.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.lblMes.Appearance.Options.UseFont = true;
            this.lblMes.Appearance.Options.UseForeColor = true;
            this.lblMes.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblMes.Location = new System.Drawing.Point(12, 52);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(97, 19);
            this.lblMes.TabIndex = 47;
            this.lblMes.Text = "TASA VENTA";
            // 
            // txtTipoCambio_venta
            // 
            this.txtTipoCambio_venta.EditValue = "";
            this.txtTipoCambio_venta.Location = new System.Drawing.Point(137, 49);
            this.txtTipoCambio_venta.Name = "txtTipoCambio_venta";
            this.txtTipoCambio_venta.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoCambio_venta.Properties.Appearance.Options.UseFont = true;
            this.txtTipoCambio_venta.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTipoCambio_venta.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtTipoCambio_venta.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(180)))));
            this.txtTipoCambio_venta.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtTipoCambio_venta.Properties.Mask.BeepOnError = true;
            this.txtTipoCambio_venta.Properties.Mask.EditMask = "c2";
            this.txtTipoCambio_venta.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTipoCambio_venta.Properties.MaxLength = 7;
            this.txtTipoCambio_venta.Properties.NullText = "Ingrese el tipo de cambio";
            this.txtTipoCambio_venta.Properties.NullValuePrompt = "Ingrese el tipo de cambio";
            this.txtTipoCambio_venta.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtTipoCambio_venta.Properties.ShowNullValuePromptWhenFocused = true;
            this.txtTipoCambio_venta.Size = new System.Drawing.Size(205, 30);
            this.txtTipoCambio_venta.TabIndex = 1;
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbi_guardar});
            this.barManager1.MaxItemId = 2;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(395, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 156);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(395, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 156);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(395, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 156);
            // 
            // bbi_guardar
            // 
            this.bbi_guardar.Caption = "Guardar";
            this.bbi_guardar.Id = 0;
            this.bbi_guardar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbi_guardar.ImageOptions.Image")));
            this.bbi_guardar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbi_guardar.ImageOptions.LargeImage")));
            this.bbi_guardar.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbi_guardar.ItemAppearance.Normal.Options.UseFont = true;
            this.bbi_guardar.Name = "bbi_guardar";
            this.bbi_guardar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_guardar_ItemClick);
            // 
            // frmTipoCambioUnico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 156);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTipoCambioUnico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipo de Cambio";
            this.Load += new System.EventHandler(this.frmTipoCambioUnico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_compra.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio_venta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.TextEdit txtTipoCambio_venta;
        private DevExpress.XtraEditors.LabelControl lblMes;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarButtonItem bbi_guardar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_compra;
        private DevExpress.XtraEditors.CheckButton bbi_editar;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}