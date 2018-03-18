using System;
using System.IO;
using notes_xform.Droid;
using SQLite.Net;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace notes_xform.Droid
{
    public class SQLite_Android
    {
        public SQLiteConnection GetConnection()
        {
            var fileName = "SQL_notes.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLiteConnection(platform, path);

            return connection;
        }
    }
}