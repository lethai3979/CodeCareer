using CodeCareer.Domain.Shared;

namespace CodeCareer.API.Extensions
{
    public static class ResultExtension
    {
        public static IResult ToProblemDetails(this Result result)
        {
            if (result.Success) 
            {
                throw new InvalidOperationException();
            }
            return Results.Problem
                (
                    statusCode: GetStatusCode(result.Error.ErrorType),
                    title: GetTitle(result.Error.ErrorType),
                    extensions: new Dictionary<string, object?>
                    {
                        {"errors", new [] { result.Error} }
                    }
                );
            #region Local function 
            //Mapping ErrorType to StatusCode
            static int GetStatusCode(ErrorType errorType)
                => errorType switch
                {
                    ErrorType.BadRequest => StatusCodes.Status400BadRequest,
                    ErrorType.NotFound => StatusCodes.Status404NotFound,
                    ErrorType.Conflict => StatusCodes.Status409Conflict,
                    ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
                    _ => StatusCodes.Status500InternalServerError
                };
            //Get ErrorType title
            static string GetTitle(ErrorType errorType)
                => errorType switch
                {
                    ErrorType.BadRequest => "Bad Request",
                    ErrorType.NotFound => "Not Found",
                    ErrorType.Conflict => "Conflict",
                    ErrorType.Unauthorized => "Unauthorized",
                    _ => "Server Failure"
                };
            #endregion
        }
    }
}
