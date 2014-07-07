using NotaSpese.Common;
using NotaSpese.Infrastructure;
using NotaSpese.Model;
using NotaSpese.Service;
using NotaSpese.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace NotaSpese.ViewModel
{
    public class ExpenseViewModel : BaseViewModel
    {
        private int _travel;
        private int _food;
        private int _hotel;
      
        private IExpenseService _expenseService;
        private INavigationService _navigationService;
       

      

        public int Travel {
            get { return _travel; }
            set { _travel = value; CalculateExpanses(); }
        }

        public int Food {
            get { return _food; }
            set { _food = value; CalculateExpanses(); }
        }

        public int Hotel {
            get { return _hotel; }
            set { _hotel = value; CalculateExpanses(); }
        }

        public int TotalAmount {
            get { return Expense.TotalAmount; }
            set { Expense.TotalAmount = value; OnPropertyChanged("TotalAmount"); }
        }

        public RelayCommand Save { get; private set; }
        public RelayCommand Backward { get; private set; }

        public ExpenseViewModel(IExpenseService expenseService,INavigationService navigationService)
        {
            _expenseService = expenseService;
            _navigationService = navigationService;

            Save = new RelayCommand(ExecuteSave);
            Backward = new RelayCommand(ExecuteBackward);
        }

        private async void ExecuteSave() {
            MessageDialog data = new MessageDialog("Dati salvati correttamente", "Salvataggio");
            await data.ShowAsync();
            await  _expenseService.Save(Expense);
            _navigationService.Navigate(typeof(MainView));
        }

        private void CalculateExpanses()
        {
             Expense.TotalAmount = _travel + _food + _hotel;
             OnPropertyChanged("TotalAmount");
        }

        private void ExecuteBackward() 
        {
            _navigationService.Navigate(typeof(ItineraryView), Expense);
        }
        
    }
}
