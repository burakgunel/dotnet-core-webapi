using System;
using System.Collections.Generic;
using System.Text;

namespace myCore.Helper
{
    public static class ServiceExecuterHelper<TRequest, TResponse>
    {
        public static TResponse Execute(Func<TRequest, TResponse> function, TRequest arg, Func<Exception, TResponse> onException = null)
        {
            try
            {
                if (function == null)
                {
                    throw new NotImplementedException("Action must be implemented");
                }
                //Request eklenmesindeki sebep ve yapılabilecekler
                //Her servis çağrısının business projesine düşmeden önce yapılabilecek kontrol/işler burada çalışabilir.
                TResponse response = function(arg);
                //Her servis çağrısının business projesine düştükten sonra yapılabilecek kontrol/işler burada çalışabilir.

                return response;
            }
            catch (Exception exc)
            {
                if (onException != null)
                {
                    return onException(exc);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
