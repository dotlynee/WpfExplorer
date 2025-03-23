using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Mvvm;
using Prism.Ioc;
using Prism.Regions;
using WpfExplorer.Support.Local.Models;

namespace WpfExplorer.Forms.Local.ViewModels
{
    public class ExplorerViewModel(IContainerProvider containerProvider, IRegionManager regionManager) : ObservableBase, IViewLoadable
    {
        private readonly IContainerProvider _contentProvider = containerProvider;
        private readonly IRegionManager _regionManager = regionManager;

        public List<FolderInfo>? Roots { get; init; }

        public void OnLoaded(IViewable view)
        {
            IRegion mainRegion = _regionManager.Regions["MainRegion"];
            IViewable mainContent = _contentProvider.Resolve<IViewable>("MainContent");

            if (!mainRegion.Views.Contains(mainContent))
            {
                mainRegion.Add(mainContent);
            }
            mainRegion.Activate(mainContent);
        }
    }
}
