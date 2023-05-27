using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dj_application.WinFormHeritage
{
    public class CustomComboBox : ComboBox
    {
        public CustomComboBox()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Appel de la méthode OnPaint de la classe de base pour dessiner les éléments par défaut de la ComboBox
            base.OnPaint(e);

            // Centrer le texte de la ComboBox
            if (Items.Count > 0 && SelectedIndex != -1)
            {
                string text = GetItemText(Items[SelectedIndex]);
                Rectangle textBounds = new Rectangle(ClientRectangle.Left + Padding.Left, ClientRectangle.Top + Padding.Top, ClientRectangle.Width - Padding.Horizontal, ClientRectangle.Height - Padding.Vertical);

                TextRenderer.DrawText(e.Graphics, text, Font, textBounds, ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            // Appel de la méthode OnDrawItem de la classe de base pour dessiner les éléments de la ComboBox
            base.OnDrawItem(e);

            if (e.Index >= 0)
            {
                string text = GetItemText(Items[e.Index]);
                Rectangle textBounds = e.Bounds;

                // Centrer le texte dans le volet déroulant
                TextRenderer.DrawText(e.Graphics, text, Font, textBounds, ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
    }

}
