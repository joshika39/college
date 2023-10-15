﻿using Bomber.BL.Tiles.Factories;
using Bomber.Main;
using Bomber.MapGenerator;
using Bomber.UI.Forms.Main;
using Bomber.UI.Forms.Main._Interfaces;
using Bomber.UI.Forms.MapGenerator;
using Bomber.UI.Forms.Objects.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace Bomber.UI.Forms.Core
{
    public class BomberModule
    {

        public void LoadModules(IServiceCollection collection)
        {
            collection.AddSingleton<IMainWindow, MainWindow>();
            collection.AddSingleton<IMapGeneratorWindow, MapGeneratorWindow>();
            
            collection.AddSingleton<IMainWindowPresenter, MainWindowPresenter>();
            collection.AddSingleton<IMapGeneratorWindowPresenter, MapGeneratorWindowPresenter>();
            
            collection.AddSingleton<ITileFactory, FormsTileFactory>();
        }
    }
}
