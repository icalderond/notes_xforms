using System;
using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using Xamarin.Forms;

namespace notes_xform.Model.DB
{
    public class DBNotes
    {
        private SQLiteConnection _connection;

        public DBNotes()
        {
            try
            {
                _connection = DependencyService.Get<ISQLite>().GetConnection();
                _connection.CreateTable<Note>();
            }
            catch (System.Exception ex)
            {
                var message = ex.Message;
            }
            // _connection.DeleteAll<Note>();
        }

        public IEnumerable<Note> GetNotes()
        {
            return (from current in _connection.Table<Note>()
                    select current).ToList();
        }

        public Note GetNote(int _consecutivo) =>
        _connection.Table<Note>().FirstOrDefault(current => current.Consecutivo == _consecutivo);


        public void DeleteNote(int _consecutivo) =>
        _connection.Delete<Note>(_consecutivo);

        public int AddNote(string _title, string _content)
        {
            var newNote = new Note
            {
                Title = _title,
                Content = _content,
                DateChanged = DateTime.Now//,
                //Labels = new List<string>()
            };

            int inserted = _connection.Insert(newNote);
            return inserted > 0 ? newNote.Consecutivo : -1;
        }
        public int EditNote(Note _noteToEdit)
        {
            int inserted = _connection.Update(_noteToEdit);
            return inserted;
        }
    }
}