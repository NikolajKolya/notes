using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notes.Models
{
    /// <summary>
    /// List item, representing one note
    /// </summary>
    public class NoteItem
    {
        /// <summary>
        /// Note name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Creation time
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Note priority
        /// </summary>
        public string PriorityText { get; set; }

        /// <summary>
        /// Note id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Index in list
        /// </summary>
        public int Index { get; set; }
    }
}
