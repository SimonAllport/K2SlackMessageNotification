using System;
using System.Text;
using Newtonsoft.Json;

namespace K2Slack
{
    public class SlackClient
    {
        private readonly Uri _uri;
     

        //Post a message using simple strings
        public static void PostMessage(string text, string username = null, string channel = null)
        {
            Payload payload = new Payload()
            {
                Channel = channel,
                Username = username,
                Text = text
            };
            
            PostMessage(payload);
        }

        //Post a message using a Payload object
        private static void PostMessage(Payload payload)
        {
              Encoding _encoding = new UTF8Encoding();
            Uri endpoint = new Uri("webhook url here");

        string payloadJson = JsonConvert.SerializeObject(payload);
            
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                System.Collections.Specialized.NameValueCollection data = new System.Collections.Specialized.NameValueCollection();
                data["payload"] = payloadJson;

                var response = client.UploadValues(endpoint, "POST", data);

                //The response text is usually "ok"
                string responseText = _encoding.GetString(response);
            }
        }
    }

    //This class serializes into the Json payload required by Slack Incoming WebHooks
    public class Payload
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
