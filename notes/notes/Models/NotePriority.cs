using notes.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notes.Models
{
    public class NotePriority
    {
        /// <summary>
        /// Priority level
        /// </summary>
        public NotePriorityEnum PriorityLevel { get; set; }

        /// <summary>
        /// Priority description
        /// </summary>
        public string Description { get; set; }
    }
}
