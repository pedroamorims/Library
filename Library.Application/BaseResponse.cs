using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application
{
    public class BaseResponse<TResponse>
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public TResponse Data { get; set; }

        public BaseResponse(bool isSuccess, TResponse data, string errorMessage = null)
        {
            IsSuccess = isSuccess;
            Data = data;
            ErrorMessage = errorMessage;
        }

        public static BaseResponse<TResponse> Success(TResponse data)
        {
            return new BaseResponse<TResponse>(true, data);
        }

        public static BaseResponse<TResponse> Failure(string errorMessage)
        {
            return new BaseResponse<TResponse>(false, default(TResponse), errorMessage);
        }
    }
}
