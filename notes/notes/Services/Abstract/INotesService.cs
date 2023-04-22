using notes.Models;
using System;
using System.Collections.Generic;

namespace notes.Services.Abstract
{
    /// <summary>
    /// Service to work with notes
    /// </summary>
    public interface INotesService
    {
        /// <summary>
        /// Add note
        /// </summary>
        Note Add(string name, string content);

        /// <summary>
        /// Get note by Id
        /// </summary>
        Note Get(Guid noteId);

        /// <summary>
        /// Get all notes
        /// </summary>
        IReadOnlyCollection<Note> GetAllNotes();

        /// <summary>
        /// Delete note by Id
        /// </summary>
        void Delete(Guid id);

        /// <summary>
        /// Обновить заметку
        /// </summary>
        void Update(Note newNote);
    }
}
