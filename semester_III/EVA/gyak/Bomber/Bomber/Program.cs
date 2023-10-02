using Bomber.Core;
using Bomber.Main;
using GameFramework.Impl.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Bomber;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        var modules = LoadModules();
        var mainWindow = modules.GetService<IMainWindowPresenter>();
        if (mainWindow?.Window is MainWindow window)
        {
            Application.Run(window);
        }
    }

    private static IServiceProvider LoadModules()
    {
        var serviceProvider = new ServiceCollection();
        var modules = new BomberModule();
        var gameModule = new GameModule();
        modules.LoadModules(serviceProvider);
        gameModule.LoadModules(serviceProvider);
        return serviceProvider.BuildServiceProvider();
    }
}