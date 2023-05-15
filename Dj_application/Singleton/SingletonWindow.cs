using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dj_application.View;

namespace Dj_application.Singleton
{
    internal class SingletonWindow
    {
        
        private static SingletonWindow? singletonWindow;
        public Window window;

        private SingletonWindow()
        {
            window = new Window();
        }

        public static SingletonWindow getInstance()
        {
            if (singletonWindow == null)
            {
                singletonWindow = new SingletonWindow();
            }
            return singletonWindow;
        }
    }
}
