using NAudio.CoreAudioApi;
using NAudio.Wave;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Dj_application.View
{
    public partial class ParametresForm : Form
    {
        private static ParametresForm instance;
        private List<KeyValuePair<int, string>> sortiesAudio;

        public static ParametresForm Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ParametresForm();
                }
                return instance;
            }
        }

        private ParametresForm()
        {
            InitializeComponent();
            this.Text = "Option";
            InitializeSortiesAudio();
            PopulateComboBoxes();
        }

        private void InitializeSortiesAudio()
        {
            sortiesAudio = GetSortiesAudio();
        }

        private List<KeyValuePair<int, string>> GetSortiesAudio()
        {
            List<KeyValuePair<int, string>> sortiesAudio = new List<KeyValuePair<int, string>>();

            for (int deviceNumber = 0; deviceNumber < WaveOut.DeviceCount; deviceNumber++)
            {
                WaveOutCapabilities capabilities = WaveOut.GetCapabilities(deviceNumber);
                string sortieAudio = capabilities.ProductName;
                sortiesAudio.Add(new KeyValuePair<int, string>(deviceNumber, sortieAudio));
            }

            return sortiesAudio;
        }

        private void PopulateComboBoxes()
        {
            foreach (KeyValuePair<int, string> sortie in sortiesAudio)
            {
                cb_audioCasque.Items.Add(sortie.Value);
                cb_audioStandard.Items.Add(sortie.Value);
            }

            cb_audioStandard.SelectedIndex = GetSortieAudioParDefaut();
            cb_audioCasque.SelectedIndex = GetSortieAudioParDefaut();
        }

        private int GetSortieAudioParDefaut()
        {
            WaveOutCapabilities defaultCapabilities = WaveOut.GetCapabilities(0);
            string defaultDeviceName = defaultCapabilities.ProductName;

            for (int i = 0; i < sortiesAudio.Count; i++)
            {
                if (sortiesAudio[i].Value == defaultDeviceName)
                {
                    return i;
                }
            }

            // Retourner une valeur par défaut si aucun périphérique correspondant n'est trouvé
            return -1;
        }

        public int GetSortieAudioStandard()
        {
            return cb_audioStandard.SelectedIndex;
        }
        public int GetSortieAudioCasque()
        {
            return cb_audioCasque.SelectedIndex;
        }
    }
}
