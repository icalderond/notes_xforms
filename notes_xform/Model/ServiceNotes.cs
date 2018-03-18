using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using notes_xform.Model.DB;

namespace notes_xform.Model
{
    public class ServiceNotes
    {
        DBNotes dbNotes;
        public event EventHandler<GenericEventArgs<List<Note>>> GetListNotes_Completed;

        public ServiceNotes()
        {
            dbNotes = new DBNotes();
        }

        public void GetListNotes()
        {
            var listNotes = new List<Note>(dbNotes.GetNotes());
            GetListNotes_Completed?.Invoke(this, new GenericEventArgs<List<Note>>(listNotes));
        }
    }
}