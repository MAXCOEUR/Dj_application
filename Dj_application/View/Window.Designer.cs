using Dj_application.View.Control;

namespace Dj_application.View
{
    partial class Window
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            Pb_LoadingDownload = new ToolStripProgressBar();
            cb_nbrPiste = new ToolStripComboBox();
            tabPage3 = new TabPage();
            pageDownloadYoutubeMusic1 = new PageDownloadYoutubeMusic();
            tabPage1 = new TabPage();
            pageMix1 = new PageMix();
            
            tabPage2 = new TabPage();
            pageDownloadYoutube1 = new PageDownloadYoutube();
            toolStrip1.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = SystemColors.ButtonShadow;
            toolStrip1.GripMargin = new Padding(0);
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, Pb_LoadingDownload, cb_nbrPiste });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0);
            toolStrip1.Size = new Size(800, 32);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripButton1.Image = Resource.setting;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(23, 29);
            toolStripButton1.Text = "option";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // Pb_LoadingDownload
            // 
            Pb_LoadingDownload.Name = "Pb_LoadingDownload";
            Pb_LoadingDownload.Size = new Size(100, 29);
            // 
            // cb_nbrPiste
            // 
            cb_nbrPiste.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_nbrPiste.Items.AddRange(new object[] { "2", "3", "4", "5", "6" });
            cb_nbrPiste.Name = "cb_nbrPiste";
            cb_nbrPiste.Size = new Size(121, 32);
            cb_nbrPiste.SelectedIndexChanged += cb_nbrPiste_SelectedIndexChanged;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(pageDownloadYoutubeMusic1);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(792, 390);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // pageDownloadYoutubeMusic1
            // 
            pageDownloadYoutubeMusic1.Dock = DockStyle.Fill;
            pageDownloadYoutubeMusic1.Location = new Point(3, 3);
            pageDownloadYoutubeMusic1.Name = "pageDownloadYoutubeMusic1";
            pageDownloadYoutubeMusic1.Size = new Size(786, 384);
            pageDownloadYoutubeMusic1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(pageMix1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 390);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // pageMix1
            // 
            pageMix1.BackColor = Color.FromArgb(28, 28, 28);
            pageMix1.Dock = DockStyle.Fill;
            pageMix1.ForeColor = Color.White;
            pageMix1.Location = new Point(3, 3);
            pageMix1.Name = "pageMix1";
            pageMix1.Size = new Size(786, 384);
            pageMix1.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 32);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 418);
            tabControl1.TabIndex = 1;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(pageDownloadYoutube1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 390);
            tabPage2.TabIndex = 3;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // pageDownloadYoutube1
            // 
            pageDownloadYoutube1.Dock = DockStyle.Fill;
            pageDownloadYoutube1.Location = new Point(3, 3);
            pageDownloadYoutube1.Name = "pageDownloadYoutube1";
            pageDownloadYoutube1.Size = new Size(786, 384);
            pageDownloadYoutube1.TabIndex = 0;
            // 
            // Window
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Controls.Add(toolStrip1);
            Name = "Window";
            Text = "Window";
            FormClosed += Window_FormClosed;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripProgressBar Pb_LoadingDownload;
        private ToolStripButton toolStripButton1;
        private TabPage tabPage3;
        private PageDownloadYoutubeMusic pageDownloadYoutubeMusic1;
        private TabPage tabPage1;
        private PageMix pageMix1;
        private TabPage tabPage2;
        private PageDownloadYoutube pageDownloadYoutube1;
        private ToolStripComboBox cb_nbrPiste;
    }
}