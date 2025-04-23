using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Services.EmployeProfile.BloodGroups.Core.DataModel;
using Services.EmployeProfile.EmployeProfiles.Core.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EmployeProfile.EmployeDBContext
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext>options):base(options)
        {

        }
        public DbSet<EmployeeProfile> EmployeeProfiles { get; set; }
        public DbSet<BloodGroup> BloodGroups { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("ep");
            modelBuilder.Entity<EmployeeProfile>(entity =>
            {
                entity.ToTable("EmployeeProfile");
                entity.HasKey(e => e.EmployeeId);
                entity.Property(e => e.EmployeeName).HasMaxLength(50);
            });
            modelBuilder.HasDefaultSchema("bg");
            modelBuilder.Entity<BloodGroup>(entity =>
            {
                entity.ToTable("BloodGroup");
                entity.HasKey(e => e.BloodGrpoupId);
                entity.Property(e => e.BloodGroupName).HasMaxLength(10);
            });
        }

        
    }
}
