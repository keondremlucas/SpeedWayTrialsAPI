using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Web
{
    public class PopulateDatabase
    {
        public static void Populate(Database db)
        {   
           
            Driver driver2 = new Driver(){ FirstName = "Timmy", LastName = "Lobby", Age = 30, Nickname = "LaAqua"};
            Driver driver = new Driver(){ FirstName = "Ricky", LastName = "Bobby", Age = 30, Nickname = "LaFlame"};
            Racecar racecar = new Racecar(){ Nickname = "Lightning", Model = CarModel.Nissan, Owner = driver, Status = "Available", TopSpeed = 400, Type = CarType.compact};
            Race race = new Race() {Name = "GrandPrix", Category = RaceCategory.tour, Date = DateTime.Parse("5/1/2021"), BestTime = TimeSpan.Parse("5.8:32:16"), Winner = driver, Participants = {driver, driver2}};
            db.Racecars.Add(racecar);
            db.Drivers.Add(driver);
            db.Races.Add(race);
            db.SaveChanges();
            Console.WriteLine($"{driver.Id}");
        }
       
    }
}