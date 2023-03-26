﻿using System;
using System.Collections.Generic;
using Infrastructure.IOManager;
using Infrastructure.Navigator;

namespace Implementation.Navigator
{
    internal class Navigator : INavigator
    {
        private readonly IIOManager _ioManager;
        
        public Navigator(IIOManager ioManager)
        {
            _ioManager = ioManager ?? throw new ArgumentNullException(nameof(ioManager));
        }
        
        public int Show(List<INavigatorElement> items)
        {
            var selectedItem = 0;
            
            ConsoleKeyInfo keyInfo;
            
            do
            {
                Console.Clear();
                Console.WriteLine("Select an option:");
                for (var i = 0; i < items.Count; i++)
                {
                    if (i == selectedItem)
                    {
                        Console.Write(">> ");
                    }
                    else
                    {
                        Console.Write("   ");
                    }

                    Console.WriteLine(items[i]);
                }
                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.UpArrow && selectedItem > 0)
                {
                    selectedItem--;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow && selectedItem < items.Count - 1)
                {
                    selectedItem++;
                }

            } while (keyInfo.Key != ConsoleKey.Enter);
            
            Console.Clear();
            _ioManager.RestoreTerminalState();
            items[selectedItem].Callback();
            return selectedItem;
        }
    }
}
