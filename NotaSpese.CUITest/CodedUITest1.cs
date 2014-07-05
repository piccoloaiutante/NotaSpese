using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Microsoft.VisualStudio.TestTools.UITest.Input;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting.WindowsRuntimeControls;
using System.Threading.Tasks;

using Windows.Storage;


namespace NotaSpese.CUITest
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        private string appIdentifier = "{F4DE85AF-57CF-4833-8D1D-32190FE39E76}:App:f4de85af-57cf-4833-8d1d-32190fe39e76_xn6pvyr3tpx86!App";



        public CodedUITest1()
        {
        }

        [TestInitialize]
        public async Task Setup()
        {
            //StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
            //var dbFile = await local.GetFileAsync("expense.sqlite");
        }

        //{F4DE85AF-57CF-4833-8D1D-32190FE39E76}:App:f4de85af-57cf-4833-8d1d-32190fe39e76_xn6pvyr3tpx86!App
        [TestMethod]
        public void Adding_New_Expense_Should_Save_New_Expense()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            XamlWindow appWindow = XamlWindow.Launch(appIdentifier);


            var expense = UIMap.UINotaSpeseWindow.UIItemList.Items.Count;
            Gesture.Tap(UIMap.UIItemWindow.UIAddButton);


            UIMap.UINotaSpeseWindow.UIItemEdit.Text = "test";

            Gesture.Tap(UIMap.UIItemWindow.UIForwardButton);
            Gesture.Tap(UIMap.UINotaSpeseWindow.UIItemList.UIRomaNapoliListItem);
            Gesture.Tap(UIMap.UIItemWindow.UIForwardButton);
            UIMap.UINotaSpeseWindow.UIItemEdit.Text = "90";
            UIMap.UINotaSpeseWindow.UIItemEdit1.Text = "150";
            UIMap.UINotaSpeseWindow.UIItemEdit2.Text = "200";
            Gesture.Tap(UIMap.UIItemWindow.UIForwardButton);
            Gesture.Tap(UIMap.UIItemWindow.UISincronizzazioneWindow.UIChiudiButton);

            Assert.IsTrue(UIMap.UINotaSpeseWindow.UIItemList.Items.Count == ++expense);
        }

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
