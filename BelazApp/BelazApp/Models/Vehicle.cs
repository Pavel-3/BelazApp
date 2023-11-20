using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace BelazApp.Models
{
    public class Vehicle : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        private ObservableCollection<Section> sections;
        public ObservableCollection<Section> Sections
        {
            get { return sections; }
            set
            {
                if (sections != value)
                {
                    sections = value;
                    OnPropertyChanged("Sections");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
