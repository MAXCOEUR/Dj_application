namespace Dj_application.View.Control
{
    partial class PageDownload
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
            splitContainer1 = new SplitContainer();
            bt_dowload = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(bt_dowload);
            splitContainer1.Size = new Size(1233, 535);
            splitContainer1.SplitterDistance = 857;
            splitContainer1.TabIndex = 0;
            // 
            // bt_dowload
            // 
            bt_dowload.BackColor = Color.Lime;
            bt_dowload.Dock = DockStyle.Fill;
            bt_dowload.Location = new Point(0, 0);
            bt_dowload.Margin = new Padding(50);
            bt_dowload.Name = "bt_dowload";
            bt_dowload.Padding = new Padding(5);
            bt_dowload.Size = new Size(372, 535);
            bt_dowload.TabIndex = 0;
            bt_dowload.Text = "Download";
            bt_dowload.UseVisualStyleBackColor = false;
            bt_dowload.Click += bt_dowload_Click;
            // 
            // PageDownload
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "PageDownload";
            Size = new Size(1233, 535);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button bt_dowload;
        private LecteurMusiqueOnline explorateurAndLecteurYoutube1;
    }
}
