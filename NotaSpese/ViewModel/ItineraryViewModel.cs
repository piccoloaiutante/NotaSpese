using NotaSpese.Common;
using NotaSpese.Infrastructure;
using NotaSpese.Service;
using NotaSpese.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaSpese.ViewModel
{
    public class ItineraryViewModel : BaseViewModel
    {
        private string _selectedItinerary;
        private INavigationService _navigationService;

        public IList<String> Itineraries { get; set; }

        public string SearchedText { get; set; }

        public RelayCommand SearchItinerary { get; private set; }
        public RelayCommand Forward { get; private set; }
        public RelayCommand Backward { get; private set; }

        public string SelectedItinerary {
            get { return Expense.Itinerary; } 
            set { 
                  Expense.Itinerary = value;
            }
        }

        public ItineraryViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Itineraries = new List<string> { "Brescia -> Bergamo", "Roma -> Napoli", "Milano -> Palermo" };
            SearchItinerary = new RelayCommand(ExecuteSearchItinerary);
            Backward = new RelayCommand(ExecuteBackward);
            Forward = new RelayCommand(ExecuteForward);
        }

        private void ExecuteSearchItinerary() {

            Itineraries = Itineraries.Where(p => p.ToLower().Contains(SearchedText.ToLower())).ToList();
            OnPropertyChanged("Itineraries");
        }

        private void ExecuteBackward() 
        {
           _navigationService.Navigate(typeof(DateView), Expense);
        }

        private void ExecuteForward()
        {
            _navigationService.Navigate(typeof(ExpenseView), Expense);
        }

    }
}
