using System;
using Web;
using Xunit;
using FluentAssertions;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public class RacecarDtoTest
    {
         [Fact]
         public void ShouldCreateRacecarFromDto()
        {   

            RacecarDto dto = new RacecarDto(){ Nickname = "Lightning", Model = CarModel.Nissan, Status = "Available", TopSpeed = 400, Type = CarType.compact};
            var context = new ValidationContext(dto);
            Action act = () => Validator.ValidateObject(dto, context, true);
            act.Should().NotThrow();
        }

         [Fact]
         public void ShouldNotCreateRacecarFromDtoNickname()
        {   

            RacecarDto dto = new RacecarDto(){ Nickname = "", Model = CarModel.Nissan, Status = "Available", TopSpeed = 400, Type = CarType.compact};
            var context = new ValidationContext(dto);
            Action act = () => Validator.ValidateObject(dto, context, true);
            act.Should().Throw<ValidationException>().Where(e => e.Message.Contains("required"));
        }

         [Fact]
         public void ShouldNotCreateRacecarFromDtoModel()
        {   

            RacecarDto dto = new RacecarDto(){ Nickname = "Lightning", Model = (CarModel)9, Status = "Available", TopSpeed = 400, Type = CarType.compact};
            var context = new ValidationContext(dto);
            Action act = () => Validator.ValidateObject(dto, context, true);
            act.Should().Throw<ValidationException>().Where(e => e.Message.Contains("invalid"));
        }
        [Fact]
         public void ShouldNotCreateRacecarFromDtoStatus()
        {   

            RacecarDto dto = new RacecarDto(){ Nickname = "Lightning", Model = (CarModel)5, Status = "", TopSpeed = 400, Type = CarType.compact};
            var context = new ValidationContext(dto);
            Action act = () => Validator.ValidateObject(dto, context, true);
            act.Should().Throw<ValidationException>().Where(e => e.Message.Contains("required"));
        }
        [Fact]
         public void ShouldNotCreateRacecarFromTopSpeed()
        {   

            RacecarDto dto = new RacecarDto(){ Nickname = "Lightning", Model = (CarModel)5, Status = "Available", TopSpeed = 400, Type = CarType.compact};
            var context = new ValidationContext(dto);
            Action act = () => Validator.ValidateObject(dto, context, true);
            act.Should().Throw<ValidationException>().Where(e => e.Message.Contains("TopSpeed"));
        }

        [Fact]
         public void ShouldNotCreateRacecarFromModel()
        {   

            RacecarDto dto = new RacecarDto(){ Nickname = "Lightning", Model = (CarModel)5, Status = "Available", TopSpeed = 400, Type = (CarType)8};
            var context = new ValidationContext(dto);
            Action act = () => Validator.ValidateObject(dto, context, true);
            act.Should().Throw<ValidationException>().Where(e => e.Message.Contains("invalid"));
        }
    }
}