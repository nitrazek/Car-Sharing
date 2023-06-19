using Moq;
using System.Collections.Generic;
using PawelCarSharing.Repositories;
using PawelCarSharing.Models;
using PawelCarSharing.Data;
using System.Linq;

namespace PawelCarSharing.Tests.Repositories
{
    public class RentalRepositoryTests
    {
        [Fact]
        public void GetAll_ReturnsAllRentals()
        {
            // Arrange
            var dbContextMock = new Mock<ApplicationDbContext>();
            var rentalRepository = new RentalRepository(dbContextMock.Object);

            var rentals = new List<Rental>
            {
                new Rental { Id = 1, StartDate = new DateTime(2023, 1, 1), EndDate = new DateTime(2023, 1, 10), Kilometers = 100, CarId = 1 },
                new Rental { Id = 2, StartDate = new DateTime(2023, 2, 1), EndDate = new DateTime(2023, 2, 10), Kilometers = 200, CarId = 2 },
                new Rental { Id = 3, StartDate = new DateTime(2023, 3, 1), EndDate = new DateTime(2023, 3, 10), Kilometers = 300, CarId = 3 }
            };

            //var rentalsDbSetMock = rentals.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(db => db.Rentals).Returns(rentalsDbSetMock.Object);

            // Act
            var result = rentalRepository.GetAll();

            // Assert
            Assert.Equal(rentals, result);
        }
    }
}