﻿using System.Collections.ObjectModel;

namespace notes_xform.Model
{
    public class Note
    {
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