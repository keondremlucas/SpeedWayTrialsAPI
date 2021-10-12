using System;
using System.ComponentModel.DataAnnotations;
namespace Web
{
    public class RacecarDto
    {
        [Required]
        public string Nickname {get; set;}
        [Required]
        [EnumDataType(typeof(CarModel))] 
        public  CarModel Model {get; set;}
        [Required]
        public string Status {get; set;}

        [Required]
        [Range(300,600)]
        public int TopSpeed {get; set;}

        [Required]
        [EnumDataType(typeof(CarType))] 
        public CarType Type {get; set;}
    }

    
}