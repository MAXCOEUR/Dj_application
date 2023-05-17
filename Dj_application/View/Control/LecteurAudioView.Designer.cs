namespace Dj_application.View.Control
{
    partial class LecteurAudioView
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            lb_name = new Label();
            lb_nbr_piste = new Label();
            bt_stop = new Button();
            bt_suite = new Button();
            lb_timeNow = new Label();
            lb_timeTotal = new Label();
            pv_graph = new OxyPlot.WindowsForms.PlotView();
            bt_play_pause = new Button();
            tb_volume = new TrackBar();
            lb_bpm = new Label();
            pb_loadingBpm = new ProgressBar();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tb_volume).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 20;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.Controls.Add(lb_name, 0, 0);
            tableLayoutPanel1.Controls.Add(lb_nbr_piste, 17, 0);
            tableLayoutPanel1.Controls.Add(bt_stop, 2, 8);
            tableLayoutPanel1.Controls.Add(bt_suite, 18, 8);
            tableLayoutPanel1.Controls.Add(lb_timeNow, 1, 7);
            tableLayoutPanel1.Controls.Add(lb_timeTotal, 10, 7);
            tableLayoutPanel1.Controls.Add(pv_graph, 0, 1);
            tableLayoutPanel1.Controls.Add(bt_play_pause, 0, 8);
            tableLayoutPanel1.Controls.Add(tb_volume, 4, 8);
            tableLayoutPanel1.Controls.Add(lb_bpm, 9, 0);
            tableLayoutPanel1.Controls.Add(pb_loadingBpm, 12, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 10;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(682, 252);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lb_name
            // 
            lb_name.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(lb_name, 4);
            lb_name.Dock = DockStyle.Fill;
            lb_name.Location = new Point(3, 0);
            lb_name.Name = "lb_name";
            lb_name.Size = new Size(130, 25);
            lb_name.TabIndex = 0;
            lb_name.Text = "nom musique";
            lb_name.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lb_nbr_piste
            // 
            lb_nbr_piste.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(lb_nbr_piste, 3);
            lb_nbr_piste.Dock = DockStyle.Fill;
            lb_nbr_piste.Location = new Point(581, 0);
            lb_nbr_piste.Name = "lb_nbr_piste";
            lb_nbr_piste.Size = new Size(98, 25);
            lb_nbr_piste.TabIndex = 1;
            lb_nbr_piste.Text = "numero piste";
            lb_nbr_piste.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // bt_stop
            // 
            bt_stop.BackColor = Color.Red;
            tableLayoutPanel1.SetColumnSpan(bt_stop, 2);
            bt_stop.Dock = DockStyle.Fill;
            bt_stop.Location = new Point(68, 200);
            bt_stop.Margin = new Padding(0);
            bt_stop.Name = "bt_stop";
            tableLayoutPanel1.SetRowSpan(bt_stop, 2);
            bt_stop.Size = new Size(68, 52);
            bt_stop.TabIndex = 6;
            bt_stop.Text = "Stop";
            bt_stop.UseVisualStyleBackColor = false;
            bt_stop.Click += bt_stop_Click;
            // 
            // bt_suite
            // 
            tableLayoutPanel1.SetColumnSpan(bt_suite, 2);
            bt_suite.Dock = DockStyle.Fill;
            bt_suite.Location = new Point(612, 200);
            bt_suite.Margin = new Padding(0);
            bt_suite.Name = "bt_suite";
            tableLayoutPanel1.SetRowSpan(bt_suite, 2);
            bt_suite.Size = new Size(70, 52);
            bt_suite.TabIndex = 8;
            bt_suite.Text = "suite";
            bt_suite.UseVisualStyleBackColor = true;
            // 
            // lb_timeNow
            // 
            lb_timeNow.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(lb_timeNow, 9);
            lb_timeNow.Dock = DockStyle.Fill;
            lb_timeNow.Location = new Point(34, 175);
            lb_timeNow.Margin = new Padding(0);
            lb_timeNow.Name = "lb_timeNow";
            lb_timeNow.Size = new Size(306, 25);
            lb_timeNow.TabIndex = 10;
            lb_timeNow.Text = "current";
            lb_timeNow.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lb_timeTotal
            // 
            lb_timeTotal.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(lb_timeTotal, 9);
            lb_timeTotal.Dock = DockStyle.Fill;
            lb_timeTotal.Location = new Point(340, 175);
            lb_timeTotal.Margin = new Padding(0);
            lb_timeTotal.Name = "lb_timeTotal";
            lb_timeTotal.Size = new Size(306, 25);
            lb_timeTotal.TabIndex = 11;
            lb_timeTotal.Text = "/ totalTime";
            lb_timeTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pv_graph
            // 
            tableLayoutPanel1.SetColumnSpan(pv_graph, 20);
            pv_graph.Dock = DockStyle.Fill;
            pv_graph.Location = new Point(0, 25);
            pv_graph.Margin = new Padding(0);
            pv_graph.Name = "pv_graph";
            pv_graph.PanCursor = Cursors.Hand;
            tableLayoutPanel1.SetRowSpan(pv_graph, 6);
            pv_graph.Size = new Size(682, 150);
            pv_graph.TabIndex = 12;
            pv_graph.Text = "plotView1";
            pv_graph.ZoomHorizontalCursor = Cursors.SizeWE;
            pv_graph.ZoomRectangleCursor = Cursors.SizeNWSE;
            pv_graph.ZoomVerticalCursor = Cursors.SizeNS;
            pv_graph.MouseClick += pv_graph_MouseClick;
            // 
            // bt_play_pause
            // 
            bt_play_pause.BackColor = Color.Lime;
            tableLayoutPanel1.SetColumnSpan(bt_play_pause, 2);
            bt_play_pause.Dock = DockStyle.Fill;
            bt_play_pause.Location = new Point(0, 200);
            bt_play_pause.Margin = new Padding(0);
            bt_play_pause.Name = "bt_play_pause";
            tableLayoutPanel1.SetRowSpan(bt_play_pause, 2);
            bt_play_pause.Size = new Size(68, 52);
            bt_play_pause.TabIndex = 14;
            bt_play_pause.Text = "Play";
            bt_play_pause.UseVisualStyleBackColor = false;
            bt_play_pause.Click += bt_play_pause_Click;
            // 
            // tb_volume
            // 
            tb_volume.AutoSize = false;
            tb_volume.BackColor = SystemColors.Control;
            tableLayoutPanel1.SetColumnSpan(tb_volume, 14);
            tb_volume.Cursor = Cursors.Hand;
            tb_volume.Dock = DockStyle.Fill;
            tb_volume.Location = new Point(139, 203);
            tb_volume.Maximum = 100;
            tb_volume.Name = "tb_volume";
            tableLayoutPanel1.SetRowSpan(tb_volume, 2);
            tb_volume.Size = new Size(470, 46);
            tb_volume.TabIndex = 15;
            tb_volume.TickStyle = TickStyle.None;
            tb_volume.Value = 100;
            tb_volume.ValueChanged += tb_volume_ValueChanged;
            // 
            // lb_bpm
            // 
            lb_bpm.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(lb_bpm, 3);
            lb_bpm.Dock = DockStyle.Fill;
            lb_bpm.Location = new Point(309, 0);
            lb_bpm.Name = "lb_bpm";
            lb_bpm.Size = new Size(96, 25);
            lb_bpm.TabIndex = 16;
            lb_bpm.Text = "BPM :";
            lb_bpm.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pb_loadingBpm
            // 
            tableLayoutPanel1.SetColumnSpan(pb_loadingBpm, 4);
            pb_loadingBpm.Dock = DockStyle.Fill;
            pb_loadingBpm.Location = new Point(411, 3);
            pb_loadingBpm.MarqueeAnimationSpeed = 50;
            pb_loadingBpm.Name = "pb_loadingBpm";
            pb_loadingBpm.Size = new Size(130, 19);
            pb_loadingBpm.Style = ProgressBarStyle.Marquee;
            pb_loadingBpm.TabIndex = 17;
            pb_loadingBpm.Visible = false;
            // 
            // LecteurAudioView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "LecteurAudioView";
            Size = new Size(682, 252);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tb_volume).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lb_name;
        private Label lb_nbr_piste;
        private Button bt_stop;
        private Button bt_suite;
        private Label lb_timeNow;
        private Label lb_timeTotal;
        private OxyPlot.WindowsForms.PlotView pv_graph;
        private Button bt_play_pause;
        private TrackBar tb_volume;
        private Label lb_bpm;
        private ProgressBar pb_loadingBpm;
    }
}
