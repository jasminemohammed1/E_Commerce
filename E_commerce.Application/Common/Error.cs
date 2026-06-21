using System.Globalization;
using System.Text.Json.Serialization;

namespace E_commerce.Application.Common
{
    public sealed record Error(string Code , string Description , ErrorType ErrorType = ErrorType.Failure )
    {

        public static Error Failure(string code = "General.Failure", string description = "General.Failure Error has occured") => new Error(code, description, ErrorType.Failure);
        public static Error Validation(string code = "General.Validation", string description = "General.Validation Error has occured") => new(code , description, ErrorType.Validation);
        public static Error NotFound(string code="General.NotFound", string description = "General.Not Found Error has occured") => new Error(code , description, ErrorType.NotFound);
        public static Error Conflict(string code = "General.Conflict", string description = "General.Conflict Error F has occured") => new Error(code, description, ErrorType.Conflict);
        public static Error UnAuthorized(string code = "General. UnAuthorized", string description = "General. UnAuthorized Error has occured") => new Error(code, description, ErrorType.UnAuthorized);
        public static Error Forbidden(string code = "General.Forbidden", string description = "General.ForbiddenError has occured") => new(code, description, ErrorType.Forbidden);
        public static Error InvalidCredential(string code = "General. InvalidCredential", string description = "General. InvalidCredential Error has occured") => new(code, description, ErrorType.InvalidCredential);




    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ErrorType
    {
        Failure = 0 ,
        Validation = 1,
        NotFound = 2,
        Conflict = 3,
        UnAuthorized = 4,
        Forbidden = 5,
        InvalidCredential = 6 

    }
}