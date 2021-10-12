using System;
using System.ComponentModel.DataAnnotations;
namespace Web
{
    public class RaceDto
    {
        [Required]
        [MinLength(3)]
        public string Name {get; set;}
        [Required]
        [EnumDataType(typeof(RaceCategory))] 
        public  RaceCategory Category {get; set;}
        [Required]
        [DataType(DataType.DateTime)]

        public DateTime? Date {get; set;}

        [Required]
        public TimeSpan? BestTime {get; set;}
    }


    
}