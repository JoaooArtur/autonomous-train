using trem_autonomo.Abstractions;
using trem_autonomo.APIs.AutonomousTrain.Validators;

namespace trem_autonomo.APIs.AutonomousTrain
{
    public class ApplicationService : ApplicationServiceBase
    {
        public int ControlAutonomousTrain(Payloads.ControlAutonomousTrain payload) 
        {
            ValidatePayload(payload, new ControlAutonomousTrainValidator());

            var position = 0;

            foreach (var direction in payload.Directions) 
            {
                var directionValue = ConvertDirectionValue(direction);
                position += directionValue;

                if (position < 0)
                    throw new Exception("Posição inválida do trem, posição não pode ser menor que 0");
            }

            return position;
        }

        public int ConvertDirectionValue(string direction) 
        {
            return direction switch
            {
                "ESQUERDA" => -1,
                "DIREITA" => 1,
                _ => 0
            };
        }
    }
}
