using System;
using System.Collections.Generic;
namespace Web
{
    public class Driver
    {
        public Guid Id {get; set;}

        public string FirstName {get; set;}
        public string LastName {get; set;}
        public int Age {get; set;}
        public string Nickname {get; set;}
        public List<Racecar> Cars {get; set;} = new List<Racecar>();
        public List<Races> RacesWon {get; set;} = new List<Races>();
        public List<Races> RacesLost {get; set;} = new List<Races>();
              
    }
}