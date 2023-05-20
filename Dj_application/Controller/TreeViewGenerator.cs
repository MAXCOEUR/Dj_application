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

            if (treeView.Created)
            {
                Thread thread = new Thread(() => GenerateSubfolders(rootFolder, rootNode));
                thread.Start();
            }

            treeView.HandleCreated += (sender, e) =>
            {
                Thread thread = new Thread(() => GenerateSubfolders(rootFolder, rootNode));
                thread.Start();
            };
            
        }

        private void GenerateSubfolders(string folderPath, TreeNode parentNode)
        {
            try
            {
                string[] subfolders = Directory.GetDirectories(folderPath);

                foreach (string subfolder in subfolders)
                {
                    var subfolderNode = new TreeNode(Path.GetFileName(subfolder));

                    // Utiliser Invoke pour ajouter le nœud dans le thread de l'interface utilisateur
                    treeView.Invoke((MethodInvoker)delegate
                    {
                        parentNode.Nodes.Add(subfolderNode);
                    });

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
