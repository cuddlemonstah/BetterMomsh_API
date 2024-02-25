using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PatientContact.Request
{
    public class PatientContactRequest
    {
        public uint Id { get; set; }
        public uint patientId { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
    }
}
