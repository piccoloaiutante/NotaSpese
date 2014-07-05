using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using NotaSpese.Model;
using NotaSpese.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace NoteSpese.Test.Service
{
    [TestClass]
    public class ExpenseServiceFixture {

        private IExpenseService service;

        [TestInitialize]
        public async Task Setup()
        {

            service = new ExpenseService();
            await service.Init();
        }

        [TestMethod]
        public async Task LoadAllExpenses_Should_ReadExpenses_From_Db()
        {
            var expenses= await service.LoadAllExpenses();

            Assert.AreEqual(expenses.Count, 0);

            await service.Save(new Expense { });

            expenses = await service.LoadAllExpenses();
           
            Assert.AreEqual(expenses.Count, 1);

        }


        [TestCleanup]
        public async Task Cleanup()
        {
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
            var dbFile = await local.GetFileAsync("expense.sqlite");
            await service.DeleteAll();
        }
    
    }
}
