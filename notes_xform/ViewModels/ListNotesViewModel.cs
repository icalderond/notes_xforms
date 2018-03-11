using System;
using System.Collections.ObjectModel;
using notes_xform.Model;

namespace notes_xform.ViewModels
{
    public class ListNotesViewModel : NotificationEnabledObject
    {
        ServiceNotes serviceNotes;
        public ListNotesViewModel()
        {
            serviceNotes = new ServiceNotes();

            serviceNotes.GetListNotes_Completed += (s, a) =>
            {
                ListNotes = new ObservableCollection<Note>(a.Result);
            };

            serviceNotes.getListNotes();
        }
        private ObservableCollection<Note> _ListNotes;
        public ObservableCollection<Note> ListNotes
        {
            get { return _ListNotes; }
            set { _ListNotes = value; OnPropertyChanged(); }
        }
    }
}