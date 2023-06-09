﻿using Dj_application.model;
using System;
using System.IO;
using System.Windows.Forms;
using Dj_application.Controller;
using System.Diagnostics;
using Dj_application.Outil;
using System.ComponentModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using OxyPlot.WindowsForms;
using OxyPlot;
using Dj_application.Singleton;

namespace Dj_application.View.Control
{
    public partial class Explorateur : UserControl
    {
        private string rootFolder;
        private string currentFolder;
        private string folderDownload = Path.GetFullPath("musique/telechargement/");
        public event EventHandler<Musique> musiqueSelected;
        public event EventHandler<Tuple<int, Musique>> musiqueSelectedWithPiste;

        private bool arrowLeftPressed = false;
        private DateTime lastArrowLeftPressTime;
        private bool arrowRightPressed = false;
        private DateTime lastArrowRightPressTime;

        private ParametresForm parametresForm = ParametresForm.Instance;

        private void setColor()
        {
            this.BackColor = parametresForm.palettesCouleur.Fond;
            this.ForeColor = parametresForm.palettesCouleur.Texte;
            treev_arbreFolder.BackColor = parametresForm.palettesCouleur.Fond;
            treev_arbreFolder.ForeColor = parametresForm.palettesCouleur.Texte;
            dgv_listMusique.DefaultCellStyle.BackColor = parametresForm.palettesCouleur.Fond;

            dgv_listMusique.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single; // Bordures pour toutes les cellules
            dgv_listMusique.CellBorderStyle = DataGridViewCellBorderStyle.Single; // Bordures pour les cellules individuelles
            dgv_listMusique.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv_listMusique.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv_listMusique.GridColor = parametresForm.palettesCouleur.Texte;

            dgv_listMusique.ColumnHeadersDefaultCellStyle.BackColor = parametresForm.palettesCouleur.Fond;
            dgv_listMusique.ColumnHeadersDefaultCellStyle.ForeColor = parametresForm.palettesCouleur.Texte;
            dgv_listMusique.RowHeadersDefaultCellStyle.BackColor = parametresForm.palettesCouleur.Fond;
            dgv_listMusique.RowHeadersDefaultCellStyle.ForeColor = parametresForm.palettesCouleur.Texte;

            bt_download.BackColor = parametresForm.palettesCouleur.Mise_Evidence;
        }

        public Explorateur()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
            setColor();

            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
            toolTip.SetToolTip(bt_download, "Clic gauche pour ouvrir le dossier ci-dessous, clic droit pour ouvrir le dossier dans l'explorateur.");

            toolTip.SetToolTip(bt_source, "Clic gauche pour choisir le dossier source, clic droit pour ouvrir le dossier source dans l'explorateur.");

            dgv_listMusique.Columns.Clear();

