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
using Dj_application.WinFormHeritage;

namespace Dj_application.View
{
    public partial class Window : Form
    {
        private Thread loadingThread;
        private bool isLoading;
        private int nbrPiste;
        private int nbrMusicDownload = 0;
        static Mutex mutex_nbrMusicDownload = new Mutex();
        private ParametresForm parametresForm = ParametresForm.Instance;
        private List<Image> imageListPerso = new List<Image>();
        private CustomTabControl tabControl1;
        public Window()
        {
            imageListPerso.Add(Resource.mixer);
            imageListPerso.Add(Resource.youtube_music);
            imageListPerso.Add(Resource.YouTube_Logo);
            tabControl1 = new CustomTabControl(imageListPerso);
            InitializeComponent();
            setColor();

            

            tabPage1.Text = "0000000000000000";
            tabPage3.Text = "0000000000000000";
            tabPage2.Text = "0000000000000000";

            cb_nbrPiste.SelectedIndex = 0;
            nbrPiste = int.Parse((string)cb_nbrPiste.SelectedItem);

            toolStripButton1.BackColor = parametresForm.palettesCouleur.Mise_Evidence;
        }

        private void setColor()
        {
            this.BackColor = parametresForm.palettesCouleur.Fond;
            this.ForeColor = parametresForm.palettesCouleur.Texte;
            toolStrip1.BackColor = parametresForm.palettesCouleur.Fond;
            tabControl1.BackColor = parametresForm.palettesCouleur.Principal;
            toolStrip1.Margin = new Padding(0);
            tabPage3.BackColor = parametresForm.palettesCouleur.Principal;
            tabPage2.BackColor = parametresForm.palettesCouleur.Principal;
            tabPage1.BackColor = parametresForm.palettesCouleur.Principal;
            cb_nbrPiste.BackColor = parametresForm.palettesCouleur.Principal;
            cb_nbrPiste.ForeColor = parametresForm.palettesCouleur.Texte;

            this.Font = parametresForm.fontDefault;
            toolStripButton1.Font = parametresForm.fontDefault;
            cb_nbrPiste.Font = parametresForm.fontDefault;
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
            mutex_nbrMusicDownload.WaitOne();
            nbrMusicDownload++;
            if (nbrMusicDownload == 1)
            {
                mutex_nbrMusicDownload.ReleaseMutex();
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
            else
            {
                mutex_nbrMusicDownload.ReleaseMutex();
            }
        }

        public void StopLoading()
        {
            mutex_nbrMusicDownload.WaitOne();
            nbrMusicDownload--;
            if (nbrMusicDownload == 0)
            {
                mutex_nbrMusicDownload.ReleaseMutex();
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
            else
            {
                mutex_nbrMusicDownload.ReleaseMutex();
            }


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
