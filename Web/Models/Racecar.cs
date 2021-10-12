using System;
namespace Web
{
    public class Racecar
    {
        public Guid Id {get; set;}

        public string Nickname {get; set;}
        public CarModel Model {get; set;}
        public Driver Owner {get; set;}
        public string Status {get; set;}
        public int TopSpeed {get; set;}
        
        public CarType Type {get; set;}
       
              
    }
}