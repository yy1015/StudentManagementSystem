using StudentEventManagement.Models;
using StudentEventManagement.Repositories;
using StudentEventManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentEventManagement.Controllers
{
    public class VenuesController : ApiController
    {
        private readonly IVenueService _venueService;
        public VenuesController(IVenueService venueService)
        {
            _venueService = venueService;
        }

        public IHttpActionResult Get()
        {
            return Ok(_venueService.GetAll());
        }

        public IHttpActionResult Get(int id)
        {
            var venue = _venueService.GetById(id);

            if(venue == null)
            {
                return NotFound();
            }

            return Ok(venue);
        }

        public IHttpActionResult Post([FromBody]Venue venue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input(s).");
            }
            if (venue.Id > 0)
            {
                return BadRequest("This venue cannot be created.");
            }

            try
            {
                _venueService.Create(venue);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return Created<Venue>("/api/venues", venue);
        }
    }
}
