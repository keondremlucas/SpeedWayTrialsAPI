using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web
{
    public interface IWebRepository
    {
        Task AddDriverAsync(Driver driver);
        Task<Driver> GetDriverAsync(Guid driverId);
        Task<IEnumerable<Driver>> GetDriversAsync();
        Task<IEnumerable<Driver>> SearchDriversByFirstName(string name);
        Task<IEnumerable<Driver>> SearchDriversByLastName(string name);

        Task<IEnumerable<Driver>> SearchDriversByNickname(string nickname);

        Task<IEnumerable<Driver>> SearchDriversByCarModel(string model);

        Task AddRacecarAsync(Racecar racecar);
        Task<Racecar> GetRacecarAsync(Guid racecarId);
        Task<IEnumerable<Racecar>> GetRacecarsAsync();
        Task<IEnumerable<Racecar>> SearchRacecarsByCarModel(CarModel model);
        Task<IEnumerable<Racecar>> SearchRacecarsByNickname(string nickname);
        Task<IEnumerable<Racecar>> SearchRacecarsByStatus(CarStatus status);



        Task AddRaceAsync(Race race);
        Task<Race> GetRaceAsync(Guid raceId);
        Task<IEnumerable<Race>> GetRacesAsync();
        Task<IEnumerable<Race>> SearchRacesByName(string name);
        Task<IEnumerable<Race>> SearchRacesByCategory(RaceCategory category);

        Task<IEnumerable<Race>> SearchRacesByDate(string date);

        Task<IEnumerable<Race>> SearchRacesByWinner(Driver driver);

        Task<IEnumerable<Race>> SearchRacesByParticipant(Driver driver);



        Task SaveAsync();
    }
}