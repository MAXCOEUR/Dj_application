using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Dj_application.View;

namespace Dj_application.WinFormHeritage
{
    public class CustomTabControl : TabControl
    {
        private ParametresForm parametresForm = ParametresForm.Instance;
        private List<Image> imageListPerso = new List<Image>();
        private Size itemSize = new Size(50, 50);
        public CustomTabControl(List<Image> imageListPerso)
        {
            this.imageListPerso = imageListPerso;

            // Assurez-vous que le style du contrôle est correctement configuré
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);

            // Modifiez la hauteur des onglets dans le style du contrôle
            ItemSize = itemSize;
            SetStyle(ControlStyles.UserPaint, true);

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (var brush = new SolidBrush(parametresForm.palettesCouleur.Principal))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }

            for (int i = 0; i < TabCount; i++)
            {
                Rectangle tabRect = GetTabRect(i);

                if (i == SelectedIndex)
                {
                    using (var brush = new SolidBrush(parametresForm.palettesCouleur.Mise_Evidence))
                    {
                        e.Graphics.FillRectangle(brush, tabRect);
                    }
                }
                else
                {
                    using (var brush = new SolidBrush(parametresForm.palettesCouleur.Fond))
                    {
                        e.Graphics.FillRectangle(brush, tabRect);
                    }
                }

                // Dessiner l'image de l'onglet
                Image image = imageListPerso[i];
                if (image != null)
                {
                    float prop = (float)tabRect.Height/image.Size.Height;
                    int imageX = (int)((tabRect.Width * i) + ((tabRect.Width / 2) - (image.Width * prop/2)));
                    e.Graphics.DrawImage(image, imageX, 0,image.Width* prop, tabRect.Height);
                }
            }
        }


    }
}
