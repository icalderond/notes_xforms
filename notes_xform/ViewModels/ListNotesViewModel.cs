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

            serviceNotes.GetListNotes();
        }
        private Note _NoteSelected;
        public Note NoteSelected
        {
            get { return _NoteSelected; }
            set
            {
                _NoteSelected = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Note> _ListNotes;
        public ObservableCollection<Note> ListNotes
        {
            get { return _ListNotes; }
            set
            {
                _ListNotes = value;
                OnPropertyChanged();
            }
        }
        private ActionCommand<string> _SelectedChangedCommand;
        public ActionCommand<string> SelectedChangedCommand
        {
            get
            {
                if (_SelectedChangedCommand == null)
                {
                    _SelectedChangedCommand = new ActionCommand<string>((param) =>
                    {
                        var u = param;
                    });
                }
                return _SelectedChangedCommand;
            }
            set { _SelectedChangedCommand = value; OnPropertyChanged(); }
        }
    }
}