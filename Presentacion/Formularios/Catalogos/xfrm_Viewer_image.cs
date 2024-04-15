using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Presentacion.Formularios.Catalogos
{
    public partial class xfrm_Viewer_image : DevExpress.XtraEditors.XtraForm
    {
        const int zomm = 150;
        Point localizacion;
        Size size;

        public xfrm_Viewer_image(Image img)
        {
            InitializeComponent();

            pictureEdit1.Image = img;
            pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            pictureEdit1.MouseMove += PictureEdit1_MouseMove;
            pictureEdit1.MouseLeave += PictureEdit1_MouseLeave;
            pictureEdit1.MouseEnter += PictureEdit1_MouseEnter;
            pictureEdit1.Size = new Size(300, 300);
            pictureEdit1.Paint += PictureEdit1_Paint;

            pictureEdit2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;

            flyoutPanel1.OwnerControl = this;
            flyoutPanel1.Size = new Size(500, 500);
            flyoutPanel1.Options.Location = new Point(350, 22);
            flyoutPanel1.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Manual;
            flyoutPanel1.Options.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Fade;
        }

        private void PictureEdit1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!flyoutPanel1.IsPopupOpen)
                flyoutPanel1.ShowPopup();
            Point desplazamiento = pictureEdit1.ViewportToImage(e.Location);

            desplazamiento.X -= zomm / 2;
            desplazamiento.Y -= zomm / 2;

            desplazamiento.X = desplazamiento.X + zomm > pictureEdit1.Image.Width ? pictureEdit1.Image.Width - zomm : desplazamiento.X;
            desplazamiento.X = desplazamiento.X < 0 ? 0 : desplazamiento.X;
            desplazamiento.Y = desplazamiento.Y + zomm > pictureEdit1.Image.Height ? pictureEdit1.Image.Height - zomm : desplazamiento.Y;
            desplazamiento.Y = desplazamiento.Y < 0 ? 0 : desplazamiento.Y;

            localizacion = pictureEdit1.ImageToViewport(desplazamiento);

            size.Height = size.Width = pictureEdit1.ImageToViewport(new Point(zomm, zomm)).X;

            using (var prevImage = pictureEdit2.Image)
                pictureEdit2.Image = delimitarImg(new Rectangle(desplazamiento, new Size(zomm, zomm)));

            pictureEdit1.Invalidate();

            //pictureEdit2.Image = delimitarImg(pictureEdit1.Image,
            //    new Rectangle(desplazamiento_ubicacion, new Size(zomm, zomm)));
        }

        private void PictureEdit1_Paint(object sender, PaintEventArgs e)
        {
            if (localizacion != null && size != null)
            {
                SolidBrush brush = new SolidBrush(Color.FromArgb(100, 255, 255, 255));
                e.Graphics.FillRectangle(brush, new RectangleF(localizacion, size));
                e.Graphics.DrawRectangle(Pens.LightSkyBlue, new Rectangle(localizacion, size));
                brush.Dispose();
            }
        }

        private Bitmap delimitarImg(Rectangle delimitarArea)
        {
            try
            {
                using (Bitmap bmp = new Bitmap(pictureEdit1.Image))
                    return bmp.Clone(delimitarArea, bmp.PixelFormat);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error con la imagen, Favor comunicarse con soporte técnico: " + ex, "Error de sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            //Bitmap bmpImage = new Bitmap(img);
            //return bmpImage.Clone(delimitarArea, bmpImage.PixelFormat);
        }

        private void PictureEdit1_MouseLeave(object sender, EventArgs e)
        {
            flyoutPanel1.HidePopup();
            localizacion = new Point();
            size = new Size();
        }

        private void PictureEdit1_MouseEnter(object sender, EventArgs e)
        {
            flyoutPanel1.ShowPopup();
        }
    }
}