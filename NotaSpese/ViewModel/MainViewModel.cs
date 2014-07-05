using NotaSpese.Common;
using NotaSpese.Infrastructure;
using NotaSpese.Service;
using NotaSpese.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaSpese.ViewModel
{
    public class MainViewModel
    {
        private INavigationService _navigationService;

        public RelayCommand CreateNewExpenseAccount { protected set; get; }
        public RelayCommand ViewExpenses { protected set; get; }

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            CreateNewExpenseAccount = new RelayCommand(ExecuteCreateNewExpenseAccount);
            ViewExpenses = new RelayCommand(ExecuteViewExpenses);
        }

        private void ExecuteViewExpenses() 
        {
            _navigationService.Navigate(typeof(ExpenseListView));
        }

        private void ExecuteCreateNewExpenseAccount()
        {
            _navigationService.Navigate(typeof(DateView));
        }
    }
}
