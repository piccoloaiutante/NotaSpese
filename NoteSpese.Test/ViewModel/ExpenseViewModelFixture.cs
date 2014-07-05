using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotaSpese.ViewModel;
using NotaSpese.Service;
using NotaSpese.Model;

namespace NoteSpese.Test
{
    [TestClass]
    public class ExpenseViewModelFixture
    {
        ExpenseViewModel vm;
        FakeExpenseService expenseService;
        FakeNavigationService navigationService;


        [TestInitialize]
        public void Setup()
        {
            navigationService = new FakeNavigationService();
            expenseService = new FakeExpenseService();
            vm = new ExpenseViewModel(expenseService, navigationService);
            vm.Expense = new Expense();
        }

        [TestMethod]
        public void CalculateExpanses_Should_Sum_AllExpenses()
        {
            //Arrange

            //Act
            vm.Food = 100;
            vm.Km = 200;
            vm.Hotel = 1000;

            //Assert
            Assert.AreEqual(vm.TotalAmount, 1300);
        }

        [TestMethod]
        [DataRow(100,50,50,200,DisplayName="prova")]
        [DataRow(200, 100, 150, 450, DisplayName = "prova")]
        public void CalculateExpanses_Should_Sum_AllExpenses_General(int food,int travel,int hotel, int total)
        {
            //Arrange

            //Act
            vm.Food = food;
            vm.Travel = travel;
            vm.Hotel = hotel;

            //Assert
            Assert.AreEqual(vm.TotalAmount, total);
        }

        [TestCleanup]
        public void Cleanup()
        {
            navigationService = null;
            expenseService = null;
            vm = null;
        }
    }

    public class FakeExpenseService:IExpenseService
    {
        public bool InitCalled;
        public bool SaveCalled;
        public bool LoadAllExpensesCalled;

        public Task Init() 
        {
            InitCalled = true;
            return null;
        }

        public Task Save(Expense exp) 
        {
            SaveCalled = true;
            return null;
        }

        public Task<List<Expense>> LoadAllExpenses() 
        {
            LoadAllExpensesCalled = true;
            return null;
        }
    }
}
