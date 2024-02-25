
using Domain.Common;

namespace Domain.Entities
{
    public class PatientBabybook : BaseEntity
    {
        public uint PatientId { get; set; } = default!;
        public string? Title { get; set; }
        public DateTime? CreatedDate { get; set; }
        public IList<BabyBook> BabyBook { get; set; }
        
    }
}
