using System.Net.Http;
using RestClient;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        RestClient.DotNetCore.RestClient client = new RestClient.DotNetCore.RestClient("http://localhost:5000/v1/api/");
        var result =Task.Run(() => client.Execute(RestClient.DotNetCore.HttpMethod.Get, "lapstats/events", null, null)).Result;
        var myResult = Task.Run(() => client.Execute<List<EventData>>(RestClient.DotNetCore.HttpMethod.Get, "lapstats/events", null, null)).Result;
    }

    public class EventData
    {
        public string EventName { get; set; }

        public string Directory { get; set; }

        public int ChassisA { get; set; }

        public int ChassisB { get; set; }

        public string DriverA { get; set; }

        public string DriverB { get; set; }

        public string Comments { get; set; }
    }
}