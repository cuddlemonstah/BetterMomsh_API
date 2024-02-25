using Domain.Common;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BabyBookTrimester : BaseEntity
    {
        public uint BabyBookId { get; set; }
        public Trimester Trimester { get; set; }
        public IList<BabyBookMonth> BabyBookMonth { get; set; } = new List<BabyBookMonth>();

    }
}
