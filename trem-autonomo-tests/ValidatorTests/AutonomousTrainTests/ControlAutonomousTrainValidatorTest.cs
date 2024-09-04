using System.ComponentModel.DataAnnotations;
using trem_autonomo.APIs.AutonomousTrain;
using trem_autonomo.APIs.AutonomousTrain.Validators;
using trem_autonomo_tests.Abstractions;

namespace trem_autonomo_tests.ValidatorTests.AutonomousTrainTests
{
    public class ControlAutonomousTrainValidatorTest : ValidatorTests<ControlAutonomousTrainValidator, Payloads.ControlAutonomousTrain>
    {
        [Fact]
        public void Should_Have_Error_When_Directions_Is_Empty()
        {
            Given()
                .When(query => query.With(x => x.Directions, new List<string>()))
                .ThenShouldHaveErrorWithCustomMessageFor((x => x.Directions, "Ao menos uma direção deve ser informada."));
        }

        [Fact]
        public void Should_Have_Error_When_Directions_Has_MoreThan50()
        {
            var directions = new List<string>();
            int i = 0;
            while (i <= 50) 
            {
                directions.Add("DIREITA");
                i++;
            }
                
            Given()
                .When(query => query.With(x => x.Directions, directions))
                .ThenShouldHaveErrorWithCustomMessageFor((x => x.Directions, "Número máximo de direções é 50."));
        }

        [Fact]
        public void Should_Not_Have_Error_When_Directions_Have_20ConsecutivesRightMoves()
        {
            var consecutiveDirections = new List<string>();
            int i = 0;
            while (i <= 20) 
            {
                consecutiveDirections.Add("DIREITA");
                i++;
            }

            Given()
                .When(query => query.With(x => x.Directions, consecutiveDirections))
                .ThenShouldHaveErrorWithCustomMessageFor((x => x.Directions, "Não se pode ter 20 movimentos consecutivos na mesma direção."));
        }

        [Fact]
        public void Should_Not_Have_Error_When_Directions_Have_20ConsecutivesLeftMoves()
        {
            var consecutiveDirections = new List<string>();
            int i = 0;
            while (i < 20)
            {
                consecutiveDirections.Add("ESQUERDA");
                i++;
            }

            Given()
                .When(query => query.With(x => x.Directions, consecutiveDirections))
                .ThenShouldHaveErrorWithCustomMessageFor((x => x.Directions, "Não se pode ter 20 movimentos consecutivos na mesma direção."));
        }

        [Fact]
        public void Should_Have_Error_When_Directions_Have_WrongNames()
        {
            var directions = new List<string>() { "direita", "frente" };

            Given()
                .When(query => query.With(x => x.Directions, directions))
                .ThenShouldHaveErrorWithCustomMessageFor((x => x.Directions, "Nome de direções inválidas, os valores devem ser DIREITA ou ESQUERDA."));
        }

        [Fact]
        public void Should_Not_Have_Error_When_Directions_Are_Valid()
        {
            var directions = new List<string>() { "DIREITA", "DIREITA", "ESQUERDA" };

            Given()
                .When(query => query.With(x => x.Directions, directions))
                .ThenNothing();
        }
    }
}
