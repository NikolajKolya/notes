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
        private List<Note> _notes= new List<Note>();

        public Note Add(string name, string content)
        {
            var note = new Note()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Content = content,
                Timestamp= DateTime.Now
            };

            _notes.Add(note);

            return note;
        }

        public Note Get(Guid noteId)
        {
            return _notes
                .SingleOrDefault(n => n.Id == noteId);
        }
    }
}
