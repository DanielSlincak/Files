
using System;
using Files.ClassLibrary.Controllers;
using Files.ClassLibrary.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Files.ClassLibrary.MockClasses;
using System.Threading;

namespace Files.ClassLibrary.Test
{
    [TestClass]
    public class SidebarUnitTests
    {
        [TestCleanup]
        public void TestCleanUp()
        {
            //sidebarPinnedModel.MainPage.ClearSidebarItems();
        }

        [TestMethod]
        public void AddDefaultItemsToSidebar_Verify()
        {
            SidebarPinnedController sidebarPinnedController = new SidebarPinnedController();
            Assert.IsTrue(sidebarPinnedController != null, "Sidebar controller is null");
            sidebarPinnedController.Model = new SidebarPinnedModel();

            SidebarPinnedModel sidebarPinnedModel = sidebarPinnedController.Model;
            Assert.IsTrue(sidebarPinnedModel != null, "Sidebar model is null");

            var sidebarPinnedModelItemsCount = sidebarPinnedModel.Items.Count;
            var mainPageItemsCount = sidebarPinnedModel.MainPage.sideBarItems.Count;

            Assert.IsTrue(sidebarPinnedModel.Items.Count == 0, $"Expected {0}, got {sidebarPinnedModel.Items.Count} in SidebarPinnedModel");
            Assert.IsTrue(sidebarPinnedModel.MainPage.sideBarItems.Count == 0, $"Expected {0}, got {sidebarPinnedModel.MainPage.sideBarItems.Count} in MainPage");

            sidebarPinnedModel.AddDefaultItems();

            Assert.IsTrue(sidebarPinnedModel.Items.Count == 6 + sidebarPinnedModelItemsCount, $"Expected {6 + sidebarPinnedModelItemsCount}, got {sidebarPinnedModel.Items.Count} in SidebarPinnedModel");

            sidebarPinnedModel.AddAllItemsToSidebar();

            Assert.IsTrue(sidebarPinnedModel.MainPage.sideBarItems.Count == 6 + mainPageItemsCount, $"Expected {6 + mainPageItemsCount}, got {sidebarPinnedModel.MainPage.sideBarItems.Count} in MainPage");
        }

        [TestMethod]
        public void AddItemToSidebar_Verify()
        {
            SidebarPinnedController sidebarPinnedController = new SidebarPinnedController();
            Assert.IsTrue(sidebarPinnedController != null, "Sidebar controller is null");
            sidebarPinnedController.Model = new SidebarPinnedModel();

            SidebarPinnedModel sidebarPinnedModel = sidebarPinnedController.Model;
            Assert.IsTrue(sidebarPinnedModel != null, "Sidebar model is null");
            sidebarPinnedModel.RemoveStaleSidebarItems();

            var sidebarPinnedModelItemsCount = sidebarPinnedModel.Items.Count;
            var mainPageItemsCount = sidebarPinnedModel.MainPage.sideBarItems.Count;

            var path = "C://Temp";

            // Add item
            sidebarPinnedModel.AddItem(path);
            Assert.IsTrue(sidebarPinnedModel.Items.Count == 1 + sidebarPinnedModelItemsCount, $"Expected {1 + sidebarPinnedModelItemsCount}, got {sidebarPinnedModel.Items.Count} in SidebarPinnedModel");
            Assert.IsTrue(sidebarPinnedModel.MainPage.sideBarItems.Count == 1 + mainPageItemsCount, $"Expected {1 + mainPageItemsCount}, got {sidebarPinnedModel.MainPage.sideBarItems.Count} in MainPage");

            path = "C://Temp2";
            // Add item
            sidebarPinnedModel.AddItem(path);
            Assert.IsTrue(sidebarPinnedModel.Items.Count == 2 + sidebarPinnedModelItemsCount, $"Expected {2 + sidebarPinnedModelItemsCount}, got {sidebarPinnedModel.Items.Count} in SidebarPinnedModel");
            Assert.IsTrue(sidebarPinnedModel.MainPage.sideBarItems.Count == 2 + mainPageItemsCount, $"Expected {2 + mainPageItemsCount}, got {sidebarPinnedModel.MainPage.sideBarItems.Count} in MainPage");
        }

