namespace CarAPI.Utils
{
    public class LogEvents
    {
        public const int GetAllCarResponses = 2000;
        public const int CreateCarResponseCreated = 2010;
        public const int UpdateCarResponseUpdated = 2020;
        public const int CarResponseInternalError = 5000;
        public const int CarResponseBadRequest = 4000;

        public const int CreateCarResponseCommandHandlerFailure = 4001;
        public const int UpdateCarResponseCommandHandlerFailure = 4002;
        public const int GetCarResponseQueryHandlerFailure = 4003;
    }
}
