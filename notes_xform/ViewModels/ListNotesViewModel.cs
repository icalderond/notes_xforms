using System;
using System.Collections.ObjectModel;
using notes_xform.Model;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace notes_xform.ViewModels
{
    public class ListNotesViewModel : BindableBase
    {
        INavigationService _navigationService;
        ServiceNotes serviceNotes;

        public ListNotesViewModel(INavigationService navigationService) // has to be named correctly
        {
            _navigationService = navigationService;
            serviceNotes = new ServiceNotes();

            serviceNotes.GetListNotes_Completed += (s, a) =>
            {
                Notes = new ObservableCollection<Note>(a.Result);
                IsRefreshing = false;
            };
            serviceNotes.CreateNote_Completed += (s, a) =>
            {
                Application.Current.Properties["consecutivo"] = a.Result;
                _navigationService.NavigateAsync("DetailNote");
            };

            SelectedChangedCommand = new DelegateCommand<object>(SelectedChanged);
            CreateNoteCommand = new DelegateCommand<string>(CreateNote);
            RefreshList = new DelegateCommand<string>(RefreshListNotes);

            serviceNotes.GetListNotes();
        }

        private void RefreshListNotes(string obj)
        {
            IsRefreshing = true;
            serviceNotes.GetListNotes();
        }

        private void CreateNote(string obj) => serviceNotes.CreateNote();

        public ListNotesViewModel() { }

        private void SelectedChanged(object param)
        {
            Application.Current.Properties["consecutivo"] = NoteSelected.Consecutivo;
            _navigationService.NavigateAsync("DetailNote");
        }

        private Note _NoteSelected;
        public Note NoteSelected
        {
            get { return _NoteSelected; }
            set
            { _NoteSelected = value; SetProperty(ref _NoteSelected, value); }
        }
        private ObservableCollection<Note> _Notes;
        public ObservableCollection<Note> Notes
        {
            get { return _Notes; }
            set
            { _Notes = value; SetProperty(ref _Notes, value); }
        }
        private bool _IsBusy;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set { _IsBusy = value; SetProperty(ref _IsBusy, value); }
        }
        private bool _IsRefreshing;
        public bool IsRefreshing
        {
            get { return _IsRefreshing; }
            set
            {
                _IsRefreshing = value;
                SetProperty(ref _IsRefreshing, value);
            }
        }

        public DelegateCommand<object> SelectedChangedCommand { get; set; }
        public DelegateCommand<string> CreateNoteCommand { get; set; }
        public DelegateCommand<string> RefreshList { get; set; }
    }
}