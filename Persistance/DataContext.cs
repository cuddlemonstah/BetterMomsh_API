using Domain.Common;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Identity;
using Domain.Entities;

namespace Persistance
{
    public class DataContext : IdentityDbContext<
    User,
    Role,
    string,
    IdentityUserClaim<string>,
    UserRole, IdentityUserLogin<string>,
    IdentityRoleClaim<string>,
    IdentityUserToken<string>>
    {
        public DbSet<Patient> Patients { get; set; } = default!;
        public DbSet<PatientContact> PatientContacts { get; set; } = default!;
        public DbSet<PatientJournal> PatientJournals { get; set; } = default!;
        public DbSet<PatientBabybook> PatientBabybooks { get; set; } = default!;
        public DbSet<BabyBook> BabyBooks { get; set; } = default!;
        public DbSet<BabyBookTrimester> BabyBookTrimesters { get; set; } = default!;
        public DbSet<BabyBookMonth> BabyBookMonths { get; set; } = default!;
        public DbSet<BabyBookWeek> BabyBookWeeks { get; set; } = default!;

        public DataContext() : base()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var table = entityType.GetTableName();
                if (table!.StartsWith("AspNet"))
                {

                    entityType.SetTableName(table.Substring(6).Replace(" ", "_"));
                }
            }
        }
    }
}


