using StudentEventManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentEventManagement.Repositories
{
    public interface IStudentEventRepository 
        : IRepositoryBase<StudentEventEntity>
    {
    }
}