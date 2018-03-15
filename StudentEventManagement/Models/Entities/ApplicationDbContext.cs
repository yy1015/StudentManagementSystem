using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentEventManagement.Models.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<VenueEntity> Venues { get; set; }
        public DbSet<StudentEventEntity> StudentEvents { get; set; }
    }
}