using SalesApi.Entities;
using SalesApi.Entities.Constants;
using System;

namespace SalesApi.Util
{
    public static class ResponseUtils
    {
        public static ResponseDto BuildSuccessfullResponse(int id)
        {
            return new ResponseDto
            {
                recordId=id,
                status=ResponseStatus.SUCCESS,
                message = ResponseStatus.SUCCESS,
            };
        }
        public static ResponseDto BuildUnsuccessfullResponse(Exception e)
        {
            return new ResponseDto
            {
                recordId = -1,
                status = ResponseStatus.ERROR,
                message = e.Message,
            };
        }
    }
}
