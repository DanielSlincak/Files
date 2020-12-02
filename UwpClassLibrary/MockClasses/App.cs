using Files.ClassLibrary.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files.ClassLibrary.MockClasses
{
    public static class App
    {
        public static SettingsViewModel AppSettings = new SettingsViewModel();
        public static SidebarPinnedController SidebarPinnedController = new SidebarPinnedController();

    }
}
