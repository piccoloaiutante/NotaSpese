using NotaSpese.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaSpese.Service
{
    public interface IExpenseService
    {
        Task Init();
        Task Save(Expense exp);
        Task<List<Expense>> LoadAllExpenses();
        Task DeleteAll();
    }

    public class ExpenseService : IExpenseService
    {
        string DBPath;
 
        public ExpenseService ()
	    {
            DBPath = Path.Combine( Windows.Storage.ApplicationData.Current.LocalFolder.Path, "expense.sqlite");
	    }

        public async Task Init()
        {
           var db = new SQLite.SQLiteAsyncConnection(DBPath,false);
            
           await db.CreateTableAsync<Expense>();
        }

        public async Task Save(Expense exp)
        {
            var db = new SQLite.SQLiteAsyncConnection(DBPath, false);
            
            await db.InsertAsync(exp);
        }

        public Task<List<Expense>> LoadAllExpenses() {
            var db = new SQLite.SQLiteAsyncConnection(DBPath, false);
            return db.QueryAsync<Expense>("Select * from expense");
        }

        public async Task DeleteAll() 
        {
            var db = new SQLite.SQLiteAsyncConnection(DBPath, false);
            await db.ExecuteAsync("delete from expense");
        }
    }
}
