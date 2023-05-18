namespace Dj_application.View.Control
{
    partial class PageMixYoutubeMusic
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
            tb_master = new TrackBar();
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)tb_master).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // tb_master
            // 
            tb_master.Dock = DockStyle.Bottom;
            tb_master.Location = new Point(0, 519);
            tb_master.Maximum = 100;
            tb_master.Minimum = -100;
            tb_master.Name = "tb_master";
            tb_master.Size = new Size(1128, 45);
            tb_master.TabIndex = 0;
            tb_master.TickStyle = TickStyle.None;
            tb_master.ValueChanged += tb_master_ValueChanged;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Size = new Size(1128, 519);
            splitContainer1.SplitterDistance = 562;
            splitContainer1.TabIndex = 1;
            // 
            // PageMixYoutubeMusic
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Controls.Add(tb_master);
            Name = "PageMixYoutubeMusic";
            Size = new Size(1128, 564);
            ((System.ComponentModel.ISupportInitialize)tb_master).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar tb_master;
        private SplitContainer splitContainer1;
    }
}
