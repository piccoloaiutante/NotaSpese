using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using NotaSpese.Model;
using NotaSpese.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteSpese.Test
{
    [TestClass]
    public class ItineraryViewModelFixture
    {
        [TestMethod]
        public void Search_Should_Filter_Itineraries()
        {
            //arrange
            var navigationService = new FakeNavigationService();
            var vm = new ItineraryViewModel(navigationService);
            vm.Itineraries = new List<String> { "Brescia -> Roma", "Brescia -> Napoli" };

            //act
            vm.SearchedText = "Napo";
            vm.SearchItinerary.Execute(null);

            //Assert
            Assert.IsTrue(vm.Itineraries.Count() ==1);
            Assert.AreEqual(vm.Itineraries[0], "Brescia -> Napoli");
        }

        [TestMethod]
        public void Selecting_Itinerary_Should_Update_Expense_Before_Navigating()
        {
            //arrange
            var navigationService = new FakeNavigationService();
            var vm = new ItineraryViewModel(navigationService);
            vm.Expense = new Expense();

            //act
            vm.SelectedItinerary = "Brescia -> Napoli";
            vm.Forward.Execute(null);

            //assert
            Assert.IsNotNull(navigationService.Paramter);
            Assert.AreEqual(((Expense)navigationService.Paramter).Itinerary, "Brescia -> Napoli");

        }
    }
}
