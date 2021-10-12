using System;
using Web;
using Xunit;
using FluentAssertions;
using System.ComponentModel.DataAnnotations;
namespace test
{
    public class DriverDtoTest
    {
        [Fact]
         public void ShouldCreateDriverFromDto()
        {   

            DriverDto dto = new DriverDto() {FirstName = "Ricky", LastName = "Bobby", Age = 30, Nickname = "LaFlame"};
            var context = new ValidationContext(dto);
            Action act = () => Validator.ValidateObject(dto, context, true);
            act.Should().NotThrow();
        }

        [Fact]
         public void ShouldFailtoCreateDriverFromDtoFirstNameLength()
        {   

            DriverDto dto = new DriverDto() {FirstName = "Ry", LastName = "Bobby", Age = 30, Nickname = "LaFlame"};
            var context = new ValidationContext(dto);
            Action act = () => Validator.ValidateObject(dto, context, true);
            act.Should().Throw<ValidationException>().Where(e => e.Message.Contains("minimum length of '3'."));
        }

        [Fact]
        public void ShouldFailtoCreateDriverFromDtoLastNameLength()
        {   

            DriverDto dto = new DriverDto() {FirstName = "Ricky", LastName = "Bo", Age = 30, Nickname = "LaFlame"};
            var context = new ValidationContext(dto);
            Action act = () => Validator.ValidateObject(dto, context, true);
            act.Should().Throw<ValidationException>().Where(e => e.Message.Contains("minimum length of '3'."));
        }

        [Fact]
        public void ShouldFailtoCreateDriverFromDtoNoAge()
        {   

            DriverDto dto = new DriverDto() {FirstName = "Ricky", LastName = "Bobby", Age = 16 , Nickname = "LaFlame"};
            var context = new ValidationContext(dto);
            Action act = () => Validator.ValidateObject(dto, context, true);
            act.Should().Throw<ValidationException>().Where(e => e.Message.Contains("be between 18 and 100"));
        }
        [Fact]
        public void ShouldFailtoCreateDriverFromDtoNickname()
        {   

            DriverDto dto = new DriverDto() {FirstName = "Ricky", LastName = "Bobby", Age = 18, Nickname = ""};
            var context = new ValidationContext(dto);
            Action act = () => Validator.ValidateObject(dto, context, true);
            act.Should().Throw<ValidationException>().Where(e => e.Message.Contains("required"));
        }
    }
}