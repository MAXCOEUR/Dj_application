using Dj_application.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        int defaultPos = 0;
        private Color thumbColor;
        private bool isThumbMoving = false;
        readonly CancellationTokenSource tokenSource = new CancellationTokenSource();
        private ParametresForm parametresForm = ParametresForm.Instance;

        private int targetPosition;
        private System.Windows.Forms.Timer updateTimer;
        private Thread thread;

        public CustomTrackBar()
        {
            this.TickStyle = TickStyle.None;
            this.thumbColor = parametresForm.palettesCouleur.Accentuation;
            targetPosition = defaultPos;
            SetStyle(ControlStyles.UserPaint, true);

            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 10; // Définissez l'intervalle de mise à jour du marqueur
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
        }

        public void setVitesse(int vit)
        {
            vitesse = vit;
        }
        public void setDefaultPos(int def)
        {
            defaultPos = def;
        }
        public void setTargetPosition(int targetPosition)
        {
            this.targetPosition=targetPosition;
            
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                changePosition();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
            }
        }

        private void changePosition()
        {
            if(Value < targetPosition + vitesse && Value > targetPosition - vitesse)
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
            this.Invalidate();
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
            if(e.Button == MouseButtons.Left)
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
            else if(e.Button == MouseButtons.Right)
            {
                targetPosition = defaultPos;
                Invalidate();
            }
        }
        protected override void OnScroll(EventArgs e)
        {
            base.OnScroll(e);
            targetPosition=Value; 
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
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
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                base.OnMouseUp(e);
                isThumbMoving = false;
                Capture = false;
                Invalidate();
            }
        }

        private int ValueFromMousePosition(Point mousePosition)
        {
            float thumbPosition = (float)(mousePosition.X - ThumbWith / 2) / (ClientSize.Width - ThumbWith);
            return (int)(Minimum + thumbPosition * (Maximum - Minimum));
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Arrêter le thread
                if (thread != null && thread.IsAlive)
                {
                    tokenSource.Cancel();
                }
            }

            base.Dispose(disposing);
        }
    }

}
