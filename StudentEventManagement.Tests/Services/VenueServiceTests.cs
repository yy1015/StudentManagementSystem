using Moq;
using NUnit.Framework;
using StudentEventManagement.Models;
using StudentEventManagement.Models.Entities;
using StudentEventManagement.Repositories;
using StudentEventManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEventManagement.Tests.Services
{
    public class VenueServiceTests
    {
        private VenueService _venueService;
        private Mock<IVenueRepository> _venueRepository;

        [SetUp]
        public void Setup()
        {
            _venueRepository = new Mock<IVenueRepository>();
            _venueService = new VenueService(_venueRepository.Object);
        }

        [Test]
        public void ShouldGetAllVenues()
        {
            // Arrange
            _venueRepository.Setup(repo => repo.GetAll()).Returns(GetAllEntites());
            // Act
            var venues = _venueService.GetAll();
            var firstVenue = venues.First();
            // Assert
            Assert.AreEqual(3, venues.Count());

            Assert.AreEqual(1, firstVenue.Id);
            Assert.AreEqual("Test Venue 1", firstVenue.Name);
        }

        [Test]
        public void ShouldGetOneVenue()
        {
            // Arrange
            var allEntities = GetAllEntites();
            _venueRepository.Setup(repo => repo.Get(3))
                .Returns(allEntities.First(e => e.Id == 3));
            // Act
            var venue = _venueService.GetById(3);
            // Assert
            Assert.AreEqual(3, venue.Id);
            Assert.AreEqual("Test Venue 3", venue.Name);
        }

        [Test]
        public void ShouldCreateNewVenue()
        {
            // Arrange
            _venueRepository.Setup(repo => repo.Create(It.IsAny<VenueEntity>()));
            // Act
            var venueVm = new Venue
            {
                Name = "Test 123",
                Description = "Test 321",
                Notes = "Test 333"
            };
            _venueService.Create(venueVm);
            // Assert
            _venueRepository.Verify(repo => 
            repo.Create(
                It.Is<VenueEntity>(
                e => e.Name == "Test 123" && e.Description == "Test 321" 
                && e.Notes == "Test 333"
                )), Times.Once());
        }

        private IQueryable<VenueEntity> GetAllEntites()
        {
            return new List<VenueEntity>
                {
                    new VenueEntity
                    {
                        Id = 1,
                        Name = "Test Venue 1",
                        Description = "Test Description 1",
                        Notes = "Notes 1"
                    },
                    new VenueEntity
                    {
                        Id = 2,
                        Name = "Test Venue 2",
                        Description = "Test Description 2",
                        Notes = "Notes 2"
                    },
                    new VenueEntity
                    {
                        Id = 3,
                        Name = "Test Venue 3",
                        Description = "Test Description 3",
                        Notes = "Notes 3"
                    }
                }.AsQueryable();
        }
    }

    
}
