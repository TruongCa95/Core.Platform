using Domain.Enums;
using TimeSheetManagement.Services;
using Xunit;

namespace TimeSheetManagement.Tests
{
    public class CalculationSalaryServiceTests
    {
        // CalculateKi is pure and never touches the unit of work, so passing
        // null! here is safe and keeps the test free of DB dependencies.
        private readonly CalculationSalaryService _service = new(null!);

        [Theory]
        [InlineData(KiEnums.APlus, 1.4)]
        [InlineData(KiEnums.A, 1.25)]
        [InlineData(KiEnums.BPlus, 1.1)]
        [InlineData(KiEnums.B, 1.0)]   // B has no explicit case -> default multiplier
        [InlineData(KiEnums.C, 0.8)]
        [InlineData(KiEnums.D, 0.5)]
        public void CalculateKi_ReturnsExpectedMultiplier(KiEnums ki, double expected)
        {
            var result = _service.CalculateKi(ki);

            Assert.Equal((decimal)expected, result);
        }
    }
}
