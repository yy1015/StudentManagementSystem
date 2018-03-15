using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentEventManagement.Mappers;
using StudentEventManagement.Models;
using StudentEventManagement.Models.Entities;
using StudentEventManagement.Repositories;

namespace StudentEventManagement.Services
{
    public class VenueService : IVenueService
    {
        private readonly IVenueRepository _venueRepository;

        public VenueService(IVenueRepository venueRepository)
        {
            _venueRepository = venueRepository;
        }

        public IEnumerable<Venue> GetAll()
        {
            var allEntities = _venueRepository.GetAll();
            var result = new List<Venue>();
            foreach (var entity in allEntities)
            {
                var venueVm = VenueMapper.FromEntity(entity);
                result.Add(venueVm);
            }
            return result;
        }

        public Venue GetById(int id)
        {
            var entity = _venueRepository.Get(id);

            return VenueMapper.FromEntity(entity);
        }

        public void Create(Venue venue)
        {
            var entity = new VenueEntity();
            VenueMapper.ToEntity(venue, entity);
            _venueRepository.Create(entity);
            venue.Id = entity.Id;

        }
    }
}