using System;
using System.ComponentModel.DataAnnotations;
namespace Web
{
    public class DriverDto
    {
        [Required]
        [MinLength(3)]
        public string FirstName {get; set;}
        [Required]
        [MinLength(3)]
        public string LastName {get; set;}
        [Required]
        [Range(18,100)]
        public int Age {get; set;}
        [Required]
        
        public string Nickname {get; set;}

        
    }
}