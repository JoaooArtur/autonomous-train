namespace trem_autonomo.APIs.AutonomousTrain
{
    public static class Payloads
    {
        public record ControlAutonomousTrain(List<string> Directions);
    }
}
