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
    public class DateViewModel :BaseViewModel
    {
        private INavigationService _navigationService;

        public string Purpose {
            get { return Expense.Purpose; }
            set { Expense.Purpose = value; }
        }

        public DateTimeOffset Date {
            get { return Expense.Date; }
            set {  Expense.Date = value; }
        }

        public RelayCommand Forward { get; private set; }
        public RelayCommand Backward { get; private set; }

        public DateViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Backward = new RelayCommand(ExecuteBackward);
            Forward = new RelayCommand(ExecuteForward);
        }

        private void ExecuteBackward()
        {
            _navigationService.Navigate(typeof(MainView));
        }

        private void ExecuteForward()
        {
            _navigationService.Navigate(typeof(ItineraryView), Expense);
        }
        
    }
}
