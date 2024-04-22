using BelazApp.Models;
using BelazApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BelazApp.ViewModels
{
    public class VehicleReportsViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<VehicleReport> _vehicleReports;
        private readonly IVehicleService _vehicleService;
        private readonly BasicVehicleInfo _basicVehicleInfo;

        public VehicleReportsViewModel(BasicVehicleInfo vehicleInfo, IVehicleService vehicleService) 
        { 
            _vehicleService = vehicleService;
            _vehicleReports = new ObservableCollection<VehicleReport>();
            _basicVehicleInfo = vehicleInfo;
        }
        public ObservableCollection<VehicleReport> VehicleReport
        {
            get { return _vehicleReports; }
            set
            {
                _vehicleReports = value;
                OnPropertyChanged("VehicleReport");
            }
        }
        public async Task GetReports()
        {
            var reports = await _vehicleService.GetVehicleReportsAsync(_basicVehicleInfo.Id);
            _vehicleReports = reports;
        }
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
