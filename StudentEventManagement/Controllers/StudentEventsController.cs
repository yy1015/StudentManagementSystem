using StudentEventManagement.Models;
using StudentEventManagement.Repositories;
using StudentEventManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StudentEventManagement.Controllers
{
    public class StudentEventsController : ApiController
    {
        private readonly IStudentEventService _studentEventService;
        public StudentEventsController(IStudentEventService studentEventService)
        {
            _studentEventService = studentEventService;
        }

        public IHttpActionResult Get()
        {
            return Ok(_studentEventService.GetAll());
        }

        public IHttpActionResult Get(int id)
        {
            var studentEvent = _studentEventService.GetById(id);

            if (studentEvent == null)
            {
                return NotFound();
            }
            return Ok(studentEvent);
        }

        public IHttpActionResult Post([FromBody]StudentEvent studentEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input(s).");
            }
            if (studentEvent.Id > 0)
            {
                return BadRequest("This event cannot be created.");
            }

            try
            {
                _studentEventService.Create(studentEvent);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return Created<StudentEvent>("/api/studentEvnet", studentEvent);
        }

        public IHttpActionResult Put(int id, [FromBody] StudentEvent studentEvent)
        {
            if (id == 0 || id != studentEvent.Id)
            {
                return BadRequest("Invalid input(s)");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input(s)");
            }

            try
            {
                _studentEventService.Update(studentEvent);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                _studentEventService.Remove(id);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            return Ok();
        }
    }
}