using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace myBusiness.Base
{
    public interface ICreateCommand<TMessage>
    {
        Task ExecuteAsync(TMessage message);
    }
}
