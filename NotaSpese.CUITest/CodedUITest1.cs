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

        [TestMethod]
        public void Adding_New_Expense_Should_Save_New_Expense()
        {
            // lancio l'applicazione
            XamlWindow appWindow = XamlWindow.Launch(appIdentifier);

            // mi salvo il numero di note spese salvate
            var expense = UIMap.UINotaSpeseWindow.UIItemList.Items.Count;

            // tap sulla creazione di una nuova nota spese
            Gesture.Tap(UIMap.UIItemWindow.UIAddButton);

            // aggiungo la motivazione della trasferta
            UIMap.UINotaSpeseWindow.UIItemEdit.Text = "Vendita nuovo prodotto";

            // Tap su avanti
            Gesture.Tap(UIMap.UIItemWindow.UIForwardButton);

            // seleziono la tratta della trasferta
            Gesture.Tap(UIMap.UINotaSpeseWindow.UIItemList.UIRomaNapoliListItem);

            // tap su avanti
            Gesture.Tap(UIMap.UIItemWindow.UIForwardButton);

            // aggiungo i costi della trasferta
            UIMap.UINotaSpeseWindow.UIItemEdit.Text = "90";
            UIMap.UINotaSpeseWindow.UIItemEdit1.Text = "150";
            UIMap.UINotaSpeseWindow.UIItemEdit2.Text = "200";

            // tap su avanti
            Gesture.Tap(UIMap.UIItemWindow.UIForwardButton);

            // ok sul salvataggio
            Gesture.Tap(UIMap.UIItemWindow.UISincronizzazioneWindow.UIChiudiButton);

            // verifico che la nota spese sia presente nella lista
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
