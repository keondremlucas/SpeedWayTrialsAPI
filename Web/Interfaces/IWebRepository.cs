using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web
{
  public interface IWebRepository
  {
    Task AddDriverAsync(Driver driver);
    Task<Driver> GetDriverAsync(int driverId);
    Task<IEnumerable<Driver>> GetDriversAsync();
    Task<IEnumerable<Driver>> SearchDriversByName(string name);

    Task<IEnumerable<Driver>> SearchDriversByNickname(string nickname);

    Task<IEnumerable<Driver>> SearchDriversByCarModel(string model);

    Task AddRacecarAsync(Racecar user);
    Task<Racecar> GetRacecarAsync(int userId);
    Task<IEnumerable<Racecar>> GetRacecarsAsync();
    Task<IEnumerable<Racecar>> SearchRacecarsByCarModel(string model);
    Task<IEnumerable<Racecar>> SearchRacecarsByNickname(string nickname);
    Task<IEnumerable<Racecar>> SearchRacecarsByStatus(string status);



    Task AddRaceAsync(Race race);
    Task<Race> GetRaceAsync(int raceId);
    Task<IEnumerable<Race>> GetRacesAsync();
    Task<IEnumerable<Racecar>> SearchRacesByName(string name);
    Task<IEnumerable<Racecar>> SearchRacesByCategory(string category);

    Task<IEnumerable<Racecar>> SearchRacesByDate(string date);

    Task<IEnumerable<Racecar>> SearchRacesByWinner(string name);

    Task<IEnumerable<Racecar>> SearchRacesByParticipants(string name);


    Task SaveAsync();
  }
}