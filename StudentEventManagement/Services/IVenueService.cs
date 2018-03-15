using StudentEventManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentEventManagement.Services
{
    public interface IVenueService
    {
        IEnumerable<Venue> GetAll();
        Venue GetById(int id);
        void Create(Venue venue);
    }
}