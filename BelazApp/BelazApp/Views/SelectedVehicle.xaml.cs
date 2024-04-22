using BelazApp.Models;
using BelazApp.Services.Interfaces;
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
        private readonly IVehicleService _vehicleService;
        public SelectedVehicle(BasicVehicleInfo basicVehicleInfo, IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
            var vehicleName = basicVehicleInfo.Id;
            Title = vehicleName;
            Children.Add(new VehilcleParameter(basicVehicleInfo, _vehicleService));
            Children.Add(new VehicleReports(basicVehicleInfo, _vehicleService));
            InitializeComponent();
        }
    }
}