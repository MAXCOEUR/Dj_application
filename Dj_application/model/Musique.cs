using System.IO;

namespace Dj_application.model
{
    public class Musique
    {
        public string Path { get; private set; }
        public int bpm { get; set; }
        public string FolderPath => System.IO.Path.GetDirectoryName(Path);
        public string FileNameWithoutExtension => System.IO.Path.GetFileNameWithoutExtension(Path);
        public string FileExtension => System.IO.Path.GetExtension(Path);

        public Musique(string path)
        {
            Path = System.IO.Path.GetFullPath(path);
        }
    }
}
