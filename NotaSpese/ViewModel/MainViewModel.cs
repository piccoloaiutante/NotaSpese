using NotaSpese.Common;
using NotaSpese.Infrastructure;
using NotaSpese.Model;
using NotaSpese.Service;
using NotaSpese.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaSpese.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private IExpenseService _expenseService;

        public IList<Expense> Expenses { get; set; }
        public RelayCommand CreateNewExpenseAccount { protected set; get; }


        public MainViewModel(INavigationService navigationService, IExpenseService expenseService)
        {
            _navigationService = navigationService;
            _expenseService = expenseService;

            CreateNewExpenseAccount = new RelayCommand(ExecuteCreateNewExpenseAccount);
        }

        private void ExecuteCreateNewExpenseAccount()
        {
            _navigationService.Navigate(typeof(DateView));
        }

        public async Task LoadExpenses()
        {
            Expenses = await _expenseService.LoadAllExpenses();
            OnPropertyChanged("Expenses");
        }
    }
}