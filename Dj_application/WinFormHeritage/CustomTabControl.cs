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
        public CustomTabControl()
        {
            //SetStyle(ControlStyles.UserPaint, true);

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

                    using (var brush = new SolidBrush(parametresForm.palettesCouleur.Texte))
                    {
                        TextRenderer.DrawText(e.Graphics, TabPages[i].Text, Font, tabRect, brush.Color, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    }
                }
                else
                {
                    using (var brush = new SolidBrush(parametresForm.palettesCouleur.Fond))
                    {
                        e.Graphics.FillRectangle(brush, tabRect);
                    }

                    using (var brush = new SolidBrush(parametresForm.palettesCouleur.Texte))
                    {
                        TextRenderer.DrawText(e.Graphics, TabPages[i].Text, Font, tabRect, brush.Color, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    }
                }
            }
        }

    }
}
