using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using StudentEventManagement.Models.Entities;

namespace StudentEventManagement.Repositories
{
    public class StudentEventRepository : 
        RepositoryBase<StudentEventEntity>, IStudentEventRepository
    {
        public StudentEventRepository(ApplicationDbContext context) 
            : base(context)
        {
        }
    }
}