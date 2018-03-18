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
        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync("ListNotes");
        }
        //public App(IPlatformInitializer initializer = null) : base(initializer) { }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<ListNotes>();//("ListNotes");
            containerRegistry.RegisterForNavigation<DetailNote>();//("DetailNote");
        }
    }
}