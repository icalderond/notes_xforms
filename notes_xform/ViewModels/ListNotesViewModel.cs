using System;
using System.Collections.ObjectModel;
using notes_xform.Model;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

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

            serviceNotes.GetListNotes_Completed += (s, a) => ListNotes = new ObservableCollection<Note>(a.Result);

            SelectedChangedCommand = new DelegateCommand<object>(SelectedChanged);

            serviceNotes.GetListNotes();
        }
        public ListNotesViewModel() { }

        private void SelectedChanged(object param)
        {
            //using both Uri parameters and NavigationParameters
            var navParameters = new NavigationParameters();
            navParameters.Add("consecutivo", NoteSelected.Consecutivo);
            _navigationService.NavigateAsync(new Uri("DetailNote", UriKind.Relative), navParameters);
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
        private bool _IsBusy = true;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set { _IsBusy = value; SetProperty(ref _IsBusy, value); }
        }
        public DelegateCommand<object> SelectedChangedCommand { get; set; }
    }
}