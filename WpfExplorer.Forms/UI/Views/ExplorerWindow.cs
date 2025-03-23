using System.Windows;
using WpfExplorer.Forms.Local.ViewModels;
using WpfExplorer.Forms.UI.Units;

namespace WpfExplorer.Forms.UI.Views
{
    public class ExplorerWindow : DarkWindow
    {
        static ExplorerWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExplorerWindow), new FrameworkPropertyMetadata(typeof(ExplorerWindow)));
        }
        public ExplorerWindow()
        {
            // 초기 크기 설정
            this.Width = 800;
            this.Height = 800;
        }
    }
}
