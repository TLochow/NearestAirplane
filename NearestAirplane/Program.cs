using System;
using System.Threading.Tasks;
using WebApiClient;

namespace NearestAirplane {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Getting Airplanes...");
            Task getAirplanesTask = new Task(GetAirplanes);
            getAirplanesTask.Start();
            Console.ReadLine();
        }

        public static async void GetAirplanes() {
            string response = await WebClient.Get("https://opensky-network.org/api/states/all");
            Console.Clear();
            Console.Write(response);
        }
    }
}