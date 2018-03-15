using StudentEventManagement.Models;
using StudentEventManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentEventManagement.Mappers
{
    public static class StudentEventMapper
    {
        public static StudentEvent FromEntity(StudentEventEntity entity)
        {
            return new StudentEvent
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Maximum = entity.Maximum,
                Venue = VenueMapper.FromEntity(entity.Venue)
            };
        }

        public static void ToEntity(StudentEvent vm, StudentEventEntity entity)
        {
            entity.Name = vm.Name;
            entity.Description = vm.Description;
            entity.StartDate = vm.StartDate;
            entity.EndDate = vm.EndDate;
            entity.Maximum = vm.Maximum;
            entity.VenueId = vm.Venue.Id;
        }
    }
}