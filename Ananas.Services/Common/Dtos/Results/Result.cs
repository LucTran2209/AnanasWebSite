
using Ananas.Services.Common.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;
using System.Text.Json;

namespace ApplicationCommon.Abstractions.Dtos.Results
{
    public class Result : IActionResult
    {
        public int StatusCode { get; }
        public object Data { get; }
        public string Message { get; }
        public Dictionary<string, string[]>? ModelState { get; }

        public Result(int statusCode, object data, string message, Dictionary<string, string[]> modelState = null)
        {
            StatusCode = statusCode;
            Data = data;
            Message = message;
            ModelState = modelState;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;
            response.StatusCode = StatusCode;
            response.ContentType = "application/json";

            var result = new Dictionary<string, object>
            {
                { "code", StatusCode },
                { "message", Message }
            };

            if (Data != null)
            {
                var dataType = Data.GetType();
                var dataPropertyName = char.ToLowerInvariant(dataType.Name[0]) + dataType.Name.Substring(1);
                result[dataPropertyName] = Data;
            }

            if (ModelState != null)
            {
                result["modelState"] = ModelState;
            }

            var jsonData = JsonSerializer.Serialize(result);
            await response.WriteAsync(jsonData);
        }

        public static Result Success(object data, string message = "Operation was successful.")
        {
            return new Result(StatusCodes.Status200OK, data, message);
        }

        public static Result Failure(object data, string message = "Operation failed.", ModelStateDictionary modelState = null)
        {
            var modelStateDict = modelState?.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
            );

            return new Result(StatusCodes.Status400BadRequest, data, message, modelStateDict);
        }
    }

}
