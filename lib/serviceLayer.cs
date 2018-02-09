using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
namespace cfNetDemo.lib
{
    public class serviceLayer
    {
        /* Service Layer module to interact with B1 Data */
        /* Server Configuration and User Credentials set as environment variables */

        private static readonly HttpClient client = new HttpClient();
        private static String SessionId;
        private static String SLServer = Environment.GetEnvironmentVariable("B1_SERVER_ENV") + ":"
                            + Environment.GetEnvironmentVariable("B1_SLPORT_ENV")
                            + Environment.GetEnvironmentVariable("B1_SLPATH_ENV");
        

        public serviceLayer()
        {
            /* Constructor connect to SL */
            Task<string> result = Connect();

            dynamic finalResult = JsonConvert.DeserializeObject(result.Result);
            if (finalResult != null)
            {
                SessionId = finalResult.SessionId;
            }else {
                SessionId = "Not Connected to SL";
            }
           
            
                     
        }
        async Task<string> Connect()
        {
            String uri = SLServer + "Login";
            var data = new Dictionary<string, string>{
                    { "UserName", Environment.GetEnvironmentVariable("B1_USER_ENV")},
                    { "Password", Environment.GetEnvironmentVariable("B1_PASS_ENV")},
                    { "CompanyDB",Environment.GetEnvironmentVariable("B1_COMP_ENV")}
                };

            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(uri, content);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Error Connecting to Service Layer");
                Console.WriteLine("Response Message Header \n\n" + response.Content.Headers + "\n");
                Console.WriteLine("Response Message Header \n\n" + response.Content.ReadAsStringAsync() + "\n");
                return "";
            }              
            var responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }

        public static string getSessionId()
        {
            return SessionId;
        }
    }
}
