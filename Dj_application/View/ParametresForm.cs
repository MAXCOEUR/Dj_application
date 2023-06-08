using Dj_application.model;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Dj_application.View
{
    public partial class ParametresForm : Form
    {
        private static ParametresForm instance;
        private List<WaveOutCapabilities> sortiesAudio;
        private WaveOutCapabilities casque;
        private WaveOutCapabilities standard;
        public Font fontDefault = new Font("Arial", 16, FontStyle.Regular);
        private string browser = "";
        public PalettesCouleur palettesCouleur { get; }
        private int timeSecondeClignotement;
        private int timeLunchMusique;

        public static ParametresForm Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ParametresForm();
                }
                instance.Initial();
                return instance;
            }
        }

        private ParametresForm()
        {
            InitializeComponent();
            cb_BrowserYTMusic.SelectedIndex = 0;
            this.Text = "Option";
            palettesCouleur = new PalettesCouleur();
            setColor();
            Initial();
            numericUpDown_timeClignotement.Value = 30;
            numericUpDown_timelunchMusic.Value = 10;
            SortieAudioParDefaut();

        }
        private void setColor()
        {
            this.BackColor = palettesCouleur.Fond;
            this.ForeColor = palettesCouleur.Texte;
            this.Font = fontDefault;
        }

        private void Initial()
        {
            casque = WaveOut.GetCapabilities(0);
            InitializeSortiesAudio();
            PopulateComboBoxes();
        }

        private void InitializeSortiesAudio()
        {
            sortiesAudio = GetSortiesAudio();
        }

        private List<WaveOutCapabilities> GetSortiesAudio()
        {
            List<WaveOutCapabilities> sortiesAudio = new List<WaveOutCapabilities>();

            for (int deviceNumber = 0; deviceNumber < WaveOut.DeviceCount; deviceNumber++)
            {
                WaveOutCapabilities capabilities = WaveOut.GetCapabilities(deviceNumber);
                sortiesAudio.Add(capabilities);
            }

            return sortiesAudio;
        }

        private void PopulateComboBoxes()
        {
            cb_audioStandard.Items.Clear();
            foreach (WaveOutCapabilities sortie in sortiesAudio)
            {
                cb_audioStandard.Items.Add(sortie.ProductName);
            }
            lb_casqueSortie.Text = casque.ProductName;
        }

        private void SortieAudioParDefaut()
        {
            int defaultOut = getSortieAudioParDefaut();
            cb_audioStandard.SelectedIndex = defaultOut;
        }
        private int getSortieAudioParDefaut()
        {
            WaveOutCapabilities defaultCapabilities = WaveOut.GetCapabilities(0);
            int defaultOut = -1;
            for (int i = 0; i < sortiesAudio.Count; i++)
            {
                if (sortiesAudio[i].Equals(defaultCapabilities))
                {
                    defaultOut = i;
                }
            }
            return defaultOut;
        }

        public int GetSortieAudioStandard()
        {
            Initial();
            for (int i = 0; i < sortiesAudio.Count(); i++)
            {
                if (sortiesAudio[i].Equals(standard))
                {
                    return i;
                }
            }
            return getSortieAudioParDefaut();
        }
        public int GetSortieAudioCasque()
        {
            Initial();
            for (int i = 0; i < sortiesAudio.Count(); i++)
            {
                if (sortiesAudio[i].Equals(casque))
                {
                    return i;
                }
            }
            return getSortieAudioParDefaut();
        }
        public WaveOutCapabilities GetSortieAudioCasqueWaveOutCapabilities()
        {
            Initial();
            for (int i = 0; i < sortiesAudio.Count(); i++)
            {
                if (sortiesAudio[i].Equals(casque))
                {
                    return sortiesAudio[i];
                }
            }
            return sortiesAudio[getSortieAudioParDefaut()];
        }
        public int getTimeClignotement()
        {
            return timeSecondeClignotement;
        }

        private void cb_audioStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("cb_audioStandard_SelectedIndexChanged " + cb_audioStandard.SelectedIndex);
            standard = sortiesAudio[cb_audioStandard.SelectedIndex];
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDown_timeClignotement_ValueChanged(object sender, EventArgs e)
        {
            timeSecondeClignotement = (int)numericUpDown_timeClignotement.Value;
        }

        private void cb_BrowserYTMusic_SelectedIndexChanged(object sender, EventArgs e)
        {
            browser = cb_BrowserYTMusic.SelectedItem.ToString();
        }
        public string getBrowser()
        {
            return browser;
        }

        private void numericUpDown_timelunchMusic_ValueChanged(object sender, EventArgs e)
        {
            timeLunchMusique = (int)numericUpDown_timelunchMusic.Value;
        }
        public int getTimelunchMusic()
        {
            return timeLunchMusique;
        }
    }
}
