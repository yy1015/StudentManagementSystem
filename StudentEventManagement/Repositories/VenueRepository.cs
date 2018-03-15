using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using StudentEventManagement.Models.Entities;

namespace StudentEventManagement.Repositories
{
    public class VenueRepository : RepositoryBase<VenueEntity>, IVenueRepository
    {
        public VenueRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}