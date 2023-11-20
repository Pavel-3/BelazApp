using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using static System.Collections.Specialized.BitVector32;

namespace BelazApp.Models
{
    public class Section : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private ObservableCollection<Parameter> parameters;
        public ObservableCollection<Parameter> Parameters
        {
            get { return parameters; }
            set
            {
                if (parameters != value)
                {
                    parameters = value;
                    OnPropertyChanged("Parameters");
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
