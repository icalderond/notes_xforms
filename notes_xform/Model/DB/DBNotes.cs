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

        public void AddNote(string _title, string _content)
        {
            var newNote = new Note
            {
                Title = _title,
                Content = _content//,
                //Labels = new List<string>()
            };

            _connection.Insert(newNote);
        }
    }
}