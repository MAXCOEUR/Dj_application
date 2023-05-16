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
            toolStripProgressBar1 = new ToolStripProgressBar();
            cb_nbrPiste = new ToolStripComboBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            pageMix1 = new Control.PageMix();
            tabPage2 = new TabPage();
            toolStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBar1, cb_nbrPiste });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 22);
            // 
            // cb_nbrPiste
            // 
            cb_nbrPiste.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_nbrPiste.Items.AddRange(new object[] { "2", "3", "4", "5", "6" });
            cb_nbrPiste.Name = "cb_nbrPiste";
            cb_nbrPiste.Size = new Size(75, 25);
            cb_nbrPiste.SelectedIndexChanged += cb_nbrPiste_SelectedIndexChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 25);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 425);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(pageMix1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 397);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // pageMix1
            // 
            pageMix1.Dock = DockStyle.Fill;
            pageMix1.Location = new Point(3, 3);
            pageMix1.Name = "pageMix1";
            pageMix1.Size = new Size(786, 391);
            pageMix1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 397);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
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
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ToolStripProgressBar toolStripProgressBar1;
        private Control.PageMix pageMix1;
        private ToolStripComboBox cb_nbrPiste;
    }
}