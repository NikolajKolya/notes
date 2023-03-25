﻿using notes.DAO.Abstract;
using notes.Mappers.Abstract;
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
        private readonly INotesMapper _notesMapper;

        public NotesService(INotesDao notesDao,
            INotesMapper notesMapper)
        {
            _notesDao = notesDao;
            _notesMapper = notesMapper;
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

            return _notesMapper.Map(dbNote);
        }

        public IReadOnlyCollection<Note> GetAllNotes()
        {
            var dbNotes = _notesDao.GetAllNotes();

            return _notesMapper.Map(dbNotes);
        }

        public void Delete(Guid id)
        {
            _notesDao.DeleteNoteById(id);
        }
    }
}
