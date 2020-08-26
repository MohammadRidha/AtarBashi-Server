using AtarBashi.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtarBashi.Data.DataBaseContext
{
    public class AtarBashiDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog=AtarBashiDb; Integrated Security=True; MultipleActiveResultSets=True;");

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

    }
}
