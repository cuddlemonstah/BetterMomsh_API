using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PatientContact.Response
{
    public class PatientContactResponse : BaseEntityResponse
    {
        public uint patientId { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
    }
}
