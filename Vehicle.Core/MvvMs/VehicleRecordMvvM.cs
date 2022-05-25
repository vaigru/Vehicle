using System;

namespace Vehicle.Core.MvvMs
{
    public class VehicleRecordMvvM
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int Speed { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
