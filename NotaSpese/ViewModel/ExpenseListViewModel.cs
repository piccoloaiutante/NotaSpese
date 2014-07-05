using NotaSpese.Infrastructure;
using NotaSpese.Model;
using NotaSpese.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaSpese.ViewModel
{
    public class ExpenseListViewModel :BaseViewModel
    {
        private IExpenseService _expenseService;

        public IList<Expense> Expenses { get; set; }

        public  ExpenseListViewModel(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        public async Task LoadExpenses()
        {
            Expenses = await _expenseService.LoadAllExpenses();
            OnPropertyChanged("Expenses");
        }
    }
}
