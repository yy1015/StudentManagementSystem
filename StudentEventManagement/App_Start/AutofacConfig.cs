using Autofac;
using Autofac.Integration.WebApi;
using StudentEventManagement.Models.Entities;
using StudentEventManagement.Repositories;
using StudentEventManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StudentEventManagement.App_Start
{
    public static class AutofacConfig
    {
        public static void BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            builder.RegisterType<VenueRepository>().As<IVenueRepository>();
            builder.RegisterType<StudentEventRepository>().As<IStudentEventRepository>();

            builder.RegisterType<VenueService>().As<IVenueService>();
            builder.RegisterType<StudentEventService>().As<IStudentEventService>();

            builder.RegisterType<ApplicationDbContext>().As<ApplicationDbContext>();

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver 
                = new AutofacWebApiDependencyResolver(container);
        }
    }
}