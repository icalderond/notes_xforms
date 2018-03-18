using System;
using System.IO;
using notes_xform.iOS;
using notes_xform.Model.DB;
using SQLite.Net;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace notes_xform.iOS
{
    public class SQLite_iOS : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var fileName = "SQL_notes.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);

            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var connection = new SQLiteConnection(platform, path);

            return connection;
        }
    }
}