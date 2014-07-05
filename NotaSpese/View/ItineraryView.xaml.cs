using NotaSpese.Model;
using NotaSpese.Service;
using NotaSpese.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Il modello di elemento per la pagina vuota è documentato all'indirizzo http://go.microsoft.com/fwlink/?LinkID=390556

namespace NotaSpese.View
{
    /// <summary>
    /// Pagina vuota che può essere utilizzata autonomamente oppure esplorata all'interno di un frame.
    /// </summary>
    public sealed partial class ItineraryView : Page
    {
        public ItineraryView()
        {
            this.InitializeComponent();
            this.Loaded += (sender, e) =>
            {
                Windows.Phone.UI.Input.HardwareButtons.BackPressed += Back_pressed;
            };

            // Undo the same changes when the page is no longer visible
            this.Unloaded += (sender, e) =>
            {
                Windows.Phone.UI.Input.HardwareButtons.BackPressed -= Back_pressed;
            };
        }

        /// <summary>
        /// Richiamato quando la pagina sta per essere visualizzata in un Frame.
        /// </summary>
        /// <param name="e">Dati dell'evento in cui vengono descritte le modalità con cui la pagina è stata raggiunta.
        /// Questo parametro viene in genere utilizzato per configurare la pagina.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var vm = new ItineraryViewModel(new NavigationService());
            vm.Expense = (Expense)e.Parameter;
            DataContext = vm;
        }


        internal void Back_pressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            e.Handled = true;
            if (App.RootFrame.CanGoBack)
                App.RootFrame.GoBack();
        }

    }
}
