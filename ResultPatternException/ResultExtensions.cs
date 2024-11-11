using Microsoft.AspNetCore.Mvc;

public static class ResultExtensions
{
    public static IActionResult ToActionResult<T>(this Result<T> result)
    {
        ApiResponse<T> apiResponse = result.IsSuccess
            ? ApiResponse<T>.Success(result.Value)
            : ApiResponse<T>.Fail(result.Error);

        return result.Error.ErrorType switch
        {
            ErrorType.Conflict => new ConflictObjectResult(apiResponse),
            ErrorType.NotFound => new NotFoundObjectResult(apiResponse),
            ErrorType.BadRequest => new BadRequestObjectResult(apiResponse),
            ErrorType.None => new OkObjectResult(apiResponse),
            _ => new ObjectResult(apiResponse) { StatusCode = 500 }
        };
    }
}