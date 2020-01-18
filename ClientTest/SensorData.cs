using System;
namespace ClientTest
{
    public class SensorData
    {
        public long id { get; set; }
        public DateTime time { get; set; }
        public double acceX { get; set; }
        public double acceY { get; set; }
        public double acceZ { get; set; }
        public double gyroX{ get; set; }
        public double gyroY { get; set; }
        public double gyroZ { get; set; }
    }
}
