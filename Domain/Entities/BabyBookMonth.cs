using Domain.Common;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BabyBookMonth : BaseEntity
    {
        public Guid BabyBookId { get; set; }
        public uint BabyBookTrimester {  get; set; }

        public Month Month { get; set; }
        public IList<BabyBookWeek> Weeks { get; set; }

    }
}
