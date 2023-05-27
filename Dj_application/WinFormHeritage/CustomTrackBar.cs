using Dj_application.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dj_application.WinFormHeritage
{
    public class CustomTrackBar : TrackBar
    {
        int ThumbWith = 30;
        private Color thumbColor;
        private bool isThumbMoving = false;
        private ParametresForm parametresForm = ParametresForm.Instance;

        public CustomTrackBar()
        {
            this.thumbColor = parametresForm.palettesCouleur.Accentuation;
            SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (SolidBrush brush = new SolidBrush(parametresForm.palettesCouleur.Mise_Evidence))
            {
                Rectangle referenceRect = new Rectangle(0, this.ClientRectangle.Height/4, this.ClientRectangle.Width, this.ClientRectangle.Height/2);
                e.Graphics.FillRectangle(brush, referenceRect);
            }

            Rectangle thumbRect = GetThumbRect();
            using (SolidBrush brush = new SolidBrush(thumbColor))
            {
                e.Graphics.FillRectangle(brush, thumbRect);
            }

            
        }



        private Rectangle GetThumbRect()
        {
            float thumbPosition = (float)(Value - Minimum) / (Maximum - Minimum);
            int thumbX = (int)(thumbPosition * (ClientSize.Width - ThumbWith));
            int thumbY = (ClientSize.Height - this.ClientRectangle.Height) / 2;

            return new Rectangle(thumbX, thumbY, ThumbWith, this.ClientRectangle.Height);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            Rectangle thumbRect = GetThumbRect();
            if (thumbRect.Contains(e.Location))
            {
                isThumbMoving = true;
                Capture = true;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (isThumbMoving)
            {
                int newValue = ValueFromMousePosition(e.Location);
                if (newValue != Value)
                {
                    Value = Math.Clamp(newValue,this.Minimum,this.Maximum);
                    Invalidate();
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            isThumbMoving = false;
            Capture = false;
        }

        private int ValueFromMousePosition(Point mousePosition)
        {
            float thumbPosition = (float)(mousePosition.X - ThumbWith / 2) / (ClientSize.Width - ThumbWith);
            return (int)(Minimum + thumbPosition * (Maximum - Minimum));
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_SETCURSOR = 0x0020;
            const int HTCLIENT = 1;
            const int IDC_HAND = 32649;

            if (m.Msg == WM_SETCURSOR && m.LParam.ToInt32() == HTCLIENT)
            {
                Cursor.Current = new Cursor(GetType(), "Cursors.Hand.cur");
                m.Result = (IntPtr)1;
                return;
            }
            else if (m.Msg == 0x000B) // WM_SETREDRAW
            {
                if (m.WParam != IntPtr.Zero)
                {
                    base.WndProc(ref m);
                    Invalidate(); // Force la révalidation du contrôle
                }
                else
                {
                    base.WndProc(ref m);
                }
            }
            else
            {
                base.WndProc(ref m);
            }
        }
    }
}
