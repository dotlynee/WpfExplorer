namespace WpfExplorer
{
    internal class Starter
    {
        [STAThread]
        private static void Main(string[] args)
        {
            _ = new App()
                .AddInversionModule<Properties.HelperModules>()
                .AddInversionModule<Properties.ViewerModules>()
                .AddWireDataContext<Properties.WireDataContext>()
                .Run();
        }
    }
}
