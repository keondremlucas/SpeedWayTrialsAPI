using System;
using Web;
using Xunit;
using FluentAssertions;
using System.ComponentModel.DataAnnotations;
namespace test
{
    public class RaceDtoTest
    {
         [Fact]
         public void ShouldCreateRaceFromDto()
        {   

            RaceDto dto = new RaceDto() {Name = "GrandPrix", Category = (RaceCategory)0 , Date = DateTime.Parse("5/1/2021"), BestTime = TimeSpan.Parse("5.8:32:16")};
            var context = new ValidationContext(dto);
            Action act = () => Validator.ValidateObject(dto, context, true);
            act.Should().NotThrow();
        }
        [Fact]
         public void ShouldNotCreateRaceFromDtoName()
        {   

            RaceDto dto = new RaceDto() {Name = "GR", Category = (RaceCategory)0 , Date = DateTime.Parse("5/1/2021"), BestTime = TimeSpan.Parse("5.8:32:16")};
            var context = new ValidationContext(dto);
            Action act = () => Validator.ValidateObject(dto, context, true);
            act.Should().Throw<ValidationException>().Where(e => e.Message.Contains("minimum length of '3'."));
        }

        [Fact]
         public void ShouldNotCreateRaceFromDtoCategory()
        {   

            RaceDto dto = new RaceDto() {Name = "GrandPrix", Category = (RaceCategory)9 , Date = DateTime.Parse("5/1/2021"), BestTime = TimeSpan.Parse("5.8:32:16")};
            var context = new ValidationContext(dto);
            Action act = () => Validator.ValidateObject(dto, context, true);
            act.Should().Throw<ValidationException>().Where(e => e.Message.Contains("invalid"));
        }

        [Fact]
         public void ShouldNotCreateRaceFromDtoDate()
        {   
        
            RaceDto dto = new RaceDto() {Name = "GrandPrix", Category = (RaceCategory)4 , Date = null  , BestTime = TimeSpan.Parse("5.8:32:16")};
            var context = new ValidationContext(dto);
            Action act = () => Validator.ValidateObject(dto, context, true);
            act.Should().Throw<ValidationException>().Where(e => e.Message.Contains("required"));
        }

        [Fact]
         public void ShouldNotCreateRaceFromDtoTime()
        {   
        
            RaceDto dto = new RaceDto() {Name = "GrandPrix", Category = (RaceCategory)4 , Date = DateTime.Parse("5/1/2021")  , BestTime = null};
            var context = new ValidationContext(dto);
            Action act = () => Validator.ValidateObject(dto, context, true);
            act.Should().Throw<ValidationException>().Where(e => e.Message.Contains("required"));
        }
    }
}