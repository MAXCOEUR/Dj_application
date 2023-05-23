using Dj_application.model;
using Dj_application.Outil;
using NAudio.Gui;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Dj_application.View.Control
{
    public partial class LecteurAudioView : UserControl
    {
        LecteurAudio? lecteurAudio;
        BpmGenerate bpmGenerate = new BpmGenerate();
        ProgressBarAnimator animator;
        private Boolean isPlay = false;
        private bool isLoading = false;
        private bool isCasque = false;
        private LineAnnotation positionMarker;
        private LineAnnotation loadingMarker;
        private RectangleAnnotation progressBarAnnotation;
        private PlotModel model;
        private static int lastCreate = 1;
        private int numeroPiste;

        private int volumeMix = 100;
        public LecteurAudioView()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();

            animator = new ProgressBarAnimator(pb_loadingBpm);
            numeroPiste = lastCreate++;
            lb_nbr_piste.Text = "Piste " + numeroPiste;

            loadingMarker = new LineAnnotation
            {
                Type = LineAnnotationType.Vertical,
                X = 0,
                Color = OxyColors.Blue, // Couleur du marqueur de chargement
                StrokeThickness = 2,
                LineStyle = LineStyle.Solid,
            };
            model = new PlotModel();
            positionMarker = new LineAnnotation
            {
                Type = LineAnnotationType.Vertical,
                X = 0,
                Color = OxyColors.Red,
                StrokeThickness = 2,
                LineStyle = LineStyle.Solid,
            };
            progressBarAnnotation = new RectangleAnnotation
            {
                MinimumX = positionMarker.X, // Position actuelle du marqueur
                MaximumX = 0, // Valeur maximale de l'axe X
                MinimumY = -1, // Valeur minimale de l'axe Y
                MaximumY = +1, // Valeur maximale de l'axe Y
                Fill = OxyColor.FromArgb(100, 0, 0, 0), // Couleur de remplissage avec une opacité de 100
                Layer = AnnotationLayer.BelowAxes // Placez l'annotation sous les axes
            };
            model.Annotations.Add(progressBarAnnotation);

            model.Annotations.Add(loadingMarker);
            model.Annotations.Add(positionMarker);
            pv_graph.InvalidatePlot(false);
            // Désactiver le déplacement

            pv_graph.MouseMove += (sender, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    pv_graph.Model.ResetAllAxes();
                }
            };


            // Désactiver le zoom
            pv_graph.MouseWheel += (sender, e) =>
            {
                Console.WriteLine(e.Delta.ToString());
                pv_graph.Model.ZoomAllAxes(0);
            };





            model.PlotMargins = new OxyThickness(0); // Supprimer les marges
            model.Padding = new OxyThickness(0); // Supprimer le padding
            pv_graph.Model = model;

            initGrpahEmpty();

        }

        private void initGrpahEmpty()
        {
            pv_graph.Model.Series.Clear();
            pv_graph.Model.Axes.Clear();
            var xAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Maximum = 100,
                Minimum = 0,
            };
            var yAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Maximum = 1,
                Minimum = -1,
            };
            pv_graph.Model.Axes.Add(yAxis);
            pv_graph.Model.Axes.Add(xAxis);
        }
        public int getNumeroPiste()
        {
            return numeroPiste;
        }
        public void setMarker(LineAnnotation marker, double pourcentage)
        {
            if (positionMarker != null)
            {
                PlotModel plotModel = pv_graph.ActualModel;

                double sizeZone = plotModel.Axes[1].Maximum;

                double newPosition = pourcentage * sizeZone;

                marker.X = newPosition;

                if (marker.Color == OxyColors.Red)
                {
                    if (!isLoading)
                    {
                        progressBarAnnotation.MaximumX = newPosition; // Mettez à jour la nouvelle position du marqueur
                    }
                }
                else
                {
                    progressBarAnnotation.MaximumX = newPosition; // Mettez à jour la nouvelle position du marqueur
                }




                pv_graph.InvalidatePlot(false);
            }
        }

        public void setvolume(int volume = -1)
        {
            if (lecteurAudio == null) return;
            if (volume != -1)
            {
                volumeMix = volume;
            }
            if (isCasque)
            {
                lecteurAudio.setVolume((tb_volume.Value / 100.0f));
            }
            else
            {
                lecteurAudio.setVolume((tb_volume.Value / 100.0f) * (volumeMix / 100.0f));
            }
            
        }

        public void initEventAndLecteurAudio(Musique musique)
        {
            if (lecteurAudio != null)
            {
                lecteurAudio.PositionChanged -= lecteurAudio_PositionChanged;
                lecteurAudio.FinishGraph -= lecteurAudio_FinishGraph;
                lecteurAudio.LoadingPositionChanged -= lecteurAudio_LoadingPositionChanged;
                lecteurAudio.clickOnModel -= lecteurAudio_clickOnModel;
                lecteurAudio.FinLecture -= LecteurAudio_FinLecture;
                BpmGenerate.BpmTrouver -= bpmGenerate_BpmTrouver;
                lecteurAudio.Dispose();
            }
            lecteurAudio = new LecteurAudio(musique);
            lecteurAudio.PositionChanged += lecteurAudio_PositionChanged;
            lecteurAudio.FinishGraph += lecteurAudio_FinishGraph;
            lecteurAudio.LoadingPositionChanged += lecteurAudio_LoadingPositionChanged;
            lecteurAudio.clickOnModel += lecteurAudio_clickOnModel;
            lecteurAudio.FinLecture += LecteurAudio_FinLecture;
            BpmGenerate.BpmTrouver += bpmGenerate_BpmTrouver;

            ParametresForm pf = ParametresForm.Instance;
            if (isCasque)
            {
                lecteurAudio.setSortieAudio(pf.GetSortieAudioCasque());
            }
            else
            {
                lecteurAudio.setSortieAudio(pf.GetSortieAudioStandard());
            }
            lecteurAudio.Jouer();
            MettreEnPause();
        }

        public void setAudio(Musique musique)
        {
            try
            {
                initEventAndLecteurAudio(musique);

                animator.StartAnimation();
                bpmGenerate.getBpm(musique);

                lb_name.Text = musique.FileNameWithoutExtension;
                lb_timeTotal.Text = "/ " + ((int)(lecteurAudio.getDureeTotalSeconde())).ToString();
                lb_timeNow.Text = ((int)(lecteurAudio.getPositionActuelleSecondes())).ToString();
                lb_bpm.Text = "BPM : ";
                initGrpahEmpty();
                setvolume();

                isLoading = true;
                StartGeneratingPlotModel();
            }
            catch
            {
                MessageBox.Show("Le format n'est pas pris en compte", "Alerte", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private void StartGeneratingPlotModel()
        {
            lecteurAudio.StartGeneratingPlotModel(pv_graph);
        }
        private void LecteurAudio_FinLecture(object sender, EventArgs e)
        {
            if (bt_play_pause.InvokeRequired)
            {
                bt_play_pause.Invoke((MethodInvoker)delegate
                {
                    MettreEnPause();
                });
            }
            else
            {
                MettreEnPause();
            }

        }
        private void bpmGenerate_BpmTrouver(object sender, Musique musique)
        {
            if (musique != lecteurAudio.getMusique()) { return; }
            if (lb_bpm.InvokeRequired)
            {
                lb_bpm.Invoke((MethodInvoker)(() => lb_bpm.Text = "BPM : " + musique.bpm));
            }
            else
            {
                lb_bpm.Text = "BPM : " + musique.bpm;
            }
            animator.StopAnimation();
        }
        private void lecteurAudio_LoadingPositionChanged(object sender, double position)
        {
            setMarker(loadingMarker, position);
        }
        private void lecteurAudio_FinishGraph(object sender, bool e)
        {
            setMarker(positionMarker, lecteurAudio.getPositionActuellePourcentage());
            setMarker(loadingMarker, -1);
            isLoading = false;
        }
        private void lecteurAudio_clickOnModel(object sender, OxyMouseDownEventArgs e)
        {
            var mouseState = System.Windows.Forms.Control.MouseButtons;
            var mouseEventArgs = new MouseEventArgs(mouseState, 1, (int)e.Position.X, (int)e.Position.Y, 0);
            pv_graph_MouseClick(pv_graph, mouseEventArgs);
        }



        private void lecteurAudio_PositionChanged(object sender, double position)
        {
            if (lecteurAudio == null) return;
            int etat = (int)(lecteurAudio.getPositionActuellePourcentage() * 1000);
            int currentSec = (int)lecteurAudio.getPositionActuelleSecondes();

            if (pv_graph.InvokeRequired)
            {
                pv_graph.Invoke((MethodInvoker)delegate
                {
                    lb_timeNow.Text = currentSec.ToString();
                    setMarker(positionMarker, lecteurAudio.getPositionActuellePourcentage());
                });
            }
            else
            {
                lb_timeNow.Text = currentSec.ToString();
                setMarker(positionMarker, lecteurAudio.getPositionActuellePourcentage());
            }
        }

        private void Reprendre()
        {
            if (lecteurAudio == null) return;
            lecteurAudio.Reprendre();
            isPlay = true;
            bt_play_pause.BackColor = Color.Red;
            bt_play_pause.Text = "Pause";
        }
        private void MettreEnPause()
        {
            lecteurAudio.MettreEnPause();
            isPlay = false;
            bt_play_pause.BackColor = Color.Green;
            bt_play_pause.Text = "Jouer";
        }

        private void bt_stop_Click(object sender, EventArgs e)
        {
            if (lecteurAudio == null) return;
            lecteurAudio.Recommencer();
            MettreEnPause();
        }

        private void pv_graph_MouseClick(object sender, MouseEventArgs e)
        {
            if (lecteurAudio == null) return;
            if (e.Button == MouseButtons.Left)
            {
                int clickX = e.X;
                double totalWidth = pv_graph.Width;
                double clickPercentage = (double)clickX / totalWidth;
                double positionSeconds = clickPercentage * lecteurAudio.getDureeTotalSeconde();
                lecteurAudio.Deplacer(positionSeconds);
            }
        }

        private void bt_play_pause_Click(object sender, EventArgs e)
        {
            if (lecteurAudio == null) return;
            if (!isPlay)
            {
                Reprendre();
            }
            else
            {
                MettreEnPause();
            }
        }

        public bool isPlaying()
        {
            return isPlay;
        }

        private void tb_volume_ValueChanged(object sender, EventArgs e)
        {
            if (lecteurAudio == null) return;
            setvolume();
        }
        public void delete()
        {
            if (lecteurAudio != null)
            {
                lecteurAudio.delete();
            }

            Dispose();
        }

        private void bt_casque_Click(object sender, EventArgs e)
        {
            if(lecteurAudio==null) return;
            ParametresForm pf = ParametresForm.Instance;
            isCasque = !isCasque;
            setvolume();
            if (isCasque)
            {
                bt_casque.BackColor = Color.Green;
                lecteurAudio.setSortieAudio(pf.GetSortieAudioCasque());
            }
            else
            {
                bt_casque.BackColor = Color.Red;
                lecteurAudio.setSortieAudio(pf.GetSortieAudioStandard());
            }
        }
    }
}
