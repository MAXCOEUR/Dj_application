namespace Dj_application.View
{
    partial class LecteurMusiqueOnline
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
            lb_temp = new Label();
            lb_name = new Label();
            tb_volume = new TrackBar();
            bt_playPause = new Button();
            pb_time = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)tb_volume).BeginInit();
            SuspendLayout();
            // 
            // lb_temp
            // 
            lb_temp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lb_temp.AutoSize = true;
            lb_temp.Location = new Point(776, 15);
            lb_temp.Name = "lb_temp";
            lb_temp.Size = new Size(112, 15);
            lb_temp.TabIndex = 9;
            lb_temp.Text = "temp de la musique";
            lb_temp.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lb_name
            // 
            lb_name.AutoSize = true;
            lb_name.Location = new Point(70, 15);
            lb_name.Name = "lb_name";
            lb_name.Size = new Size(109, 15);
            lb_name.TabIndex = 8;
            lb_name.Text = "nom de la musique";
            lb_name.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tb_volume
            // 
            tb_volume.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tb_volume.Location = new Point(119, 90);
            tb_volume.Maximum = 100;
            tb_volume.Name = "tb_volume";
            tb_volume.Size = new Size(769, 45);
            tb_volume.TabIndex = 7;
            tb_volume.TickStyle = TickStyle.None;
            tb_volume.Value = 100;
            // 
            // bt_playPause
            // 
            bt_playPause.Location = new Point(25, 86);
            bt_playPause.Name = "bt_playPause";
            bt_playPause.Size = new Size(75, 23);
            bt_playPause.TabIndex = 6;
            bt_playPause.Text = "Play";
            bt_playPause.UseVisualStyleBackColor = true;
            // 
            // pb_time
            // 
            pb_time.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pb_time.Location = new Point(70, 33);
            pb_time.Name = "pb_time";
            pb_time.Size = new Size(818, 23);
            pb_time.TabIndex = 5;
            // 
            // LecteurMusiqueOnline
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lb_temp);
            Controls.Add(lb_name);
            Controls.Add(tb_volume);
            Controls.Add(bt_playPause);
            Controls.Add(pb_time);
            Name = "LecteurMusiqueOnline";
            Size = new Size(950, 150);
            ((System.ComponentModel.ISupportInitialize)tb_volume).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lb_temp;
        private Label lb_name;
        private TrackBar tb_volume;
        private Button bt_playPause;
        private ProgressBar pb_time;
    }
}
