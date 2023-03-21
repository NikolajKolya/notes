using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notes.Models
{
    /// <summary>
    /// Note at service level
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Note Id
        /// </summary>
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
