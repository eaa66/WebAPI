using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ClientTest
{
    class Program
    {
        static List<SensorData> lstData = new List<SensorData>();       
        static HttpClient  client = new System.Net.Http.HttpClient();
        static int numRecords = 1000;
        static  void  Main(string[] args)
        {
            send();
            send();
            send();
            send();
            Console.ReadLine();
        }
        private static async void send()
        {


            fillData(numRecords);
            DateTime st = DateTime.Now;
            string json = JsonConvert.SerializeObject(lstData, Formatting.Indented);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = client.PostAsync("https://webapipcs.azurewebsites.net/api/SensorData", content);
            result.ContinueWith(task=> {

            Console.WriteLine($"num records = {numRecords}, elapsed time = {DateTime.Now.Subtract(st).TotalSeconds }");
            Console.WriteLine(result.ToString());
            });

        }

        private static void fillData(int numPoints)
        {
            // fills list with random data
            lstData.Clear();
            var ran = new Random();
            for (int i = 0; i < numPoints; i++)
            {
                SensorData s = new SensorData()
                {
                    time = DateTime.Now,
                    acceX = ran.NextDouble(),
                    acceY = ran.NextDouble(),
                    acceZ = ran.NextDouble(),
                    gyroX = ran.NextDouble(),
                    gyroY = ran.NextDouble(),
                    gyroZ = ran.NextDouble()
                };
                lstData.Add(s);
            }
        }
    }
}
