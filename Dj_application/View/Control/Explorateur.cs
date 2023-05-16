using Dj_application.model;
using System;
using System.IO;
using System.Windows.Forms;
using Dj_application.Controller;
using System.Diagnostics;

namespace Dj_application.View.Control
{
    public partial class Explorateur : UserControl
    {
        private string rootFolder;
        private string currentFolder;
        public event EventHandler<Musique> musiqueSelected;

        public Explorateur()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();

            dgv_listMusique.Columns.Clear();
            dgv_listMusique.Columns.Add("NomMusiqueColumn", "Nom Musique");
            dgv_listMusique.Columns.Add("ExtensionColumn", "Extension");
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

            string sourceFolder = Path.Combine(Application.StartupPath, "Musique");

            // Vérifier si le dossier "Musique" existe
            if (Directory.Exists(sourceFolder))
            {
                setRootFolder(sourceFolder);
            }
            else
            {
                //MessageBox.Show("Le dossier 'Musique' n'existe pas dans le répertoire source du projet.");
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

        private void LoadFiles(string folderPath)
        {
            // Effacer les lignes existantes dans le DataGridView
            dgv_listMusique.Rows.Clear();


            try
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
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgv_listMusique);
                    row.Cells[dgv_listMusique.Columns["MusiqueColumn"].Index].Tag = musique;
                    row.Cells[dgv_listMusique.Columns["NomMusiqueColumn"].Index].Value = musique.FileNameWithoutExtension;
                    row.Cells[dgv_listMusique.Columns["ExtensionColumn"].Index].Value = musique.FileExtension;

                    dgv_listMusique.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors du chargement des fichiers : " + ex.Message);
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

        private void splitContainer1_SizeChanged(object sender, EventArgs e)
        {
            if (spCon_explorateur.Width < 400)
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

        private void bt_source_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string selectedFolder = folderBrowserDialog.SelectedPath;
                setRootFolder(selectedFolder);
            }
        }

    }
}
