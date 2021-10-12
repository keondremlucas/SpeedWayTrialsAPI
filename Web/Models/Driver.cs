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
        public List<Race> RacesWon {get; set;} = new List<Race>();
        public List<Race> RacesLost {get; set;} = new List<Race>();
              
    }
}