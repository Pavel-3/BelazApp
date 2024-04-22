using BelazApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ViewModels
{
    public class BasicVehicleInfoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private BasicVehicleInfo _vehicle;

        public BasicVehicleInfoViewModel()
        {
            _vehicle = new BasicVehicleInfo();
        }
        public BasicVehicleInfo Vehicle
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

        public string Id
        {
            get { return _vehicle.Id; }
            set
            {
                if (_vehicle.Id != value)
                {
                    _vehicle.Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        public string Name
        {
            get { return _vehicle.Name; }
            set
            {
                if (_vehicle.Name != value)
                {
                    _vehicle.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Model
        {
            get { return _vehicle.Model; }
            set
            {
                if (_vehicle.Model != value)
                {
                    _vehicle.Model = value;
                    OnPropertyChanged("Model");
                }
            }
        }

        public string Description
        {
            get { return _vehicle.Description; }
            set
            {
                if (_vehicle.Description != value)
                {
                    _vehicle.Description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        public string ImagePath
        {
            get { return _vehicle.ImagePath; }
            set
            {
                if (_vehicle.ImagePath != value)
                {
                    _vehicle.ImagePath = value;
                    OnPropertyChanged("ImagePath");
                }
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
