//using AddressBook;
using AppNote.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace AppNote.ViewModels
{
    public partial class NoteViewModel : ObservableObject
    {

        //Fields
        [ObservableProperty]
        string noteTitel;

        [ObservableProperty]
        string noteDescription;

        [ObservableProperty]
        Note selectedNote;

        [ObservableProperty]
        public ObservableCollection<Note> noteCollection;

        //GET AND SET




        //Property




        public NoteViewModel()
        {
            noteCollection = new ObservableCollection<Note>();


        }
        [RelayCommand]
        void EditeNote()
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

        [RelayCommand]
        void DeleteNote()
        {
            if(selectedNote != null)
            {
                NoteCollection.Remove(selectedNote);
                NoteTitel = string.Empty;
                NoteDescription = string.Empty;

            }
        }

        [RelayCommand]
        void AddNote()
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

       
    }
}
