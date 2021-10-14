using System;
using Xunit;
using Web;
using FluentAssertions;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace test
{
    public class WebRepositoryTest
    {
        DriverDto DriverDto = new() { FirstName = "Ricky", LastName = "Bobby", Age = 30, Nickname = "LaFlame" };
        DriverDto DriverDto2 = new() { FirstName = "Tricky", LastName = "Bobby", Age = 30, Nickname = "LaAqua" };
        Driver driver;
        Driver driver2;
        Racecar racecar;
        Racecar racecar2;
        Race race;
        Race race2;

        private Database _db;
        private IWebRepository _repo;

        public WebRepositoryTest()
        {
            var conn = new SqliteConnection("DataSource=:memory:");
            conn.Open();
            var options = new DbContextOptionsBuilder<Database>().UseSqlite(conn).Options;
            _db = new Database(options);
            _db.Database.EnsureDeleted();
            _db.Database.EnsureCreated();
            _repo = new WebRepository(_db);

            driver = new Driver(DriverDto);
            driver2 = new Driver(DriverDto2);
            racecar = new Racecar() { Nickname = "Lightning", Model = CarModel.Nissan, Owner = driver, Status = 0, TopSpeed = 400, Type = CarType.compact };
            racecar2 = new Racecar() { Nickname = "Thunder", Model = CarModel.Jaguar, Owner = driver2, Status = 0, TopSpeed = 350, Type = CarType.compact };
            race = new Race() { Name = "GrandPrix", Category = RaceCategory.tour, Date = DateTime.Parse("5/1/2021"), BestTime = TimeSpan.Parse("5.8:32:16"), Winner = driver, Participants = { driver, driver2 } };
            race2 = new Race() { Name = "SomeRace", Category = RaceCategory.rally, Date = DateTime.Parse("5/10/2021"), BestTime = TimeSpan.Parse("4.2:10:12"), Winner = driver2, Participants = { driver, driver2 } };
        }

        [Fact]
        public async Task ShouldAddDriverToDatabase()
        {
            await _repo.AddDriverAsync(driver);
            await _repo.SaveAsync();
            _db.Drivers.Count().Should().Be(1);
        }
        [Fact]
        public async Task ShouldGetDriverFromDatabase()
        {
            await _repo.AddDriverAsync(driver);
            await _repo.SaveAsync();
            var drivers = await _repo.GetDriverAsync(driver.Id);
            drivers.FirstName.Should().Be("Ricky");
        }


        [Fact]
        public async Task ShouldGetAllDrivers()
        {
            await _repo.AddDriverAsync(driver);
            await _repo.AddDriverAsync(driver2);
            await _repo.SaveAsync();
            var drivers = await _repo.GetDriversAsync();
            drivers.Count().Should().Be(2);
        }

        [Fact]
        public async Task ShouldGetDriverByFirstName()
        {
            await _repo.AddDriverAsync(driver);
            await _repo.AddDriverAsync(driver2);
            await _repo.SaveAsync();
            var drivers = await _repo.SearchDriversByFirstName("Ricky");
            drivers.Count().Should().Be(1);
            drivers.First().FirstName.Should().Be("Ricky");
        }

        [Fact]
        public async Task ShouldGetDriverByLastName()
        {
            await _repo.AddDriverAsync(driver);
            await _repo.AddDriverAsync(driver2);
            await _repo.SaveAsync();
            var drivers = await _repo.SearchDriversByLastName("Bobby");
            drivers.ToList().Count().Should().Be(2);
            drivers.ToList()[1].FirstName.Should().Be("Tricky");
        }

        [Fact]
        public async Task ShouldGetDriverByNickname()
        {
            await _repo.AddDriverAsync(driver);
            await _repo.AddDriverAsync(driver2);
            await _repo.SaveAsync();
            var drivers = await _repo.SearchDriversByNickname("LaFlame");
            drivers.ToList().Count().Should().Be(1);
            drivers.ToList()[0].FirstName.Should().Be("Ricky");
        }

        [Fact]
        public async Task ShouldAddRacecarToDatabase()
        {
            await _repo.AddRacecarAsync(racecar);
            await _repo.SaveAsync();
            _db.Racecars.Count().Should().Be(1);
        }
        [Fact]
        public async Task ShouldGetRacecarFromDatabase()
        {
            await _repo.AddRacecarAsync(racecar);
            await _repo.SaveAsync();
            var racecars = await _repo.GetRacecarAsync(racecar.Id);
            racecars.Nickname.Should().Be("Lightning");
        }
        [Fact]
        public async Task ShouldGetRacecarsFromDatabase()
        {
            await _repo.AddRacecarAsync(racecar);
            await _repo.AddRacecarAsync(racecar2);
            await _repo.SaveAsync();
            var racecars = await _repo.GetRacecarsAsync();
            racecars.Count().Should().Be(2);
            racecars.ToList()[0].Nickname.Should().Be("Lightning");
            racecars.ToList()[1].Nickname.Should().Be("Thunder");
        }
        [Fact]
        public async Task ShouldSearchRacecarsByModel()
        {
            await _repo.AddRacecarAsync(racecar);
            await _repo.AddRacecarAsync(racecar2);
            await _repo.SaveAsync();
            var racecars = await _repo.SearchRacecarsByCarModel((CarModel)4);
            racecars.Count().Should().Be(1);
            racecars.ToList()[0].Nickname.Should().Be("Lightning");
        }
        [Fact]
        public async Task ShouldSearchRacecarsByNickname()
        {
            await _repo.AddRacecarAsync(racecar);
            await _repo.AddRacecarAsync(racecar2);
            await _repo.SaveAsync();
            var racecars = await _repo.SearchRacecarsByNickname("Thunder");
            racecars.Count().Should().Be(1);
            racecars.ToList()[0].Nickname.Should().Be("Thunder");
        }
        [Fact]
        public async Task ShouldSearchRacecarsByStatus()
        {
            await _repo.AddRacecarAsync(racecar);
            await _repo.AddRacecarAsync(racecar2);
            await _repo.SaveAsync();
            var racecars = await _repo.SearchRacecarsByStatus((CarStatus)0);
            racecars.Count().Should().Be(2);
            racecars.ToList()[0].Nickname.Should().Be("Lightning");
            racecars.ToList()[1].Nickname.Should().Be("Thunder");
        }

        [Fact]
        public async Task ShouldAddRaceToDatabase()
        {
            await _repo.AddRaceAsync(race);
            await _repo.SaveAsync();
            _db.Races.Count().Should().Be(1);
        }
        [Fact]
        public async Task ShouldGetRaceFromDatabase()
        {
            await _repo.AddRaceAsync(race);
            await _repo.SaveAsync();
            var races = await _repo.GetRaceAsync(race.Id);
            races.Name.Should().Be("GrandPrix");
        }
        [Fact]
        public async Task ShouldGetRacesFromDatabase()
        {
            await _repo.AddRaceAsync(race);
            await _repo.AddRaceAsync(race2);
            await _repo.SaveAsync();
            var races = await _repo.GetRacesAsync();
            races.Count().Should().Be(2);
            races.ToList()[0].Name.Should().Be("GrandPrix");
            races.ToList()[1].Name.Should().Be("SomeRace");
        }
        [Fact]
        public async Task ShouldSearchRacesByName()
        {
            await _repo.AddRaceAsync(race);
            await _repo.AddRaceAsync(race2);
            await _repo.SaveAsync();
            var races = await _repo.SearchRacesByName("GrandPrix");
            races.Count().Should().Be(1);
            races.ToList()[0].Name.Should().Be("GrandPrix");
        }
        [Fact]
        public async Task ShouldSearchRacesByCategory()
        {
            await _repo.AddRaceAsync(race);
            await _repo.AddRaceAsync(race2);
            await _repo.SaveAsync();
            var races = await _repo.SearchRacesByCategory(RaceCategory.tour);
            races.Count().Should().Be(1);
            races.ToList()[0].Name.Should().Be("GrandPrix");
        }
        [Fact]
        public async Task ShouldSearchRacesByDate()
        {
            await _repo.AddRaceAsync(race);
            await _repo.AddRaceAsync(race2);
            await _repo.SaveAsync();
            var races = await _repo.SearchRacesByDate("5/1/2021");
            races.Count().Should().Be(1);
            races.ToList()[0].Name.Should().Be("GrandPrix");
        }
        [Fact]
        public async Task ShouldSearchRacesByWinner()
        {
            await _repo.AddRaceAsync(race);
            await _repo.AddRaceAsync(race2);
            await _repo.SaveAsync();
            var races = await _repo.SearchRacesByWinner(driver);
            races.Count().Should().Be(1);
            races.ToList()[0].Name.Should().Be("GrandPrix");
        }
        [Fact]
        public async Task ShouldSearchRacesByParticipant()
        {
            await _repo.AddRaceAsync(race);
            await _repo.AddRaceAsync(race2);
            await _repo.SaveAsync();
            var races = await _repo.SearchRacesByParticipant(driver2);
            races.Count().Should().Be(2);
            races.ToList()[0].Name.Should().Be("GrandPrix");
            races.ToList()[1].Name.Should().Be("SomeRace");
        }
    }
}
