using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Web
{
  public class WebRepository : IWebRepository
  {
    // private Database _db;
    // public WebRepository(Database db)
    // {
    //   _db=db;
    // }
    // public async Task AddDriverAsync(Driver driver)
    // {
    //   await _db.AddAsync(driver);
      
    // }
    // public async Task<Driver> GetDriverAsync(Guid driverId)
    // {
    //   return await _db.Drivers.Where(d=> d.Id == driverId).SingleOrDefaultAsync();
      
    // }

    // public async Task<IEnumerable<Driver>>  GetDriversAsync()
    // {
    //   return await _db.Drivers.ToListAsync();
      
    // }

    // public async Task<IEnumerable<Driver>> SearchDriversByFirstName(string name)
    // {
    //     return await _db.Drivers.Where(d=> d.FirstName.Contains(name)).ToListAsync();
    // }

    // public async Task<IEnumerable<Driver>> SearchDriversByLastName(string name)
    // {
    //     return await _db.Drivers.Where(d=> d.LastName.Contains(name)).ToListAsync();
    // }

    // public async Task<IEnumerable<Driver>> SearchDriversByNickname(string name)
    // {
    //     return await _db.Drivers.Where(d=> d.Nickname.Contains(name)).ToListAsync();
    // }

    // public async Task<IEnumerable<Driver>> SearchDriversByCarModel(string model)
    // {
    //     return await _db.Racecars.Where(d=> d.Model.ToString() == (model)).Include(d => d.Owner).Select(d => d.Owner).ToListAsync();
    
    // }
    // public async Task AddRacecarAsync(Racecar racecar)
    // {
    //   await _db.AddAsync(racecar);
      
    // }
    // public async Task<Racecar> GetRacecarAsync(Guid racecarId)
    // {
    //   return await _db.Racecars.Where(r=> r.Id == racecarId).SingleOrDefaultAsync();
      
    // }

    // public async Task<IEnumerable<Racecar>>  GetRacecarsAsync()
    // {
    //   return await _db.Racecars.ToListAsync();
      
    // }

    // public async Task<IEnumerable<Racecar>> SearchRacecarsByCarModel(string model)
    // {
    //      return await _db.Racecars.Where(r=> r.Model.ToString() == (model)).ToListAsync();
    // }

    // public async Task<IEnumerable<Racecar>> SearchRacecarsByNickname(string name)
    // {
    //     return await _db.Racecars.Where(r=> r.Nickname.Contains(name)).ToListAsync();
    // }

    // public async Task<IEnumerable<Racecar>> SearchRacecarsByStatus(string status)
    // {
    //     return await _db.Racecars.Where(r=> r.Status == status).ToListAsync();
    // }

    // public async Task AddRaceAsync(Race race)
    // {
    //   await _db.AddAsync(race);
      
    // }

    // public async Task<Race> GetRaceAsync(Guid raceId)
    // {
    //   return await _db.Races.Where(r=> r.Id == raceId).FirstOrDefaultAsync();
      
    // }

    // public async Task<IEnumerable<Race>> GetRacesAsync()
    // {
    //   return await _db.Races.ToListAsync();
      
    // }

    // public async Task<IEnumerable<Race>> SearchRacesByName(string name)
    // {
    //      return await _db.Races.Where(r=> r.Name.Contains(name)).ToListAsync();
    // }

    // public async Task<IEnumerable<Race>> SearchRacesByCategory(string category)
    // {
    //      return await _db.Races.Where(r=> r.Category.ToString() == (category)).ToListAsync();
    // }

    // public async Task<IEnumerable<Race>> SearchRacesByDate(string date)
    // {
    //      return await _db.Races.Where(r=> r.Date.ToString().Contains(date)).ToListAsync();
    // }

    // public async Task<IEnumerable<Race>> SearchRacesByWinner(string name)
    // {
    //     return await _db.Races.Where(r => r.Winner == name).ToListAsync();
    // } 

    // public async Task<IEnumerable<Race>>  SearchRacesByParticipants(Guid driverId)
    // {   
      
    //     var Races =  await _db.Races.Include(p => p.Participants).ToListAsync();
    //     return Races.Where(r => r.Participants.Contains(driverId));
      
    // } 



    

    // public async Task SaveAsync()
    // {
    //         await _db.SaveChangesAsync();
    // }
  }
}