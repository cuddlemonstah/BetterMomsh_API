using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BabyBook : BaseEntity
    {
        public uint PatientId { get; set; }
        public string Title { get; set; }
        public IList<BabyBookTrimester> BabyBookTrimesters { get; set; } = default!;
    }
}