            dgv_listMusique.Columns.Add("NomMusiqueColumn", "Nom Musique");
            dgv_listMusique.Columns["NomMusiqueColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv_listMusique.Columns.Add("ExtensionColumn", "Extension");
            dgv_listMusique.Columns["ExtensionColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv_listMusique.Columns.Add("BpmMusiqueColumn", "Bpm");
            dgv_listMusique.Columns["BpmMusiqueColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewColumn musiqueColumn = new DataGridViewColumn();
            musiqueColumn.HeaderText = "Musique";
            musiqueColumn.Visible = false; // Rendre la colonne invisible
            musiqueColumn.Name = "MusiqueColumn";
            musiqueColumn.CellTemplate = new DataGridViewTextBoxCell();
            dgv_listMusique.Columns.Add(musiqueColumn);

            foreach (DataGridViewColumn column in dgv_listMusique.Columns)
            {
                column.ReadOnly = true;
            }

            string sourceFolder = Path.GetFullPath("musique");

            // Vérifier si le dossier "Musique" existe
            if (Directory.Exists(sourceFolder))
            {
                setRootFolder(sourceFolder);
            }
            else
            {
                //MessageBox.Show("Le dossier 'Musique' n'existe pas dans le répertoire source du projet.");
            }

            BpmGenerate.BpmTrouver += bpmGenerate_BpmTrouver;

        }
        private void bpmGenerate_BpmTrouver(object sender, Musique musique)
        {
            if (dgv_listMusique.InvokeRequired)
            {
                dgv_listMusique.Invoke((MethodInvoker)(() => updateBpm()));

            }
            else
            {
                updateBpm();
            }
        }
        private void setRootFolder(string rootFolder)
        {
            this.rootFolder = rootFolder;
            currentFolder = rootFolder;

            // Appeler la méthode pour charger les fichiers du dossier racine
            LoadFiles(rootFolder);
            TreeViewGenerator treeViewGenerator = new TreeViewGenerator(treev_arbreFolder);
            treeViewGenerator.GenerateTree(rootFolder);
        }

        private void updateBpm()
        {
            foreach (DataGridViewRow row in dgv_listMusique.Rows)
            {
                Musique musique = row.Cells[dgv_listMusique.Columns["MusiqueColumn"].Index].Tag as Musique;
                int bpm = MusicBpmDatabase.Instance.GetBpm(musique.Path);
                row.Cells[dgv_listMusique.Columns["BpmMusiqueColumn"].Index].Value = bpm;
            }
        }


        private void LoadFiles(string folderPath)
        {
            // Effacer les lignes existantes dans le DataGridView
            dgv_listMusique.Rows.Clear();

            if (dgv_listMusique.Created)
            {
                Thread thread = new Thread(() =>
                {
                    LoadFilesAsync(folderPath);
                });
                thread.Start();
            }

            dgv_listMusique.HandleCreated += (sender, e) =>
            {
                Thread thread = new Thread(() =>
                {
                    LoadFilesAsync(folderPath);
                });
                thread.Start();
            };


        }

        private void LoadFilesAsync(string folderPath)
        {
            try
            {
                dgv_listMusique.Invoke((MethodInvoker)delegate
                {

                    // Obtenir la liste des fichiers dans le dossier spécifié
                    string[] files = Directory.GetFiles(folderPath);

                    Musique[] musiques = new Musique[files.Length];
                    for (int i = 0; i < files.Length; i++)
                    {
                        musiques[i] = new Musique(files[i]);
                    }

                    // Ajouter les musiques dans le DataGridView
                    foreach (Musique musique in musiques)
                    {
                        musique.bpm = MusicBpmDatabase.Instance.GetBpm(musique.Path);
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dgv_listMusique);
                        row.Cells[dgv_listMusique.Columns["MusiqueColumn"].Index].Tag = musique;
                        row.Cells[dgv_listMusique.Columns["NomMusiqueColumn"].Index].Value = musique.FileNameWithoutExtension;
                        row.Cells[dgv_listMusique.Columns["ExtensionColumn"].Index].Value = musique.FileExtension;
                        row.Cells[dgv_listMusique.Columns["BpmMusiqueColumn"].Index].Value = musique.bpm;
                        dgv_listMusique.Rows.Add(row);
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors du chargement des fichiers : " + ex.Message);
            }
        }
        private void dgv_listMusique_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.RowIndex < dgv_listMusique.Rows.Count)
            {
                DataGridViewCell clickedCell = dgv_listMusique.Rows[e.RowIndex].Cells[e.ColumnIndex];

                DataGridViewRow selectedRow = dgv_listMusique.Rows[e.RowIndex];
                Musique musique = selectedRow.Cells["MusiqueColumn"].Tag as Musique;

                // Créer le menu contextuel
                ContextMenuStrip contextMenu = new ContextMenuStrip();


                // Ajouter les options au menu contextuel
                Window win = SingletonWindow.getInstance().window;
                for (int i = 1; i <= win.getNbrPiste(); i++)
                {
                    string optionText = $"Piste {i}";
                    ToolStripMenuItem menuItem = new ToolStripMenuItem(optionText);
                    menuItem.Click += (sender, eventArgs) => MenuItem_Click(sender, eventArgs, musique);
                    contextMenu.Items.Add(menuItem);
                }

                // Afficher le menu contextuel à l'emplacement du clic
                Point relativeMousePosition = dgv_listMusique.PointToClient(Cursor.Position);
                contextMenu.Show(dgv_listMusique, relativeMousePosition);
            }
        }

        private void dgv_listMusique_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgv_listMusique.Rows.Count)
            {
                DataGridViewRow selectedRow = dgv_listMusique.Rows[e.RowIndex];
                Musique musique = selectedRow.Cells["MusiqueColumn"].Tag as Musique;

                musiqueSelected?.Invoke(this, musique);
            }
        }

