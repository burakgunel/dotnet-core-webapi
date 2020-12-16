using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace myBusiness.Base
{
    public interface IGetCommand<TResponse,TRequest>
    {
        TResponse Execute(TRequest request);
    }
}
