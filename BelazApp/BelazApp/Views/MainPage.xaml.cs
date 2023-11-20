using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BelazApp.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BelazApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        
        public List<Vehicle> Vehicles { get; set; }
        public MainPage()
        {
            Title = "Список ТС";
            InitializeComponent();
            Vehicles = Data.GetVehicles();
            BindingContext = this;
        }
        private async void VehicleSelected(object sender, ItemTappedEventArgs e)
        {
            var vehicle = (Vehicle)e.Item;
            await Navigation.PushAsync(new SelectedVehicle(vehicle.Id));
        }
    }
}