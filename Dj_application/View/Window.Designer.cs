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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            lecteurAudioView1 = new Control.LecteurAudioView();
            lecteurAudioView2 = new Control.LecteurAudioView();
            lecteurAudioView3 = new Control.LecteurAudioView();
            lecteurAudioView4 = new Control.LecteurAudioView();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 450);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tableLayoutPanel1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 422);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(192, 72);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(lecteurAudioView1, 0, 0);
            tableLayoutPanel1.Controls.Add(lecteurAudioView2, 0, 1);
            tableLayoutPanel1.Controls.Add(lecteurAudioView3, 1, 0);
            tableLayoutPanel1.Controls.Add(lecteurAudioView4, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(786, 416);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lecteurAudioView1
            // 
            lecteurAudioView1.Dock = DockStyle.Fill;
            lecteurAudioView1.Location = new Point(3, 3);
            lecteurAudioView1.Name = "lecteurAudioView1";
            lecteurAudioView1.Size = new Size(387, 202);
            lecteurAudioView1.TabIndex = 0;
            // 
            // lecteurAudioView2
            // 
            lecteurAudioView2.Dock = DockStyle.Fill;
            lecteurAudioView2.Location = new Point(3, 211);
            lecteurAudioView2.Name = "lecteurAudioView2";
            lecteurAudioView2.Size = new Size(387, 202);
            lecteurAudioView2.TabIndex = 1;
            // 
            // lecteurAudioView3
            // 
            lecteurAudioView3.Dock = DockStyle.Fill;
            lecteurAudioView3.Location = new Point(396, 3);
            lecteurAudioView3.Name = "lecteurAudioView3";
            lecteurAudioView3.Size = new Size(387, 202);
            lecteurAudioView3.TabIndex = 2;
            // 
            // lecteurAudioView4
            // 
            lecteurAudioView4.Dock = DockStyle.Fill;
            lecteurAudioView4.Location = new Point(396, 211);
            lecteurAudioView4.Name = "lecteurAudioView4";
            lecteurAudioView4.Size = new Size(387, 202);
            lecteurAudioView4.TabIndex = 3;
            // 
            // Window
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "Window";
            Text = "Window";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TableLayoutPanel tableLayoutPanel1;
        private Control.LecteurAudioView lecteurAudioView1;
        private Control.LecteurAudioView lecteurAudioView2;
        private Control.LecteurAudioView lecteurAudioView3;
        private Control.LecteurAudioView lecteurAudioView4;
    }
}