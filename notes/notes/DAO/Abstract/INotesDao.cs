using notes.DAO.Models;
using System;

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
        public void AddNote(Note note);

        /// <summary>
        /// Получить заметку по идентификатору
        /// </summary>
        public Note GetNoteById(Guid id);
    }
}
