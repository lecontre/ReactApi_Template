using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        //Generates a Table call Activities for our Activity Object
        public DbSet<Activity> Activities { get; set; }
    }
}
