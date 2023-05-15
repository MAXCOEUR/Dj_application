using Dj_application.View;
using Dj_application.Singleton;
using Dj_application.model;

namespace Dj_application
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Window window = SingletonWindow.getInstance().window;
            window.ShowDialog();
        }
    }
}