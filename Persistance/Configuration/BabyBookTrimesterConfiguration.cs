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
    public class BabyBookTrimesterConfiguration : IEntityTypeConfiguration<BabyBookTrimester>
    {
        public void Configure(EntityTypeBuilder<BabyBookTrimester> builder) {
            builder.Property(x => x.Trimester).HasConversion(x => x.ToString(), x => (Trimester)Enum.Parse(typeof(Trimester), x));
         
        }
    }
}
