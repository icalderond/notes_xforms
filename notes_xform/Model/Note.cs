using System;
using System.Collections.Generic;
using Prism.Mvvm;
using SQLite.Net.Attributes;

namespace notes_xform.Model
{
    public class Note //: BindableBase
    {
        [PrimaryKey, AutoIncrement]
        public int Consecutivo { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateChanged { get; set; }

        //private int _Consecutivo;

        //[PrimaryKey, AutoIncrement]
        //public int Consecutivo
        //{
        //    get { return _Consecutivo; }
        //    set { _Consecutivo = value; }
        //}

        //private string _Title;
        //public string Title
        //{
        //    get { return _Title; }
        //    set { _Title = value; }
        //}
        //private string _Content;
        //public string Content
        //{
        //    get { return _Content; }
        //    set { _Content = value; }
        //}
        //private DateTime _DateChanged;
        //public DateTime DateChanged
        //{
        //    get { return _DateChanged; }
        //    set { _DateChanged = value; }
        //}
    }
}