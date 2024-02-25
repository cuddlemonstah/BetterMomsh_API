using Domain.Entities;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Configuration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder) {
            builder.Property(x => x.Title).HasConversion(x => x.ToString(), x => (Title)Enum.Parse(typeof(Title), x));
            builder.Property(x => x.MaritalStatus).HasConversion(x => x.ToString(), x => (MaritalStatus)Enum.Parse(typeof(MaritalStatus), x));
        }
    }
}
