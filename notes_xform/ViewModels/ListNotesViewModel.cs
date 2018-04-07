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
                var consecutivo = a.Result;
                _navigationService.NavigateAsync($"DetailNote?consecutivo={consecutivo}");
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
            _navigationService.NavigateAsync($"DetailNote?consecutivo={NoteSelected.Consecutivo}");
        }

        private Note _NoteSelected;
        public Note NoteSelected
        {
            get => _NoteSelected;
            set => SetProperty(ref _NoteSelected, value);
        }
        private ObservableCollection<Note> _Notes;
        public ObservableCollection<Note> Notes
        {
            get => _Notes;
            set => SetProperty(ref _Notes, value);
        }
        private bool _IsBusy;
        public bool IsBusy
        {
            get => _IsBusy;
            set => SetProperty(ref _IsBusy, value);
        }
        private bool _IsRefreshing;
        public bool IsRefreshing
        {
            get => _IsRefreshing;
            set => SetProperty(ref _IsRefreshing, value);
        }

        public DelegateCommand<object> SelectedChangedCommand { get; set; }
        public DelegateCommand<string> CreateNoteCommand { get; set; }
        public DelegateCommand<string> RefreshList { get; set; }
    }
}