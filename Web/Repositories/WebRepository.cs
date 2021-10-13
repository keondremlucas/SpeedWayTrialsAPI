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
    private Database _db;
    public WebRepository(Database db)
    {
      _db=db;
    }
    public async Task AddDriverAsync(Driver driver)
    {
      await _db.AddAsync(driver);
      
    }
    public async Task<Driver> GetDriverAsync(Guid driverId)
    {
      return await _db.Drivers.Where(d=> d.Id == driverId).SingleOrDefaultAsync();
      
    }

    public async Task<IEnumerable<Driver>>  GetDriversAsync()
    {
      return await _db.Drivers.ToListAsync();
      
    }

    public async Task<IEnumerable<Driver>> SearchDriversByFirstName(string name)
    {
        return await _db.Drivers.Where(d=> d.FirstName.Contains(name)).ToListAsync();
    }

    public async Task<IEnumerable<Driver>> SearchDriversByLastName(string name)
    {
        return await _db.Drivers.Where(d=> d.LastName.Contains(name)).ToListAsync();
    }

    public async Task<IEnumerable<Driver>> SearchDriversByNickname(string name)
    {
        return await _db.Drivers.Where(d=> d.Nickname.Contains(name)).ToListAsync();
    }

    public async Task<IEnumerable<Driver>> SearchDriversByCarModel(string model)
    {
        return await _db.Racecars.Where(d=> d.Model.ToString() == (model)).Include(d => d.Owner).Select(d => d.Owner).ToListAsync();
    
    }

    public async Task SaveAsync()
    {
            await _db.SaveChangesAsync();
    }
  }
}