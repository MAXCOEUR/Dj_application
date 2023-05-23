using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dj_application.model;
using Dj_application.View;
using NAudio.Wave.SampleProviders;
using NAudio.Wave;

namespace Dj_application.View
{
    public partial class Window : Form
    {
        private Thread loadingThread;
        private bool isLoading;
        private int nbrPiste;
        public Window()
        {
            InitializeComponent();
            tabPage3.Text = "Download Musique Youtube";
            tabPage2.Text = "Mix Youtube Music";
            tabPage1.Text = "Mix Fichier";
            cb_nbrPiste.SelectedIndex = 0;
            nbrPiste = int.Parse((string)cb_nbrPiste.SelectedItem);

        }

        private void Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopLoading();
            pageMix1.delete();
        }

        private void cb_nbrPiste_SelectedIndexChanged(object sender, EventArgs e)
        {
            nbrPiste = int.Parse((string)cb_nbrPiste.SelectedItem);
            pageMix1.setNumberPist(nbrPiste);
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
            ParametresForm pf = ParametresForm.Instance;
            pf.ShowDialog();
        }

        public int getNbrPiste()
        {
            return nbrPiste;
        }
    }
}
