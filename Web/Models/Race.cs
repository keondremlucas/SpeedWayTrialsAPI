using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Web
{
    public class Race
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public RaceCategory Category { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? BestTime { get; set; }
        [JsonIgnore]
        public Driver Winner { get; set; }

        [JsonIgnore]
        public List<Driver> Participants { get; set; } = new();
        public Race()
        {

        }
        public Race(RaceDto racedto)
        {
            Id = Guid.NewGuid();
            Name = racedto.Name;
            Category = racedto.Category;
            Date = racedto.Date;
            BestTime = racedto.BestTime;
            Participants = new();
        }


    }

}