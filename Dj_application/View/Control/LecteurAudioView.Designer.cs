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
            pb_progress = new ProgressBar();
            vm_son = new NAudio.Gui.VolumeMeter();
            bt_play_pause = new Button();
            bt_stop = new Button();
            bt_suite = new Button();
            sb_son = new TrackBar();
            lb_timeNow = new Label();
            lb_timeTotal = new Label();
            pv_graph = new OxyPlot.WindowsForms.PlotView();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sb_son).BeginInit();
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
            tableLayoutPanel1.Controls.Add(pb_progress, 0, 6);
            tableLayoutPanel1.Controls.Add(vm_son, 18, 1);
            tableLayoutPanel1.Controls.Add(bt_play_pause, 0, 8);
            tableLayoutPanel1.Controls.Add(bt_stop, 2, 8);
            tableLayoutPanel1.Controls.Add(bt_suite, 18, 8);
            tableLayoutPanel1.Controls.Add(sb_son, 4, 8);
            tableLayoutPanel1.Controls.Add(lb_timeNow, 8, 7);
            tableLayoutPanel1.Controls.Add(lb_timeTotal, 10, 7);
            tableLayoutPanel1.Controls.Add(pv_graph, 0, 1);
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
            // pb_progress
            // 
            tableLayoutPanel1.SetColumnSpan(pb_progress, 18);
            pb_progress.Dock = DockStyle.Fill;
            pb_progress.Location = new Point(3, 153);
            pb_progress.Maximum = 1000;
            pb_progress.Name = "pb_progress";
            pb_progress.Size = new Size(606, 19);
            pb_progress.Step = 1;
            pb_progress.Style = ProgressBarStyle.Continuous;
            pb_progress.TabIndex = 3;
            pb_progress.MouseClick += pb_progress_MouseClick;
            // 
            // vm_son
            // 
            vm_son.Amplitude = 0F;
            tableLayoutPanel1.SetColumnSpan(vm_son, 2);
            vm_son.Dock = DockStyle.Fill;
            vm_son.Location = new Point(615, 28);
            vm_son.MaxDb = 18F;
            vm_son.MinDb = -60F;
            vm_son.Name = "vm_son";
            vm_son.RightToLeft = RightToLeft.No;
            tableLayoutPanel1.SetRowSpan(vm_son, 6);
            vm_son.Size = new Size(64, 144);
            vm_son.TabIndex = 4;
            vm_son.Text = "volumeMeter1";
            // 
            // bt_play_pause
            // 
            bt_play_pause.BackColor = Color.FromArgb(0, 192, 0);
            tableLayoutPanel1.SetColumnSpan(bt_play_pause, 2);
            bt_play_pause.Dock = DockStyle.Fill;
            bt_play_pause.Location = new Point(0, 200);
            bt_play_pause.Margin = new Padding(0);
            bt_play_pause.Name = "bt_play_pause";
            bt_play_pause.Size = new Size(68, 25);
            bt_play_pause.TabIndex = 5;
            bt_play_pause.Text = "play";
            bt_play_pause.UseVisualStyleBackColor = false;
            bt_play_pause.Click += bt_play_pause_Click;
            // 
            // bt_stop
            // 
            bt_stop.BackColor = Color.Red;
            tableLayoutPanel1.SetColumnSpan(bt_stop, 2);
            bt_stop.Dock = DockStyle.Fill;
            bt_stop.Location = new Point(68, 200);
            bt_stop.Margin = new Padding(0);
            bt_stop.Name = "bt_stop";
            bt_stop.Size = new Size(68, 25);
            bt_stop.TabIndex = 6;
            bt_stop.Text = "stop";
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
            bt_suite.Size = new Size(70, 25);
            bt_suite.TabIndex = 8;
            bt_suite.Text = "suite";
            bt_suite.UseVisualStyleBackColor = true;
            // 
            // sb_son
            // 
            tableLayoutPanel1.SetColumnSpan(sb_son, 14);
            sb_son.Dock = DockStyle.Fill;
            sb_son.LargeChange = 1;
            sb_son.Location = new Point(139, 203);
            sb_son.Maximum = 100;
            sb_son.Name = "sb_son";
            sb_son.Size = new Size(470, 19);
            sb_son.TabIndex = 1;
            sb_son.Value = 100;
            sb_son.Scroll += sb_son_Scroll;
            // 
            // lb_timeNow
            // 
            lb_timeNow.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(lb_timeNow, 2);
            lb_timeNow.Dock = DockStyle.Fill;
            lb_timeNow.Location = new Point(272, 175);
            lb_timeNow.Margin = new Padding(0);
            lb_timeNow.Name = "lb_timeNow";
            lb_timeNow.Size = new Size(68, 25);
            lb_timeNow.TabIndex = 10;
            lb_timeNow.Text = "current";
            lb_timeNow.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lb_timeTotal
            // 
            lb_timeTotal.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(lb_timeTotal, 2);
            lb_timeTotal.Dock = DockStyle.Fill;
            lb_timeTotal.Location = new Point(340, 175);
            lb_timeTotal.Margin = new Padding(0);
            lb_timeTotal.Name = "lb_timeTotal";
            lb_timeTotal.Size = new Size(68, 25);
            lb_timeTotal.TabIndex = 11;
            lb_timeTotal.Text = "/ totalTime";
            lb_timeTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pv_graph
            // 
            tableLayoutPanel1.SetColumnSpan(pv_graph, 18);
            pv_graph.Dock = DockStyle.Fill;
            pv_graph.Location = new Point(3, 28);
            pv_graph.Name = "pv_graph";
            pv_graph.PanCursor = Cursors.Hand;
            tableLayoutPanel1.SetRowSpan(pv_graph, 5);
            pv_graph.Size = new Size(606, 119);
            pv_graph.TabIndex = 12;
            pv_graph.Text = "plotView1";
            pv_graph.ZoomHorizontalCursor = Cursors.SizeWE;
            pv_graph.ZoomRectangleCursor = Cursors.SizeNWSE;
            pv_graph.ZoomVerticalCursor = Cursors.SizeNS;
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
            ((System.ComponentModel.ISupportInitialize)sb_son).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lb_name;
        private Label lb_nbr_piste;
        private ProgressBar pb_progress;
        private NAudio.Gui.VolumeMeter vm_son;
        private Button bt_play_pause;
        private Button bt_stop;
        private Button bt_suite;
        private TrackBar sb_son;
        private Label lb_timeNow;
        private Label lb_timeTotal;
        private OxyPlot.WindowsForms.PlotView pv_graph;
    }
}
