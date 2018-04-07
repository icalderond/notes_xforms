using System;
using notes_xform.Model;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace notes_xform.ViewModels
{
    public class DetailNoteViewModel : BindableBase, INavigationAware
    {
        ServiceNotes serviceNotes;
        public DetailNoteViewModel()
        {
            serviceNotes = new ServiceNotes();
            serviceNotes.GetNote_Completed += (s, a) => NoteSelected = a.Result;
        }

        private Note _NoteSelected;
        public Note NoteSelected
        {
            get => _NoteSelected;
            set
            {
                SetProperty(ref _NoteSelected, value);
                serviceNotes.UpdateNote(value);
            }
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            var consecutivo = Convert.ToInt32(parameters["consecutivo"]);
            serviceNotes.GetNote(consecutivo);
        }
    }
}