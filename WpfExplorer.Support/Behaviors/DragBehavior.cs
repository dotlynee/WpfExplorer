using System.Windows;
using System.Windows.Input;

namespace WpfExplorer.Support.Behaviors
{
    public static class DragBehavior
    {
        public static readonly DependencyProperty IsDraggableProperty =
            DependencyProperty.RegisterAttached(
                "IsDraggable",
                typeof(bool),
                typeof(DragBehavior),
                new PropertyMetadata(false, OnIsDraggableChanged));

        public static bool GetIsDraggable(DependencyObject obj) => (bool)obj.GetValue(IsDraggableProperty);

        public static void SetIsDraggable(DependencyObject obj, bool value) => obj.SetValue(IsDraggableProperty, value);

        private static void OnIsDraggableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement element)
            {
                if ((bool)e.NewValue)
                {
                    element.MouseDown += Element_MouseDown;
                }
                else
                {
                    element.MouseDown -= Element_MouseDown;
                }
            }
        }

        private static void Element_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && sender is FrameworkElement element)
            {
                if (Window.GetWindow(element) is Window window)
                {
                    window.DragMove();
                }
            }
        }
    }
}
