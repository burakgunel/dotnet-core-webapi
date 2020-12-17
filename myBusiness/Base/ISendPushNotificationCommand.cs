using System;
using System.Collections.Generic;
using System.Text;

namespace myBusiness.Base
{
    public interface ISendPushNotificationCommand
    {
        void SendPushNotification(string content);
    }
}
