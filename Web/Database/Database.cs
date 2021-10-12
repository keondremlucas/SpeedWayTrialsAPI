using System;
using Microsoft.EntityFrameworkCore;

namespace Web
{
    public class Database : DbContext
    {
        public DbSet<Driver> Drivers {get; set;}
        public DbSet<Race> Races {get; set;}
        public DbSet<Racecar> Racecars {get; set;} 
        public Database(DbContextOptions<Database> options) : base(options) {}  
    }
}