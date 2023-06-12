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
using Dj_application.View.DownloadPage;
using Dj_application.View.Control;

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



        private TabPage tabPage1;
        private TabPage tabPage3;
        private TabPage tabPage2;
        private TabPage tabPage4;

        private PageDownloadYoutubeMusic pageDownloadYoutubeMusic1;
        private PageMix pageMix1;
        private PageDownloadYoutube pageDownloadYoutube1;
        private PageDownloadSpotify pageDownloadSpotify;
        public Window()
        {
            imageListPerso.Add(Resource.mixer);
            imageListPerso.Add(Resource.youtube_music);
            imageListPerso.Add(Resource.YouTube_Logo);
            imageListPerso.Add(Resource.Spotify);
            tabControl1 = new CustomTabControl(imageListPerso);
            this.Controls.Add(tabControl1);

            InitializeComponent();
            initTab();
            setColor();



            tabPage1.Text = "0000000000000000";
            tabPage3.Text = "0000000000000000";
            tabPage2.Text = "0000000000000000";
            tabPage4.Text = "0000000000000000";

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
            tabPage4.BackColor = parametresForm.palettesCouleur.Principal;
            cb_nbrPiste.BackColor = parametresForm.palettesCouleur.Principal;
            cb_nbrPiste.ForeColor = parametresForm.palettesCouleur.Texte;

            this.Font = parametresForm.fontDefault;
            toolStripButton1.Font = parametresForm.fontDefault;
            cb_nbrPiste.Font = parametresForm.fontDefault;
        }

        void initTab()
        {
            tabPage3 = new TabPage();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage4 = new TabPage();

            pageDownloadYoutubeMusic1 = new PageDownloadYoutubeMusic();
            pageMix1 = new PageMix();
            pageDownloadYoutube1 = new PageDownloadYoutube();
            pageDownloadSpotify = new PageDownloadSpotify();

            tabPage3.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage4.SuspendLayout();

            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(pageMix1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 390);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(pageDownloadYoutubeMusic1);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(792, 390);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(pageDownloadYoutube1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 390);
            tabPage2.TabIndex = 3;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(pageDownloadSpotify);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(792, 390);
            tabPage4.TabIndex = 2;
            tabPage4.Text = "tabPage4";
            tabPage4.UseVisualStyleBackColor = true;

            // 
            // pageDownloadYoutubeMusic1
            // 
            pageDownloadYoutubeMusic1.Dock = DockStyle.Fill;
            pageDownloadYoutubeMusic1.Location = new Point(3, 3);
            pageDownloadYoutubeMusic1.Name = "pageDownloadYoutubeMusic1";
            pageDownloadYoutubeMusic1.Size = new Size(786, 384);
            pageDownloadYoutubeMusic1.TabIndex = 0;
            // 
            // pageMix1
            // 
            pageMix1.BackColor = Color.FromArgb(28, 28, 28);
            pageMix1.Dock = DockStyle.Fill;
            pageMix1.ForeColor = Color.White;
            pageMix1.Location = new Point(3, 3);
            pageMix1.Name = "pageMix1";
            pageMix1.Size = new Size(786, 384);
            pageMix1.TabIndex = 0;
            // 
            // pageDownloadYoutube1
            // 
            pageDownloadYoutube1.Dock = DockStyle.Fill;
            pageDownloadYoutube1.Location = new Point(3, 3);
            pageDownloadYoutube1.Name = "pageDownloadYoutube1";
            pageDownloadYoutube1.Size = new Size(786, 384);
            pageDownloadYoutube1.TabIndex = 0;
            // 
            // pageDownloadSpotify
            // 
            pageDownloadSpotify.Dock = DockStyle.Fill;
            pageDownloadSpotify.Location = new Point(3, 3);
            pageDownloadSpotify.Name = "pageDownloadSpotify";
            pageDownloadSpotify.TabIndex = 0;


            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 32);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 418);
            tabControl1.TabIndex = 1;


            tabPage3.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
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
