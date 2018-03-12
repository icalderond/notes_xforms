using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace notes_xform.Model
{
    public class ServiceNotes
    {
        public event EventHandler<GenericEventArgs<List<Note>>> GetListNotes_Completed;

        public void GetListNotes()
        {
            var listNotes = new List<Note>();

            for (int i = 0; i < 20; i++)
            {
                listNotes.Add(new Note()
                {
                    Title = $"Este es el Titulo numero {i}",
                    Content = "Esto es un texto que es largo pero no tan larco como para cort...",
                    Labels = new ObservableCollection<string>()
                    {
                        "#Israel",
                        "Coliflor"
                    }
                });
            }

            GetListNotes_Completed?.Invoke(this, new GenericEventArgs<List<Note>>(listNotes));
        }
    }
}