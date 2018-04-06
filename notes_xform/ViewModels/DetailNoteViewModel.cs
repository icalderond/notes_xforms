using System;
using notes_xform.Model;
using Prism.Mvvm;
using Xamarin.Forms;

namespace notes_xform.ViewModels
{
    public class DetailNoteViewModel : BindableBase
    {
        ServiceNotes serviceNotes;
        public DetailNoteViewModel()
        {
            serviceNotes = new ServiceNotes();
            serviceNotes.GetNote_Completed += (s, a) => NoteSelected = a.Result;

            var consecutivo = Convert.ToInt32(Application.Current.Properties["consecutivo"]);
            serviceNotes.GetNote(consecutivo);
        }

        private Note _NoteSelected;
        public Note NoteSelected
        {
            get => _NoteSelected;
            set
            {
                _NoteSelected = value;
                SetProperty(ref _NoteSelected, value);
                serviceNotes.UpdateNote(value);
            }
        }
    }
}