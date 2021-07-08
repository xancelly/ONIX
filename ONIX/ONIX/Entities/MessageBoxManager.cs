using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Effects;
using ONIX.Windows;

namespace ONIX.Entities
{
    public class MessageBoxManager
    {
        public enum Buttons
        {
            Yes_No, Save_Cancel
        }
        public enum Type
        {
            Question, AddManufacturer, AddCategory, AddParametr, AddTypeService, AddCount
        }

        public static string ShowDialog(string Text, Buttons buttons, Type type)
        {
            ShowBlurEffectAllWindow();
            MessageBoxWindow messageBox = new MessageBoxWindow(Text, buttons, type);
            messageBox.ShowDialog();
            StopBlurEffectAllWindow();
            return messageBox.ReturnString;
        }

        public static string ShowDialogCategory(string Text, Buttons buttons, Type type)
        {
            ShowBlurEffectAllWindow();
            MessageBoxWindow messageBox = new MessageBoxWindow(Text, buttons, type);
            messageBox.ShowDialog();
            StopBlurEffectAllWindow();
            return messageBox.ReturnString;
        }

        static BlurEffect MyBlur = new BlurEffect();
        public static void ShowBlurEffectAllWindow()
        {
            MyBlur.Radius = 5;
            foreach (Window window in Application.Current.Windows)
                window.Effect = MyBlur;
        }

        public static void StopBlurEffectAllWindow()
        {
            MyBlur.Radius = 0;
        }
    }
}
