using Domain.Common;

namespace Domain.Entities
{
    public class PatientContact : BaseEntity
    {
        public uint PatientId { get; set; } = default!;
        public string? Mobile {  get; set; }
        public string? Email { get; set; }
        public bool IsDeleted { get; set; }
    }
}
