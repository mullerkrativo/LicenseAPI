using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Reliance.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliance.Data
{
    public class RelianceDBContext : IdentityDbContext<ApplicationUser>
    {
        public RelianceDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Licensetable> Licensetables { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
