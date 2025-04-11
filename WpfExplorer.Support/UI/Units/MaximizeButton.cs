using Jamesnet.Wpf.Controls;
using System.Windows;
using System.Windows.Controls;

namespace WpfExplorer.Forms.UI.Units
{
    public class MaximizeButton : Button
    {
        static MaximizeButton() => DefaultStyleKeyProperty.OverrideMetadata(typeof(MaximizeButton), new FrameworkPropertyMetadata(typeof(MaximizeButton)));

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(IconType), typeof(MaximizeButton), new PropertyMetadata(IconType.Maximize));


        public IconType Icon
        {
            get => (IconType)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        protected override void OnClick()
        {
            base.OnClick();

            // Toggle the window's maximized state
            if (Window.GetWindow(this) is Window window)
            {
                if (window.WindowState == WindowState.Normal)
                {
                    window.WindowState = WindowState.Maximized;
                    Icon = IconType.Restore; // Change icon to "Restore" when maximized
                }
                else
                {
                    window.WindowState = WindowState.Normal;
                    Icon = IconType.Maximize; // Change icon back to "Maximize" when restored
                }
            }
        }
    }
}
