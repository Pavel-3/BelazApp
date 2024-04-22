using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace BelazApp.Models
{
    public class DetailedVehicleInfo : BasicVehicleInfo
    {
        public Coordinates Coordinates { get; set; }
        public DateTime? RecordingTime { get; set; }
        public Dictionary<string, Dictionary<string, Parameter>> Sections { get; set; }

    }
    public class Coordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