        [TestMethod]
        public void AddItemTwiceToSidebar_Verify()
        {
            SidebarPinnedController sidebarPinnedController = new SidebarPinnedController();
            Assert.IsTrue(sidebarPinnedController != null, "Sidebar controller is null");
            sidebarPinnedController.Model = new SidebarPinnedModel();

            SidebarPinnedModel sidebarPinnedModel = sidebarPinnedController.Model;
            Assert.IsTrue(sidebarPinnedModel != null, "Sidebar model is null");
            sidebarPinnedModel.RemoveStaleSidebarItems();

            var sidebarPinnedModelItemsCount = sidebarPinnedModel.Items.Count;
            var mainPageItemsCount = sidebarPinnedModel.MainPage.sideBarItems.Count;

            var path = "C://Temp";

            // Add item
            sidebarPinnedModel.AddItem(path);
            Assert.IsTrue(sidebarPinnedModel.Items.Count == sidebarPinnedModelItemsCount + 1, $"Expected {1 + sidebarPinnedModelItemsCount}, got {sidebarPinnedModel.Items.Count} in SidebarPinnedModel");
            Assert.IsTrue(sidebarPinnedModel.MainPage.sideBarItems.Count == 1 + mainPageItemsCount, $"Expected {1 + mainPageItemsCount}, got {sidebarPinnedModel.MainPage.sideBarItems.Count} in MainPage");

            // Add same item
            sidebarPinnedModel.AddItem(path);
            Assert.IsTrue(sidebarPinnedModel.Items.Count == sidebarPinnedModelItemsCount + 1, $"Expected {1 + sidebarPinnedModelItemsCount}, got {sidebarPinnedModel.Items.Count} in SidebarPinnedModel");
            Assert.IsTrue(sidebarPinnedModel.MainPage.sideBarItems.Count == 1 + mainPageItemsCount, $"Expected {1 + mainPageItemsCount}, got {sidebarPinnedModel.MainPage.sideBarItems.Count} in MainPage");
        }

        [TestMethod]
        public void RemoveItemFromSidebar_Verify()
        {
            SidebarPinnedController sidebarPinnedController = new SidebarPinnedController();
            Assert.IsTrue(sidebarPinnedController != null, "Sidebar controller is null");
            sidebarPinnedController.Model = new SidebarPinnedModel();

            SidebarPinnedModel sidebarPinnedModel = sidebarPinnedController.Model;
            Assert.IsTrue(sidebarPinnedModel != null, "Sidebar model is null");
            sidebarPinnedModel.RemoveStaleSidebarItems();

            var sidebarPinnedModelItemsCount = sidebarPinnedModel.Items.Count;
            var mainPageItemsCount = sidebarPinnedModel.MainPage.sideBarItems.Count;

            var path = "C://Temp";

            // Add item
            sidebarPinnedModel.AddItem(path);
            Assert.IsTrue(sidebarPinnedModel.Items.Count == sidebarPinnedModelItemsCount + 1, $"Expected {1 + sidebarPinnedModelItemsCount}, got {sidebarPinnedModel.Items.Count} in SidebarPinnedModel");
            Assert.IsTrue(sidebarPinnedModel.MainPage.sideBarItems.Count == mainPageItemsCount + 1, $"Expected {1 + mainPageItemsCount}, got {sidebarPinnedModel.MainPage.sideBarItems.Count} in MainPage");

            // Add item
            sidebarPinnedModel.RemoveItem(path);
            Assert.IsTrue(sidebarPinnedModel.Items.Count == sidebarPinnedModelItemsCount, $"Expected {0 + sidebarPinnedModelItemsCount}, got {sidebarPinnedModel.Items.Count} in SidebarPinnedModel");
            sidebarPinnedModel.RemoveStaleSidebarItems();
            Assert.IsTrue(sidebarPinnedModel.MainPage.sideBarItems.Count == mainPageItemsCount, $"Expected {0 + mainPageItemsCount}, got {sidebarPinnedModel.MainPage.sideBarItems.Count} in MainPage");
        }

        [TestMethod]
        public void SwapItemsInSidebar_Verify()
        {
            SidebarPinnedController sidebarPinnedController = new SidebarPinnedController();
            Assert.IsTrue(sidebarPinnedController != null, "Sidebar controller is null");
            sidebarPinnedController.Model = new SidebarPinnedModel();

            SidebarPinnedModel sidebarPinnedModel = sidebarPinnedController.Model;
            Assert.IsTrue(sidebarPinnedModel != null, "Sidebar model is null");

            var sidebarPinnedModelItemsCount = sidebarPinnedModel.Items.Count;
            var mainPageItemsCount = sidebarPinnedModel.MainPage.sideBarItems.Count;

            sidebarPinnedModel.AddDefaultItems();
            Assert.IsTrue(sidebarPinnedModel.Items.Count == 6 + sidebarPinnedModelItemsCount, $"Expected {6 + sidebarPinnedModelItemsCount}, got {sidebarPinnedModel.Items.Count} in SidebarPinnedModel");
            sidebarPinnedModel.AddAllItemsToSidebar();
            Assert.IsTrue(sidebarPinnedModel.MainPage.sideBarItems.Count == 6 + mainPageItemsCount, $"Expected {6 + mainPageItemsCount}, got {sidebarPinnedModel.MainPage.sideBarItems.Count} in MainPage");

            int oldIndex = 2;
            int newIndex = 4;

            string itemAtOldIndex_Model = sidebarPinnedModel.Items[oldIndex];
            string itemAtNewIndex_Model = sidebarPinnedModel.Items[newIndex];

            var itemAtOldIndex_Page = sidebarPinnedModel.MainPage.sideBarItems[oldIndex];
            var itemAtNewIndex_Page = sidebarPinnedModel.MainPage.sideBarItems[newIndex];

            Assert.IsTrue(itemAtOldIndex_Model == itemAtOldIndex_Page.Path, $"Item name in model and page do not match. Model {itemAtOldIndex_Model} - Page {itemAtOldIndex_Page.Path} ");
            Assert.IsTrue(itemAtNewIndex_Model == itemAtNewIndex_Page.Path, $"Item name in model and page do not match. Model {itemAtNewIndex_Model} - Page {itemAtNewIndex_Page.Path} ");

            sidebarPinnedModel.SwapItems(itemAtOldIndex_Page, itemAtNewIndex_Page);

            itemAtNewIndex_Page = sidebarPinnedModel.MainPage.sideBarItems[newIndex];

            Assert.IsTrue(itemAtOldIndex_Model == itemAtNewIndex_Page.Path, $"Item name in model and page do not match after swap. Model {itemAtOldIndex_Model} - Page {itemAtNewIndex_Page.Path} ");
        }

