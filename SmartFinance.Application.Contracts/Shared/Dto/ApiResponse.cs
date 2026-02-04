using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Application.Contracts.Shared.Dto
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse(int statusCode, string message, T data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        public static ApiResponse<T> Success(int statusCode, T data, string message = "Request successful") => new ApiResponse<T>(statusCode: statusCode, message: message, data: data);
        public static ApiResponse<T> Failure(int statusCode, T data, string message = "Request failed") => new ApiResponse<T>(statusCode: statusCode, message: message, data: data);
    }
}
