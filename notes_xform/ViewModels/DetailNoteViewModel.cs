using System;
using notes_xform.Model;
using Prism.Commands;
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
            serviceNotes.GetNote_Completed += (s, a) =>
            {
                NoteSelected = a.Result;
            };
            var consecutivo = Convert.ToInt32(Application.Current.Properties["consecutivo"]);
            serviceNotes.GetNote(consecutivo);
        }

        //public DelegateCommand PruebaCommand { get; set; }

        private Note _NoteSelected;
        public Note NoteSelected
        {
            get
            {
                //if (_NoteSelected == null)
                //{
                //    _NoteSelected = new Note();
                //}
                return _NoteSelected;
            }
            set
            {
                _NoteSelected = value;
                SetProperty(ref _NoteSelected, value);
            }
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            //var _contact = Convert.ToInt32(parameters["consecutivo"]);
            //serviceNotes.GetNote(_contact);
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            //var _contact = Convert.ToInt32(parameters["consecutivo"]);
            //serviceNotes.GetNote(_contact);
        }
    }
}
