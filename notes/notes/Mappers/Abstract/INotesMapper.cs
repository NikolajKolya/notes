using notes.Models;
using System.Collections.Generic;

namespace notes.Mappers.Abstract
{
    /// <summary>
    /// Notes mapper
    /// </summary>
    public interface INotesMapper
    {
        IReadOnlyCollection<Note> Map(IEnumerable<DAO.Models.Note> notes);

        Note Map(DAO.Models.Note note);

        DAO.Models.Note Map(Note note);

        IReadOnlyCollection<DAO.Models.Note> Map(IEnumerable<Note> notes);
    }
}
