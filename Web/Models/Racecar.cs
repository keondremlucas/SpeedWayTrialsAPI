using System;
using System.Text.Json.Serialization;
namespace Web
{
    public class Racecar
    {
        public Guid Id { get; set; }

        public string Nickname { get; set; }
        public CarModel Model { get; set; }
        [JsonIgnore]
        public Driver Owner { get; set; }
        public CarStatus Status { get; set; }
        public int TopSpeed { get; set; }

        public CarType Type { get; set; }
        public Racecar()
        {

        }
        public Racecar(RacecarDto racecardto)
        {
            Id = Guid.NewGuid();
            Nickname = racecardto.Nickname;
            Model = racecardto.Model;
            TopSpeed = racecardto.TopSpeed;
            Type = racecardto.Type;
        }


    }
}