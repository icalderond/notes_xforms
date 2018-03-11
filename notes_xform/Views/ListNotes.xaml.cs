using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace notes_xform.Views
{
    public partial class ListNotes : ContentPage
    {
        public ListNotes()
        {
            InitializeComponent();
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            // throw new NotImplementedException();
            var t = e.Item;
        }
    }
}
