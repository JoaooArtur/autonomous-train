using trem_autonomo.APIs.AutonomousTrain;

namespace trem_autonomo_tests.ApplicationServiceTests.AutonomousTrainTests
{
    public class ApplicationServiceTest
    {
        private ApplicationService GenerateAppService()
            => new ApplicationService();

        [Fact]
        public void Should_Have_Error_When_Directions_Ends_In_Negative()
        {
            var directions = new List<string>() { "ESQUERDA" };

            var ex = Assert.Throws<Exception>(() => GenerateAppService().ControlAutonomousTrain(new(directions)));
            Assert.Equal("Posição inválida do trem, posição não pode ser menor que 0", ex.Message);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Directions_Are_Valid()
        {
            var directions = new List<string>() { "DIREITA", "ESQUERDA", "DIREITA" };

            Assert.IsType<int>(GenerateAppService().ControlAutonomousTrain(new(directions)));
        }

        [Fact]
        public void Should_Convert_To_1_When_Direction_Is_Right()
        {
            Assert.Equal(1,GenerateAppService().ConvertDirectionValue("DIREITA"));
        }

        [Fact]
        public void Should_Convert_To_Minus_1_When_Direction_Is_Right()
        {
            Assert.Equal(-1, GenerateAppService().ConvertDirectionValue("ESQUERDA"));
        }
    }
}
