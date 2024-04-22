using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace BelazApp.Models
{
    public class VehicleReport
    {
        public string VehicleId { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public Coordinates Coordinates { get; set; }
        public DateTime? RecordingTime { get; set; }
    }
    public class VehicleReportData
    {
        public string ReportDate { get; set; }
        public string Text { get; set; }
    }
}
