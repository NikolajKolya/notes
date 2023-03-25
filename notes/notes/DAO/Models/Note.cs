using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notes.DAO.Models
{
    /// <summary>
    /// Note at database level
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Note Id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Note Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Note Content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Creation time
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
