using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaSpese.Service
{
    public interface INavigationService
    {
        void Navigate(Type destination, object parameter);

        void Navigate(Type type);
    }

    public class NavigationService : INavigationService 
    {
        public void Navigate(Type destination, object parameter)
        {
            App.RootFrame.Navigate(destination,parameter);
        }

        public void Navigate(Type destination)
        {
            App.RootFrame.Navigate(destination);
        }
    }
}
