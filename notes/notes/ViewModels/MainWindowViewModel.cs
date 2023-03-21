using Microsoft.Extensions.DependencyInjection;
using notes.Models;
using notes.Services.Abstract;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;

namespace notes.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly INotesService _notesService;

        private string _noteText;

        private NoteItem _selectedNote;

        /// <summary>
        /// Add new note
        /// </summary>
        public ReactiveCommand<Unit, Unit> AddNewNoteCommand { get; }

        public ObservableCollection<NoteItem> NoteItems { get; }

        public NoteItem SelectedNote
        {
            get => _selectedNote;
            set
            {
                _selectedNote = value;
                this.RaiseAndSetIfChanged(ref _selectedNote, value);
                LoadNoteBySelectedNote(value);
            }
        }

        public string NoteText
        {
            get => _noteText;
            set
            {
                _noteText = value;
                this.RaiseAndSetIfChanged(ref _noteText, value);
            }
        }

        public MainWindowViewModel()
        {
            _notesService = Program.Di.GetService<INotesService>();

            AddNewNoteCommand = ReactiveCommand.Create(OnAddNewNoteCommand);

            NoteItems = new ObservableCollection<NoteItem>();
        }

        /// <summary>
        /// Add new note
        /// </summary>
        private void OnAddNewNoteCommand()
        {
            var note = _notesService.Add("Title will be here", NoteText);

            NoteItems.Add(new NoteItem
            {
                Index = NoteItems.Count,
                Id = note.Id,
                Name = note.Name,
                Timestamp = note.Timestamp
            });
        }

        private void LoadNoteBySelectedNote(NoteItem selectedNoteItem)
        {
            var note = _notesService.Get(selectedNoteItem.Id);

            NoteText = note.Content;
        }
    }
}
