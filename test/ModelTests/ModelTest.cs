using System;
using Xunit;
using FluentAssertions;
using Web;

namespace test
{
    public class ModelTests
    {
        [Fact]
        public void ShouldCreateADriver()
        {
            Driver driver = new Driver(){ FirstName = "Ricky", LastName = "Bobby", Age = 30, Nickname = "LaFlame"};
            driver.FirstName.Should().Be("Ricky");
            driver.LastName.Should().Be("Bobby");
            driver.Nickname.Should().Be("LaFlame");
            driver.Age.Should().Be(30);
            driver.RacesWon.Should().HaveCount(0);
            driver.RacesLost.Should().HaveCount(0);
            
        }
        [Fact]
        public void ShouldCreateARaceCar()
        {   
            Driver driver = new Driver(){ FirstName = "Ricky", LastName = "Bobby", Age = 30, Nickname = "LaFlame"};
            Racecar racecar = new Racecar(){ Nickname = "Lightning", Model = CarModel.Nissan, Owner = driver, Status = "Available", TopSpeed = 400, Type = CarType.compact};
            racecar.Nickname.Should().Be("Lightning");
            racecar.Model.Should().Be(CarModel.Nissan);
            racecar.Owner.Should().Be(driver);
            racecar.Status.Should().Be("Available");
            racecar.TopSpeed.Should().Be(400);;
          
            
        }

         [Fact]
        public void ShouldCreateARace()
        {   
            Driver driver = new Driver(){ FirstName = "Ricky", LastName = "Bobby", Age = 30, Nickname = "LaFlame"};
            Driver driver2 = new Driver(){ FirstName = "Ricky", LastName = "Lobby", Age = 30, Nickname = "LaFlame"};
            Race race = new Race() {Name = "GrandPrix", Category = RaceCategory.tour, Date = DateTime.Parse("5/1/2021"), BestTime = TimeSpan.Parse("5.8:32:16"), Winner = driver, Participants = {driver2}};
            race.Name.Should().Be("GrandPrix");
            race.Category.Should().Be(RaceCategory.tour);
            race.Date.Should().Be(DateTime.Parse("5/1/2021"));
            race.BestTime.Should().Be(TimeSpan.Parse("5.8:32:16"));
            race.Winner.Should().Be(driver);
            race.Participants.Should().HaveCount(1);
            
        }
    }
}
