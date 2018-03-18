using System.Collections.ObjectModel;
using SQLite.Net.Attributes;

namespace notes_xform.Model
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Consecutivo
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
        public string Content
        {
            get;
            set;
        }
        public ObservableCollection<string> Labels
        {
            get;
            set;
        }
    }
}