        [TestMethod]
        public void MoveItemInSidebar_Verify()
        {
            SidebarPinnedController sidebarPinnedController = new SidebarPinnedController();
            Assert.IsTrue(sidebarPinnedController != null, "Sidebar controller is null");
            sidebarPinnedController.Model = new SidebarPinnedModel();

            SidebarPinnedModel sidebarPinnedModel = sidebarPinnedController.Model;
            Assert.IsTrue(sidebarPinnedModel != null, "Sidebar model is null");

            var sidebarPinnedModelItemsCount = sidebarPinnedModel.Items.Count;
            var mainPageItemsCount = sidebarPinnedModel.MainPage.sideBarItems.Count;

            sidebarPinnedModel.AddDefaultItems();

            Assert.IsTrue(sidebarPinnedModel.Items.Count == 6 + sidebarPinnedModelItemsCount, $"Expected {6 + sidebarPinnedModelItemsCount}, got {sidebarPinnedModel.Items.Count} in SidebarPinnedModel");

            sidebarPinnedModel.AddAllItemsToSidebar();

            Assert.IsTrue(sidebarPinnedModel.MainPage.sideBarItems.Count == 6 + mainPageItemsCount, $"Expected {6 + mainPageItemsCount}, got {sidebarPinnedModel.MainPage.sideBarItems.Count} in MainPage");

            int oldIndex = 2;
            int newIndex = 4;
            var itemAtOldIndex_Page = sidebarPinnedModel.MainPage.sideBarItems[oldIndex];
            sidebarPinnedModel.MoveItem(itemAtOldIndex_Page, oldIndex,newIndex);
            var itemAtNewIndex_Page = sidebarPinnedModel.MainPage.sideBarItems[newIndex];

            Assert.IsTrue(itemAtOldIndex_Page.Path == itemAtNewIndex_Page.Path, $"Item at new index is different. Should be {itemAtOldIndex_Page.Path}, but is{itemAtNewIndex_Page.Path} ");
        }


        [TestMethod]
        public void SaveAndLoadSidebar_Verify()
        {
            SidebarPinnedController sidebarPinnedController = new SidebarPinnedController();
            Assert.IsTrue(sidebarPinnedController != null, "Sidebar controller is null");
            sidebarPinnedController.Model = new SidebarPinnedModel();

            SidebarPinnedModel sidebarPinnedModel = sidebarPinnedController.Model;
            Assert.IsTrue(sidebarPinnedModel != null, "Sidebar model is null");

            var sidebarPinnedModelItemsCount = sidebarPinnedModel.Items.Count;
            var mainPageItemsCount = sidebarPinnedModel.MainPage.sideBarItems.Count;
            var path = "C://Temp";

            // Add item
            sidebarPinnedModel.AddItem(path);
            Assert.IsTrue(sidebarPinnedModel.Items.Count == sidebarPinnedModelItemsCount + 1, $"Add item - Expected {1 + sidebarPinnedModelItemsCount}, got {sidebarPinnedModel.Items.Count} in SidebarPinnedModel");
            Assert.IsTrue(sidebarPinnedModel.MainPage.sideBarItems.Count == mainPageItemsCount + 1, $"Add item- Expected {1 + mainPageItemsCount}, got {sidebarPinnedModel.MainPage.sideBarItems.Count} in MainPage");

            sidebarPinnedController.SaveModel();
            Thread.Sleep(3000);

            sidebarPinnedController = new SidebarPinnedController();
            Thread.Sleep(3000);
            sidebarPinnedModel = sidebarPinnedController.Model;
            Assert.IsTrue(sidebarPinnedModel.Items.Count == sidebarPinnedModelItemsCount + 1, $"Load model - Expected {1 + sidebarPinnedModelItemsCount}, got {sidebarPinnedModel.Items.Count} in SidebarPinnedModel");
            Assert.IsTrue(sidebarPinnedController.Model.Items.Contains(path), "Load model - Sidebar doesn't contain saved item.");
        }
    }
}
