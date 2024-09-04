using Asp.Versioning.Builder;

namespace trem_autonomo.APIs.AutonomousTrain
{
    public static class AutonomousTrainApi
    {
        private const string BaseUrl = "/api/v{version:apiVersion}/autonomous-train/";

        public static IVersionedEndpointRouteBuilder MapAutonomousTrainApiV1(this IVersionedEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup(BaseUrl).HasApiVersion(1);

            group.MapPost("/", ([AsParameters] Payloads.ControlAutonomousTrain payload)
                => new ApplicationService().ControlAutonomousTrain(payload));

            return builder;
        }
    }
}
