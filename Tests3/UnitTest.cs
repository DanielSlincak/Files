
using System;
using Files.ClassLibrary.Controllers;
using Files.ClassLibrary.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Files.ClassLibrary.MockClasses;

namespace Files.ClassLibrary.Test
{
    [TestClass]
    public class SidebarUnitTests
    {
        [TestCleanup]
        public void TestCleanUp()
        {
            MainPage.ClearSidebarItems();
        }

        [TestMethod]
        public void AddDefaultItemsToSidebar_Verify()
        {
            SidebarPinnedController sidebarPinnedController = new SidebarPinnedController();
            Assert.IsTrue(sidebarPinnedController != null, "Sidebar controller is null");

            SidebarPinnedModel sidebarPinnedModel = sidebarPinnedController.Model;
            Assert.IsTrue(sidebarPinnedModel != null, "Sidebar model is null");

            var sidebarPinnedModelItemsCount = sidebarPinnedModel.Items.Count;
            var mainPageItemsCount = MainPage.sideBarItems.Count;

            sidebarPinnedModel.AddDefaultItems();

            Assert.IsTrue(sidebarPinnedModel.Items.Count == 6 + sidebarPinnedModelItemsCount, $"Expected {6 + sidebarPinnedModelItemsCount}, got {sidebarPinnedModel.Items.Count} in SidebarPinnedModel");

            sidebarPinnedModel.AddAllItemsToSidebar();

            Assert.IsTrue(MainPage.sideBarItems.Count == 6 + mainPageItemsCount, $"Expected {6 + mainPageItemsCount}, got {MainPage.sideBarItems.Count} in MainPage");
        }

        [TestMethod]
        public void AddItemToSidebar_Verify()
        {
            SidebarPinnedController sidebarPinnedController = new SidebarPinnedController();
            Assert.IsTrue(sidebarPinnedController != null, "Sidebar controller is null");

            SidebarPinnedModel sidebarPinnedModel = sidebarPinnedController.Model;
            Assert.IsTrue(sidebarPinnedModel != null, "Sidebar model is null");
            sidebarPinnedModel.RemoveStaleSidebarItems();

            var sidebarPinnedModelItemsCount = sidebarPinnedModel.Items.Count;
            var mainPageItemsCount = MainPage.sideBarItems.Count;

            var path = "C://Temp";

            // Add item
            sidebarPinnedModel.AddItem(path);
            Assert.IsTrue(sidebarPinnedModel.Items.Count == 1 + sidebarPinnedModelItemsCount, $"Expected {1 + sidebarPinnedModelItemsCount}, got {sidebarPinnedModel.Items.Count} in SidebarPinnedModel");
            Assert.IsTrue(MainPage.sideBarItems.Count == 1 + mainPageItemsCount, $"Expected {1 + mainPageItemsCount}, got {MainPage.sideBarItems.Count} in MainPage");

            path = "C://Temp2";
            // Add item
            sidebarPinnedModel.AddItem(path);
            Assert.IsTrue(sidebarPinnedModel.Items.Count == 2 + sidebarPinnedModelItemsCount, $"Expected {2 + sidebarPinnedModelItemsCount}, got {sidebarPinnedModel.Items.Count} in SidebarPinnedModel");
            Assert.IsTrue(MainPage.sideBarItems.Count == 2 + mainPageItemsCount, $"Expected {2 + mainPageItemsCount}, got {MainPage.sideBarItems.Count} in MainPage");
        }

        [TestMethod]
        public void AddItemTwiceToSidebar_Verify()
        {
            SidebarPinnedController sidebarPinnedController = new SidebarPinnedController();
            Assert.IsTrue(sidebarPinnedController != null, "Sidebar controller is null");

            SidebarPinnedModel sidebarPinnedModel = sidebarPinnedController.Model;
            Assert.IsTrue(sidebarPinnedModel != null, "Sidebar model is null");
            sidebarPinnedModel.RemoveStaleSidebarItems();

            var sidebarPinnedModelItemsCount = sidebarPinnedModel.Items.Count;
            var mainPageItemsCount = MainPage.sideBarItems.Count;

            var path = "C://Temp";

            // Add item
            sidebarPinnedModel.AddItem(path);
            Assert.IsTrue(sidebarPinnedModel.Items.Count == sidebarPinnedModelItemsCount + 1, $"Expected {1 + sidebarPinnedModelItemsCount}, got {sidebarPinnedModel.Items.Count} in SidebarPinnedModel");
            Assert.IsTrue(MainPage.sideBarItems.Count == 1 + mainPageItemsCount, $"Expected {1 + mainPageItemsCount}, got {MainPage.sideBarItems.Count} in MainPage");

            // Add same item
            sidebarPinnedModel.AddItem(path);
            Assert.IsTrue(sidebarPinnedModel.Items.Count == sidebarPinnedModelItemsCount + 1, $"Expected {1 + sidebarPinnedModelItemsCount}, got {sidebarPinnedModel.Items.Count} in SidebarPinnedModel");
            Assert.IsTrue(MainPage.sideBarItems.Count == 1 + mainPageItemsCount, $"Expected {1 + mainPageItemsCount}, got {MainPage.sideBarItems.Count} in MainPage");
        }

        [TestMethod]
        public void RemoveItemFromSidebar_Verify()
        {
            SidebarPinnedController sidebarPinnedController = new SidebarPinnedController();
            Assert.IsTrue(sidebarPinnedController != null, "Sidebar controller is null");

            SidebarPinnedModel sidebarPinnedModel = sidebarPinnedController.Model;
            Assert.IsTrue(sidebarPinnedModel != null, "Sidebar model is null");
            sidebarPinnedModel.RemoveStaleSidebarItems();

            var sidebarPinnedModelItemsCount = sidebarPinnedModel.Items.Count;
            var mainPageItemsCount = MainPage.sideBarItems.Count;

            var path = "C://Temp";

            // Add item
            sidebarPinnedModel.AddItem(path);
            Assert.IsTrue(sidebarPinnedModel.Items.Count == sidebarPinnedModelItemsCount + 1, $"Expected {1 + sidebarPinnedModelItemsCount}, got {sidebarPinnedModel.Items.Count} in SidebarPinnedModel");
            Assert.IsTrue(MainPage.sideBarItems.Count == mainPageItemsCount + 1, $"Expected {1 + mainPageItemsCount}, got {MainPage.sideBarItems.Count} in MainPage");

            // Add item
            sidebarPinnedModel.RemoveItem(path);
            Assert.IsTrue(sidebarPinnedModel.Items.Count == sidebarPinnedModelItemsCount, $"Expected {0 + sidebarPinnedModelItemsCount}, got {sidebarPinnedModel.Items.Count} in SidebarPinnedModel");
            sidebarPinnedModel.RemoveStaleSidebarItems();
            Assert.IsTrue(MainPage.sideBarItems.Count == mainPageItemsCount, $"Expected {0 + mainPageItemsCount}, got {MainPage.sideBarItems.Count} in MainPage");
        }
    }
}
