using notes_xform.ViewModels;
using notes_xform.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;

namespace notes_xform
{
    public partial class App : PrismApplication
    {
        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync("ListNotes");
        }
        //public App(IPlatformInitializer initializer = null) : base(initializer) { }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ListNotes, ListNotesViewModel>("ListNotes");
        }
    }
}