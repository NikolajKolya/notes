using Microsoft.Extensions.DependencyInjection;
using notes.DAO.Models;
using notes.Models;
using notes.Services.Abstract;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using notes.Views;
using Note = notes.Models.Note;

namespace notes.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly INotesService _notesService;

        private string _noteText;

        private string _noteTitle;

        private NoteItem _selectedNote;

        private IList<NoteItem> _noteItems = new List<NoteItem>();

        private IList<NotePriority> _notesPriorities = new List<NotePriority>();

        public IList<NotePriority> NotesPriorities
        {
            get => _notesPriorities;

            set
            {
                this.RaiseAndSetIfChanged(ref _notesPriorities, value);
            }
        }

        private int _selectedPriorityIndex;

        public int SelectedPriorityIndex
        {
            get => _selectedPriorityIndex;

            set
            {
                this.RaiseAndSetIfChanged(ref _selectedPriorityIndex, value);

                // Здесь мы обрабатываем выбор нового элемента списка
                if (_selectedPriorityIndex == -1)
                {
                    return;
                }

                _selectedPriority = _notesPriorities[_selectedPriorityIndex];
            }
        }

        private NotePriority _selectedPriority;

        /// <summary>
        /// Add new note
        /// </summary>
        public ReactiveCommand<Unit, Unit> AddNewNoteCommand { get; }

        /// <summary>
        /// Delete selected note
        /// </summary>
        public ReactiveCommand<Unit, Unit> DeleteNoteCommand { get; }

        public ReactiveCommand<Unit, Unit> SaveNoteCommand { get; }

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

            _notesPriorities.Add(new NotePriority() { PriorityLevel = Models.Enums.NotePriorityEnum.Low, Description = "Низкая" });
            _notesPriorities.Add(new NotePriority() { PriorityLevel = Models.Enums.NotePriorityEnum.Normal, Description = "Нормальная" });
            _notesPriorities.Add(new NotePriority() { PriorityLevel = Models.Enums.NotePriorityEnum.High, Description = "Высокая" });

            SelectedPriorityIndex = 1;

            AddNewNoteCommand = ReactiveCommand.Create(OnAddNewNoteCommand);
            DeleteNoteCommand = ReactiveCommand.Create(OnDeleteNewNoteCommand);
            SaveNoteCommand = ReactiveCommand.Create(OnSaveNoteCommand);

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

        private void OnSaveNoteCommand()
        {
            if (SelectedNote == null)
            {
                return;
            }

            var updatedNote = new Note()
            {
                Id = SelectedNote.Id,
                Name = NoteTitle,
                Content = NoteText,
                Timestamp = DateTime.Now
            };

            _notesService.Update(updatedNote);

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
