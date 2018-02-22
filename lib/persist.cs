using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;


namespace cfNetDemo.lib
{
    public class persist
    {
      //  NpgsqlConnection conn = null;
        public persist()
        {
            Connect();

        }
        public void Initialize()
        {
            Connect();

        }

        public void Connect()
        {
            Console.WriteLine("Retriving Cloud Foundry Services");
            string dbServiceName = Environment.GetEnvironmentVariable("DB_SERVICE_NAME"); //postgresql
            string vcapServices =  Environment.GetEnvironmentVariable("VCAP_SERVICES");
            Console.WriteLine(vcapServices);
            
            
            // if DB is bound to the App on Cloud Foundry
            if (vcapServices != null)
            {
                dynamic json = JsonConvert.DeserializeObject(vcapServices);
                foreach (dynamic obj in json.Children())
                {
                    if (((string)obj.Name).ToLowerInvariant().Contains(dbServiceName))
                    {
                        dynamic credentials = (((JProperty)obj).Value[0] as dynamic).credentials.uri;

                        Console.WriteLine("POSTGREE CONNECTION STRING IS: " + credentials);
                    }
                }
            }

        }
        public void Disconnect()
        {

        }
    }
}
