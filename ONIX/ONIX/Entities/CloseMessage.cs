using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ONIX.Windows;

namespace ONIX
{
    public class CloseMessage
    {
        public static void AllMessageBoxes()
        {
            foreach (MessageBoxWindow window in Application.Current.Windows.OfType<MessageBoxWindow>())
                window.Close();
            while (Application.Current.Windows.OfType<MessageBoxWindow>().Count() > 0) { }
        }

        public static void AllMessages()
        {
            AllMessageBoxes();
        }
    }
}
