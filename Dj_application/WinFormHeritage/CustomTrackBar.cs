using Dj_application.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Dj_application.WinFormHeritage
{
    public class CustomTrackBar : TrackBar
    {
        int vitesse = 1;
        int ThumbWith = 30;
        private Color thumbColor;
        private bool isThumbMoving = false;
        private ParametresForm parametresForm = ParametresForm.Instance;

        private int targetPosition;
        private Thread thread;

        public CustomTrackBar()
        {
            this.TickStyle = TickStyle.None;
            this.thumbColor = parametresForm.palettesCouleur.Accentuation;
            targetPosition = 0;
            SetStyle(ControlStyles.UserPaint, true);

            thread = new Thread(threadMethode);
            thread.Start();
        }

        public void setTargetPosition(int targetPosition)
        {
            this.targetPosition=targetPosition;
        }

        private void threadMethode()
        {
            while (true)
            {
                try
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            changePosition();
                        });
                    }
                    else
                    {
                        changePosition();
                    }
                }
                catch
                {
                    break;
                }
                
                
                Thread.Sleep(10);
            }
        }

        private void changePosition()
        {
            if(targetPosition==Value)
            {
                return;
            }
            else if (targetPosition > Value)
            {
                Value += vitesse;
            }
            else if (targetPosition < Value)
            {
                Value -= vitesse;
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (SolidBrush brush = new SolidBrush(parametresForm.palettesCouleur.Mise_Evidence))
            {
                Rectangle referenceRect = new Rectangle(0, this.ClientRectangle.Height / 4, this.ClientRectangle.Width, this.ClientRectangle.Height/2);
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

            return new Rectangle(thumbX, 0, ThumbWith, this.ClientRectangle.Height);
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
            else
            {
                int newValue = ValueFromMousePosition(e.Location);
                if (newValue != Value)
                {
                    isThumbMoving = true;
                    Capture = true;
                    targetPosition = Math.Clamp(newValue, Minimum, Maximum);
                    Invalidate();
                }
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
                    targetPosition = Math.Clamp(newValue, Minimum, Maximum);
                    Value = Math.Clamp(newValue, Minimum, Maximum);
                    Invalidate();
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            isThumbMoving = false;
            Capture = false;
            Invalidate();
        }

        private int ValueFromMousePosition(Point mousePosition)
        {
            float thumbPosition = (float)(mousePosition.X - ThumbWith / 2) / (ClientSize.Width - ThumbWith);
            return (int)(Minimum + thumbPosition * (Maximum - Minimum));
        }
    }

}
