using Files.ClassLibrary.Filesystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files.ClassLibrary.MockClasses
{
    public static class MainPage
    {
        public static ObservableCollection<INavigationControlItem> sideBarItems = new ObservableCollection<INavigationControlItem>();

        public static void ClearSidebarItems()
        {
            sideBarItems.Clear();
        }
    }
}
