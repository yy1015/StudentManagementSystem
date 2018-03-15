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
    public class StudentEventService : IStudentEventService
    {
        private readonly IStudentEventRepository _studentEventRepository;
        public StudentEventService(IStudentEventRepository studentEventRepository)
        {
            _studentEventRepository = studentEventRepository;
        }

        public IEnumerable<StudentEvent> GetAll()
        {
            var entities = _studentEventRepository.GetAll().ToList();
            var result = new List<StudentEvent>();

            foreach (var entity in entities)
            {
                result.Add(StudentEventMapper.FromEntity(entity));
            }
            return result;
        }

        public StudentEvent GetById(int id)
        {
            var entity = _studentEventRepository.Get(id);
            return StudentEventMapper.FromEntity(entity);
        }

        public void Create(StudentEvent studentEvent)
        {
            var entity = new StudentEventEntity();
            StudentEventMapper.ToEntity(studentEvent, entity);
            _studentEventRepository.Create(entity);
            studentEvent.Id = entity.Id;
        }

        public void Update(StudentEvent studentEvent)
        {
            var entity = _studentEventRepository.Get(studentEvent.Id);
            StudentEventMapper.ToEntity(studentEvent, entity);
            _studentEventRepository.Update(entity);
        }

        public void Remove(int id)
        {
            _studentEventRepository.Delete(id);
        }
    }
}