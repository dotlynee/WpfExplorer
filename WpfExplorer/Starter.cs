namespace WpfExplorer
{
    internal class Starter
    {
        [STAThread]
        private static void Main(string[] args)
        {
            _ = new App()
                .AddInversionModule<Properties.HelperModules>()
                .AddWireDataContext<Properties.WireDataContext>()
                .Run();
        }
    }
}
