using System.Collections.ObjectModel;
using notes_xform.Model;
using Prism.Commands;
using Prism.Mvvm;

namespace notes_xform.ViewModels
{
    public class ListNotesViewModel : BindableBase
    {
        ServiceNotes serviceNotes;
        public ListNotesViewModel()
        {
            serviceNotes = new ServiceNotes();

            serviceNotes.GetListNotes_Completed += (s, a) =>
            {
                ListNotes = new ObservableCollection<Note>(a.Result);
            };

            SelectedChangedCommand = new DelegateCommand<object>(SelectedChanged);

            serviceNotes.GetListNotes();
        }

        private void SelectedChanged(object param)
        {
            var u = param;
        }

        private Note _NoteSelected;
        public Note NoteSelected
        {
            get { return _NoteSelected; }
            set
            {
                _NoteSelected = value;
                SetProperty(ref _NoteSelected, value);
            }
        }
        private ObservableCollection<Note> _ListNotes;
        public ObservableCollection<Note> ListNotes
        {
            get { return _ListNotes; }
            set
            {
                _ListNotes = value;
                SetProperty(ref _ListNotes, value);
            }
        }
        public DelegateCommand<object> SelectedChangedCommand { get; set; }
    }
}