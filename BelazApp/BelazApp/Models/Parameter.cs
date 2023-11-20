using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BelazApp.Models
{
    public class Parameter : INotifyPropertyChanged
    {
        public int ParameterId { get; set; }

        public int VehicleId { get; set; }
        public string ParameterName { get; set; }
        private float patemeterValue;
        public float ParameterValue
        {
            get { return patemeterValue; }
            set
            {
                if (patemeterValue != value)
                {
                    patemeterValue = value;
                    OnPropertyChanged("ParameterValue");
                }
            }
        }
        public bool IsValid { get; set; }
                public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
