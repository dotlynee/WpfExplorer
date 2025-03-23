using Jamesnet.Wpf.Controls;
using Prism.Ioc;
using Prism.Modularity;

namespace WpfExplorer.Properties
{
    internal class ViewerModules : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // containerRegistry.RegisterSingleton<IViewable, MainContent>("MainContent");
        }
    }
}
