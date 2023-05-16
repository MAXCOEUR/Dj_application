using System.IO;
using System.Windows.Forms;

namespace Dj_application.Controller
{
    public class TreeViewGenerator
    {
        private TreeView treeView;

        public TreeViewGenerator(TreeView treeView)
        {
            this.treeView = treeView;
        }

        public void GenerateTree(string rootFolder)
        {
            treeView.Nodes.Clear();

            var rootNode = new TreeNode(Path.GetFileName(rootFolder));
            treeView.Nodes.Add(rootNode);

            GenerateSubfolders(rootFolder, rootNode);
        }

        private void GenerateSubfolders(string folderPath, TreeNode parentNode)
        {
            try
            {
                string[] subfolders = Directory.GetDirectories(folderPath);

                foreach (string subfolder in subfolders)
                {
                    var subfolderNode = new TreeNode(Path.GetFileName(subfolder));
                    parentNode.Nodes.Add(subfolderNode);

                    GenerateSubfolders(subfolder, subfolderNode);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Gérer les erreurs d'accès non autorisé
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite lors de la génération de l'arborescence des dossiers : " + ex.Message);
            }
        }
    }
}
