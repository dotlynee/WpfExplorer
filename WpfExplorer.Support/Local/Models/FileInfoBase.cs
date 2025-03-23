using CommunityToolkit.Mvvm.ComponentModel;
using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Mvvm;

namespace WpfExplorer.Support.Local.Models
{
    public partial class FileInfoBase : ObservableBase
    {
        [ObservableProperty]
        private bool _isDenied;

        public required string Name { get; set; }
        public required string FullPath { get; set; }
        public int Depth {  get; set; }
        public long Length { get; set; }
        public IconType IconType { get; set; }
    }
}
