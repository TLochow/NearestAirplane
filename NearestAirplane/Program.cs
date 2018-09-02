using Airplanes;
using System;

namespace NearestAirplane {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Loading planes...");
            NearestPlaneCalculator calculator = new NearestPlaneCalculator();
            Console.WriteLine("Done.");
            while (true) {
                double longitude = AskForDouble("Please enter the longitude: ");
                double latitude = AskForDouble("Please enter the latitude: ");
                bool onGround = AskForBool("Should the plane be on the ground? (Please enter 'true' or 'false') ");

                Airplane nearestPlane = calculator.GetNearestAirplane(longitude, latitude, onGround);
                Console.WriteLine(nearestPlane);
            }
        }

        public static double AskForDouble(string text) {
            bool validInput = false;
            double result = 0;
            while (!validInput) {
                Console.Write(text);
                string input = Console.ReadLine();
                if (double.TryParse(input, out result))
                    validInput = true;
                else
                    Console.WriteLine("Invalid input.");
            }
            return result;
        }

        public static bool AskForBool(string text) {
            bool validInput = false;
            bool result = false;
            while (!validInput) {
                validInput = true;
                Console.Write(text);
                string input = Console.ReadLine();
                if (!bool.TryParse(input, out result)) {
                    validInput = false;
                    Console.WriteLine("Invalid input.");
                }
            }
            return result;
        }
    }
}