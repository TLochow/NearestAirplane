using System;
using System.Reflection;
using System.Text;

namespace Airplanes {
    public class Airplane :IComparable {
        public string Name { get; set; }
        public string Country { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public bool OnGround { get; set; }

        public double Distance { get; set; }

        public int CompareTo(object obj) {
            Airplane other = (Airplane)obj;
            return other.Distance.CompareTo(Distance);
        }

        public override string ToString() {
            PropertyInfo[] propertyInfos = this.GetType().GetProperties();

            var sb = new StringBuilder();

            foreach (var info in propertyInfos) {
                var value = info.GetValue(this, null) ?? "(null)";
                sb.AppendLine(info.Name + ": " + value.ToString());
            }

            return sb.ToString();
        }
    }
}