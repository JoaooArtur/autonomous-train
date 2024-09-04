using FluentValidation;
using System.Text.RegularExpressions;

namespace trem_autonomo.APIs.AutonomousTrain.Validators
{
    public class ControlAutonomousTrainValidator : AbstractValidator<Payloads.ControlAutonomousTrain>
    {

        public ControlAutonomousTrainValidator()
        {
            RuleFor(payload => payload.Directions)
                .Must((payload) => payload.Any())
                .WithMessage("Ao menos uma direção deve ser informada.");

            RuleForEach(payload => payload.Directions)
                .Must((payload, direction) => direction == "DIREITA" || direction == "ESQUERDA")
                .WithMessage("Nome de direções inválidas, os valores devem ser DIREITA ou ESQUERDA.");

            RuleFor(payload => payload.Directions)
                .Must(directions => directions.Count <= 50).WithMessage("Número máximo de direções é 50.");

            RuleFor(payload => payload.Directions)
                .Must(HaveLessThan20ConsecutiveMoves).WithMessage("Não se pode ter 20 movimentos consecutivos na mesma direção.");
        }

        protected static bool HaveLessThan20ConsecutiveMoves(List<string> directions)
        {
            var consecutiveMoves = 1;
            string lastMove = string.Empty;
            foreach (var direction in directions) 
            {
                if (direction == lastMove)
                {
                    consecutiveMoves++;
                    if (consecutiveMoves == 20)
                        return false;
                }
                else
                    consecutiveMoves = 1;

                lastMove = direction;
            }
            return true;
        }
    }
}
