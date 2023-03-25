using notes.DAO.Abstract;
using notes.DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notes.DAO.Implementations
{
    public class NotesDao : INotesDao
    {
        private MainDbContext _mainDbContext;

        public NotesDao()
        {
            _mainDbContext = new MainDbContext();
        }

        public void AddNote(Note note)
        {
            _ = note ?? throw new ArgumentNullException(nameof(note));

            _mainDbContext.Add(note);
            _mainDbContext.SaveChanges();
        }

        public void DeleteNoteById(Guid id)
        {
            _mainDbContext.Remove(GetNoteById(id));
            _mainDbContext.SaveChanges();
        }

        public IReadOnlyCollection<Note> GetAllNotes()
        {
            return _mainDbContext
                .Notes
                .ToList();
        }

        public Note GetNoteById(Guid id)
        {
            return _mainDbContext
                .Notes
                .Single(n => n.Id == id);
        }
    }
}
