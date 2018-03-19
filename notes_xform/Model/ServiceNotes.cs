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
        public event EventHandler<GenericEventArgs<int>> CreateNote_Completed;
        public event EventHandler<GenericEventArgs<Note>> GetNote_Completed;

        public ServiceNotes()
        {
            dbNotes = new DBNotes();
        }

        public void GetListNotes()
        {
            var listNotes = new List<Note>(dbNotes.GetNotes());
            GetListNotes_Completed?.Invoke(this, new GenericEventArgs<List<Note>>(listNotes));
        }
        public void CreateNote(string _Title = "", string _Content = "")
        {
            var consecutivo = dbNotes.AddNote(_Title, _Content);
            CreateNote_Completed?.Invoke(this, new GenericEventArgs<int>(consecutivo));
        }
        public void GetNote(int _consecutivo)
        {
            var note = dbNotes.GetNote(_consecutivo);
            GetNote_Completed?.Invoke(this, new GenericEventArgs<Note>(note));
        }
    }
}