using BelazApp.Models;
using BelazApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BelazApp.ViewModels
{
    public class DetailedVehicleInfoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IVehicleService _vehicleService;
        DetailedVehicleInfo _vehicle;
        private string _id;
        private Stack<DateTime> _previousDateTimes;
        private Stack<DateTime> _upcomingDateTimes;
        private DateTime _currentDateTime;
        public ICommand BackTimeCommand { protected set; get; }
        public ICommand ForwardTimeCommand { protected set; get; }
        public INavigation Navigation { get; set; }

        public DetailedVehicleInfoViewModel(BasicVehicleInfo vehicleInfo, IVehicleService vehicleService)
        {
            _id = vehicleInfo.Id;
            _vehicleService = vehicleService;
            BackTimeCommand = new Command(BackTime);
            ForwardTimeCommand = new Command(ForwardTime);
        }
        public DetailedVehicleInfo Vehicle
        {
            get { return _vehicle; }
            set
            {
                if (_vehicle != value)
                {
                    _vehicle = value;
                    OnPropertyChanged("Vehicle");
                }
            }
        }
        public DateTime CurrentDateTime
        {
            get { return _currentDateTime; }
            set
            {
                OnPropertyChanged("CurrentDateTime");
                _currentDateTime = value;
            }
        }
        public async Task GetDetailedVehicleInfo()
        {
            Vehicle = await _vehicleService.GetDetailedVehicleInfoAsync(_id);
            IEnumerable<DateTime> dateTimes = await _vehicleService.GetAllDatesForVehicleAsync(_id);
            _previousDateTimes = new Stack<DateTime>(dateTimes);
            _currentDateTime = _previousDateTimes.Pop();
        }
        private async void BackTime()
        {
            if(_previousDateTimes.Any())
            {
                _upcomingDateTimes.Push(_currentDateTime);
                _currentDateTime = _previousDateTimes.Pop();
                Vehicle = await _vehicleService.GetDetailedVehicleInfoAsync(_id, _currentDateTime);
            }
        }
        private async void ForwardTime()
        {
            if (_upcomingDateTimes.Any())
            {
                _previousDateTimes.Push(_currentDateTime);
                _currentDateTime = _upcomingDateTimes.Pop();
                Vehicle = await _vehicleService.GetDetailedVehicleInfoAsync(_id, _currentDateTime);
            }
            else
            {
                IEnumerable<DateTime> serverTimes = await _vehicleService.GetAllDatesForVehicleAsync(_id);
                List<DateTime> upcomingDateTimes = serverTimes.Where(time => time > _currentDateTime).ToList();
                if (upcomingDateTimes.Any())
                {
                    _upcomingDateTimes = new Stack<DateTime>(upcomingDateTimes);
                    _currentDateTime = _upcomingDateTimes.Pop();
                    Vehicle = await _vehicleService.GetDetailedVehicleInfoAsync(_id, _currentDateTime);
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}