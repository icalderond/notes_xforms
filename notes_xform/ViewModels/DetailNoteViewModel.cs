using System;
using Prism.Mvvm;
using Prism.Navigation;

namespace notes_xform.ViewModels
{
    public class DetailNoteViewModel : BindableBase, INavigationAware
    {
        public DetailNoteViewModel()
        {
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            var _contact = Convert.ToString(parameters["consecutivo"]);
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }
    }
}
