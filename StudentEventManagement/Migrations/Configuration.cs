namespace StudentEventManagement.Migrations
{
    using StudentEventManagement.Models.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentEventManagement.Models.Entities.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StudentEventManagement.Models.Entities.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (!context.Venues.Any())
            {
                context.Venues.AddRange(new List<VenueEntity> {
                    new VenueEntity {
                        Id = 1,
                        Name = "Building 101, room 2.201",
                        Description = "This is a classroom which can have 30 students in it. ",
                        Notes = "This room is under renovation between 02/03/2018 and 15/04/2018. Please make sure you don't come to this venue during this period."},
                    new VenueEntity {
                        Id = 2,
                        Name = "Building 111, room 3.322",
                        Description = "This is a classroom which can have 20 students in it. "
                    },
                    new VenueEntity {
                        Id = 3,
                        Name = "Cafeteria",
                        Description = "This is a uni mean restaurant. There is a planty of foods in it."
                    },
                    new VenueEntity {
                        Id = 4,
                        Name = "Footy Ground",
                        Description = "This is the Footy Ground the students can enjoy their sports here.",
                        Notes = "There is a footy match on every Saturday morning from 9am to 11am. Please make sure this is available for the footy players."
                    }
                });
            }

            if (!context.StudentEvents.Any())
            {
                context.StudentEvents.AddRange(
                    new List<StudentEventEntity>
                    {
                        new StudentEventEntity
                        {
                            Id = 1,
                            Name = "Student Movie Night",
                            Description = "Please come to our student movie night. We will be watching the latest and most popular movie this night. You will meet a lot of students and you can make friends in the event. Don't miss out!",
                            VenueId = 1,
                            StartDate = new DateTime(2018, 3, 8),
                            EndDate = new DateTime(2018, 3, 8),
                            Maximum = 25
                        },
                        new StudentEventEntity
                        {
                            Id = 2,
                            Name = "Student Gaming Session",
                            Description = "We are playing games together. You can choose computer games, Play Station 4 games, XBox One games, even Nitendon Switch games. Please come and enjoy.",
                            VenueId = 2,
                            StartDate = new DateTime(2018, 3, 15),
                            EndDate = new DateTime(2018, 3, 15),
                            Maximum = 20
                        },
                        new StudentEventEntity
                        {
                            Id = 3,
                            Name = "Multi-calture Food Sharing",
                            Description = "Please bring a dish of your calture. We are sharing food in the Cafe. You will enjoy different types of food from around the world. Let's eat!",
                            VenueId = 3,
                            StartDate = new DateTime(2018, 2, 10),
                            EndDate = new DateTime(2018, 2, 10),
                            Maximum = 50
                        },
                        new StudentEventEntity
                        {
                            Id = 4,
                            Name = "Student Sports Day",
                            Description = "We are hosting an existing footy game in the footy ground. Please come to play and enjoy the weather outside.",
                            VenueId = 4,
                            StartDate = new DateTime(2018, 4, 11),
                            EndDate = new DateTime(2018, 4, 11),
                            Maximum = 40
                        }
                    }
                );
            }
        }
    }
}
