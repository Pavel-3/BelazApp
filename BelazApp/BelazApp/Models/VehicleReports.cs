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
        public int VehicleId { get; set; }
        public List<VehicleReportData> vehicleReporDatas { get; set; }
    }
    public class VehicleReportData
    {
        public string ReportDate { get; set; }
        public string Text { get; set; }
    }
}
