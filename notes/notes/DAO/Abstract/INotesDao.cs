using notes.DAO.Models;
using System;
using System.Collections.Generic;

namespace notes.DAO.Abstract
{
    /// <summary>
    /// Интерфейс для работы с базой данных
    /// </summary>
    public interface INotesDao
    {
        /// <summary>
        /// Добавить заметку в базу.
        /// Ключ переданной заметки игнорируется, база сама генерирует новый ключ и записывает его в Note.Id
        /// </summary>
        void AddNote(Note note);

        /// <summary>
        /// Получить заметку по идентификатору
        /// </summary>
        Note GetNoteById(Guid id);

        /// <summary>
        /// Получить все заметки
        /// </summary>
        IReadOnlyCollection<Note> GetAllNotes();

        /// <summary>
        /// Удалить заметку по её ID
        /// </summary>
        void DeleteNoteById(Guid id);

        /// <summary>
        /// Обновляем заметку. В заметке должен быть заполнен ID (по нему определяем какую заметку обновлять).
        /// </summary>
        void Update(Note newNote);
    }
}
