using Microsoft.EntityFrameworkCore;
using notes.DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notes.DAO
{
    /// <summary>
    /// Контекст для работы с базой данных
    /// </summary>
    public class MainDbContext : DbContext
    {
        private string _dbPath;

        public MainDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            _dbPath = System.IO.Path.Join(path, "notes.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={ _dbPath }");
        }

        /// <summary>
        /// Заметки в базе данных
        /// </summary>
        public DbSet<Note> Notes { get; set; }
    }
}
