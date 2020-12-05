using Files.ClassLibrary.Filesystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files.ClassLibrary.MockClasses
{
    public class MainPage
    {
        public ObservableCollection<INavigationControlItem> sideBarItems = new ObservableCollection<INavigationControlItem>();

        public void ClearSidebarItems()
        {
            sideBarItems.Clear();
        }

        public MainPage()
        {

        }
    }
}
