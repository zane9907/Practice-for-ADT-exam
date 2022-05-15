using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH_gyakorlas2
{
    public class PlanningContext : DbContext
    {
        public DbSet<Catering> Caterings { get; set; }

        public PlanningContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies()
                .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Planning.mdf;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Catering c0 = new Catering() { Id = 1, Name = "Cég1", PricePerPerson = 1000 };
            Catering c1 = new Catering() { Id = 2, Name = "Cég2", PricePerPerson = 2000 };
            Catering c2 = new Catering() { Id = 3, Name = "Cég3", PricePerPerson = 3000 };
            Catering c3 = new Catering() { Id = 4, Name = "Cég4", PricePerPerson = 4000 };
        }
    }
}
