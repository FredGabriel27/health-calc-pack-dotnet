using health_calc_pack_dotnet;

namespace health_calc_test_xunit
{
    public class IMCTest
    {
        [Fact]
        public void When_RequestIMCCalcWithValidData_ThenReturnIMCIndex()
        {
            //Arrange
            var Imc = new IMC();
            var Height = 1.68;
            var Weight = 85;
            var Expected = 30.12;

            //Act
            var Result = Imc.Calc(Height, Weight);

            //Assert
            Assert.Equal(Expected,Result);

        }

        [Fact]
        public void When_RequestIMCCalcWithValidData_ThenReturnIMCIndexWithRangeAssert()
        {
            //Arrange
            var Imc = new IMC();
            var Height = 1.68;
            var Weight = 85;
            var ExpectedMin = 30.10;
            var ExpectedMax = 30.14;

            //Act
            var Result = Imc.Calc(Height, Weight);

            //Assert
            Assert.InRange(Result,ExpectedMin,ExpectedMax);

        }

        [Fact]
        public void When_RequestIMCCalcWithInvalidAllData_ThenThrowException()
        {
            //Arrange
            var Imc = new IMC();
            var Height = 0.0;
            var Weight = 0.0;

            //Act and Assert
            Assert.Throws<Exception>(() => Imc.Calc(Height, Weight));

        }

        [Fact]
        public void When_RequestIMCCalcWithInvalidHeightData_ThenThrowException()
        {
            //Arrange
            var Imc = new IMC();
            var Height = 0.0;
            var Weight = 0.0;

            //Act and Assert
            Assert.Throws<Exception>(() => Imc.Calc(Height, Weight));

        }

        [Theory]
        [InlineData(17.5, "Abaixo do peso")]
        [InlineData(18.49, "Abaixo do peso")]
        [InlineData(18.50, "Peso normal")]
        [InlineData(24.99, "Peso normal")]
        [InlineData(25, "Pr?-obesidade")]
        [InlineData(29.99, "Pr?-obesidade")]
        [InlineData(30, "Obesidade Grau 1")]
        [InlineData(34.99, "Obesidade Grau 1")]
        [InlineData(35, "Obesidade Grau 2")]
        [InlineData(39.99, "Obesidade Grau 2")]
        [InlineData(40, "Obesidade Grau 3")]
        [InlineData(45, "Obesidade Grau 3")]
        public void When_RequestIMCCategory_ThenReturnCategory(double IMC, string ExpectedResult)
        {
            //Arrange
            var Imc = new IMC();

            //Act
            var Result = Imc.GetIMCCategory(IMC);

            //Assert
            Assert.Equal(ExpectedResult, Result);

        }

        [Theory]
        [InlineData(0, 1.68)]
        [InlineData(85, 0)]
        [InlineData(0, 0)]
        public void When_InvalidData_ThenReturnValidationResultFalse(double Weight, double Height)
        {
            //Arrange
            var Imc = new IMC();
            var _Height = Height;
            var _Weight = Weight;

            //Act
            var Result = Imc.IsValidData(Height, Weight);

            //Assert
            Assert.False(Result);

        }


    }
}