using notes.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;

namespace notes.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IList<NoteItem> _noteItems = new List<NoteItem>();

        private string _noteText;

        /// <summary>
        /// Add new note
        /// </summary>
        public ReactiveCommand<Unit, Unit> AddNewNoteCommand { get; }

        public IList<NoteItem> NoteItems
        {
            get => _noteItems;
            set
            {
                _noteItems = value;
                this.RaiseAndSetIfChanged(ref _noteItems, value);
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
            AddNewNoteCommand = ReactiveCommand.Create(OnAddNewNoteCommand);

            NoteItems = new List<NoteItem>();
            NoteItems.Add(new NoteItem { Name = "Note 1", Timestamp = DateTime.Now });
            NoteItems.Add(new NoteItem { Name = "Note 2", Timestamp = DateTime.Now });
        }

        /// <summary>
        /// Add new note
        /// </summary>
        private void OnAddNewNoteCommand()
        {

        }
    }
}
