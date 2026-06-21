using E_commerce.Application.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        public static ActionResult<T> ToActionResult<T>(Result<T> result)
        {
            if(result.IsSucesss)
            {
                return new OkObjectResult(result.data);
            }
            else
            {
               return ToProblem(result.Errors);
            }
        }

        public static ActionResult ToActionResult(Result result)
        {
            if(result.IsSucesss)
            {
                return new OkResult();
            }
            else
            {
                return ToProblem(result.Errors);
            }
        }



        private static ObjectResult ToProblem(IReadOnlyList<Error> errors)
        {
            var firstError = errors[0];
            var statusCode = firstError.ErrorType switch
            {
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Failure => StatusCodes.Status417ExpectationFailed,
                ErrorType.Forbidden => StatusCodes.Status403Forbidden,
                ErrorType.UnAuthorized => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError

            };

            var problem = new ProblemDetails()
            {
                Title = firstError.Code,
                Detail = firstError.Description,
                Status = statusCode,
                Extensions = { ["errors"] = errors }

            };
            return new ObjectResult(problem) { StatusCode = statusCode};
        }
    }
}
