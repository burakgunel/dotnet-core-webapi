using myDomain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace myCore.Helper
{
    public static class ServiceException<TResult> where TResult : BaseResponseDTO, new()
    {
        public static TResult onException(System.Exception ex)
        {
            //Burada alınacak hata tipi ile ilgili ayrıştırma, kategorize edilme vs gibi işlemler yapılabilir. @CanBeImprove

            var result = new TResult();
            result.Success = false;
            result.ExceptionMessage = ex.Message;
            result.ExceptionType = ex.GetType().Name;
            result.IsBusinessException = true;

            return result;
        }
    }
}
