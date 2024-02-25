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
    public class BabyBookMonthConfiguration : IEntityTypeConfiguration<BabyBookMonth>
    {
        public void Configure(EntityTypeBuilder<BabyBookMonth> builder)
        {
            builder.Property(x => x.Month).HasConversion(x => x.ToString(), x => (Month)Enum.Parse(typeof(Month), x));
        }
    }
}
