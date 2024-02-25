using Application.Common.Models;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PatientProfile.Responses
{
    public class PatientProfileResponse : BaseEntityResponse
    {
        public uint PatientId { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Religion { get; set; }
        public string? Occupation { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
    }
}
