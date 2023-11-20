using BelazApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BelazApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedVehicle : TabbedPage
    {
        public SelectedVehicle(int vehicleId)
        {
            var vehicleName = Data.GetVehicles().FirstOrDefault(x => x.Id == vehicleId).Name;
            Title = vehicleName;
            Children.Add(new VehilcleParameter(vehicleId));
            Children.Add(new VehicleReports(vehicleId));
            InitializeComponent();

        }
    }
}