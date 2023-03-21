using notes.Models;
using System;

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
    }
}
