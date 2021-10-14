using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Web
{
    public class Driver
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        
        public string Nickname { get; set; }
        [JsonIgnore]
        [InverseProperty("Owner")]
        public List<Racecar> Cars {get; set;} = new();
        [JsonIgnore]
        [InverseProperty("Winner")]
        public List<Race> RacesWon { get; set; } = new();
        [JsonIgnore]
        public List<Race> RacesLost {get; set;} = new();
        public Driver()
        {

        }
        public Driver(DriverDto driverdto)
        {
            Id = Guid.NewGuid();
            FirstName = driverdto.FirstName;
            LastName = driverdto.LastName;
            Age = driverdto.Age;
            Nickname = driverdto.Nickname;
            RacesWon = new();
            // RacesLost = new();
        }
    }

}