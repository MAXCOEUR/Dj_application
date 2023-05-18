using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dj_application.View;

namespace Dj_application.View
{
    public partial class Window : Form
    {
        private Thread loadingThread;
        private bool isLoading;
        ParametresForm pf = ParametresForm.Instance;

        public Window()
        {
            InitializeComponent();
            tabPage3.Text = "Download Musique Youtube";
            tabPage2.Text = "Mix Youtube Music";
            tabPage1.Text = "Mix Fichier";
            cb_nbrPiste.SelectedIndex = 0;
        }

        private void Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopLoading();
            pageMix1.delete();
        }

        private void cb_nbrPiste_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageMix1.setNumberPist(int.Parse((string)cb_nbrPiste.SelectedItem));
        }

        public void StartLoading()
        {
            isLoading = true;

            // Créez et démarrez le thread de chargement
            loadingThread = new Thread(() =>
            {
                while (isLoading)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        Pb_LoadingDownload.Value++;
                        if (Pb_LoadingDownload.Value >= Pb_LoadingDownload.Maximum)
                            Pb_LoadingDownload.Value = Pb_LoadingDownload.Minimum;
                    }));

                    Thread.Sleep(50);
                }
            });

            loadingThread.Start();
        }

        public void StopLoading()
        {
            isLoading = false;


            // Attendez que le thread de chargement se termine
            if (loadingThread != null && loadingThread.IsAlive)
            {
                loadingThread.Join();
            }
            Invoke((MethodInvoker)(() =>
            {
                Pb_LoadingDownload.Value = 0;
            }));

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            pf.ShowDialog();
        }
    }
}
