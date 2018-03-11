using System;
using System.Collections.Generic;

namespace notes_xform.Model
{
    public class ServiceNotes
    {
        public event EventHandler<GenericEventArgs<List<Note>>> GetListNotes_Completed;
        public ServiceNotes()
        {
        }
        public void getListNotes()
        {
            var listNotes = new List<Note>();
            GetListNotes_Completed?.Invoke(this, new GenericEventArgs<List<Note>>(listNotes));
        }
    }
}