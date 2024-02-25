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
    public class BabyBookWeekConfiguration : IEntityTypeConfiguration<BabyBookWeek>
    {
        public void Configure(EntityTypeBuilder<BabyBookWeek> builder)
        {
            builder.Property(x => x.Week).HasConversion(x => x.ToString(), x => (Week)Enum.Parse(typeof(Week), x));
        }
    }
}
