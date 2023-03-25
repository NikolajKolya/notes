using notes.DAO.Abstract;
using notes.Models;
using notes.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notes.Services.Implementations
{
    public class NotesService : INotesService
    {
        private readonly INotesDao _notesDao;

        public NotesService(INotesDao notesDao)
        {
            _notesDao = notesDao;
        }

        public Note Add(string name, string content)
        {
            var dbNote = new DAO.Models.Note()
            {
                Name = name,
                Content = content,
                Timestamp= DateTime.Now
            };

            _notesDao.AddNote(dbNote);

            return Get(dbNote.Id);
        }

        public Note Get(Guid noteId)
        {
            var dbNote = _notesDao.GetNoteById(noteId);

            return new Note()
            {
                Id = dbNote.Id,
                Name = dbNote.Name,
                Content = dbNote.Content,
                Timestamp = DateTime.Now
            };
        }
    }
}
