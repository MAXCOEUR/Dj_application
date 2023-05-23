using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
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
            this.Text = "Option";
            Initial();
            SortieAudioParDefaut();

        }

        private void Initial()
        {
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
            cb_audioCasque.Items.Clear();
            cb_audioStandard.Items.Clear();
            foreach (WaveOutCapabilities sortie in sortiesAudio)
            {
                cb_audioCasque.Items.Add(sortie.ProductName);
                cb_audioStandard.Items.Add(sortie.ProductName);
            }
        }

        private void SortieAudioParDefaut()
        {

            int defaultOut = getSortieAudioParDefaut();
            cb_audioStandard.SelectedIndex = defaultOut;
            cb_audioCasque.SelectedIndex = defaultOut;
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

        private void cb_audioStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("cb_audioStandard_SelectedIndexChanged " + cb_audioStandard.SelectedIndex);
            standard = sortiesAudio[cb_audioStandard.SelectedIndex];
        }

        private void cb_audioCasque_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("cb_audioCasque_SelectedIndexChanged " + cb_audioCasque.SelectedIndex);
            casque = sortiesAudio[cb_audioCasque.SelectedIndex];
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
