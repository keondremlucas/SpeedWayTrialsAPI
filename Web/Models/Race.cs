using System;
using System.Collections.Generic;
namespace Web
{
    public class Race
    {
        public Guid Id {get; set;}

        public string Name {get; set;}
        public RaceCategory Category {get; set;}
        public DateTime? Date {get; set;}
        public TimeSpan? BestTime {get; set;}
        public Driver Winner {get; set;}
        public List<Driver> Participants {get; set;} = new List<Driver>();
        public Race()
        {

        }
        public Race(RaceDto racedto)
        {   
            Id = new();
            Name =racedto.Name;
            Category =racedto.Category;
            Date = racedto.Date;
            BestTime =racedto.BestTime;
        } 
       
              
    }
    
}