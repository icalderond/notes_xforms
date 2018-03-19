using System;
using System.Collections.Generic;
using Prism.Mvvm;
using SQLite.Net.Attributes;

namespace notes_xform.Model
{
    public class Note : BindableBase
    {
        private int _Consecutivo;

        [PrimaryKey, AutoIncrement]
        public int Consecutivo
        {
            get { return _Consecutivo; }
            set { _Consecutivo = value; SetProperty(ref _Consecutivo, value); }
        }

        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; SetProperty(ref _Title, value); }
        }
        private string _Content;
        public string Content
        {
            get { return _Content; }
            set { _Content = value; SetProperty(ref _Content, value); }
        }
        private DateTime _DateChanged;
        public DateTime DateChanged
        {
            get { return _DateChanged; }
            set { _DateChanged = value; SetProperty(ref _DateChanged, value); }
        }
        //public List<string> Labels
        //{
        //    get;
        //    set;
        //}
    }
}