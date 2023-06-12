using Dj_application.View.Control;
using Dj_application.View.DownloadPage;

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
            toolStrip1.SuspendLayout();
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
            // Window
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(toolStrip1);
            Name = "Window";
            Text = "DJ_Application";
            FormClosed += Window_FormClosed;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripProgressBar Pb_LoadingDownload;
        private ToolStripButton toolStripButton1;
        private ToolStripComboBox cb_nbrPiste;
    }
}