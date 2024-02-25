using Domain.Common;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BabyBookWeek : BaseEntity
    {
        public uint BabyBookId { get; set; }
        public uint BabyBookTrimester {  get; set; }
        public uint BabyBookMonth { get; set; }
        public Week Week { get; set; }
        public IList<Journal> Journals { get; set; }
    }
}
