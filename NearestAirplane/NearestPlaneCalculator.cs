using Airplanes;
using JsonDataHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApiClient;

namespace NearestAirplane {
    class NearestPlaneCalculator {
        AirplaneCollection _airplanes;
        bool _loadedPlanes;

        public NearestPlaneCalculator() {
            Reload();
        }

        public void Reload() {
            _loadedPlanes = false;
            Task getAirplanesTask = new Task(GetAirplanes);
            getAirplanesTask.Start();

            while (!_loadedPlanes)
                Thread.Sleep(1000);
        }

        public Airplane GetNearestAirplane(double longitude, double latitude, bool onGround) {
            List<Airplane> planes = _airplanes.Airplanes.Where(a => a.OnGround == onGround).ToList();
            foreach (Airplane plane in planes)
                plane.Distance = Distance(longitude, latitude, plane.Longitude, plane.Latitude);

            Airplane nearest = null;
            double bestScore = double.MaxValue;
            foreach (Airplane plane in planes) {
                if (plane.Distance < bestScore) {
                    nearest = plane;
                    bestScore = plane.Distance;
                }
            }

            return nearest;
        }

        public static double Distance(double x1, double y1, double x2, double y2) {
            return Math.Sqrt(((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)));
        }

        public async void GetAirplanes() {
            string response = await WebClient.Get("https://opensky-network.org/api/states/all");
            _airplanes = AirplaneCollectionParser.FromJson(response);
            _loadedPlanes = true;
        }
    }
}