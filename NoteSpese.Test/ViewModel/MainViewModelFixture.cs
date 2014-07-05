using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using NotaSpese.ViewModel;
using NotaSpese.Service;
using NotaSpese.View;

namespace NoteSpese.Test
{
    [TestClass]
    public class MainViewModelFixture
    {
        [TestMethod]
        public void CreateExpanse_Should_Navigate_To_DateViewModel()
        {
            //arrange
            var navigationService=new FakeNavigationService();
            var expenseService = new FakeExpenseService();
            MainViewModel vm = new MainViewModel(navigationService, expenseService);

            //act
            vm.CreateNewExpenseAccount.Execute(null);

            //Assert
            Assert.AreEqual(navigationService.Destination , typeof(DateView));
        }

        
    }

    public class FakeNavigationService:INavigationService
    {
        public Type Destination;
        public object Paramter;

        public void Navigate(Type destination, object parameter)
        {
            Destination = destination;
            Paramter = parameter;
        }

        public void Navigate(Type type) 
        {
            Destination = type;
        }
    }
}
