using System;
using Web;
using Xunit;
using FluentAssertions;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public class RacecarDtoTest
    {
        RacecarDto workingCarDto = new RacecarDto() { Nickname = "Lightning", Model = CarModel.Nissan, Status = CarStatus.Available, TopSpeed = 400, Type = CarType.compact };
        [Fact]
        public void ShouldCreateRacecarFromDto()
        {
            var context = new ValidationContext(workingCarDto);
            Action act = () => Validator.ValidateObject(workingCarDto, context, true);
            act.Should().NotThrow();
        }

        [Fact]
        public void ShouldNotCreateRacecarFromDtoNickname()
        {
            workingCarDto.Nickname = "";
            var context = new ValidationContext(workingCarDto);
            Action act = () => Validator.ValidateObject(workingCarDto, context, true);
            act.Should().Throw<ValidationException>().Where(e => e.Message.Contains("required"));
        }

        [Fact]
        public void ShouldNotCreateRacecarFromDtoModel()
        {
            workingCarDto.Model = (CarModel)9;
            var context = new ValidationContext(workingCarDto);
            Action act = () => Validator.ValidateObject(workingCarDto, context, true);
            act.Should().Throw<ValidationException>().Where(e => e.Message.Contains("invalid"));
        }
        [Fact]
        public void ShouldNotCreateRacecarFromDtoStatus()
        {
            workingCarDto.Status = (CarStatus)3;
            var context = new ValidationContext(workingCarDto);
            Action act = () => Validator.ValidateObject(workingCarDto, context, true);
            act.Should().Throw<ValidationException>().Where(e => e.Message.Contains("invalid"));
        }
        [Fact]
        public void ShouldNotCreateRacecarFromTopSpeed()
        {
            workingCarDto.TopSpeed = 200;
            var context = new ValidationContext(workingCarDto);
            Action act = () => Validator.ValidateObject(workingCarDto, context, true);
            act.Should().Throw<ValidationException>().Where(e => e.Message.Contains("TopSpeed"));
        }

        [Fact]
        public void ShouldNotCreateRacecarFromType()
        {
            workingCarDto.Type = (CarType)8;
            var context = new ValidationContext(workingCarDto);
            Action act = () => Validator.ValidateObject(workingCarDto, context, true);
            act.Should().Throw<ValidationException>().Where(e => e.Message.Contains("invalid"));
        }
    }
}