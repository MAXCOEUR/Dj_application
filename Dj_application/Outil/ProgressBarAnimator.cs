using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dj_application.Outil
{
    public class ProgressBarAnimator
    {
        private readonly ProgressBar progressBar;
        private Thread animationThread;
        private bool isAnimating;

        public ProgressBarAnimator(ProgressBar progressBar)
        {
            this.progressBar = progressBar;
        }

        public void StartAnimation()
        {
            if (isAnimating) return;

            isAnimating = true;
            animationThread = new Thread(AnimateProgressBar);
            animationThread.Start();

            progressBar.Invoke((MethodInvoker)(() =>
            {
                progressBar.Visible = true;
            }));
        }

        public void StopAnimation()
        {
            if (!isAnimating) return;

            isAnimating = false;
            animationThread.Join();

            progressBar.Invoke((MethodInvoker)(() =>
            {
                progressBar.Visible = false;
            }));
            
        }

        private void AnimateProgressBar()
        {
            try
            {
                while (isAnimating)
                {
                    progressBar.Invoke((MethodInvoker)(() =>
                    {
                        progressBar.Value++;
                        if (progressBar.Value >= progressBar.Maximum)
                            progressBar.Value = progressBar.Minimum;
                    }));

                    Thread.Sleep(50);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }
    }
}
