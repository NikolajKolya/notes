using Microsoft.Extensions.DependencyInjection;
using notes.DAO.Models;
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

        private string _noteTitle;

        private NoteItem _selectedNote;

        private IList<NoteItem> _noteItems = new List<NoteItem>();

        /// <summary>
        /// Add new note
        /// </summary>
        public ReactiveCommand<Unit, Unit> AddNewNoteCommand { get; }

        /// <summary>
        /// Delete selected note
        /// </summary>
        public ReactiveCommand<Unit, Unit> DeleteNoteCommand { get; }

        public IList<NoteItem> NoteItems
        {
            get => _noteItems;

            set
            {
                this.RaiseAndSetIfChanged(ref _noteItems, value);
            }
        }

        public NoteItem SelectedNote
        {
            get => _selectedNote;
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedNote, value);
                LoadNoteBySelectedNote(value);
            }
        }

        public string NoteTitle
        {
            get => _noteTitle;
            set
            {
                this.RaiseAndSetIfChanged(ref _noteTitle, value);
            }
        }

        public string NoteText
        {
            get => _noteText;
            set
            {
                this.RaiseAndSetIfChanged(ref _noteText, value);
            }
        }

        public MainWindowViewModel()
        {
            _notesService = Program.Di.GetService<INotesService>();

            AddNewNoteCommand = ReactiveCommand.Create(OnAddNewNoteCommand);
            DeleteNoteCommand = ReactiveCommand.Create(OnDeleteNewNoteCommand);

            ReloadNotesList();
        }

        /// <summary>
        /// Add new note
        /// </summary>
        private void OnAddNewNoteCommand()
        {
            _notesService.Add(NoteTitle, NoteText);

            ReloadNotesList();
        }

        /// <summary>
        /// Delete note
        /// </summary>
        private void OnDeleteNewNoteCommand()
        {
            if (SelectedNote == null)
            {
                return;
            }

            _notesService.Delete(SelectedNote.Id);

            ReloadNotesList();
        }

        private void LoadNoteBySelectedNote(NoteItem selectedNoteItem)
        {
            if (selectedNoteItem == null)
            {
                return;
            }

            var note = _notesService.Get(selectedNoteItem.Id);

            NoteTitle = note.Name;
            NoteText = note.Content;
        }

        private void ReloadNotesList()
        {
            NoteItems = new List<NoteItem>();

            foreach (var dbNote in _notesService.GetAllNotes())
            {
                NoteItems.Add(new NoteItem
                {
                    Index = NoteItems.Count,
                    Id = dbNote.Id,
                    Name = dbNote.Name,
                    Timestamp = dbNote.Timestamp
                });
            }

            NoteItems = new List<NoteItem>(NoteItems);
        }
    }
}
