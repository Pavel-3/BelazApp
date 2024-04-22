using BelazApp.Models;
using BelazApp.Services.Interfaces;
using BelazApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ViewModels
{

    namespace BelazApp.ViewModels
    {
        public class MainViewModel : INotifyPropertyChanged
        {
            private readonly IVehicleService _vehicleService;
            private ObservableCollection<BasicVehicleInfoViewModel> _vehicles;
            private BasicVehicleInfoViewModel _selectedVehicle;

            public INavigation Navigation { set; get; }

            public MainViewModel(IVehicleService vehicleService)
            {
                _vehicleService = vehicleService;
                _vehicles = new ObservableCollection<BasicVehicleInfoViewModel>();
            }
            public ObservableCollection<BasicVehicleInfoViewModel> Vehicles
            {
                get { return _vehicles; }
                set
                {
                    _vehicles = value;
                    OnPropertyChanged("Vehicles");
                }
            }
            public BasicVehicleInfoViewModel SelectedVehicle
            {
                get { return _selectedVehicle; }
                set
                {
                    OnPropertyChanged("SelectedVehicle");
                    _selectedVehicle = value;
                    Navigation.PushAsync(new SelectedVehicle(value.Vehicle, _vehicleService));
                }
            }
            public async Task GetVehicles()
            {
                var vehicleInfos = await _vehicleService.GetBasicVehiclesAsync();
                var vehiclesIEnumerable = vehicleInfos.Select(x => (new BasicVehicleInfoViewModel() { Vehicle = x }));
                _vehicles = new ObservableCollection<BasicVehicleInfoViewModel>(vehiclesIEnumerable);
            }
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}
