using notes.Mappers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notes.Mappers.Implementations
{
    public class NotesMapper : INotesMapper
    {
        public IReadOnlyCollection<Models.Note> Map(IEnumerable<DAO.Models.Note> notes)
        {
            if (notes == null)
            {
                return null;
            }

            return notes.Select(n => Map(n)).ToList();
        }

        public Models.Note Map(DAO.Models.Note note)
        {
            if (note == null)
            {
                return null;
            }

            return new Models.Note()
            {
                Id = note.Id,
                Name = note.Name,
                Content = note.Content,
                Timestamp = note.Timestamp,
                Priority = note.Priority
            };
        }

        public DAO.Models.Note Map(Models.Note note)
        {
            if (note == null)
            {
                return null;
            }

            return new DAO.Models.Note()
            {
                Id = note.Id,
                Name = note.Name,
                Content = note.Content,
                Timestamp = note.Timestamp,
                Priority = note.Priority
            };
        }

        public IReadOnlyCollection<DAO.Models.Note> Map(IEnumerable<Models.Note> notes)
        {
            if (notes == null)
            {
                return null;
            }

            return notes.Select(n => Map(n)).ToList();
        }
    }
}
