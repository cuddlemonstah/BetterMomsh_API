using Domain.Common;
using Domain.Enum;

namespace Domain.Entities
{
    public class Patient : BaseEntity
    {
        public Patient() { 
            isDeleted = false;
        }

        public Title Title { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; } 
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Religion { get; set; }
        public string? Occupation { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public bool isDeleted { get; set; }
        public PatientContact PatientContact { get; set; } = default!;
        public List<PatientBabybook> PatientBabybook { get; set; } = default!;

    }
}
