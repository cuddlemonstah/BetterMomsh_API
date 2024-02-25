using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Journal : BaseEntity
    {
        public uint PatientId { get; set; } = default!;
        public uint BabyBookId { get; set; } = default!;
        public uint BabyBookWeekId { get; set; } = default!;

        public string JournalName { get; set; }
        public string journalEntry { get; set; }
        public byte[] PhotoData { get; set; }

    }
}
