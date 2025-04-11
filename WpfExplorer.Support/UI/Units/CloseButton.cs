using System.Windows;
using System.Windows.Controls;

namespace WpfExplorer.Forms.UI.Units
{
    public class CloseButton : Button 
    {
        static CloseButton() => DefaultStyleKeyProperty.OverrideMetadata(typeof(CloseButton), new FrameworkPropertyMetadata(typeof(CloseButton)));

        protected override void OnClick()
        {
            base.OnClick();

            // Close the window when the button is clicked
            if (Window.GetWindow(this) is Window window)
            {
                window.Close();
            }
        }
    }
}