        private void dgv_listMusique_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgv_listMusique.SelectedCells.Count > 0)
            {
                int rowIndex = dgv_listMusique.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgv_listMusique.Rows[rowIndex];
                Musique musique = selectedRow.Cells["MusiqueColumn"].Tag as Musique;
                musiqueSelected?.Invoke(this, musique);
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (arrowLeftPressed && (DateTime.Now - lastArrowLeftPressTime).TotalMilliseconds < 500)
                {
                    // Changer le focus sur le DataGridView
                    treev_arbreFolder.Focus();
                }
                else
                {
                    arrowLeftPressed = true;
                    lastArrowLeftPressTime = DateTime.Now;
                }
            }
            else
            {
                arrowLeftPressed = false;
            }
        }

        private void splitContainer1_SizeChanged(object sender, EventArgs e)
        {
            if (spCon_explorateur.Width < 500)
            {
                spCon_explorateur.Orientation = Orientation.Horizontal; // Changer l'orientation en vertical
                spCon_explorateur.SplitterDistance = spCon_explorateur.Height / 5;
            }
            else
            {
                spCon_explorateur.Orientation = Orientation.Vertical; // Revenir à l'orientation horizontale
                spCon_explorateur.SplitterDistance = spCon_explorateur.Width / 10;
            }
        }

        private void MenuItem_Click(object sender, EventArgs e, Musique musique)
        {
            // Gérer le clic sur une option du menu contextuel
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            int option = int.Parse(menuItem.Text.Replace("Piste ", ""));
            musiqueSelectedWithPiste?.Invoke(this, new Tuple<int, Musique>(option - 1, musique));
        }

        private void bt_download_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                LoadFiles(folderDownload);
            }
            else if (e.Button == MouseButtons.Right)
            {
                Process.Start("explorer.exe", folderDownload);
            }
        }

        private void bt_source_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string selectedFolder = folderBrowserDialog.SelectedPath;
                    setRootFolder(selectedFolder);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                Process.Start("explorer.exe", rootFolder);
            }
        }

        private void treev_arbreFolder_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.Node != null)
                {
                    string nodeFullPath = e.Node.FullPath;
                    string[] pathSegments = nodeFullPath.Split('\\');
                    string[] remainingSegments = pathSegments.Skip(1).ToArray();
                    string selectedFolderPath = string.Join("/", remainingSegments);
                    selectedFolderPath = Path.Combine(rootFolder, selectedFolderPath);
                    Process.Start("explorer.exe", selectedFolderPath);
                }
            }
        }

        private void tb_search_Click(object sender, EventArgs e)
        {
            tb_search.Text = "";
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            string searchText = tb_search.Text.ToLower(); // Texte de recherche en minuscules

            foreach (DataGridViewRow row in dgv_listMusique.Rows)
            {
                string cellValue = row.Cells["NomMusiqueColumn"].Value.ToString().ToLower();

                if (cellValue.Contains(searchText))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void treev_arbreFolder_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                string nodeFullPath = e.Node.FullPath;
                string[] pathSegments = nodeFullPath.Split('\\');
                string[] remainingSegments = pathSegments.Skip(1).ToArray();
                string selectedFolderPath = string.Join("/", remainingSegments);
                selectedFolderPath = Path.Combine(rootFolder, selectedFolderPath);

                currentFolder = selectedFolderPath;
                LoadFiles(selectedFolderPath);
            }
        }

        private void treev_arbreFolder_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                if (arrowRightPressed && (DateTime.Now - lastArrowRightPressTime).TotalMilliseconds < 500)
                {
                    // Changer le focus sur le DataGridView
                    dgv_listMusique.Focus();
                }
                else
                {
                    arrowRightPressed = true;
                    lastArrowRightPressTime = DateTime.Now;
                }
            }
            else
            {
                arrowRightPressed = false;
            }
        }
    }
}
