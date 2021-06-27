using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// Presentation
/// </summary>
namespace ConsoleEShopMultilayered.PL
{
    /// <summary>
    /// Handler of view
    /// </summary>
    static class ViewHandler
    {
        /// <summary>
        /// Delegate for show Guest or Registered or Admin menu
        /// </summary>
        public delegate void Menu();

        /// <summary>
        /// Delegate Menu
        /// </summary>
        public static Menu menu;
        /// <summary>
        /// Initialization menu
        /// </summary>
        static ViewHandler()
        {
            menu = ViewGuest.Menu;
        }
        /// <summary>
        /// Invoke menu to show items menu
        /// </summary>
        public static void MainHandle()
        {
            while (true) menu.Invoke();
        }
    }
}
