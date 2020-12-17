using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace myBusiness.Base
{
    public class SendPushNotificationCommand : ISendPushNotificationCommand
    {
        //Notificationlar farklı sunucular üzerinden atılmak istenirse ServiceProvider-ServiceManager yapısı ile tanımlama yapılarak çözümlenebilir.
        public void SendPushNotification(string content)
        {
            try
            {
                //endpoint config e eklenebilir.
                var request = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;

                request.KeepAlive = true;
                request.Method = "POST";
                request.ContentType = "application/json; charset=utf-8";
                //Bunlar config e eklenebilir.
                //app id hash veya encription ile encode decode edilerek kullanılabilir.
                byte[] byteArray = Encoding.UTF8.GetBytes("{"
                                                        + "\"app_id\": \"ebf027b0-459f-4745-bab5-6141b905eb3b\","
                                                        + "\"contents\": {\"en\": \""+content+"\"},"
                                                        + "\"include_player_ids\": [\"f5eb4c7e-bec0-455e-bbf4-5d68c804578c\"]}");

                string responseContent = null;


                using (var writer = request.GetRequestStream())
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }

                using (var resp = request.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(resp.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception)
            {
                //loglanabilir. hata alırsa throw etmemesini istedim.
            }
        }
    }
}
