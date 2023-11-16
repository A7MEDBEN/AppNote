//using AddressBook;
using AppNote.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppNote.ViewModels
{
    public partial class NoteViewModel : INotifyPropertyChanged
    {

        //Fields
        private string _noteTitel;
        private string _noteDescription;
        private  Note _selectedNote;

        //GET AND SET
        public string NoteTitel
        {
            get => _noteTitel;
            set
            {
                if(_noteTitel != value)
                {
                    _noteTitel = value;
                    OnPropertyChanged();
                }
            }
        }
        public string NoteDescription
        {
            get => _noteDescription;
            set
            {
                if (_noteDescription != value)
                {
                    _noteDescription = value;
                    OnPropertyChanged();
                }
            }
        }
        public Note selectedNote
        {
            get => _selectedNote;
            set
            {
                if (_selectedNote != value)
                {
                    _selectedNote = value;
                    NoteTitel = _selectedNote.Title;
                    NoteDescription = _selectedNote.Description;
                    OnPropertyChanged();
                }
            }
        }

        //Property
        public ObservableCollection <Note> NoteCollection {  get; set; }

        public ICommand AddNoteCommade  { get;  }
        public ICommand EditeNoteCommade  { get;  }
        public ICommand RemoveNoteCommade  { get; }

        public NoteViewModel()
        {
            NoteCollection = new ObservableCollection<Note>();
            AddNoteCommade = new Command(AddNote);
            RemoveNoteCommade = new Command(DeleteNote);
            EditeNoteCommade = new Command(EditeNote);

        }

        private void EditeNote(object obj)
        {
            if(selectedNote != null)
            {
                foreach (Note note in NoteCollection.ToList())
                {
                    if(note == selectedNote)
                    {   //set new note
                        var newNote = new Note
                        {
                            Id = note.Id,
                            Title = NoteTitel,
                            Description = note.Description,
                        };
                        
                        //remove old note
                        NoteCollection.Remove(note);
                        NoteCollection.Add(newNote);
                    }
                }
            }
        }

        private void DeleteNote(object obj)
        {
            if(selectedNote != null)
            {
                NoteCollection.Remove(selectedNote);
                NoteTitel = string.Empty;
                NoteDescription = string.Empty;

            }
        }

        private void AddNote(object obj)
        {
            //Generate a unique ID for the new person
            int newId = NoteCollection.Count > 0 ? NoteCollection.Max( p => p.Id) + 1 : 1;
            //set new note
            var note = new Note
            {
                Title = NoteTitel,
                Description = NoteDescription,

            };
            NoteCollection.Add(note);
            //rest values
            NoteTitel = string.Empty;
            NoteDescription = string.Empty;
        }

        //PropertyChanged عملية التغيير
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
