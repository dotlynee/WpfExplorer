using System.Windows;
using System.Windows.Controls;

namespace WpfExplorer.Forms.UI.Units
{
    public class MinimizeButton : Button 
    {
        static MinimizeButton() => DefaultStyleKeyProperty.OverrideMetadata(typeof(MinimizeButton), new FrameworkPropertyMetadata(typeof(MinimizeButton)));

        protected override void OnClick()
        {
            base.OnClick();
            // Minimize the window when the button is clicked
            if (Window.GetWindow(this) is Window window)
            {
                window.WindowState = WindowState.Minimized;
            }
        }
    }
}
