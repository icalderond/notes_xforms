using System;
using System.Threading.Tasks;
using notes_xform.ViewModels;
using notes_xform.Views;
using Prism.Ioc;
using Prism.Unity;

namespace notes_xform
{
    public partial class App : PrismApplication
    {
        protected override void OnInitialized()
        {
            try
            {
                TaskScheduler.UnobservedTaskException += (sender, e) =>
                {
                    //Logger.Log(e.Exception.ToString(), Category.Exception, Priority.High);
                };
                InitializeComponent();
                NavigationService.NavigateAsync("ListNotes");
            }
            catch (Exception e)
            {
                var t = e.Message;
                // Logger.Log(e.Exception.ToString(), Category.Exception, Priority.High);
            }
        }
        //public App(IPlatformInitializer initializer = null) : base(initializer) { }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ListNotes, ListNotesViewModel>("ListNotes");
            containerRegistry.RegisterForNavigation<DetailNote, DetailNoteViewModel>("DetailNote");

        }
    }
}