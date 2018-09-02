using Airplanes;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace JsonDataHandling {
    public class AirplaneCollectionParser {
        public static AirplaneCollection FromJson(string json) {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            dynamic parsed = serializer.Deserialize<dynamic>(json);
            List<Airplane> airplanes = new List<Airplane>();
            IEnumerable<dynamic> states = parsed["states"];
            foreach (dynamic currentState in states) {
                try {
                    Airplane airplane = new Airplane();

                    string preferredName = currentState[1];
                    string id = currentState[0];
                    if (String.IsNullOrWhiteSpace(preferredName))
                        airplane.Name = id;
                    else
                        airplane.Name = preferredName;
                    airplane.Name = airplane.Name.Trim();

                    airplane.Country = currentState[2];

                    airplane.Longitude = Convert.ToDouble(currentState[5]);
                    airplane.Latitude = Convert.ToDouble(currentState[6]);

                    airplane.OnGround = currentState[8];

                    airplanes.Add(airplane);
                }
                catch { }
            }
            AirplaneCollection collection = new AirplaneCollection();
            collection.Time = new DateTime(parsed["time"]);
            collection.Airplanes = airplanes;

            return collection;
        }
    }
}