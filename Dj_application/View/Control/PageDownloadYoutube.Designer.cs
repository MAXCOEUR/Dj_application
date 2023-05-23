namespace Dj_application.View.Control
{
    partial class PageDownloadYoutube
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
            bt_mute = new Button();
            bt_back = new Button();
            wv_youtube = new Microsoft.Web.WebView2.WinForms.WebView2();
            bt_download = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)wv_youtube).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(bt_mute);
            splitContainer1.Panel1.Controls.Add(bt_back);
            splitContainer1.Panel1.Controls.Add(wv_youtube);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(bt_download);
            splitContainer1.Size = new Size(823, 476);
            splitContainer1.SplitterDistance = 590;
            splitContainer1.TabIndex = 0;
            // 
            // bt_mute
            // 
            bt_mute.BackColor = Color.Lime;
            bt_mute.Location = new Point(100, 3);
            bt_mute.Name = "bt_mute";
            bt_mute.Size = new Size(93, 23);
            bt_mute.TabIndex = 3;
            bt_mute.Text = "mute";
            bt_mute.UseVisualStyleBackColor = false;
            bt_mute.Click += bt_mute_Click;
            // 
            // bt_back
            // 
            bt_back.Location = new Point(0, 3);
            bt_back.Name = "bt_back";
            bt_back.Size = new Size(94, 23);
            bt_back.TabIndex = 2;
            bt_back.Text = "retour";
            bt_back.UseVisualStyleBackColor = true;
            bt_back.Click += bt_back_Click;
            // 
            // wv_youtube
            // 
            wv_youtube.AllowExternalDrop = true;
            wv_youtube.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            wv_youtube.CreationProperties = null;
            wv_youtube.DefaultBackgroundColor = Color.White;
            wv_youtube.Location = new Point(0, 29);
            wv_youtube.Name = "wv_youtube";
            wv_youtube.Size = new Size(590, 447);
            wv_youtube.TabIndex = 0;
            wv_youtube.ZoomFactor = 1D;
            // 
            // bt_download
            // 
            bt_download.BackColor = Color.Lime;
            bt_download.Dock = DockStyle.Fill;
            bt_download.Location = new Point(0, 0);
            bt_download.Name = "bt_download";
            bt_download.Size = new Size(229, 476);
            bt_download.TabIndex = 0;
            bt_download.Text = "telecharger";
            bt_download.UseVisualStyleBackColor = false;
            bt_download.Click += bt_download_Click;
            // 
            // PageDownloadYoutube
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "PageDownloadYoutube";
            Size = new Size(823, 476);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)wv_youtube).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Microsoft.Web.WebView2.WinForms.WebView2 wv_youtube;
        private Button bt_download;
        private Button bt_back;
        private Button bt_mute;
    }
}
