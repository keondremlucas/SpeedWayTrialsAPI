using System;
using System.ComponentModel.DataAnnotations;
namespace Web
{
    public class RacecarDto
    {
        [Required]
        public string Nickname {get; set;}
        [Required]
        public  CarModel Model {get; set;}
        [Required]
        public string Status {get; set;}

        [Required]
        public int TopSpeed {get; set;}

        [Required]
        public CarType Type {get; set;}
    }

    
}