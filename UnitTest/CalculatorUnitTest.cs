using Moq;
using AllPurposeCalculator.Services.Interfaces;
using AllPurposeCalculator.Business;
using AllPurposeCalculator.Entities;

namespace UnitTest
{
    [TestClass]
    public class CalculatorUnitTest
    {
        private Mock<IUnitService> _mockUnitService;
        private Mock<IConversionService> _mockConversionService;

        private readonly List<Unit> _mockUnitsData;

        public CalculatorUnitTest()
        {
            _mockConversionService = new Mock<IConversionService>();
            _mockUnitService = new Mock<IUnitService>();

            _mockUnitsData = new List<Unit>()
            {
                new Unit()
                {
                    UnitType = "Mass",
                    Id = 1,
                    Name = "Kilograms",
                    ShortName = "kg"
                },
                new Unit() 
                {
                    UnitType = "Length",
                    Id = 1,
                    Name = "Meters",
                    ShortName = "m"
                },
                new Unit()
                {
                    UnitType = "Temperature",
                    Id = 1,
                    Name = "Kelvin",
                    ShortName = "K"
                },
                new Unit()
                {
                    UnitType = "Time",
                    Id = 1,
                    Name = "Hours",
                    ShortName = "H"
                }
            };
        }

        [TestMethod]
        public void TestGetUnitsDoesNotReturnUnitNotExistingInUnitTypeEnum()
        {
            // arrange
            _mockUnitService.Setup(u => u.GetUnits()).Returns(_mockUnitsData);
            var calculator = new Calculator(_mockConversionService.Object, _mockUnitService.Object);
            
            // act
            var results = calculator.GetUnits();

            // assert
            Assert.IsFalse(results.Select(x => x.UnitType).Contains("Time"));
        }
    }
}