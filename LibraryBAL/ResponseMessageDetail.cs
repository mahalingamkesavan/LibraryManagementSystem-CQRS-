using LibraryUtil.DTO.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBAL
{
    internal  class ResponseMessageDetail
    {
        internal static ResultResponseDTO resultResponse(bool IsExcute, string message)
        {
            ResultResponseDTO result = new ResultResponseDTO();
            if (IsExcute)
            {
                result.StatusCode = HttpStatusCode.OK;
                result.Message = message;
            }
            else
            {
                result.StatusCode = HttpStatusCode.BadRequest;
                result.Message = Constants.UserRegistration.ErrorMessage;
            }
            return result;
        }
    }
}
