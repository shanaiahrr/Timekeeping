using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infra
{
    public class TimeKeepingDBContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Roles> Role { get; set; }
        public DbSet<Rights> Right { get; set; }
        public DbSet<RoleRights> RoleRight { get; set; }
        public DbSet<TypeofRights> TypeofRight { get; set; }

        public DbSet<Department> Department { get; set; }
        public DbSet<Shifts> Shift { get; set; }
        public DbSet<ActivityType> ActivityType { get; set; }
        public TimeKeepingDBContext(DbContextOptions<TimeKeepingDBContext> options) : base(options)
        {

        }
        public TimeKeepingDBContext()
        {

        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=.;Database=TimeTracking;Integrated Security=true;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
