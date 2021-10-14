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
        private Database _db;
        private IWebRepository _repo;

        // public WebRepositoryTest()
        // {
        //     var conn = new SqliteConnection("DataSource=:memory:");
        //     conn.Open();
        //     var options = new DbContextOptionsBuilder<Database>().UseSqlite(conn).Options;
        //     _db = new Database(options);
        //     _db.Database.EnsureDeleted();
        //     _db.Database.EnsureCreated();
        //     _repo = new WebRepository(_db);
        // }

        // [Fact]
        // public async Task ShouldAddDriverToDatabase()
        // {
        //     DriverDto DriverDto = new() { FirstName = "Ricky", LastName = "Bobby", Age = 30, Nickname = "LaFlame"};
        //     Driver driver = new Driver(DriverDto);
        //     await _repo.AddDriverAsync(driver);
        //     await _repo.SaveAsync();
        //     _db.Drivers.Count().Should().Be(1);
        // }
        // [Fact]
        // public async Task ShouldGetDriverFromDatabase()
        // {   
        //     DriverDto DriverDto = new() {FirstName = "Ricky", LastName = "Bobby", Age = 30, Nickname = "LaFlame"};
        //     Driver driver = new Driver(DriverDto);
        //     await _repo.AddDriverAsync(driver);
        //     await _repo.SaveAsync();
        //     var drivers = await _repo.GetDriverAsync(driver.Id);
        //     drivers.FirstName.Should().Be("Ricky");
        // }


        // [Fact]
        // public async Task ShouldGetAllDrivers()
        // {
        //     DriverDto DriverDto = new() { FirstName = "Ricky", LastName = "Bobby", Age = 30, Nickname = "LaFlame"};
        //     DriverDto DriverDto2 = new() { FirstName = "Tricky", LastName = "Bobby", Age = 30, Nickname = "LaFlame"};
        //     Driver driver = new Driver(DriverDto);
        //     Driver driver2 = new Driver(DriverDto2);
        //     await _repo.AddDriverAsync(driver);
        //     await _repo.AddDriverAsync(driver2);
        //     var drivers = await _repo.GetDriversAsync();
        //     await _repo.SaveAsync();
        //     drivers.Count().Should().Be(2);
        // }

        // [Fact]
        // public async Task ShouldGetDriverByFirstName()
        // {
        //     DriverDto DriverDto = new() { FirstName = "Ricky", LastName = "Bobby", Age = 30, Nickname = "LaFlame"};
        //     DriverDto DriverDto2 = new() { FirstName = "Tricky", LastName = "Bobby", Age = 30, Nickname = "LaFlame"};
        //     Driver driver = new Driver(DriverDto);
        //     Driver driver2 = new Driver(DriverDto2);
        //     await _repo.AddDriverAsync(driver);
        //     await _repo.AddDriverAsync(driver2);
        //     await _repo.SaveAsync();
        //     var drivers = await _repo.SearchDriversByFirstName("Ricky");
        //     drivers.Count().Should().Be(1);
        //     drivers.First().FirstName.Should().Be("Ricky");
        // }

        // [Fact]
        // public async Task ShouldGetDriverByLastName()
        // {
        //     DriverDto DriverDto = new() { FirstName = "Ricky", LastName = "Bobby", Age = 30, Nickname = "LaFlame"};
        //     DriverDto DriverDto2 = new() { FirstName = "Tricky", LastName = "Bobby", Age = 30, Nickname = "LaFlame"};
        //     Driver driver = new Driver(DriverDto);
        //     Driver driver2 = new Driver(DriverDto2);
        //     await _repo.AddDriverAsync(driver);
        //     await _repo.AddDriverAsync(driver2);
        //     await _repo.SaveAsync();
        //     var drivers = await _repo.SearchDriversByLastName("Bobby");
        //     drivers.ToList().Count().Should().Be(2);
        //     drivers.ToList()[1].FirstName.Should().Be("Tricky");
        // }

        // [Fact]
        // public async Task ShouldGetDriverByNickname()
        // {
        //     DriverDto DriverDto = new() { FirstName = "Ricky", LastName = "Bobby", Age = 30, Nickname = "LaFlame"};
        //     DriverDto DriverDto2 = new() { FirstName = "Tricky", LastName = "Bobby", Age = 30, Nickname = "LaAqua"};
        //     Driver driver = new Driver(DriverDto);
        //     Driver driver2 = new Driver(DriverDto2);
        //     await _repo.AddDriverAsync(driver);
        //     await _repo.AddDriverAsync(driver2);
        //     await _repo.SaveAsync();
        //     var drivers = await _repo.SearchDriversByNickname("LaFlame");
        //     drivers.ToList().Count().Should().Be(1);
        //     drivers.ToList()[0].FirstName.Should().Be("Ricky");
        // }


    }
}
