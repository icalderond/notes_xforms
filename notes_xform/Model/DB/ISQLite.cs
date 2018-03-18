using System;
using SQLite.Net;

namespace notes_xform.Model.DB
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
