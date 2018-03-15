using StudentEventManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentEventManagement.Services
{
    public interface IStudentEventService
    {
        IEnumerable<StudentEvent> GetAll();
        StudentEvent GetById(int id);
        void Create(StudentEvent studentEvent);
        void Update(StudentEvent studentEvent);
        void Remove(int id);
    }
}