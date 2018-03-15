using StudentEventManagement.Models;
using StudentEventManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentEventManagement.Mappers
{
    public static class VenueMapper
    {
        public static Venue FromEntity(VenueEntity entity)
        {
            return new Venue
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Notes = entity.Notes
            };
        }

        public static void ToEntity(Venue vm, VenueEntity entity)
        {
            entity.Name = vm.Name;
            entity.Description = vm.Description;
            entity.Notes = vm.Notes;
        }
    }
}